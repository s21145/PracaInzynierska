using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pracaInzynierska_backend.Models;

namespace pracaInzynierska_backend.EfConfigurations
{
    public class CommentEFConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            SeedData(builder);
        }

        private void SeedData(EntityTypeBuilder<Comment> builder)
        {
            builder
                .HasData(
                new Comment {CommentId =1,Date=DateTime.Now,Context="Komentarz 1",IdUser=1,IdPost=1 },
                new Comment { CommentId = 2, Date = DateTime.Now, Context = "Komentarz 2", IdUser = 1, IdPost = 1 },
                 new Comment { CommentId = 3, Date = DateTime.Now, Context = "Komentarz 3", IdUser = 1, IdPost = 1 },
                  new Comment { CommentId = 4, Date = DateTime.Now, Context = "Komentarz 4", IdUser = 1, IdPost = 1 }

                );
        }
    }
}
