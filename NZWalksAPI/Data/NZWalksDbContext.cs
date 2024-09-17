using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Data For Difficulties
            // Easy, Medium, Hard

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("96f833d2-4212-49b7-a0e6-0940c407c760"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("2a58c91b-6e76-4b82-8103-3fd3fbfaee1f"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("4f218539-284b-40b4-9856-1c0a08163b4b"),
                    Name = "Hard"
                }
            };

            // Seed Dificulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed Data For Regions
            var regions = new List<Region>()
            {
                new Region
                {
                    Id = Guid.Parse("9429d309-dc40-4569-a49e-91740a1e00df"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("1989b615-dbdc-4f47-b1eb-e379da23a3b7"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("241286d4-6d20-4949-bf09-6b7635441a85"),
                    Name = "Bay Of Plenty",
                    Code = "BOP",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("c5b31584-3ff8-442e-b3e4-6fd72f189b73"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("0d79d6d9-f76a-4350-bf93-4a6f3b388831"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("a74ad913-b5b0-4225-8c37-1f1ffc684213"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = null
                },
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
