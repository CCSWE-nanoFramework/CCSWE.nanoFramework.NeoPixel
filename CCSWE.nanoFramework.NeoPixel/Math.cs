using System;

// TODO: Move this to a library if there is something I'm missing regarding the reasoning for using slower native methods in System.Math
namespace CCSWE.nanoFramework.NeoPixel
{
    /// <summary>
    /// Provides constants and static methods for trigonometric, logarithmic, and other common mathematical functions.
    /// </summary>
    internal static class Math
    {
        /// <inheritdoc cref="System.Math.PI"/>
        public const double PI = 3.1415926535897931;

        /// <inheritdoc cref="System.Math.E"/>
        public const double E = 2.7182818284590451;

        /// <inheritdoc cref="System.Math.Abs(double)"/>
        public static double Abs(double value) => value < 0 ? value * -1 : value;

        /// <inheritdoc cref="System.Math.Abs(float)"/>
        public static float Abs(float value) => value < 0 ? value * -1 : value;

        /// <inheritdoc cref="System.Math.Abs(int)"/>
        public static int Abs(int value) => value < 0 ? value * -1 : value;

        /// <inheritdoc cref="System.Math.Ceiling(double)"/>
        public static double Ceiling(double d)
        {
            return System.Math.Ceiling(d);
        }

        /// <inheritdoc cref="System.Math.Clamp(double,double,double)"/>
        public static double Clamp(double value, double min, double max) => Max(min, Min(max, value));

        /// <inheritdoc cref="System.Math.Clamp(float,float,float)"/>
        public static float Clamp(float value, float min, float max) => Max(min, Min(max, value));

        /// <inheritdoc cref="System.Math.Floor(double)"/>
        public static double Floor(double d)
        {
            return System.Math.Floor(d);
        }

        /// <inheritdoc cref="System.Math.Max(double, double)"/>
        public static double Max(double val1, double val2) => val1 > val2 ? val1 : val2;

        /// <inheritdoc cref="System.Math.Max(float, float)"/>
        public static float Max(float val1, float val2) => val1 > val2 ? val1 : val2;

        /// <inheritdoc cref="System.Math.Max(int, int)"/>
        public static int Max(int val1, int val2) => val1 > val2 ? val1 : val2;

        /// <inheritdoc cref="System.Math.Min(double, double)"/>
        public static double Min(double val1, double val2) => val1 < val2 ? val1 : val2;

        /// <inheritdoc cref="System.Math.Min(float, float)"/>
        public static float Min(float val1, float val2) => val1 < val2 ? val1 : val2;

        /// <inheritdoc cref="System.Math.Min(int, int)"/>
        public static int Min(int val1, int val2) => val1 < val2 ? val1 : val2;
    }

    // TODO: If I do move this to a separate library it should be two libraries. One that references System.Math and uses the fastest implementation and the other should be entirely managed code

    /// <summary>
    /// Managed implementation of the <see cref="System.Math"/> methods.
    /// </summary>
    /// <remarks>These should not be used directly as the fastest implementation will always be used in <see cref="Math"/>.</remarks>
    internal static class ManagedMath
    {
        /// <inheritdoc cref="System.Math.PI"/>
        public const double PI = 3.1415926535897931;

        /// <inheritdoc cref="System.Math.E"/>
        public const double E = 2.7182818284590451;

        /// <inheritdoc cref="System.Math.Abs(double)"/>
        public static double Abs(double value) => value < 0 ? value * -1 : value;

        /// <inheritdoc cref="System.Math.Abs(float)"/>
        public static float Abs(float value) => value < 0 ? value * -1 : value;

        /// <inheritdoc cref="System.Math.Abs(int)"/>
        public static int Abs(int value) => value < 0 ? value * -1 : value;

        /// <inheritdoc cref="System.Math.Ceiling(double)"/>
        public static double Ceiling(double d) => Floor(d) + 1;

        /// <inheritdoc cref="System.Math.Clamp(double,double,double)"/>
        public static double Clamp(double value, double min, double max) => Max(min, Min(max, value));

        /// <inheritdoc cref="System.Math.Clamp(float,float,float)"/>
        public static float Clamp(float value, float min, float max) => Max(min, Min(max, value));

        /*
        /// <inheritdoc cref="System.Math.Clamp(long,long,long)"/>
        public static long Clamp(long value, long min, long max) => Max(min, Min(max, value));

        /// <inheritdoc cref="System.Math.Clamp(ulong,ulong,ulong)"/>
        public static ulong Clamp(ulong value, ulong min, ulong max) => Max(min, Min(max, value));
        */

        /// <inheritdoc cref="System.Math.Floor(double)"/>
        public static double Floor(double d) => d % 1 == 0 ? d : (int)(d - (d < 0 ? 1 : 0));

        /// <inheritdoc cref="System.Math.Max(double, double)"/>
        public static double Max(double val1, double val2) => val1 > val2 ? val1 : val2;

        /// <inheritdoc cref="System.Math.Max(float, float)"/>
        public static float Max(float val1, float val2) => val1 > val2 ? val1 : val2;

        /// <inheritdoc cref="System.Math.Max(int, int)"/>
        public static int Max(int val1, int val2) => val1 > val2 ? val1 : val2;

        /// <inheritdoc cref="System.Math.Min(double, double)"/>
        public static double Min(double val1, double val2) => val1 < val2 ? val1 : val2;

        /// <inheritdoc cref="System.Math.Min(float, float)"/>
        public static float Min(float val1, float val2) => val1 < val2 ? val1 : val2;

        /// <inheritdoc cref="System.Math.Min(int, int)"/>
        public static int Min(int val1, int val2) => val1 < val2 ? val1 : val2;
    }
}
