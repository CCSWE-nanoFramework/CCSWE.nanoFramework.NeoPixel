using System;
using nanoFramework.Benchmark;
using nanoFramework.Benchmark.Attributes;

namespace CCSWE.nanoFramework.NeoPixel.Benchmarks
{
    [IterationCount(500)]
    public class MathBenchmarksOld: BenchmarkBase
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
        public void Abs_Double_Managed()
        {
            RunIterations(Loops, () =>
            {
                var result = ManagedMath.Abs(LeftDouble);
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
        public void Abs_Float_Managed()
        {
            RunIterations(Loops, () =>
            {
                var result = ManagedMath.Abs(LeftFloat);
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
        public void Abs_Int_Managed()
        {
            RunIterations(Loops, () =>
            {
                var result = ManagedMath.Abs(LeftInt);
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
        public void Ceiling_Double()
        {
            RunIterations(Loops, () =>
            {
                var result = Math.Ceiling(LeftDouble);
            });
        }

        [Benchmark]
        public void Ceiling_Double_Managed()
        {
            RunIterations(Loops, () =>
            {
                var result = ManagedMath.Ceiling(LeftDouble);
            });
        }

        [Benchmark]
        public void Ceiling_Double_System()
        {
            RunIterations(Loops, () =>
            {
                var result = System.Math.Ceiling(LeftDouble);
            });
        }

        [Benchmark]
        public void Floor_Double()
        {
            RunIterations(Loops, () =>
            {
                var result = Math.Floor(LeftDouble);
            });
        }

        [Benchmark]
        public void Floor_Double_Managed()
        {
            RunIterations(Loops, () =>
            {
                var result = ManagedMath.Floor(LeftDouble);
            });
        }

        [Benchmark]
        public void Floor_Double_System()
        {
            RunIterations(Loops, () =>
            {
                var result = System.Math.Floor(LeftDouble);
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
        public void Max_Double_Managed()
        {
            RunIterations(Loops, () =>
            {
                var result = ManagedMath.Max(LeftDouble, RightDouble);
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
        public void Max_Float_Managed()
        {
            RunIterations(Loops, () =>
            {
                var result = ManagedMath.Max(LeftFloat, RightFloat);
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
        public void Max_Int_Managed()
        {
            RunIterations(Loops, () =>
            {
                var result = ManagedMath.Max(LeftInt, RightInt);
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

        public void Min_Double()
        {
            RunIterations(Loops, () =>
            {
                var result = Math.Min(LeftDouble, RightDouble);
            });
        }

        public void Min_Double_Managed()
        {
            RunIterations(Loops, () =>
            {
                var result = ManagedMath.Min(LeftDouble, RightDouble);
            });
        }

        [Benchmark]
        public void Min_Double_System()
        {
            RunIterations(Loops, () =>
            {
                var result = System.Math.Min(LeftDouble, RightDouble);
            });
        }

        [Benchmark]
        public void Min_Float()
        {
            RunIterations(Loops, () =>
            {
                var result = Math.Min(LeftFloat, RightFloat);
            });
        }

        [Benchmark]
        public void Min_Float_Managed()
        {
            RunIterations(Loops, () =>
            {
                var result = ManagedMath.Min(LeftFloat, RightFloat);
            });
        }

        [Benchmark]
        public void Min_Float_System()
        {
            RunIterations(Loops, () =>
            {
                var result = System.Math.Min(LeftFloat, RightFloat);
            });
        }

        [Benchmark]
        public void Min_Int()
        {
            RunIterations(Loops, () =>
            {
                var result = Math.Min(LeftInt, RightInt);
            });
        }

        [Benchmark]
        public void Min_Int_Managed()
        {
            RunIterations(Loops, () =>
            {
                var result = ManagedMath.Min(LeftInt, RightInt);
            });
        }

        [Benchmark]
        public void Min_Int_System()
        {
            RunIterations(Loops, () =>
            {
                var result = System.Math.Min(LeftInt, RightInt);
            });
        }
    }
}
