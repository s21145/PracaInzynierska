using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pracaInzynierska_backend.Models;

namespace pracaInzynierska_backend.EfConfigurations
{
    public class MessageEFConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            //builder
            //    .HasOne(x => x.Sender)
            //    .WithMany(x => x.SendMessages)
            //    .OnDelete(DeleteBehavior.ClientCascade)
            //    .HasForeignKey(x => x.SenderId);

            //builder
            //    .HasOne(x => x.Receiver)
            //    .WithMany(x => x.ReceivedMessages)
            //    .OnDelete(DeleteBehavior.ClientCascade)
            //    .HasForeignKey(x => x.ReceiverId);

        }
    }
}
