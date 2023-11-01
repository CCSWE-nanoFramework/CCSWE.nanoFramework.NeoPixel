using nanoFramework.Benchmark;
using nanoFramework.Benchmark.Attributes;

namespace CCSWE.nanoFramework.NeoPixel.Benchmarks.MathBenchmarks
{
    [IterationCount(Iterations)]
    public class CeilingBenchmarks: MathBenchmarksBase
    {
        [Benchmark]
        public void Ceiling_Double()
        {
            RunIterations(Loops, () =>
            {
                var result = NeoPixel.Math.Ceiling(Double1);
            });
        }

        [Benchmark]
        public void Ceiling_Double_Managed()
        {
            RunIterations(Loops, () =>
            {
                var result = ManagedMath.Ceiling(Double1);
            });
        }

        [Benchmark]
        public void Ceiling_Double_System()
        {
            RunIterations(Loops, () =>
            {
                var result = System.Math.Ceiling(Double1);
            });
        }
    }
}
