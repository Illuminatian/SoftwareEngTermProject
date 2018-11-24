using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelConnect.Data;
using TravelConnect.Helpers;
using TravelConnect.Models;

namespace TravelConnect.Controllers
{
    public class TripController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public TripController(ApplicationDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            hostingEnvironment = environment;
        }

        [HttpPost]
        public string UploadFiles(IFormFile file)
        {
            long size = file.Length;

            // full path to file in temp location
            var filePath = Path.GetTempFileName();
            try
            {
                string uploads;
                uploads = Path.Combine(hostingEnvironment.WebRootPath, "images");
                var savedFileName = GetUniqueFileName(file.FileName);
                var fullPath = Path.Combine(uploads, savedFileName);
                file.CopyTo(new FileStream(fullPath, FileMode.Create));

                return savedFileName;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }

        public async Task<IActionResult> Search(SearchModel search)
        {
            var toReturn = await _context.TripModel.ToListAsync();

            if(search.DestinationCity != null)
            {
                toReturn = toReturn.Where(x => x.DestinationCity == search.DestinationCity).ToList();
            }

            if(search.DepartureCity != null)
            {
                toReturn = toReturn.Where(x => x.DepartureCity == search.DepartureCity).ToList();
            }

            if (search.MaxCost > 0)
            {
                toReturn = toReturn.Where(x => x.Cost <= search.MaxCost).ToList();
            }

            if (search.DepartureDate != null)
            {
                toReturn = toReturn.Where(x => x.TripStartDate == search.DepartureDate).ToList();
            }

            if (search.TripLength > 0)
            {
                toReturn = toReturn.Where(x => x.TripLength <= search.TripLength).ToList();
            }

            return View("Index", toReturn);
        }

        // GET: Trip
        public async Task<IActionResult> Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                var subscribed = _context.SubscribedModel.Where(x => x.UserId == User.GetUserId());
                List<int> tripIds = new List<int>();

                if (subscribed != null)
                {
                    foreach (var subscription in subscribed)
                    {
                        tripIds.Add(subscription.TripId);
                    }
                }

                var trips = await _context.TripModel.ToListAsync();
                foreach (var trip in trips)
                {
                    if (tripIds.Contains(trip.Id))
                    {
                        trip.Subscribed = true;
                    }
                }
                return View(trips);
            }
            else
            {
                return View(await _context.TripModel.ToListAsync());
            }
        }

        [Authorize]
        public async Task<IActionResult> MyTrips()
        {
            return View(await _context.TripModel.Where(x => x.CreateUserId == User.GetUserId()).ToListAsync());
        }

        // GET: Trip/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripModel = await _context.TripModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tripModel == null)
            {
                return NotFound();
            }

            var subscribedUsers = _context.SubscribedModel.Where(x => x.TripId == id);

            foreach(var user in subscribedUsers)
            {
                if (User.GetUserId() == user.UserId)
                {
                    tripModel.Subscribed = true;
                }

                var subscribed = new SubscribedUsers();
                var subbedUser = _context.Users.Where(x => x.Id == user.UserId).FirstOrDefault();

                subscribed.UserName = subbedUser.FirstName + " " + subbedUser.LastName;
                subscribed.UserId = user.UserId;
                subscribed.IsConfirmed = user.IsConfirmed;

                tripModel.SubscribedUsers.Add(subscribed);
            }

            return View(tripModel);
        }

        public void Subscribe(int tripId, string userId)
        {
            var subscribedModel = _context.SubscribedModel.Where(x => x.TripId == tripId && x.UserId == userId).FirstOrDefault();

            if (subscribedModel == null)
            {
                subscribedModel = new Subscribed();
                subscribedModel.TripId = tripId;
                subscribedModel.UserId = userId;
                _context.SubscribedModel.Add(subscribedModel);
            }
            else
            {
                _context.SubscribedModel.Remove(subscribedModel);
                
            }

            _context.SaveChanges();
        }

        public JsonResult Confirm(string userId, bool isConfirmed, int tripId)
        {
            var subscribedModel = _context.SubscribedModel.Where(x => x.TripId == tripId && x.UserId == userId).FirstOrDefault();

            if(subscribedModel == null)
            {
                return Json(new { OK = false });
            }
            else
            {
                if(isConfirmed)
                {
                    subscribedModel.IsConfirmed = true;
                    _context.Update(subscribedModel);

                }
                else
                {
                    _context.SubscribedModel.Remove(subscribedModel);
                }

                _context.SaveChanges();

                return Json(new { OK = true });
            }
        }

        // GET: Trip/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm][Bind("Id,TripStartDate,DepartureCity,DestinationCity,TripEndDate,MaxTravellers,TravelMode,Cost,TripDescription,FileToUpload")] TripModel tripModel)
        {
            if (ModelState.IsValid)
            {
                if (tripModel.FileToUpload != null)
                {
                    string fileName = UploadFiles(tripModel.FileToUpload);
                    tripModel.CustomPicturePath = fileName;
                }

                tripModel.CreateDate = DateTime.Now;
                tripModel.CreateUserId = UserHelper.GetUserId(User);
                _context.Add(tripModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tripModel);
        }

        // GET: Trip/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripModel = await _context.TripModel.FindAsync(id);
            if (tripModel == null)
            {
                return NotFound();
            }
            return View(tripModel);
        }

        // POST: Trip/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm][Bind("Id,CreateUserId,CreateDate,TripStartDate,DepartureCity,DestinationCity,TripEndDate,MaxTravellers,TravelMode,Cost,TripDescription,FileToUpload,CustomPicturePath")] TripModel tripModel)
        {
            if (id != tripModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(tripModel.FileToUpload != null)
                    {
                        string fileName = UploadFiles(tripModel.FileToUpload);
                        tripModel.CustomPicturePath = fileName;
                    }
                    
                    _context.Update(tripModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripModelExists(tripModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tripModel);
        }

        // GET: Trip/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripModel = await _context.TripModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tripModel == null)
            {
                return NotFound();
            }

            return View(tripModel);
        }

        // POST: Trip/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tripModel = await _context.TripModel.FindAsync(id);
            _context.TripModel.Remove(tripModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripModelExists(int id)
        {
            return _context.TripModel.Any(e => e.Id == id);
        }
    }
}
