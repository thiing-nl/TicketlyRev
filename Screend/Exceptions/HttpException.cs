using System;
using System.Net;

namespace Screend.Exceptions
{
    public class HttpException : Exception
    {
        /// <inheritdoc />
        /// <param name="message"></param>
        public HttpException(string message) : base(message)
        {
        }
    }
}