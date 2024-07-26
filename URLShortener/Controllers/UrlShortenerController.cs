using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application.ShortenedUrls;
using UrlShortener.Application.ShortenedUrls.DTOs;

namespace URLShortener.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class UrlShortenerController(IUrlShortenerService urlShortenerService) : ControllerBase
    {
        [HttpPost("")]
        public async Task<ActionResult> Generate([FromBody] ShortenedUrlCreateDto body, CancellationToken cancellationToken)
        {
            var result = await urlShortenerService.GenerateAndSaveShortenedUrl(body, cancellationToken);
            return Ok(result);
        }
    }
}
