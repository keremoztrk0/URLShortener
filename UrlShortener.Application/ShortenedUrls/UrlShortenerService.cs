using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Application.Abstracts;
using URLShortener.Domain.ShortenedUrls;

namespace UrlShortener.Application.ShortenedUrls
{
    public class UrlShortenerService(IUrlShortenerDbContext dbContext) : IUrlShortenerService
    {
        public Task DeleteShortenedUrl(string code)
        {
            throw new NotImplementedException();
        }

        public Task<ShortenedUrl> GenerateAndSaveShortenedUrl(string url)
        {
            throw new NotImplementedException();
        }

        public Task<ShortenedUrl> GetShortenedUrl(string code)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUrl(string code, string url)
        {
            throw new NotImplementedException();
        }
    }
}
