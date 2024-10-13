using blogger.Server.Model;
using Microsoft.EntityFrameworkCore;

namespace blogger.Server.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User Configuration
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            // Blog Configuration
            modelBuilder.Entity<Blog>()
                .HasKey(b => b.BlogId);

            modelBuilder.Entity<Blog>()
                .HasOne(b => b.Author)
                .WithMany(u => u.Blogs)
                .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Blog>()
                .HasOne(b => b.Creator)
                .WithMany()
                .HasForeignKey(b => b.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Blog>()
                .HasOne(b => b.Updater)
                .WithMany()
                .HasForeignKey(b => b.UpdatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            // Comment Configuration
            modelBuilder.Entity<Comment>()
                .HasKey(c => c.CommentId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Blog)
                .WithMany(b => b.Comments)
                .HasForeignKey(c => c.BlogId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Commenter)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.CommenterId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Creator)
                .WithMany()
                .HasForeignKey(c => c.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Updater)
                .WithMany()
                .HasForeignKey(c => c.UpdatedBy)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
