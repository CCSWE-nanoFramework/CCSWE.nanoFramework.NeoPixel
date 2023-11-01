using System.Drawing;
using CCSWE.nanoFramework.NeoPixel.Benchmarks.Comparisons;
using nanoFramework.Benchmark;
using nanoFramework.Benchmark.Attributes;

namespace CCSWE.nanoFramework.NeoPixel.Benchmarks
{
    [IterationCount(50)]
    public class NeoPixelStripBenchmarks: BenchmarkBase
    {
        private byte _colorIndex = 0;
        private Color[] _colors;

        private NeoPixelStrip _neoPixelStrip;
        private SampleNeoPixelStrip _sampleNeoPixel;
        private Ws28xxNeoPixelStrip _ws28xxNeoPixel;

        [Setup]
        public void Setup()
        {
            _colors = ColorHelper.TestColors;
            _neoPixelStrip = new NeoPixelStrip(19, 47);//, ColorOrder.GRB);
            _sampleNeoPixel = new SampleNeoPixelStrip(19, 47);
            _ws28xxNeoPixel = new Ws28xxNeoPixelStrip(19, 47);
        }

        /*
        [Benchmark]
        public void Fill_Multiple_Colors()
        {
            RunIterations(10, () =>
            {
                for (var i = 0; i < _colors.Length; i++)
                {
                    var color = _colors[i];
                    _sampleNeoPixel.Fill(new byte[] { color.G, color.R, color.B });
                }
            });
        }
        */

        [Benchmark]
        public void NeoPixel_Fill()
        {
            _neoPixelStrip.Fill(GetColor());
            _neoPixelStrip.Update();
        }

        [Benchmark]
        public void NeoPixel_SetLed()
        {
            var color = GetColor();//.ToBytes(ColorOrder.GRB);

            for (var i = 0; i < _neoPixelStrip.Count; i++)
            {
                _neoPixelStrip.SetLed(i, color);
            }

            _neoPixelStrip.Update();
        }

        [Benchmark]
        public void Sample_Fill()
        {
            _sampleNeoPixel.Fill(GetColorArray());
        }

        /*
        [Benchmark]
        public void Ws28xx_Fill_Clear()
        {
            _ws28xxNeoPixel.Fill_Clear(GetColor());
        }

        [Benchmark]
        public void Ws28xx_Fill_SetPixel()
        {
            _ws28xxNeoPixel.Fill_Set_Pixel(GetColor());
        }
        */

        private byte[] GetColorArray()
        {
            var color = GetColor();
            return new[] { color.G, color.R, color.B };
        }

        private Color GetColor()
        {
            var color = _colors[_colorIndex];

            _colorIndex++;

            if (_colorIndex >= _colors.Length)
            {
                _colorIndex = 0;
            }

            return color;
        }
    }
}
