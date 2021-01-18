using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RDIChallenge.Domain.ExceptionHandler
{
    public class RDICustomException :Exception
    {

        public HttpStatusCode StatusCode { get; set; }
        public string ContentType { get; set; } = @"text/plain";

        public RDICustomException(HttpStatusCode statusCode)
        {
            this.StatusCode = statusCode;
        }

        public RDICustomException(HttpStatusCode statusCode, string message)
            : base(message)
        {
            this.StatusCode = statusCode;
        }

        public RDICustomException(HttpStatusCode statusCode, Exception inner)
            : this(statusCode, inner.ToString()) { }

        public RDICustomException(HttpStatusCode statusCode, JObject errorObject)
            : this(statusCode, errorObject.ToString())
        {
            this.ContentType = @"application/json";
        }

    }
}
