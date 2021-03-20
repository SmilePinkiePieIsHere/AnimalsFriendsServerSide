using Microsoft.EntityFrameworkCore;

namespace AnimalsFriends.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(
                new Post { Id = 1, Title = "Martenici" },                
                new Post { Id = 5, Title = "Koledna kashtichka" });

            modelBuilder.Entity<Animal>().HasData(
                new Animal { Id = 1, UserId = 1, Name = "Zima"},
                new Animal { Id = 2, UserId = 1, Name = "Buria" },               
                new Animal { Id = 33, UserId = 2, Name = "Terry" });

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Email = "danitza@example.com" },
                new User { Id = 2, Email = "niya@example.com" });
        }
    }
}
