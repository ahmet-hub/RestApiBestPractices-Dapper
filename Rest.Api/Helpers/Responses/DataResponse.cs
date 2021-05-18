using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.Api.Helpers.Responses
{
    public class DataResponse<T> : Response, IDataResponse<T>
    {
        public DataResponse(T data, bool succes, string message) : base(succes, message)
        {
            Data = data;
        }
        public DataResponse(T data, bool success) : base(success)
        {
            Data = data;
        }
        public T Data { get; }
    }

}

