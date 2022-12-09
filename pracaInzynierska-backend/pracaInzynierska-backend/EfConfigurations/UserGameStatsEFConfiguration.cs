using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pracaInzynierska_backend.Models;

namespace pracaInzynierska_backend.EfConfigurations
{
    public class UserGameStatsEFConfiguration : IEntityTypeConfiguration<UserGameStats>
    {
        public void Configure(EntityTypeBuilder<UserGameStats> builder)
        {
            builder
                .HasOne(e => e.User)
                .WithMany(e => e.Stats)
                .HasForeignKey(e => e.IdUser);
            builder
                .HasOne(e => e.Game)
                .WithMany(e => e.Stats)
                .HasForeignKey(e => e.IdGame);
        }
    }
}
