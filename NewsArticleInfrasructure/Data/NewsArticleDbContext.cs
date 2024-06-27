using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsArticlesDomain.Entities;

namespace NewsArticleInfrasructure.Data
{
    public class NewsArticleDbContext : DbContext
    {
        public NewsArticleDbContext(DbContextOptions<NewsArticleDbContext> options): base(options) 
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> likes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Comment>().
                HasOne(x => x.User).WithMany(z => z.Comments)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Comment>().
                HasOne(x => x.Article).WithMany(z => z.Comments)
                .HasForeignKey(x => x.ArticleId)
                .OnDelete(DeleteBehavior.ClientSetNull); base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Like>().
                HasOne(x => x.User).WithMany(z => z.Likes)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Like>().
                HasOne(x => x.Article).WithMany(z => z.Likes)
                .HasForeignKey(x => x.ArticleId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }


    }
}
