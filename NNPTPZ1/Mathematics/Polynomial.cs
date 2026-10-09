using System.Collections.Generic;
using System.Text;

namespace NNPTPZ1.Mathematics
{
    /// <summary>
    /// Represents a polynomial with complex coefficients.
    /// </summary>
    public class Polynomial
    {
        public List<ComplexNumber> Coefficients { get; set; } = new List<ComplexNumber>();

        public void Add(ComplexNumber coefficient)
        {
            Coefficients.Add(coefficient);
        }

        public Polynomial Derivative()
        {
            Polynomial derivative = new Polynomial();

            for (int i = 1; i < Coefficients.Count; i++)
            {
                derivative.Coefficients.Add(
                    Coefficients[i].Multiply(
                        new ComplexNumber
                        {
                            Real = i
                        }
                    )
                );
            }

            return derivative;
        }

        public ComplexNumber Eval(double value)
        {
            return Eval(new ComplexNumber
            {
                Real = value,
                Imaginary = 0
            });
        }

        public ComplexNumber Eval(ComplexNumber point)
        {
            ComplexNumber result = ComplexNumber.Zero;

            for (int i = 0; i < Coefficients.Count; i++)
            {
                ComplexNumber coefficient = Coefficients[i];
                ComplexNumber powerValue = point;

                if (i > 0)
                {
                    for (int j = 0; j < i - 1; j++)
                    {
                        powerValue = powerValue.Multiply(point);
                    }

                    coefficient = coefficient.Multiply(powerValue);
                }

                result = result.Add(coefficient);
            }

            return result;

        }

        public override string ToString()
        {
            var result = new StringBuilder();

            for (int i = 0; i < Coefficients.Count; i++)
            {
                result.Append(Coefficients[i]);

                if (i > 0)
                {
                    result.Append(new string('x', i));
                }

                if (i < Coefficients.Count - 1)
                {
                    result.Append(" + ");
                }
            }

            return result.ToString();
        }
    }
}