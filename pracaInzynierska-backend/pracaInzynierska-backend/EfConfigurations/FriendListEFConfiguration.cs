

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pracaInzynierska_backend.Models;

namespace pracaInzynierska_backend.EfConfigurations
{

    public class FriendListEFConfiguration : IEntityTypeConfiguration<FriendList>
    {
        public void Configure(EntityTypeBuilder<FriendList> builder)
        {
            builder
            .HasOne(x => x.Friend)
            .WithMany(x => x.Friends)
            .OnDelete(DeleteBehavior.ClientCascade)
            .HasForeignKey(x => x.FriendId);


            builder
                .HasOne(x => x.Owner)
                .WithMany(x => x.OnFriendList)
                .OnDelete(DeleteBehavior.ClientCascade)
                .HasForeignKey(x => x.OwnerId);

        }
    }
}
