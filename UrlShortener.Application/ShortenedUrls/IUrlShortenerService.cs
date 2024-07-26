using UrlShortener.Application.ShortenedUrls.DTOs;
using URLShortener.Domain.ShortenedUrls;

namespace UrlShortener.Application.ShortenedUrls
{
    public interface IUrlShortenerService
    {
        public Task<ShortenedUrlDto> GenerateAndSaveShortenedUrl(ShortenedUrlCreateDto url, CancellationToken cancellation);
        public Task UpdateUrl(int id, string url, CancellationToken cancellation);
        public Task<string> GetOriginalUrl(string code, CancellationToken cancellation);
        public Task DeleteShortenedUrl(int id, CancellationToken cancellation);
        public Task<List<ShortenedUrlDto>> GetAll(CancellationToken cancellation);
    }
}