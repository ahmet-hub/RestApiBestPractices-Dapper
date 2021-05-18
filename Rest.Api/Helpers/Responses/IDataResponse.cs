using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.Api.Helpers.Responses
{
    public interface IDataResponse<T>:IResponse
    {
        public T Data { get; }
    }
}
