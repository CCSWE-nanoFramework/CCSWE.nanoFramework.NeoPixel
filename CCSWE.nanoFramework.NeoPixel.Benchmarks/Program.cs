using System.Threading;
using nanoFramework.Benchmark;

namespace CCSWE.nanoFramework.NeoPixel.Benchmarks
{
    public class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run(typeof(Program).Assembly);
            Thread.Sleep(Timeout.Infinite);
        }
    }
}
