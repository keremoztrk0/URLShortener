using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Application.Abstracts
{
    public enum URLShortenerApplicationError
    {
        NotFound = 1900,
        BadRequest = 1901
    }
    public class URLShortenerApplicationException : Exception
    {
        private const string URL_INVALID = "Url is invalid";
        private const string SHORTENED_URL_NOT_FOUND = "Shortened Url not found.";
        private URLShortenerApplicationException(URLShortenerApplicationError error, string errorCode)
        {
            ErrorType = error;
            ErrorCode = errorCode;
        }
        protected URLShortenerApplicationException(URLShortenerApplicationError error, string errorCode, object args)
        {
            ErrorType = error;
            ErrorCode = errorCode;
            Args = args;
        }

        public string ErrorCode { get; }
        public object? Args { get; }
        public URLShortenerApplicationError ErrorType { get; }

        public static URLShortenerApplicationException UrlInvalid(string url) => new URLShortenerApplicationException(URLShortenerApplicationError.BadRequest, URL_INVALID,url);

        public static Exception ShortenedUrlNotFound() => new URLShortenerApplicationException(URLShortenerApplicationError.NotFound, SHORTENED_URL_NOT_FOUND);
    }
}
