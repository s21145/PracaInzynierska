using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pracaInzynierska_backend.Models;

namespace pracaInzynierska_backend.EfConfigurations
{
    public class PostEfConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder
                .HasMany(e => e.Comments)
                .WithOne(e => e.Post)
                .HasForeignKey(e => e.IdPost);
            builder
                .HasOne(e => e.Game)
                .WithMany(e => e.Posts)
                .HasForeignKey(e => e.IdGame);
            SeedData(builder);
        }

        private void SeedData(EntityTypeBuilder<Post> builder)
        {
            builder
                .HasData(
                new Post { PostId =1,Title="Ale CunterStrike jest kozak", Content = "jak w temacie",IdUser=1,IdGame=1,Date=DateTime.Now},
                new Post { PostId = 2, Title = "CUNTER STRIKE",
                    Content = "long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versi", 
                    IdUser = 1, IdGame = 1 ,Date=DateTime.Now},
                new Post { PostId = 3, Title = "CZY CUNTERSTRIKE JEST LEPSZE OD ESCAPE FROM TARKOV", Content = "jak w temacie", IdUser = 1, IdGame = 1, Date = DateTime.Now },
                new Post { PostId = 4, Title = "REPORT GARO",
                    Content = "long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versi", 
                    IdUser = 1, IdGame = 1 ,
                    Date = DateTime.Now
                },
                new Post { PostId = 5, Title = "CZY KTOS TO CZYTA?",
                    Content = " are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.",
                    IdUser = 1, IdGame = 1,
                    Date = DateTime.Now
                }
                );
        }
    }
}
