using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Tadas_SOA_Repeat_CA.Models;
using Tadas_SOA_Repeat_CA.Models.Dto;

namespace Tadas_SOA_Repeat_CA.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeding categories remains unchanged
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher
                {
                    Id = 1,
                    Name = "Nintendo",
                },
                new Publisher
                {
                    Id = 2,
                    Name = "Mojang",
                }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Platform" },
                new Category { Id = 2, Name = "Adventure" },
                new Category { Id = 3, Name = "Action" },
                new Category { Id = 4, Name = "Sandbox" },
                new Category { Id = 5, Name = "Survival" }
            );

            modelBuilder.Entity<Developer>().HasData(
                new Developer
                {
                    Id = 1,
                    Name = "Nintendo",
                },
                new Developer
                {
                    Id = 2,
                    Name = "Mojang Studios",
                }
            );

            

            modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    Id = 1,
                    Name = "Super Mario Bros.",
                    CategoriesJson = JsonConvert.SerializeObject(new List<string> { "Platform", "Action" }),
                    PublisherId = 1,
                    DeveloperId = 1,
                    ReleaseDate = new DateTime(1985, 9, 13),
                    RecordCreationDate = DateTime.Now,
                    Owned = true
                },
                new Game
                {
                    Id = 2,
                    Name = "The Legend of Zelda: Breath of the Wild",
                    CategoriesJson = JsonConvert.SerializeObject(new List<string> { "Adventure", "Action" }),
                    PublisherId = 1,
                    DeveloperId = 1,
                    ReleaseDate = new DateTime(2017, 3, 3),
                    RecordCreationDate = DateTime.Now,
                    Owned = true
                },
                new Game
                {
                    Id = 3,
                    Name = "Minecraft",
                    CategoriesJson = JsonConvert.SerializeObject(new List<string> { "Sandbox", "Survival" }), 
                    PublisherId = 2,
                    DeveloperId = 2,
                    ReleaseDate = new DateTime(2011, 11, 18),
                    RecordCreationDate = DateTime.Now,
                    Owned = false
                }
            );
        }
    }
}
