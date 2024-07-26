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
            ValidateUrl(createDto.Url);
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

        private static void ValidateUrl(string url)
        {
            
            var result = Uri.TryCreate(url, UriKind.Absolute, out _);
            if (!result)
            {
                throw URLShortenerApplicationException.UrlInvalid(url);
            }
        }

        public async Task<string> GetOriginalUrl(string code, CancellationToken cancellation)
        {
            ShortenedUrl? url = await dbContext.ShortenedUrls.FirstOrDefaultAsync(m => m.Code == code);
            if (url == null) throw URLShortenerApplicationException.ShortenedUrlNotFound();
            return url.OriginalUrl;
        }

        public Task UpdateUrl(int id, string url, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        private ShortenedUrlDto MapToShortenedUrlDto(ShortenedUrl url)
        {
            string shortUrl = GetShortUrl(url);
            return new ShortenedUrlDto(url.Id, url.OriginalUrl, url.Code, shortUrl, url.CreatedAt);
        }

        private string GetShortUrl(ShortenedUrl url)
        {
            return $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}/{url.Code}";
        }

        public async Task<List<ShortenedUrlDto>> GetAll(CancellationToken cancellation)
        {
            var urls = await dbContext.ShortenedUrls.ToListAsync();
            return urls.Select(MapToShortenedUrlDto).ToList();
        }
    }
}
