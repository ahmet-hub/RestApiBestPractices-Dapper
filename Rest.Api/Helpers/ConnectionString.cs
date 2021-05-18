using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.Api.Helpers
{
    public static class ConnectionString
    {
        public static string sqlConnectionString = "Data Source = (localdb)\\ProjectsV13;Initial Catalog = RestApiDb; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
