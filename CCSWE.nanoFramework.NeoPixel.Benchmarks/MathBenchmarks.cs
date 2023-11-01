using System;
using nanoFramework.Benchmark;
using nanoFramework.Benchmark.Attributes;

namespace CCSWE.nanoFramework.NeoPixel.Benchmarks
{
    [IterationCount(500)]
    public class MathBenchmarks: BenchmarkBase
    {
        private const int Loops = 100;

        private const double LeftDouble = -0.1;
        private const double RightDouble = 0.1;

        private const float LeftFloat = -0.1f;
        private const float RightFloat = 0.1f;

        private const int LeftInt = -1;
        private const int RightInt = 1;

        [Benchmark]
        public void Abs_Double()
        {
            RunIterations(Loops, () =>
            {
                var result = Math.Abs(LeftDouble);
            });
        }

        [Benchmark]
        public void Abs_Double_System()
        {
            RunIterations(Loops, () =>
            {
                var result = System.Math.Abs(LeftDouble);
            });
        }

        [Benchmark]
        public void Abs_Float()
        {
            RunIterations(Loops, () =>
            {
                var result = Math.Abs(LeftFloat);
            });
        }

        [Benchmark]
        public void Abs_Float_System()
        {
            RunIterations(Loops, () =>
            {
                var result = System.Math.Abs(LeftFloat);
            });
        }

        [Benchmark]
        public void Abs_Int()
        {
            RunIterations(Loops, () =>
            {
                var result = Math.Abs(LeftInt);
            });
        }

        [Benchmark]
        public void Abs_Int_System()
        {
            RunIterations(Loops, () =>
            {
                var result = System.Math.Abs(LeftInt);
            });
        }

        [Benchmark]
        public void Max_Double()
        {
            RunIterations(Loops, () =>
            {
                var result = Math.Max(LeftDouble, RightDouble);
            });
        }

        [Benchmark]
        public void Max_Double_System()
        {
            RunIterations(Loops, () =>
            {
                var result = System.Math.Max(LeftDouble, RightDouble);
            });
        }

        [Benchmark]
        public void Max_Float()
        {
            RunIterations(Loops, () =>
            {
                var result = Math.Max(LeftFloat, RightFloat);
            });
        }


        [Benchmark]
        public void Max_Float_System()
        {
            RunIterations(Loops, () =>
            {
                var result = System.Math.Max(LeftFloat, RightFloat);
            });
        }

        [Benchmark]
        public void Max_Int()
        {
            RunIterations(Loops, () =>
            {
                var result = Math.Max(LeftInt, RightInt);
            });
        }

        [Benchmark]
        public void Max_Int_System()
        {
            RunIterations(Loops, () =>
            {
                var result = System.Math.Max(LeftInt, RightInt);
            });
        }
    }
}
