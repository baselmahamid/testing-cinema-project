using System;
using System.Collections.Generic;
using System.Text;
using Cinema.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Cinema.Models.ViewModels;

namespace Cinema.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BookingTable> BookingTable { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<MovieDetails> MovieDetails { get; set; }
        public DbSet<ShowTime> ShowTimes { get; set; }
        public DbSet<Cinema.Models.ViewModels.MovieDetailsViewmodel> MovieDetailsViewmodel { get; set; }
       
    }
}
