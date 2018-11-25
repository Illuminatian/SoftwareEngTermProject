using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelConnect.Models;

namespace TravelConnect.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TripModel> TripModel { get; set; }
        public DbSet<Subscribed> SubscribedModel { get; set; }
        public DbSet<MessagesModel> MessagesModel { get; set; }
    }
}
