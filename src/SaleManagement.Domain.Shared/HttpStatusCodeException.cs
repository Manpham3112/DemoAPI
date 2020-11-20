using System;
using System.Net;

namespace SaleManagement
{
    public class HttpStatusCodeException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; private set; }

        public int ApplicationCode { get; private set; }

        public HttpStatusCodeException()
        {

        }

        public HttpStatusCodeException(HttpStatusCode httpCode)
        {
            HttpStatusCode = httpCode;
        }

        public HttpStatusCodeException(HttpStatusCode httpCode, int applicationCode)
        {
            HttpStatusCode = httpCode;
            ApplicationCode = applicationCode;
        }
    }
}
