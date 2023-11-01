namespace CCSWE.nanoFramework.NeoPixel.Benchmarks.MathBenchmarks
{
    public abstract class MathBenchmarksBase : BenchmarkBase
    {
        protected const int Iterations = 500;
        protected const int Loops = 100;

        protected const double Double1 = Math.PI;
        protected const double Double2 = Double1 * -1;

        protected const float Float1 = (float)Math.PI;
        protected const float Float2 = Float1 * -1;

        protected const int Int1 = 1234567890;
        protected const int Int2 = Int1 * -1;
    }
}
