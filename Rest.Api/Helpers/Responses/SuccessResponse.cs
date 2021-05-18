using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.Api.Helpers.Responses
{
    public class SuccessResponse:Response
    {
        public SuccessResponse(string message) : base(true, message)
        {

        }

        public SuccessResponse() : base(true)
        {

        }

    }
}
