﻿using System.Drawing;

namespace CCSWE.nanoFramework.NeoPixel
{
    // Based on: https://gist.github.com/UweKeim/fb7f829b852c209557bc49c51ba14c8b

    /// <summary>
    /// Represents a HSB color space.
    /// https://en.wikipedia.org/wiki/HSL_and_HSV
    /// </summary>
    internal readonly struct HsbColor
    {
        public HsbColor(double hue, double saturation, double brightness, int alpha)
        {
            Hue = hue;
            Saturation = saturation;
            Brightness = brightness;
            Alpha = alpha;
        }

        /// <summary>
        /// Gets or sets the hue. Values from 0 to 360.
        /// </summary>
        public double Hue { get; }

        /// <summary>
        /// Gets or sets the saturation. Values from 0 to 100.
        /// </summary>
        public double Saturation { get; }

        /// <summary>
        /// Gets or sets the brightness. Values from 0 to 100.
        /// </summary>
        public double Brightness { get; }

        /// <summary>
        /// Gets or sets the alpha. Values from 0 to 255.
        /// </summary>
        public int Alpha { get; }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is not HsbColor color)
            {
                return false;
            }

            return FastMath.Abs(Hue - color.Hue) < double.Epsilon &&
                   FastMath.Abs(Saturation - color.Saturation) < double.Epsilon &&
                   FastMath.Abs(Brightness - color.Brightness) < double.Epsilon &&
                   Alpha == color.Alpha;
        }

        public static HsbColor FromColor(Color color)
        {
            return ColorConverter.ToHsbColor(color);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                return Hue.GetHashCode() ^ Saturation.GetHashCode() ^ Brightness.GetHashCode() ^ Alpha.GetHashCode();
            }
        }

        public Color ToColor()
        {
            return ColorConverter.ToColor(this);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"Hue: {Hue}; Saturation: {Saturation}; Brightness: {Brightness}; Alpha: {Alpha}";
        }
    }
}
