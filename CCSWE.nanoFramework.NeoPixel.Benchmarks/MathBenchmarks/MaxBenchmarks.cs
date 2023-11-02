using nanoFramework.Benchmark;
using nanoFramework.Benchmark.Attributes;

namespace CCSWE.nanoFramework.NeoPixel.Benchmarks.MathBenchmarks
{
    [IterationCount(Iterations)]
    public class MaxBenchmarks: MathBenchmarksBase
    {
        [Benchmark]
        public void Max_Double()
        {
            RunIterations(Loops, () =>
            {
                var result = NeoPixel.Math.Max(Double1, Double2);
            });
        }

        [Benchmark]
        public void Max_Double_Managed()
        {
            RunIterations(Loops, () =>
            {
                var result = ManagedMath.Max(Double1, Double2);
            });
        }

        [Benchmark]
        public void Max_Double_System()
        {
            RunIterations(Loops, () =>
            {
                var result = System.Math.Max(Double1, Double2);
            });
        }

        [Benchmark]
        public void Max_Float()
        {
            RunIterations(Loops, () =>
            {
                var result = NeoPixel.Math.Max(Float1, Float2);
            });
        }

        [Benchmark]
        public void Max_Float_Managed()
        {
            RunIterations(Loops, () =>
            {
                var result = ManagedMath.Max(Float1, Float2);
            });
        }

        [Benchmark]
        public void Max_Float_System()
        {
            RunIterations(Loops, () =>
            {
                var result = System.Math.Max(Float1, Float2);
            });
        }

        [Benchmark]
        public void Max_Int()
        {
            RunIterations(Loops, () =>
            {
                var result = NeoPixel.Math.Max(Int1, Int2);
            });
        }

        [Benchmark]
        public void Max_Int_Managed()
        {
            RunIterations(Loops, () =>
            {
                var result = ManagedMath.Max(Int1, Int2);
            });
        }

        [Benchmark]
        public void Max_Int_System()
        {
            RunIterations(Loops, () =>
            {
                var result = System.Math.Max(Int1, Int2);
            });
        }
    }
}
