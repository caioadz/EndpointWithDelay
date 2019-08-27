using System.Threading;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using EndpointWithDelayHelper;

namespace EndpointWithDelay.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        IApplicationLifetime _appLifetime;
        ShutdownCounter _shutdownCounter;

        public ValuesController(IApplicationLifetime appLifetime, ShutdownCounter shutdownCounter)
        {
            _appLifetime = appLifetime;
            _shutdownCounter = shutdownCounter;
        }
        public Response Get(string key)
        {
            if (_shutdownCounter.Shutdown())
                _appLifetime.StopApplication();

            int i = 0;

            while (true)
            {
                if (i > 350) break;
                Thread.Sleep(10);
                i++;
            }

            return new Response(key);
        }
    }

    public class Response
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public Response(string key)
        {
            Key = key;
            Value = Key?.ToBase64();
        }
    }
}
