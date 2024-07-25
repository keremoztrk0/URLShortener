using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLShortener.Domain.ShortenedUrls;

namespace UrlShortener.Application.Abstracts
{
    public interface IUrlShortenerDbContext
    {
        public DbSet<ShortenedUrl> ShortenedUrls { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellation);
    }
}
