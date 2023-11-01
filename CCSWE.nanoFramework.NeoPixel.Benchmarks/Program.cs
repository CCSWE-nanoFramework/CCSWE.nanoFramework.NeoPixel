using System;
using System.Diagnostics;
using CCSWE.nanoFramework.NeoPixel.Benchmarks.Reference;
using nanoFramework.Benchmark;

namespace CCSWE.nanoFramework.NeoPixel.Benchmarks
{
    public class Program
    {
        public static void Main()
        {
#if DEBUG
            Console.WriteLine("Benchmarks should be run in a release build.");
            Debugger.Break();
            return;
#endif
            BenchmarkRunner.RunClass(typeof(MathBenchmarks));

            //BenchmarkRunner.RunClass(typeof(NeoPixelStripBenchmarks));
            //BenchmarkRunner.RunClass(typeof(SampleNeoPixelStripBenchmarks));
            //BenchmarkRunner.RunClass(typeof(Ws28xxNeoPixelStripBenchmarks));
        }
    }
}
