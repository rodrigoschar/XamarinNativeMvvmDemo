using System;
using System.Net.Http;

namespace SharedCode.Utils
{

    public class NetworkErrorException : HttpRequestException
    {
        public int Code;
        public NetworkErrorException(int code)
        {
            this.Code = code;
        }
        public NetworkErrorException(int code, string message) : base(message)
        {
            this.Code = code;
        }
        public NetworkErrorException(int code, string message, Exception inner) : base(message, inner)
        {
            this.Code = code;
        }
    }

    public static class NetworkErrors
    {
        public static readonly NetworkErrorException BadRequest = new NetworkErrorException(400, "Bad request");
        public static readonly NetworkErrorException NotFound = new NetworkErrorException(404, "Not Found");
        public static readonly NetworkErrorException InternalServerError = new NetworkErrorException(500, "Internal Server Error");
        public static readonly NetworkErrorException UnknownError = new NetworkErrorException(0, "Unknown Error");
    }
}

