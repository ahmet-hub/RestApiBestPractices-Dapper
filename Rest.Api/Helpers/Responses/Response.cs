using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.Api.Helpers.Responses
{
    public class Response : IResponse
    {

        public Response(bool success, string message) : this(success)
        {
            Message = message;
        }
        public Response(bool succes)
        {
            Success = succes;
        }
        public bool Success { get; }
        public string Message { get; }

    }
}
