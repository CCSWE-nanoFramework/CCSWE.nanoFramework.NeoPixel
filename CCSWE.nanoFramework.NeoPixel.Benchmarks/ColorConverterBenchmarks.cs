using nanoFramework.Benchmark;
using nanoFramework.Benchmark.Attributes;

namespace CCSWE.nanoFramework.NeoPixel.Benchmarks
{
    [IterationCount(100)]
    public class ColorConverterBenchmarks: BenchmarkBase
    {
        [Benchmark]
        public void ScaleBrightness_Double()
        {
            var result = Brightness.Double.ColorConverter.ScaleBrightness(TestData.Color, 0.5d);
        }

        [Benchmark]
        public void ScaleBrightness_Float()
        {
            var result = Brightness.Float.ColorConverter.ScaleBrightness(TestData.Color, 0.5f);
        }
    }
}
