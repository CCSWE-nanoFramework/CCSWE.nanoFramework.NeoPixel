using System.Drawing;
using Iot.Device.Ws28xx.Esp32;

namespace CCSWE.nanoFramework.NeoPixel.Benchmarks.Comparisons
{
    public class Ws28xxNeoPixelStrip
    {
        private readonly ushort _count;
        private readonly Ws2812c _ws28xx;

        public Ws28xxNeoPixelStrip(byte pin, ushort count)
        {
            _count = count;

            _ws28xx = new Ws2812c(pin, count);
        }

        public void Fill_Clear(Color color)
        {
            _ws28xx.Image.Clear(color);
            _ws28xx.Update();
        }

        public void Fill_Set_Pixel(Color color)
        {
            for (int i = 0; i < _count; i++)
            {
                _ws28xx.Image.SetPixel(i, 0, color);
            }

            _ws28xx.Update();
        }
    }
}
