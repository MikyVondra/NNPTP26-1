using Microsoft.VisualStudio.TestTools.UnitTesting;
using NNPTPZ1.Mathematics;

namespace NNPTPZ1Tests
{
    [TestClass]
    public class ComplexNumberTests
    {
        [TestMethod]
        public void Add_WithPositiveAndNegativeValues_ReturnsExpectedResult()
        {
            var first = new ComplexNumber
            {
                Real = 5,
                Imaginary = -3
            };

            var second = new ComplexNumber
            {
                Real = -2,
                Imaginary = 7
            };

            var result = first.Add(second);

            Assert.AreEqual(3.0, result.Real);
            Assert.AreEqual(4.0, result.Imaginary);
        }

        [TestMethod]
        public void Subtract_ReturnsExpectedResult()
        {
            var first = new ComplexNumber
            {
                Real = 8,
                Imaginary = 6
            };

            var second = new ComplexNumber
            {
                Real = 3,
                Imaginary = 2
            };

            var result = first.Subtract(second);

            Assert.AreEqual(5.0, result.Real);
            Assert.AreEqual(4.0, result.Imaginary);
        }

        [TestMethod]
        public void Multiply_ReturnsExpectedResult()
        {
            var first = new ComplexNumber
            {
                Real = 2,
                Imaginary = 3
            };

            var second = new ComplexNumber
            {
                Real = 1,
                Imaginary = -4
            };

            var result = first.Multiply(second);

            Assert.AreEqual(14.0, result.Real);
            Assert.AreEqual(-5.0, result.Imaginary);
        }

        [TestMethod]
        public void AddingZero_DoesNotChangeNumber()
        {
            var number = new ComplexNumber
            {
                Real = 4,
                Imaginary = -6
            };

            var result = number.Add(ComplexNumber.Zero);

            Assert.AreEqual(number, result);
        }

        [TestMethod]
        public void GetAbsoluteValue_ForThreeFourTriangle_ReturnsFive()
        {
            var number = new ComplexNumber
            {
                Real = 3,
                Imaginary = 4
            };

            double result = number.GetAbsoluteValue();

            Assert.AreEqual(5.0, result, 0.000001);
        }

        [TestMethod]
        public void GetSquaredMagnitude_ReturnsExpectedValue()
        {
            var number = new ComplexNumber
            {
                Real = 2,
                Imaginary = 5
            };

            double result = number.GetSquaredMagnitude();

            Assert.AreEqual(29.0, result);
        }

        [TestMethod]
        public void GetAngleInDegrees_ReturnsCorrectQuadrantAngle()
        {
            var number = new ComplexNumber
            {
                Real = 0,
                Imaginary = 1
            };

            double result = number.GetAngleInDegrees();

            Assert.AreEqual(90.0, result, 0.000001);
        }

        [TestMethod]
        public void Equals_WithSameParts_ReturnsTrue()
        {
            var first = new ComplexNumber
            {
                Real = 7,
                Imaginary = -2
            };

            var second = new ComplexNumber
            {
                Real = 7,
                Imaginary = -2
            };

            Assert.IsTrue(first.Equals(second));
        }

        [TestMethod]
        public void Equals_WithDifferentParts_ReturnsFalse()
        {
            var first = new ComplexNumber
            {
                Real = 7,
                Imaginary = -2
            };

            var second = new ComplexNumber
            {
                Real = 7,
                Imaginary = 2
            };

            Assert.IsFalse(first.Equals(second));
        }

        [TestMethod]
        public void ToString_ReturnsExpectedFormat()
        {
            var number = new ComplexNumber
            {
                Real = -2,
                Imaginary = 3
            };

            Assert.AreEqual("(-2 + 3i)", number.ToString());
        }
    }
}