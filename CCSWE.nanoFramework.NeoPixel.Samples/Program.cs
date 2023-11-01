using System.Drawing;
using System.Threading;
using CCSWE.nanoFramework.NeoPixel.Drivers;

namespace CCSWE.nanoFramework.NeoPixel.Samples
{
    public class Program
    {


        public static void Main()
        {
            // Configure the number of leds
            const ushort count = 47;

            // Adjust the pin number
            const byte pin = 19;

            // Choose the correct driver and color order
            var driver = new Ws2812B(ColorOrder.GRB);

            // Create the strip
            var strip = new NeoPixelStrip(pin, count, driver);

            strip.Fill(Color.Red);
            strip.Update();
            Thread.Sleep(1000);

            strip.Fill(Color.Green);
            strip.Update();
            Thread.Sleep(1000);

            strip.Fill(Color.Blue);
            strip.Update();
            Thread.Sleep(1000);

            while (true)
            {
                //ColorFade(strip);

                ColorWipe(strip, Color.White);
                ColorWipe(strip, Color.Red);
                ColorWipe(strip, Color.Green);
                ColorWipe(strip, Color.Blue);

                TheaterChase(strip, Color.White);
                TheaterChase(strip, Color.Red);
                TheaterChase(strip, Color.Green);
                TheaterChase(strip, Color.Blue);

                Rainbow(strip);
                RainbowCycle(strip);
                TheaterChaseRainbow(strip);
            }
        }

        private static void ColorFade(NeoPixelStrip strip)
        {
            // White
            for (byte iteration = 0; iteration < 255; iteration++)
            {
                var color = Color.FromArgb(iteration, iteration, iteration);
                for (var led = 0; led < strip.Count; led++)
                {
                    strip.SetLed(led, color);
                }

                strip.Update();
            }

            // Red
            for (byte iteration = 0; iteration < 255; iteration++)
            {
                var color = Color.FromArgb(iteration, 0, 0);
                for (var led = 0; led < strip.Count; led++)
                {
                    strip.SetLed(led, color);
                }

                strip.Update();
            }

            // Green
            for (byte iteration = 0; iteration < 255; iteration++)
            {
                var color = Color.FromArgb(0, iteration, 0);
                for (var led = 0; led < strip.Count; led++)
                {
                    strip.SetLed(led, color);
                }

                strip.Update();
            }

            // Blue
            for (byte iteration = 0; iteration < 255; iteration++)
            {
                var color = Color.FromArgb(0, 0, iteration);
                for (var led = 0; led < strip.Count; led++)
                {
                    strip.SetLed(led, color);
                }

                strip.Update();
            }
        }

        private static void ColorWipe(NeoPixelStrip strip, Color color)
        {
            for (var i = 0; i < strip.Count; i++)
            {
                strip.SetLed(i, color);
                strip.Update();
            }
        }

        private static void Rainbow(NeoPixelStrip strip, int iterations = 1)
        {
            for (var i = 0; i < 255 * iterations; i++)
            {
                for (var j = 0; j < strip.Count; j++)
                {
                    strip.SetLed(j, Wheel((i + j) & 255));
                }

                strip.Update();
            }
        }

        private static void RainbowCycle(NeoPixelStrip strip, int iterations = 1)
        {
            for (var i = 0; i < 255 * iterations; i++)
            {
                for (var j = 0; j < strip.Count; j++)
                {
                    strip.SetLed(j, Wheel(((j * 255 / strip.Count) + i) & 255));
                }

                strip.Update();
            }
        }

        private static void TheaterChase(NeoPixelStrip strip, Color color, int iterations = 10)
        {
            for (var i = 0; i < iterations; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    for (var k = 0; k < strip.Count; k += 3)
                    {
                        if (j + k < strip.Count)
                        {
                            strip.SetLed(j + k, color);
                        }
                    }

                    strip.Update();
                    Thread.Sleep(100);
                    
                    for (var k = 0; k < strip.Count; k += 3)
                    {
                        if (j + k < strip.Count)
                        {
                            strip.SetLed(j + k, Color.Black);
                        }
                    }
                }
            }
        }

        private static void TheaterChaseRainbow(NeoPixelStrip strip)
        {
            for (var i = 0; i < 255; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    for (var k = 0; k < strip.Count; k += 3)
                    {
                        if (k + j < strip.Count)
                        {
                            strip.SetLed(k + j, Wheel((k + i) % 255));
                        }
                    }

                    strip.Update();
                    Thread.Sleep(100);

                    for (var k = 0; k < strip.Count; k += 3)
                    {
                        if (k + j < strip.Count)
                        {
                            strip.SetLed(k + j, Color.Black);
                        }
                    }
                }
            }
        }

        private static Color Wheel(int position)
        {
            switch (position)
            {
                case < 85:
                    return Color.FromArgb(position * 3, 255 - position * 3, 0);
                case < 170:
                    position -= 85;
                    return Color.FromArgb(255 - position * 3, 0, position * 3);
                default:
                    position -= 170;
                    return Color.FromArgb(0, position * 3, 255 - position * 3);
            }
        }
    }
}
