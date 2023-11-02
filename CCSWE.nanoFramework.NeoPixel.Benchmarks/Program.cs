using System;
using System.Diagnostics;
using CCSWE.nanoFramework.NeoPixel.Benchmarks.MathBenchmarks;
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
            /* Math Benchmarks */
            //BenchmarkRunner.RunClass(typeof(AbsBenchmarks));
            //BenchmarkRunner.RunClass(typeof(CeilingBenchmarks));
            //BenchmarkRunner.RunClass(typeof(ClampBenchmarks));
            //BenchmarkRunner.RunClass(typeof(FloorBenchmarks));
            //BenchmarkRunner.RunClass(typeof(MaxBenchmarks));
            //BenchmarkRunner.RunClass(typeof(MinBenchmarks));

            BenchmarkRunner.RunClass(typeof(ColorConverterBenchmarks));

            //BenchmarkRunner.RunClass(typeof(NeoPixelStripBenchmarks));
            //BenchmarkRunner.RunClass(typeof(SampleNeoPixelStripBenchmarks));
            //BenchmarkRunner.RunClass(typeof(Ws28xxNeoPixelStripBenchmarks));
        }
    }
}
