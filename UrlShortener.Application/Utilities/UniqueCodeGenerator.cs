using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using URLShortener.Domain.ShortenedUrls;

namespace UrlShortener.Application.Utilities
{
    public static class UniqueCodeGenerator
    {
        private const int MaxCodeLength = ShortenedUrlConsts.MaxCodeLength;
        public static string Generate()
        {
            Random random = new Random();
            long randomNumber = ((long)random.Next() << 32) | (long)random.Next();
            byte[] byteArray = BitConverter.GetBytes(randomNumber);
            var base64String = Convert.ToBase64String(byteArray);

            base64String = base64String.Replace("+", "")
                                               .Replace("/", "")
                                               .Replace("=", "");
            if (base64String.Length < MaxCodeLength)
            {
                base64String = base64String.PadRight(7, (char)random.Next(0,9));
            }

            return base64String.Substring(0, 7);
        }
    }
}
