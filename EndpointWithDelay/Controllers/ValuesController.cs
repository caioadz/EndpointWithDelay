using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EndpointWithDelay.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        public Response Get(string key)
        {
            int i = 0;

            while (true)
            {
                if (i > 500) break;
                Thread.Sleep(10);
                i++;
            }

            return new Response(key);
        }
    }

    public class Response
    {
        public string Key { get; set; }
        public int? Value { get; set; }

        public Response(string key)
        {
            Key = key;
            Value = Key?.GetHashCode();
        }
    }
}
