using CCSWE.nanoFramework.NeoPixel.Drivers;
using nanoFramework.Benchmark;
using nanoFramework.Benchmark.Attributes;

namespace CCSWE.nanoFramework.NeoPixel.Benchmarks
{
    [IterationCount(IterationCount)]
    public class NeoPixelStripBenchmarks : NeoPixelStripBenchmarkBase
    {
        private NeoPixelStrip _sut;

        [Setup]
        public override void Setup()
        {
            _sut = new NeoPixelStrip(StripParameters.Pin, StripParameters.Count, new Ws2812B(StripParameters.ColorOrder));
        }

        [Benchmark]
        public override void Fill()
        {
            _sut.Fill(TestData.Color);
            _sut.Update();
        }

        [Benchmark]
        public void SetPixel()
        {
            for (var i = 0; i < _sut.Count; i++)
            {
                _sut.SetLed(i, TestData.Color);
            }

            _sut.Update();
        }
    }
}

