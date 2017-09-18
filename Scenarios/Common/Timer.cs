using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Common
{
    public class Timer : IDisposable
    {
        private Stopwatch sw;
        public Timer()
        {
            sw = new Stopwatch();
            sw.Start();
        }

        public void Dispose()
        {
            sw.Stop();
            Console.WriteLine("Time taken {0}", sw.Elapsed.Ticks);
        }
    }
}
