namespace CCSWE.nanoFramework.NeoPixel.Benchmarks
{
    public abstract class NeoPixelStripBenchmarkBase
    {
        public const int IterationCount = 50;

        public abstract void Setup();

        public abstract void Fill();
    }
}
