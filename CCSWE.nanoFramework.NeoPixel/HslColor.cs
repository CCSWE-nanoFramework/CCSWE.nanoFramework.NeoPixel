using System.Drawing;

namespace CCSWE.nanoFramework.NeoPixel
{
    // Based on: https://gist.github.com/UweKeim/fb7f829b852c209557bc49c51ba14c8b

    /// <summary>
    /// Represents a HSL color space.
    /// https://en.wikipedia.org/wiki/HSL_and_HSV
    /// </summary>
    internal readonly struct HslColor
    {
        public HslColor(double hue, double saturation, double light, int alpha)
        {
            Hue = hue;
            Saturation = saturation;
            Light = light;
            Alpha = alpha;
        }

        /// <summary>
        /// Gets the hue. Values from 0 to 360.
        /// </summary>
        public double Hue { get; }

        /// <summary>
        /// Gets the saturation. Values from 0 to 100.
        /// </summary>
        public double Saturation { get; }

        /// <summary>
        /// Gets the light. Values from 0 to 100.
        /// </summary>
        public double Light { get; }

        /// <summary>
        /// Gets the alpha. Values from 0 to 255
        /// </summary>
        public int Alpha { get; }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is not HslColor color)
            {
                return false;
            }

            return Math.Abs(Hue - color.Hue) < double.Epsilon &&
                   Math.Abs(Saturation - color.Saturation) < double.Epsilon &&
                   Math.Abs(Light - color.Light) < double.Epsilon &&
                   Alpha == color.Alpha;
        }

        public static HslColor FromColor(Color color)
        {
            return ColorConverter.ToHslColor(color);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                return Hue.GetHashCode() ^ Saturation.GetHashCode() ^ Light.GetHashCode() ^ Alpha.GetHashCode();
            }
        }

        public Color ToColor()
        {
            return ColorConverter.ToColor(this);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return Alpha < 255
                ? $@"hsla({Hue}, {Saturation}%, {Light}%, {Alpha / 255f})"
                : $@"hsl({Hue}, {Saturation}%, {Light}%)";
        }
    }
}
