using System.Net;

namespace Screend.Exceptions
{
    public class InternalServerErrorException : HttpException
    {
        /// <summary>
        /// <inheritdoc cref="HttpException" />
        /// </summary>
        public HttpStatusCode StatusCode = HttpStatusCode.InternalServerError;
        
        /// <summary>
        /// <inheritdoc cref="HttpException" />
        /// </summary>
        /// <param name="message"></param>
        public InternalServerErrorException(string message) : base(message)
        {
        }
    }
}