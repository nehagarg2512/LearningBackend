using System;
using System.Net;

namespace Common.Errors
{
    public class RestException: Exception
    {
        public Object Error { get; set; }
        public HttpStatusCode Code { get; set; }

        public RestException(HttpStatusCode code, Object error = null)
        {
            Code = code;
            Error = error;
        }
    }
}
