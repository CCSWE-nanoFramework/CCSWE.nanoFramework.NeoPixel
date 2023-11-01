using nanoFramework.Benchmark;
using nanoFramework.Benchmark.Attributes;

namespace CCSWE.nanoFramework.NeoPixel.Benchmarks.MathBenchmarks
{
    [IterationCount(Iterations)]
    public class AbsBenchmarks: MathBenchmarksBase
    {
        [Benchmark]
        public void Abs_Double()
        {
            RunIterations(Loops, () =>
            {
                var result = NeoPixel.Math.Abs(Double1);
            });
        }

        [Benchmark]
        public void Abs_Double_Managed()
        {
            RunIterations(Loops, () =>
            {
                var result = ManagedMath.Abs(Double1);
            });
        }

        [Benchmark]
        public void Abs_Double_System()
        {
            RunIterations(Loops, () =>
            {
                var result = System.Math.Abs(Double1);
            });
        }

        [Benchmark]
        public void Abs_Float()
        {
            RunIterations(Loops, () =>
            {
                var result = NeoPixel.Math.Abs(Float1);
            });
        }

        [Benchmark]
        public void Abs_Float_Managed()
        {
            RunIterations(Loops, () =>
            {
                var result = ManagedMath.Abs(Float1);
            });
        }

        [Benchmark]
        public void Abs_Float_System()
        {
            RunIterations(Loops, () =>
            {
                var result = System.Math.Abs(Float1);
            });
        }

        [Benchmark]
        public void Abs_Int()
        {
            RunIterations(Loops, () =>
            {
                var result = NeoPixel.Math.Abs(Int1);
            });
        }

        [Benchmark]
        public void Abs_Int_Managed()
        {
            RunIterations(Loops, () =>
            {
                var result = ManagedMath.Abs(Int1);
            });
        }

        [Benchmark]
        public void Abs_Int_System()
        {
            RunIterations(Loops, () =>
            {
                var result = System.Math.Abs(Int1);
            });
        }
    }
}
