using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XDDDD.Model
{
    public class GalleryDbContext: DbContext
    {
        public GalleryDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Picture> Pictures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Album>().HasData(new Album { Id = 1, Name = "Album 1"  });
        }
    }
}
