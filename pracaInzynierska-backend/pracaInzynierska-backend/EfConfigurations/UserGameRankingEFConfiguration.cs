using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pracaInzynierska_backend.Models;

namespace pracaInzynierska_backend.EfConfigurations
{
    public class UserGameRankingEFConfiguration : IEntityTypeConfiguration<UserGameRanking>
    {
        public void Configure(EntityTypeBuilder<UserGameRanking> builder)
        {
            builder
               .HasOne(e => e.User)
               .WithMany(e => e.Ranking)
               .HasForeignKey(e => e.IdUser);
            builder
                .HasOne(e => e.Game)
                .WithMany(e => e.Ranking)
                .HasForeignKey(e => e.IdGame);
        }
    }
}
