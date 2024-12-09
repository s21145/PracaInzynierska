using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pracaInzynierska_backend.Models;

namespace pracaInzynierska_backend.EfConfigurations
{
    public class UserEFConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(e => e.Posts)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.IdUser);
               


            builder
                .HasMany(e => e.Comments)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .OnDelete(DeleteBehavior.ClientCascade);
            SeedData(builder);


            builder
                .HasMany(x => x.SendMessages)
                .WithOne(x => x.Sender)
                .OnDelete(DeleteBehavior.ClientCascade)
                .HasForeignKey(x => x.SenderId);
            builder
              .HasMany(x => x.ReceivedMessages)
              .WithOne(x => x.Receiver)
              .OnDelete(DeleteBehavior.ClientCascade)
              .HasForeignKey(x => x.ReceiverId);




        }
        private void SeedData(EntityTypeBuilder<User> builder)
        {
            builder
                .HasData(
                new User {UserId = 1,Email = "adres@o2.pl",Login="Czarek12",BirthDate=DateTime.Now.AddYears(-20),Password= "59Vrw5YDQ2QrbnB3ArrLUK6nkGhl+cf+V3hG9RuMFuN4HfKnS7ymZu4XEIcCPWuN", Description="Lubie CS GO",IconPath= "../../images/users/default.png" },
                new User { UserId = 2, Email = "tendrugiUser@gmail.com", Login = "kozak5222", BirthDate = DateTime.Now.AddYears(-25), Password = "59Vrw5YDQ2QrbnB3ArrLUK6nkGhl+cf+V3hG9RuMFuN4HfKnS7ymZu4XEIcCPWuN", Description = "Lubie CS GO", IconPath = "../../images/users/default.png" },
                new User { UserId = 3, Email = "Zielony@o2.pl", Login = "Garo", BirthDate = DateTime.Now.AddYears(-30), Password = "59Vrw5YDQ2QrbnB3ArrLUK6nkGhl+cf+V3hG9RuMFuN4HfKnS7ymZu4XEIcCPWuN", Description = "Lubie CS GO", IconPath = "../../images/users/default.png" }
                );
        }
    }
}
