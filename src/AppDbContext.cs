using Microsoft.EntityFrameworkCore;
using bitly.Domain.Models;

namespace bitly
{
    public class AppDbContext : DbContext
    {

        public DbSet<Url> urls { get; set; }
        


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Url>().ToTable("url");
            builder.Entity<Url>().HasKey(p => p.ShortUrl);
            builder.Entity<Url>().Property(p => p.ShortUrl).IsRequired();
            builder.Entity<Url>().Property(p => p.LongUrl).IsRequired();
        }

    }
}
