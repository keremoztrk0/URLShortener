using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Application.ShortenedUrls.DTOs
{
    public record ShortenedUrlDto(int Id,string OriginalUrl,string Code,string ShortUrl,DateTime CreatedAt);
}
