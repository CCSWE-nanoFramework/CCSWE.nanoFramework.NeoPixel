using System;
using System.Drawing;

namespace CCSWE.nanoFramework.NeoPixel.Extensions
{
    public static class ColorExtensions
    {
        public static byte[] ToBytes(this Color color, ColorOrder order)
        {
            return order switch
            {
                ColorOrder.RGB => new[] { color.R, color.G, color.B },
                ColorOrder.GRB => new[] { color.G, color.R, color.B },
                _ => throw new ArgumentOutOfRangeException(nameof(order))
            };
        }
    }
}
