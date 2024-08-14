﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using pracaInzynierska_backend.Models;

#nullable disable

namespace pracaInzynierska_backend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("pracaInzynierska_backend.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPost")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("IdPost");

                    b.HasIndex("IdUser");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            CommentId = 1,
                            Content = "Komentarz 1",
                            Date = new DateTime(2024, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(3515),
                            IdPost = 1,
                            IdUser = 1
                        },
                        new
                        {
                            CommentId = 2,
                            Content = "Komentarz 2",
                            Date = new DateTime(2024, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(3518),
                            IdPost = 1,
                            IdUser = 1
                        },
                        new
                        {
                            CommentId = 3,
                            Content = "Komentarz 3",
                            Date = new DateTime(2024, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(3519),
                            IdPost = 1,
                            IdUser = 1
                        },
                        new
                        {
                            CommentId = 4,
                            Content = "Komentarz 4",
                            Date = new DateTime(2024, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(3520),
                            IdPost = 1,
                            IdUser = 1
                        });
                });

            modelBuilder.Entity("pracaInzynierska_backend.Models.FriendList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FriendId")
                        .HasColumnType("int");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FriendId");

                    b.HasIndex("OwnerId");

                    b.ToTable("FriendLists");
                });

            modelBuilder.Entity("pracaInzynierska_backend.Models.FriendListRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FromUserId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ToUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FromUserId");

                    b.HasIndex("ToUserId");

                    b.ToTable("FriendListRequests");
                });

            modelBuilder.Entity("pracaInzynierska_backend.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameId"), 1L, 1);

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SteamId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GameId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            GameId = 1,
                            ImagePath = "../../images/games/csgo.jpg",
                            Name = "CounterStrike",
                            Publisher = "Valve",
                            SteamId = "730"
                        },
                        new
                        {
                            GameId = 2,
                            ImagePath = "../../images/games/valorant.jpg",
                            Name = "Fortnite",
                            Publisher = "Epic Games"
                        },
                        new
                        {
                            GameId = 3,
                            ImagePath = "../../images/games/lol.png",
                            Name = "Leauge of Legends",
                            Publisher = "Riot Games"
                        },
                        new
                        {
                            GameId = 4,
                            ImagePath = "../../images/games/rust.jpg",
                            Name = "Rust",
                            Publisher = "ktos?",
                            SteamId = "252490"
                        });
                });

            modelBuilder.Entity("pracaInzynierska_backend.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostId"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdGame")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PostId");

                    b.HasIndex("IdGame");

                    b.HasIndex("IdUser");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            PostId = 1,
                            Content = "jak w temacie",
                            Date = new DateTime(2024, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(3433),
                            IdGame = 1,
                            IdUser = 1,
                            Title = "Ale CunterStrike jest kozak"
                        },
                        new
                        {
                            PostId = 2,
                            Content = "long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versi",
                            Date = new DateTime(2024, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(3444),
                            IdGame = 1,
                            IdUser = 1,
                            Title = "CUNTER STRIKE"
                        },
                        new
                        {
                            PostId = 3,
                            Content = "jak w temacie",
                            Date = new DateTime(2024, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(3446),
                            IdGame = 1,
                            IdUser = 1,
                            Title = "CZY CUNTERSTRIKE JEST LEPSZE OD ESCAPE FROM TARKOV"
                        },
                        new
                        {
                            PostId = 4,
                            Content = "long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versi",
                            Date = new DateTime(2024, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(3448),
                            IdGame = 1,
                            IdUser = 1,
                            Title = "REPORT GARO"
                        },
                        new
                        {
                            PostId = 5,
                            Content = " are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.",
                            Date = new DateTime(2024, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(3449),
                            IdGame = 1,
                            IdUser = 1,
                            Title = "CZY KTOS TO CZYTA?"
                        });
                });

            modelBuilder.Entity("pracaInzynierska_backend.Models.StatsName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdGame")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdGame");

                    b.ToTable("StatsNames");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdGame = 1,
                            Name = "total_kills",
                            PublicName = "Kills"
                        },
                        new
                        {
                            Id = 2,
                            IdGame = 1,
                            Name = "total_deaths",
                            PublicName = "Deaths"
                        },
                        new
                        {
                            Id = 3,
                            IdGame = 1,
                            Name = "total_kills_headshot",
                            PublicName = "Headshots"
                        },
                        new
                        {
                            Id = 4,
                            IdGame = 1,
                            Name = "total_wins",
                            PublicName = "Wins"
                        },
                        new
                        {
                            Id = 5,
                            IdGame = 1,
                            Name = "total_matches_played",
                            PublicName = "Matches"
                        },
                        new
                        {
                            Id = 6,
                            IdGame = 1,
                            Name = "total_shots_hit",
                            PublicName = "Hit Shots"
                        },
                        new
                        {
                            Id = 7,
                            IdGame = 1,
                            Name = "total_shots_fired",
                            PublicName = "Fired Shots"
                        },
                        new
                        {
                            Id = 9,
                            IdGame = 1,
                            Name = "total_mvps",
                            PublicName = "MVP"
                        },
                        new
                        {
                            Id = 10,
                            IdGame = 4,
                            Name = "kill_player",
                            PublicName = "Kills"
                        },
                        new
                        {
                            Id = 11,
                            IdGame = 4,
                            Name = "deaths",
                            PublicName = "Deaths"
                        },
                        new
                        {
                            Id = 12,
                            IdGame = 4,
                            Name = "bullet_fired",
                            PublicName = "Bullet fired"
                        },
                        new
                        {
                            Id = 13,
                            IdGame = 4,
                            Name = "headshot",
                            PublicName = "Headshots"
                        },
                        new
                        {
                            Id = 14,
                            IdGame = 4,
                            Name = "bullet_hit_player",
                            PublicName = "Hit Shots Player"
                        });
                });

            modelBuilder.Entity("pracaInzynierska_backend.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CurrentRefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IconPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefreshTokenExp")
                        .HasColumnType("datetime2");

                    b.Property<string>("SteamId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            BirthDate = new DateTime(2004, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(1393),
                            Description = "Lubie CS GO",
                            Email = "adres@o2.pl",
                            IconPath = "../../images/users/default.png",
                            Login = "Czarek12",
                            Password = "bedzieHash"
                        },
                        new
                        {
                            UserId = 2,
                            BirthDate = new DateTime(1999, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(1418),
                            Description = "Lubie CS GO",
                            Email = "tendrugiUser@gmail.com",
                            IconPath = "../../images/users/default.png",
                            Login = "kozak5222",
                            Password = "bedzieHash"
                        },
                        new
                        {
                            UserId = 3,
                            BirthDate = new DateTime(1994, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(1421),
                            Description = "Lubie CS GO",
                            Email = "Zielony@o2.pl",
                            IconPath = "../../images/users/default.png",
                            Login = "Garo",
                            Password = "bedzieHash"
                        });
                });

            modelBuilder.Entity("pracaInzynierska_backend.Models.UserGameRanking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdGame")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<int>("score")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdGame");

                    b.HasIndex("IdUser");

                    b.ToTable("UserGameRakings");
                });

            modelBuilder.Entity("pracaInzynierska_backend.Models.UserGameStats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdGame")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Value")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("IdGame");

                    b.HasIndex("IdUser");

                    b.ToTable("UserGameStats");
                });

            modelBuilder.Entity("pracaInzynierska_backend.Models.Comment", b =>
                {
                    b.HasOne("pracaInzynierska_backend.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("IdPost")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("pracaInzynierska_backend.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("pracaInzynierska_backend.Models.FriendList", b =>
                {
                    b.HasOne("pracaInzynierska_backend.Models.User", "Friend")
                        .WithMany("Friends")
                        .HasForeignKey("FriendId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("pracaInzynierska_backend.Models.User", "Owner")
                        .WithMany("OnFriendList")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Friend");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("pracaInzynierska_backend.Models.FriendListRequest", b =>
                {
                    b.HasOne("pracaInzynierska_backend.Models.User", "Sender")
                        .WithMany("RequestsSent")
                        .HasForeignKey("FromUserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("pracaInzynierska_backend.Models.User", "Recipient")
                        .WithMany("RequestsReceived")
                        .HasForeignKey("ToUserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Recipient");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("pracaInzynierska_backend.Models.Post", b =>
                {
                    b.HasOne("pracaInzynierska_backend.Models.Game", "Game")
                        .WithMany("Posts")
                        .HasForeignKey("IdGame")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("pracaInzynierska_backend.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("pracaInzynierska_backend.Models.StatsName", b =>
                {
                    b.HasOne("pracaInzynierska_backend.Models.Game", "Game")
                        .WithMany("StatsNames")
                        .HasForeignKey("IdGame")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("pracaInzynierska_backend.Models.UserGameRanking", b =>
                {
                    b.HasOne("pracaInzynierska_backend.Models.Game", "Game")
                        .WithMany("Ranking")
                        .HasForeignKey("IdGame")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("pracaInzynierska_backend.Models.User", "User")
                        .WithMany("Ranking")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("pracaInzynierska_backend.Models.UserGameStats", b =>
                {
                    b.HasOne("pracaInzynierska_backend.Models.Game", "Game")
                        .WithMany("Stats")
                        .HasForeignKey("IdGame")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("pracaInzynierska_backend.Models.User", "User")
                        .WithMany("Stats")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("pracaInzynierska_backend.Models.Game", b =>
                {
                    b.Navigation("Posts");

                    b.Navigation("Ranking");

                    b.Navigation("Stats");

                    b.Navigation("StatsNames");
                });

            modelBuilder.Entity("pracaInzynierska_backend.Models.Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("pracaInzynierska_backend.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Friends");

                    b.Navigation("OnFriendList");

                    b.Navigation("Posts");

                    b.Navigation("Ranking");

                    b.Navigation("RequestsReceived");

                    b.Navigation("RequestsSent");

                    b.Navigation("Stats");
                });
#pragma warning restore 612, 618
        }
    }
}
