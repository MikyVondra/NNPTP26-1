using System;

namespace NNPTPZ1.Mathematics
{
    /// <summary>
    /// Represents a complex number with real and imaginary parts.
    /// </summary>
    public class ComplexNumber
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is ComplexNumber other)
            {
                return other.Real == Real && other.Imaginary == Imaginary;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Real.GetHashCode() ^ Imaginary.GetHashCode();
        }

        public static readonly ComplexNumber Zero = new ComplexNumber();

        public ComplexNumber Multiply(ComplexNumber other)
        {
            return new ComplexNumber
            {
                Real = Real * other.Real - Imaginary * other.Imaginary,
                Imaginary = Real * other.Imaginary + Imaginary * other.Real
            };
        }

        /// <summary>
        /// Returns the absolute value of the complex number.
        /// </summary>
        public double GetAbsoluteValue()
        {
            return Math.Sqrt(GetSquaredMagnitude());
        }

        public ComplexNumber Add(ComplexNumber other)
        {
            return new ComplexNumber
            {
                Real = Real + other.Real,
                Imaginary = Imaginary + other.Imaginary
            };
        }

        /// <summary>
        /// Returns the angle of the complex number in degrees.
        /// </summary>
        public double GetAngleInDegrees()
        {
            return Math.Atan2(Imaginary, Real) * 180.0 / Math.PI;
        }

        /// <summary>
        /// Returns the squared magnitude of the complex number.
        /// </summary>
        public double GetSquaredMagnitude()
        {
            return Real * Real + Imaginary * Imaginary;
        }

        public ComplexNumber Subtract(ComplexNumber other)
        {
            return new ComplexNumber
            {
                Real = Real - other.Real,
                Imaginary = Imaginary - other.Imaginary
            };
        }

        public override string ToString()
        {
            return $"({Real} + {Imaginary}i)";
        }

        /// <summary>
        /// Divides this complex number by another complex number.
        /// </summary>
        internal ComplexNumber Divide(ComplexNumber other)
        {
            var numerator = Multiply(new ComplexNumber
            {
                Real = other.Real,
                Imaginary = -other.Imaginary
            });

            var denominator = other.GetSquaredMagnitude();

            return new ComplexNumber
            {
                Real = numerator.Real / denominator,
                Imaginary = numerator.Imaginary / denominator
            };
        }
    }
}