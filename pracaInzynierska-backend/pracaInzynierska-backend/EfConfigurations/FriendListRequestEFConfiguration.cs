using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pracaInzynierska_backend.Models;

namespace pracaInzynierska_backend.EfConfigurations
{
    public class FriendListRequestEFConfiguration : IEntityTypeConfiguration<FriendListRequest>
    {
        public void Configure(EntityTypeBuilder<FriendListRequest> builder)
        {
            builder
            .HasOne(x => x.Sender)
            .WithMany(x => x.RequestsSent)
            .OnDelete(DeleteBehavior.ClientCascade)
            .HasForeignKey(x => x.FromUserId);


            builder
                .HasOne(x => x.Recipient)
                .WithMany(x => x.RequestsReceived)
                .OnDelete(DeleteBehavior.ClientCascade)
                .HasForeignKey(x => x.ToUserId);

        }
    }
}
