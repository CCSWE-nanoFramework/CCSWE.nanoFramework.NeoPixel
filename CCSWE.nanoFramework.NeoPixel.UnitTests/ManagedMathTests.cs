using nanoFramework.TestFramework;
// ReSharper disable ConvertToConstant.Local
// ReSharper disable UselessBinaryOperation

namespace CCSWE.nanoFramework.NeoPixel.UnitTests
{
    [TestClass]
    public class ManagedMathTests
    {
        [TestMethod]
        public void Abs_returns_correct_value_for_double()
        {
            var expect = 1d;
            var value1 = expect * 1;
            var value2 = expect * -1;

            Assert.AreEqual(expect, ManagedMath.Abs(value1));
            Assert.AreEqual(expect, ManagedMath.Abs(value2));
        }

        [TestMethod]
        public void Abs_returns_correct_value_for_float()
        {
            var expect = 1f;
            var value1 = expect * 1;
            var value2 = expect * -1;

            Assert.AreEqual(expect, ManagedMath.Abs(value1));
            Assert.AreEqual(expect, ManagedMath.Abs(value2));
        }

        [TestMethod]
        public void Abs_returns_correct_value_for_int()
        {
            var expect = 1;
            var value1 = expect * 1;
            var value2 = expect * -1;

            Assert.AreEqual(expect, ManagedMath.Abs(value1));
            Assert.AreEqual(expect, ManagedMath.Abs(value2));
        }

        [TestMethod]
        public void Ceiling_returns_correct_value_for_negative_double()
        {
            var expect = -3d;
            var value = -3.14d;

            Assert.AreEqual(expect, ManagedMath.Ceiling(value));
            Assert.AreEqual(expect, System.Math.Ceiling(value));
        }

        [TestMethod]
        public void Ceiling_returns_correct_value_for_positive_double()
        {
            var expect = 4d;
            var value = 3.14d;

            Assert.AreEqual(expect, ManagedMath.Ceiling(value));
            Assert.AreEqual(expect, System.Math.Ceiling(value));
        }

        [TestMethod]
        public void Clamp_returns_correct_value_for_double()
        {
            var expect = 1d;
            var max = expect * 1;
            var min = expect * -1;
            var value = 10d;

            Assert.AreEqual(expect, ManagedMath.Clamp(value, min, max));
            Assert.AreEqual(expect, System.Math.Clamp(value, min, max));
        }

        [TestMethod]
        public void Clamp_returns_correct_value_for_float()
        {
            var expect = 1f;
            var max = expect * 1;
            var min = expect * -1;
            var value = 10f;

            Assert.AreEqual(expect, ManagedMath.Clamp(value, min, max));
            Assert.AreEqual(expect, System.Math.Clamp(value, min, max));
        }

        [TestMethod]
        public void Floor_returns_correct_value_for_negative_double()
        {
            var expect = -4d;
            var value = -3.14d;

            Assert.AreEqual(expect, ManagedMath.Floor(value));
            Assert.AreEqual(expect, System.Math.Floor(value));
        }

        [TestMethod]
        public void Floor_returns_correct_value_for_positive_double()
        {
            var expect = 3d;
            var value = 3.14d;

            Assert.AreEqual(expect, ManagedMath.Floor(value));
            Assert.AreEqual(expect, System.Math.Floor(value));
        }

        [TestMethod]
        public void Max_returns_correct_value_for_double()
        {
            var expect = 1d;
            var value1 = expect * 1;
            var value2 = expect * -1;

            Assert.AreEqual(expect, ManagedMath.Max(value1, value2));
        }

        [TestMethod]
        public void Max_returns_correct_value_for_float()
        {
            var expect = 1f;
            var value1 = expect * 1;
            var value2 = expect * -1;

            Assert.AreEqual(expect, ManagedMath.Max(value1, value2));
        }

        [TestMethod]
        public void Max_returns_correct_value_for_int()
        {
            var expect = 1;
            var value1 = expect * 1;
            var value2 = expect * -1;

            Assert.AreEqual(expect, ManagedMath.Max(value1, value2));
        }

        [TestMethod]
        public void Min_returns_correct_value_for_double()
        {
            var expect = -1d;
            var value1 = expect * 1;
            var value2 = expect * -1;

            Assert.AreEqual(expect, ManagedMath.Min(value1, value2));
        }

        [TestMethod]
        public void Min_returns_correct_value_for_float()
        {
            var expect = -1f;
            var value1 = expect * 1;
            var value2 = expect * -1;

            Assert.AreEqual(expect, ManagedMath.Min(value1, value2));
        }

        [TestMethod]
        public void Min_returns_correct_value_for_int()
        {
            var expect = -1;
            var value1 = expect * 1;
            var value2 = expect * -1;

            Assert.AreEqual(expect, ManagedMath.Min(value1, value2));
        }
    }
}
