using Api1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api1.DAL
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Book { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Book>()
                .HasData(
                
                new Book { Id=1,Name="History",Price=24},
                 new Book { Id = 2, Name = "Math", Price = 24 },
                  new Book { Id = 3, Name = "Chemistry", Price = 24 },
                   new Book { Id = 4, Name = "Geography", Price = 24 },
                    new Book { Id =5, Name = "English", Price = 24 }
                                    );

        }
    }
}
