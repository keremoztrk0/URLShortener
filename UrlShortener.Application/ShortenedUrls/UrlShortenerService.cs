using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Application.Abstracts;
using UrlShortener.Application.ShortenedUrls.DTOs;
using URLShortener.Domain.ShortenedUrls;

namespace UrlShortener.Application.ShortenedUrls
{
    public class UrlShortenerService(IUrlShortenerDbContext dbContext, IHttpContextAccessor httpContextAccessor) : IUrlShortenerService
    {
        public Task DeleteShortenedUrl(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task<ShortenedUrlDto> GenerateAndSaveShortenedUrl(ShortenedUrlCreateDto createDto, CancellationToken cancellation)
        {
            var codes = await dbContext.ShortenedUrls.Select(m => m.Code).ToListAsync(cancellation);
            var generatedCode = string.Empty;
            do
            {
                generatedCode = Utilities.UniqueCodeGenerator.Generate();

            } while (codes.Contains(generatedCode));
            var shortenedUrl = new ShortenedUrl { Code = generatedCode, OriginalUrl = createDto.Url, CreatedAt = DateTime.Now };
            await dbContext.ShortenedUrls.AddAsync(shortenedUrl);
            await dbContext.SaveChangesAsync(cancellation);
            return MapToShortenedUrlDto(shortenedUrl);

        }

        public Task<ShortenedUrl> GetShortenedUrl(string code, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUrl(int id, string url, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        private ShortenedUrlDto MapToShortenedUrlDto(ShortenedUrl url)
        {

            string shortUrl = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}/{url.Code}";
            return new ShortenedUrlDto(url.Id, url.OriginalUrl, url.Code, shortUrl, url.CreatedAt);
        }
    }
}
