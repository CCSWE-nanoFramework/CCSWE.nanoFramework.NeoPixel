using System;

namespace CCSWE.nanoFramework.NeoPixel
{
    internal static class Math
    {
        public static double Abs(double value) => value < 0 ? value * -1 : value;
        public static float Abs(float value) => value < 0 ? value * -1 : value;
        public static int Abs(int value) => value < 0 ? value * -1 : value;

        public static double Max(double left, double right) => left > right ? left : right;
        public static float Max(float left, float right) => left > right ? left : right;
        public static int Max(int left, int right) => left > right ? left : right;
    }
}
