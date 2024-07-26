using UrlShortener.Application.ShortenedUrls.DTOs;
using URLShortener.Domain.ShortenedUrls;

namespace UrlShortener.Application.ShortenedUrls
{
    public interface IUrlShortenerService
    {
        public Task<ShortenedUrlDto> GenerateAndSaveShortenedUrl(ShortenedUrlCreateDto url, CancellationToken cancellation);
        public Task UpdateUrl(int id, string url, CancellationToken cancellation);
        public Task<ShortenedUrl> GetShortenedUrl(string code, CancellationToken cancellation);
        public Task DeleteShortenedUrl(int id, CancellationToken cancellation);
    }
}