using nanoFramework.Benchmark;
using nanoFramework.Benchmark.Attributes;

namespace CCSWE.nanoFramework.NeoPixel.Benchmarks.MathBenchmarks
{
    [IterationCount(Iterations)]
    public class ClampBenchmarks: MathBenchmarksBase
    {
        [Benchmark]
        public void Clamp_Double()
        {
            RunIterations(Loops, () =>
            {
                var result = NeoPixel.Math.Clamp(Double1, Double2, Double3);
            });
        }

        [Benchmark]
        public void Clamp_Double_Managed()
        {
            RunIterations(Loops, () =>
            {
                var result = ManagedMath.Clamp(Double1, Double2, Double3);
            });
        }

        [Benchmark]
        public void Clamp_Double_System()
        {
            RunIterations(Loops, () =>
            {
                var result = System.Math.Clamp(Double1, Double2, Double3);
            });
        }

        [Benchmark]
        public void Clamp_Float()
        {
            RunIterations(Loops, () =>
            {
                var result = NeoPixel.Math.Clamp(Float1, Float2, Float3);
            });
        }

        [Benchmark]
        public void Clamp_Float_Managed()
        {
            RunIterations(Loops, () =>
            {
                var result = ManagedMath.Clamp(Float1, Float2, Float3);
            });
        }

        [Benchmark]
        public void Clamp_Float_System()
        {
            RunIterations(Loops, () =>
            {
                var result = System.Math.Clamp(Float1, Float2, Float3);
            });
        }
    }
}
