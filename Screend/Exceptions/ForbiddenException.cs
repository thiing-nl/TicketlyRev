using System.Net;

namespace Screend.Exceptions
{
    public class ForbiddenException : HttpException
    {
        /// <summary>
        /// <inheritdoc cref="HttpException" />
        /// </summary>
        public HttpStatusCode StatusCode = HttpStatusCode.Forbidden;
        
        /// <summary>
        /// <inheritdoc cref="HttpException" />
        /// </summary>
        /// <param name="message"></param>
        public ForbiddenException(string message) : base(message)
        {
        }
    }
}