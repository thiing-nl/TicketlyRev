using System.Net;

namespace Screend.Exceptions
{
    public class NotFoundException : HttpException
    {
        /// <summary>
        /// <inheritdoc cref="HttpException" />
        /// </summary>
        public HttpStatusCode StatusCode = HttpStatusCode.NotFound;
        
        /// <summary>
        /// <inheritdoc cref="HttpException" />
        /// </summary>
        /// <param name="message"></param>
        public NotFoundException(string message) : base(message)
        {
        }
    }
}