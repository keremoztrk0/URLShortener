using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text;
using System.Text.Json;
using UrlShortener.Application.Abstracts;

namespace URLShortener.API.Middlewares
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (URLShortenerApplicationException applicationException) when (applicationException.ErrorType == URLShortenerApplicationError.BadRequest)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await WriteResultToResponse(context, applicationException);
            }
            catch (URLShortenerApplicationException applicationException) when (applicationException.ErrorType == URLShortenerApplicationError.NotFound)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await WriteResultToResponse(context, applicationException);
            }

            static async Task WriteResultToResponse(HttpContext context, URLShortenerApplicationException applicationException)
            {
                context.Response.ContentType = "application/json";
                var responseJson = JsonSerializer.Serialize(new
                {
                    Code = applicationException.ErrorCode,
                    applicationException.Args,
                });
                await context.Response.WriteAsync(responseJson,Encoding.UTF8);
            }
        }
    }
}
