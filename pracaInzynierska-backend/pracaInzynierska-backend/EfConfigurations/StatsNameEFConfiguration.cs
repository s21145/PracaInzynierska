using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pracaInzynierska_backend.Models;

namespace pracaInzynierska_backend.EfConfigurations
{
    public class StatsNameEFConfiguration : IEntityTypeConfiguration<StatsName>
    {
        public void Configure(EntityTypeBuilder<StatsName> builder)
        {
            builder
            .HasOne(e => e.Game)
            .WithMany(e => e.StatsNames)
            .HasForeignKey(e => e.IdGame);
            SeedData(builder);
        }
        private void SeedData(EntityTypeBuilder<StatsName> builder)
        {
            builder.HasData(
                new StatsName { Id =1,IdGame=1,Name = "total_kills",PublicName="Kills" },
                new StatsName { Id = 2, IdGame = 1, Name = "total_deaths", PublicName = "Deaths" },
                new StatsName { Id = 3, IdGame = 1, Name = "total_kills_headshot", PublicName = "Headshots" },
                new StatsName { Id = 4, IdGame = 1, Name = "total_wins", PublicName = "Wins" },
                new StatsName { Id = 5, IdGame = 1, Name = "total_matches_played", PublicName = "Matches" },
                new StatsName { Id = 6, IdGame = 1, Name = "total_shots_hit", PublicName = "Hit Shots" },
                new StatsName { Id = 7, IdGame = 1, Name = "total_shots_fired", PublicName = "Fired Shots" },
                new StatsName { Id = 8, IdGame = 1, Name = "total_time_played", PublicName = "Play Time" },
                new StatsName { Id = 9, IdGame = 1, Name = "total_mvps", PublicName = "MVP" }
            );
        }
    }
}
