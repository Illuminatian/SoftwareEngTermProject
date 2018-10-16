using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        public TripController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Trip
        public async Task<IActionResult> Index()
        {
            return View(await _context.TripModel.ToListAsync());
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

            return View(tripModel);
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
        public async Task<IActionResult> Create([Bind("Id,TripStartDate,DepartureCity,DestinationCity,TripLength,MaxTravellers,TravelMode,Cost")] TripModel tripModel)
        {
            if (ModelState.IsValid)
            {
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,CreateUserId,CreateDate,TripStartDate,DepartureCity,DestinationCity,TripLength,MaxTravellers,TravelMode,Cost")] TripModel tripModel)
        {
            if (id != tripModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
