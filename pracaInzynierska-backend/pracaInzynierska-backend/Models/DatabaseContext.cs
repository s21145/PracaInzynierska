﻿using Microsoft.EntityFrameworkCore;
using pracaInzynierska_backend.EfConfigurations;

namespace pracaInzynierska_backend.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Game> Games { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GameEfConfiguration());
            modelBuilder.ApplyConfiguration(new UserEFConfiguration());
            modelBuilder.ApplyConfiguration(new PostEfConfiguration());
            modelBuilder.ApplyConfiguration(new CommentEFConfiguration());
            




        }



    }
}
