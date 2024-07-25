namespace URLShortener.Domain.ShortenedUrls
{
    public class ShortenedUrl
    {
        public int Id { get; set; }
        public string OriginalUrl { get; set; }
        public string Code { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
