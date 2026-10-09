using System;
using System.Drawing;
using System.Drawing.Imaging;
using NNPTPZ1.Mathematics;

namespace NNPTPZ1
{
    /// <summary>
    /// This program should produce Newton fractals.
    /// </summary>
    internal static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FractalInput input = FractalInput.Parse(args);

                Polynomial polynomial = CreatePolynomial();

                Console.WriteLine(polynomial);
                Console.WriteLine(polynomial.Derivative());

                FractalGenerator generator = new FractalGenerator();

                using (Bitmap bitmap = generator.Generate(input, polynomial))
                {
                    bitmap.Save(input.OutputPath, ImageFormat.Png);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static Polynomial CreatePolynomial()
        {
            Polynomial polynomial = new Polynomial();

            polynomial.Coefficients.Add(new ComplexNumber { Real = 1 });
            polynomial.Coefficients.Add(ComplexNumber.Zero);
            polynomial.Coefficients.Add(ComplexNumber.Zero);
            polynomial.Coefficients.Add(new ComplexNumber { Real = 1 });

            return polynomial;
        }
    }
}
