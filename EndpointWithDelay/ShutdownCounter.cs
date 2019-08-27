using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndpointWithDelay
{
    public class ShutdownCounter
    {
        int _counter = 0, _threshold = 20;

        public bool Shutdown() => _counter++ >= _threshold;
    }
}
