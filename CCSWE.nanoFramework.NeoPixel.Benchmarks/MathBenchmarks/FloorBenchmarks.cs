using nanoFramework.Benchmark;
using nanoFramework.Benchmark.Attributes;

namespace CCSWE.nanoFramework.NeoPixel.Benchmarks.MathBenchmarks
{
    [IterationCount(Iterations)]
    public class FloorBenchmarks: MathBenchmarksBase
    {
        [Benchmark]
        public void Floor_Double()
        {
            RunIterations(Loops, () =>
            {
                var result = NeoPixel.Math.Floor(Double1);
            });
        }

        [Benchmark]
        public void Floor_Double_Managed()
        {
            RunIterations(Loops, () =>
            {
                var result = ManagedMath.Floor(Double1);
            });
        }

        [Benchmark]
        public void Floor_Double_System()
        {
            RunIterations(Loops, () =>
            {
                var result = System.Math.Floor(Double1);
            });
        }
    }
}
