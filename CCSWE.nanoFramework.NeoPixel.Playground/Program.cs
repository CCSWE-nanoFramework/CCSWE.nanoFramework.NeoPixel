using CCSWE.nanoFramework.NeoPixel.Drivers;
using System;
using System.Device.Gpio;
using System.Drawing;
using System.Threading;

namespace CCSWE.nanoFramework.NeoPixel.Playground
{
    public class Program
    {
        public static void Main()
        {
            var testColors = new[] { Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.DarkOrchid, Color.Orange, Color.DeepPink, Color.DarkCyan };

            for (var i = 0; i < testColors.Length; i++)
            {
                var testColor = testColors[i];

                Console.WriteLine($"Starting with {testColor}");
                for (var j = 10; j >= 1; j--)
                {
                    var brightness = j * 0.1f;
                    var color = ColorConverter.ScaleBrightness(testColor, brightness);

                    Console.WriteLine($"{brightness}: R:{color.R} G:{color.G} B:{color.B} - {color}");
                }
            }

            // Enable LDO2 on UM FeatherS3
            var gpioController = new GpioController();
            gpioController.OpenPin(39, PinMode.Output).Write(PinValue.High);

            var delay = 125;
            var index = 0;
            var strip = new NeoPixelStrip(40, 1, new Ws2812B());

            while (true)
            {
                var color = testColors[index];

                for (var i = 0; i < 4; i++)
                {
                    strip.SetLed(0, i % 2 == 0 ? color : Color.Black);
                    strip.Update();
                    Thread.Sleep(delay);
                }

                strip.Clear();
                strip.Update();
                Thread.Sleep(delay);

                for (var i = 1; i <= 10; i++)
                {
                    strip.SetLed(0, color, i * 0.1f);
                    strip.Update();
                    Thread.Sleep(delay);
                }

                for (var i = 10; i >= 1; i--)
                {
                    strip.SetLed(0, color, i * 0.1f);
                    strip.Update();
                    Thread.Sleep(delay);
                }

                if (++index >= testColors.Length)
                {
                    index = 0;
                }
            }

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
