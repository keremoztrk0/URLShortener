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

        [HttpGet("{code}")]
        public async Task<ActionResult> RedirectToUrl(string code, CancellationToken cancellationToken)
        {
            var result = await urlShortenerService.GetOriginalUrl(code, cancellationToken);
            return Redirect(result);
        }

        [HttpGet("urls")]
        public async Task<ActionResult> GetAllUrls(CancellationToken cancellationToken)
        {
            var result = await urlShortenerService.GetAll(cancellationToken);
            return Ok(result);
        }
    }
}
