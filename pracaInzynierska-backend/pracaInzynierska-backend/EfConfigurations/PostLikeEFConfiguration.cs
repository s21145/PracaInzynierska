using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pracaInzynierska_backend.Models;

namespace pracaInzynierska_backend.EfConfigurations
{
    public class PostLikeEFConfiguration : IEntityTypeConfiguration<PostLike>
    {
        public void Configure(EntityTypeBuilder<PostLike> builder)
        {
            builder
            .HasOne(x => x.User)
            .WithMany(x => x.PostLiked)
            .OnDelete(DeleteBehavior.ClientCascade)
            .HasForeignKey(x => x.UserId);


            builder
                .HasOne(x => x.Post)
                .WithMany(x => x.Likes)
                .OnDelete(DeleteBehavior.ClientCascade)
                .HasForeignKey(x => x.PostId);

        }
    }
}
