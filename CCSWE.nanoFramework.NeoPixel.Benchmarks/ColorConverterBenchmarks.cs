using nanoFramework.Benchmark;
using nanoFramework.Benchmark.Attributes;

namespace CCSWE.nanoFramework.NeoPixel.Benchmarks
{
    [IterationCount(100)]
    public class ColorConverterBenchmarks: BenchmarkBase
    {
        [Benchmark]
        public void ScaleBrightness()
        {
            var result = ColorConverter.ScaleBrightness(TestData.Color, 0.5d);
        }
    }
}
