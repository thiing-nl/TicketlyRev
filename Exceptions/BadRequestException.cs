using System.Net;

namespace Screend.Exceptions
{
    public class BadRequestException : HttpException
    {
        /// <summary>
        /// <inheritdoc cref="HttpException" />
        /// </summary>
        public HttpStatusCode StatusCode = HttpStatusCode.BadRequest;
        
        /// <summary>
        /// <inheritdoc cref="HttpException" />
        /// </summary>
        /// <param name="message"></param>
        public BadRequestException(string message) : base(message)
        {
        }
    }
}