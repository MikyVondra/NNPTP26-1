using Microsoft.VisualStudio.TestTools.UnitTesting;
using NNPTPZ1.Mathematics;

namespace NNPTPZ1Tests
{
    [TestClass]
    public class PolynomialTests
    {
        [TestMethod]
        public void Eval_RealInput_ReturnsExpectedValue()
        {
            var polynomial = new Polynomial();

            polynomial.Coefficients.Add(new ComplexNumber { Real = 3 });
            polynomial.Coefficients.Add(new ComplexNumber { Real = 2 });
            polynomial.Coefficients.Add(new ComplexNumber { Real = 1 });

            ComplexNumber result = polynomial.Eval(2);

            Assert.AreEqual(11.0, result.Real);
            Assert.AreEqual(0.0, result.Imaginary);
        }

        [TestMethod]
        public void Eval_ComplexInput_ReturnsExpectedValue()
        {
            var polynomial = new Polynomial();

            polynomial.Coefficients.Add(new ComplexNumber { Real = 2 });
            polynomial.Coefficients.Add(new ComplexNumber { Real = 1 });

            var point = new ComplexNumber
            {
                Real = 1,
                Imaginary = 2
            };

            ComplexNumber result = polynomial.Eval(point);

            Assert.AreEqual(3.0, result.Real);
            Assert.AreEqual(2.0, result.Imaginary);
        }

        [TestMethod]
        public void Derivative_CreatesCorrectCoefficients()
        {
            var polynomial = new Polynomial();

            polynomial.Coefficients.Add(new ComplexNumber { Real = 5 });
            polynomial.Coefficients.Add(new ComplexNumber { Real = 4 });
            polynomial.Coefficients.Add(new ComplexNumber { Real = 3 });
            polynomial.Coefficients.Add(new ComplexNumber { Real = 2 });

            Polynomial derivative = polynomial.Derivative();

            Assert.AreEqual(3, derivative.Coefficients.Count);

            Assert.AreEqual(4.0, derivative.Coefficients[0].Real);
            Assert.AreEqual(6.0, derivative.Coefficients[1].Real);
            Assert.AreEqual(6.0, derivative.Coefficients[2].Real);
        }

        [TestMethod]
        public void Add_AddsCoefficientToPolynomial()
        {
            var polynomial = new Polynomial();

            var coefficient = new ComplexNumber
            {
                Real = -2,
                Imaginary = 4
            };

            polynomial.Add(coefficient);

            Assert.AreEqual(1, polynomial.Coefficients.Count);
            Assert.AreEqual(coefficient, polynomial.Coefficients[0]);
        }

        [TestMethod]
        public void ToString_ReturnsPolynomialInExpectedFormat()
        {
            var polynomial = new Polynomial();

            polynomial.Coefficients.Add(new ComplexNumber { Real = 4 });
            polynomial.Coefficients.Add(new ComplexNumber { Real = -1 });
            polynomial.Coefficients.Add(new ComplexNumber { Real = 2 });

            string result = polynomial.ToString();

            Assert.AreEqual(
                "(4 + 0i) + (-1 + 0i)x + (2 + 0i)xx",
                result);
        }
    }
}