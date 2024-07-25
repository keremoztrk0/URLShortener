using URLShortener.Domain.ShortenedUrls;

namespace UrlShortener.Application.ShortenedUrls
{
    public interface IUrlShortenerService
    {
        public Task<ShortenedUrl> GenerateAndSaveShortenedUrl(string url);
        public Task UpdateUrl(string code,string url);
        public Task<ShortenedUrl> GetShortenedUrl(string code);
        public Task DeleteShortenedUrl(string code);


    }
}