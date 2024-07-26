using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Application.Abstracts;
using URLShortener.Domain.ShortenedUrls;

namespace URLShortener.Infrastructure.Data
{
    internal class UrlShortenerDbContext : DbContext, IUrlShortenerDbContext
    {
        public UrlShortenerDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ShortenedUrl> ShortenedUrls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ShortenedUrl>()
                .HasKey(m => m.Id);
            modelBuilder.Entity<ShortenedUrl>()
                .Property(m => m.Code)
                .HasMaxLength(ShortenedUrlConsts.MaxCodeLength);
            modelBuilder.Entity<ShortenedUrl>()
                .HasIndex(m => m.Code);

        }
    }

}