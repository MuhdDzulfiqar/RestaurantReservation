using RestaurantReservation.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace RestaurantReservation.Server.Configurations.Entities
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
            new ApplicationUser
            {
                Id = "3781efa7-66dc-47f0-860f-e506d04102e4",
                Email = "admin@localhost.com",
                NormalizedEmail = "ADMIN@LOCALHOST.COM",
                FirstName = "Admin",
                LastName = "User",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                PasswordHash = hasher.HashPassword(null, "P@ssword1")
            },
            new ApplicationUser
            {
                Id = "s6d9f4v0-e72c-12es-0971-es2d21f0e898",
                Email = "user@localhost.com",
                NormalizedEmail = "USER@LOCALHOST.COM",
                FirstName = "User",
                LastName = "User2",
                UserName = "User",
                NormalizedUserName = "USER",
                PasswordHash = hasher.HashPassword(null, "P@ssword2")
            }
             );
        }
    }
}