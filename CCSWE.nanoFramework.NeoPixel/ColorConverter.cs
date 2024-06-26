﻿using System;
using System.Drawing;

// TODO: Consider moving this stuff to a Graphics library
namespace CCSWE.nanoFramework.NeoPixel
{
    // Based on: https://gist.github.com/UweKeim/fb7f829b852c209557bc49c51ba14c8b

    /// <summary>
    /// Provides color conversion functionality.
    /// </summary>
    public static class ColorConverter
    {
        private static double Hue2Rgb(double v1, double v2, double vH)
        {
            if (vH < 0.0)
            {
                vH += 1.0;
            }
            if (vH > 1.0)
            {
                vH -= 1.0;
            }
            if (6.0 * vH < 1.0)
            {
                return v1 + (v2 - v1) * 6.0 * vH;
            }
            if (2.0 * vH < 1.0)
            {
                return v2;
            }
            if (3.0 * vH < 2.0)
            {
                return v1 + (v2 - v1) * (2.0 / 3.0 - vH) * 6.0;
            }

            return v1;
        }

        private static void MinMax(out double min, out double max, double r, double g, double b)
        {
            if (r > g)
            {
                max = r;
                min = g;
            }
            else
            {
                max = g;
                min = r;
            }
            if (b > max)
            {
                max = b;
            }
            else if (b < min)
            {
                min = b;
            }
        }

        /// <summary>
        /// Adjust the brightness of a <see cref="Color"/>.
        /// </summary>
        /// <param name="color">The <see cref="Color"/> to adjust.</param>
        /// <param name="brightness">The brightness value between 0.0 and 1.0.</param>
        public static Color ScaleBrightness(Color color, double brightness)
        {
            var brightnessAdjusted = FastMath.Clamp(brightness, 0.0, 1.0);
            var scaledColor = ToHsbColor(color, brightnessAdjusted);

            return scaledColor.ToColor();
        }

        internal static Color ToColor(HsbColor hsb)
        {
            double red = 0, green = 0, blue = 0;

            var hue = hsb.Hue;
            var saturation = hsb.Saturation / 100.0;
            var brightness = hsb.Brightness / 100.0;

            if (FastMath.Abs(saturation - 0) < double.Epsilon)
            {
                red = brightness;
                green = brightness;
                blue = brightness;
            }
            else
            {
                // the color wheel has six sectors.

                var sectorPosition = hue / 60;
                var sectorNumber = (int)Math.Floor(sectorPosition);
                var fractionalSector = sectorPosition - sectorNumber;

                var p = brightness * (1 - saturation);
                var q = brightness * (1 - saturation * fractionalSector);
                var t = brightness * (1 - saturation * (1 - fractionalSector));

                // Assign the fractional colors to r, g, and b
                // based on the sector the angle is in.
                switch (sectorNumber)
                {
                    case 0:
                        red = brightness;
                        green = t;
                        blue = p;
                        break;

                    case 1:
                        red = q;
                        green = brightness;
                        blue = p;
                        break;

                    case 2:
                        red = p;
                        green = brightness;
                        blue = t;
                        break;

                    case 3:
                        red = p;
                        green = q;
                        blue = brightness;
                        break;

                    case 4:
                        red = t;
                        green = p;
                        blue = brightness;
                        break;

                    case 5:
                        red = brightness;
                        green = p;
                        blue = q;
                        break;
                }
            }

            var nRed = (int)(red * 255);
            var nGreen = (int)(green * 255);
            var nBlue = (int)(blue * 255);

            return Color.FromArgb(hsb.Alpha, nRed, nGreen, nBlue);
        }

        internal static Color ToColor(HslColor hsl)
        {
            double red, green, blue;

            var hue = hsl.Hue / 360.0;
            var saturation = hsl.Saturation / 100.0;
            var light = hsl.Light / 100.0;

            if (FastMath.Abs(saturation - 0.0) < double.Epsilon)
            {
                red = light;
                green = light;
                blue = light;
            }
            else
            {
                double var2;

                if (light < 0.5)
                {
                    var2 = light * (1.0 + saturation);
                }
                else
                {
                    var2 = light + saturation - saturation * light;
                }

                var var1 = 2.0 * light - var2;

                red = Hue2Rgb(var1, var2, hue + 1.0 / 3.0);
                green = Hue2Rgb(var1, var2, hue);
                blue = Hue2Rgb(var1, var2, hue - 1.0 / 3.0);
            }

            var nRed = (int)(red * 255.0);
            var nGreen = (int)(green * 255.0);
            var nBlue = (int)(blue * 255.0);

            return Color.FromArgb(hsl.Alpha, nRed, nGreen, nBlue);
        }

        internal static HsbColor ToHsbColor(Color color, double brightness = -1.0d)
        {
            var r = color.R / 255d;
            var g = color.G / 255d;
            var b = color.B / 255d;

            MinMax(out var min, out var max, r, g, b);
            
            var delta = max - min;

            var hue = 0d;
            var saturation = 0d;
            brightness = brightness < 0 ? max * 100 : brightness * 100;

            if (min == 0)
            {
                saturation = 100;
            }
            else if (max != 0)
            {
                saturation = delta / max * 100;
            }

            // ReSharper disable CompareOfFloatsByEqualityOperator
            if (max == r && g >= b)
            {
                hue = 60 * (g - b) / delta;
            }
            else if (max == r && g < b)
            {
                hue = 60 * (g - b) / delta + 360;
            }
            else if (max == g)
            {
                hue = 60 * (b - r) / delta + 120;
            }
            else if (max == b)
            {
                hue = 60 * (r - g) / delta + 240;
            }
            // ReSharper restore CompareOfFloatsByEqualityOperator

            return new HsbColor(hue, saturation, brightness, color.A);
        }

        internal static HslColor ToHslColor(Color color)
        {
            var r = color.R;
            var g = color.G;
            var b = color.B;

            MinMax(out var min, out var max, r, g, b);

            var delta = max - min;

            double hue;
            double saturation;
            var light = (max + min) / (byte.MaxValue * 2f);

            if (r == g && g == b)
            {
                hue = 0;
                saturation = 0;
            }
            else
            {
                // ReSharper disable CompareOfFloatsByEqualityOperator
                if (r == max)
                {
                    hue = (g - b) / delta;
                }
                else if (g == max)
                {
                    hue = (b - r) / delta + 2f;
                }
                else
                {
                    hue = (r - g) / delta + 4f;
                }
                // ReSharper restore CompareOfFloatsByEqualityOperator

                hue *= 60f;
                if (hue < 0f)
                {
                    hue += 360f;
                }

                var div = max + min;
                if (div > byte.MaxValue)
                {
                    div = byte.MaxValue * 2 - max - min;
                }

                saturation = (max - min) / div;
            }

            return new HslColor(hue, saturation * 100.0, light * 100.0, color.A);
        }
    }
}
