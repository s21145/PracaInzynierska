using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pracaInzynierska_backend.Models;

namespace pracaInzynierska_backend.EfConfigurations
{
    public class GameEfConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            SeedData(builder);
        }

        private void SeedData(EntityTypeBuilder<Game> builder)
        {
            builder.HasData(
                new Game { GameId =1,Name="CunterStrike",Publisher="Valve"},
                new Game { GameId = 2, Name = "Fortnite", Publisher = "Epic Games" },
                new Game { GameId = 3, Name = "Leauge of Legends", Publisher = "Riot Games" },
                new Game { GameId = 4, Name = "Rust", Publisher = "ktos?" }
                );
        }
    }
}
