using nanoFramework.Benchmark;
using nanoFramework.Benchmark.Attributes;

namespace CCSWE.nanoFramework.NeoPixel.Benchmarks.MathBenchmarks
{
    [IterationCount(Iterations)]
    public class MinBenchmarks: MathBenchmarksBase
    {
        [Benchmark]
        public void Min_Double()
        {
            RunIterations(Loops, () =>
            {
                var result = Math.Min(Double1, Double2);
            });
        }

        [Benchmark]
        public void Min_Double_Managed()
        {
            RunIterations(Loops, () =>
            {
                var result = ManagedMath.Min(Double1, Double2);
            });
        }

        [Benchmark]
        public void Min_Double_System()
        {
            RunIterations(Loops, () =>
            {
                var result = System.Math.Min(Double1, Double2);
            });
        }

        [Benchmark]
        public void Min_Float()
        {
            RunIterations(Loops, () =>
            {
                var result = Math.Min(Float1, Float2);
            });
        }

        [Benchmark]
        public void Min_Float_Managed()
        {
            RunIterations(Loops, () =>
            {
                var result = ManagedMath.Min(Float1, Float2);
            });
        }

        [Benchmark]
        public void Min_Float_System()
        {
            RunIterations(Loops, () =>
            {
                var result = System.Math.Min(Float1, Float2);
            });
        }

        [Benchmark]
        public void Min_Int()
        {
            RunIterations(Loops, () =>
            {
                var result = Math.Min(Int1, Int2);
            });
        }

        [Benchmark]
        public void Min_Int_Managed()
        {
            RunIterations(Loops, () =>
            {
                var result = ManagedMath.Min(Int1, Int2);
            });
        }

        [Benchmark]
        public void Min_Int_System()
        {
            RunIterations(Loops, () =>
            {
                var result = System.Math.Min(Int1, Int2);
            });
        }
    }
}
