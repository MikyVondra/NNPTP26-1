using System;
using System.Collections.Generic;
using System.Drawing;
using NNPTPZ1.Mathematics;

namespace NNPTPZ1
{
    /// <summary>
    /// Generates Newton fractal images.
    /// </summary>
    internal class FractalGenerator
    {
        private static readonly Color[] Colors =
        {
            Color.Red,
            Color.Blue,
            Color.Green,
            Color.Yellow,
            Color.Orange,
            Color.Fuchsia,
            Color.Gold,
            Color.Cyan,
            Color.Magenta
        };

        internal Bitmap Generate(FractalInput input, Polynomial polynomial)
        {
            Bitmap bitmap = new Bitmap(input.Width, input.Height);

            double stepX = (input.MaxX - input.MinX) / input.Width;
            double stepY = (input.MaxY - input.MinY) / input.Height;

            Polynomial derivative = polynomial.Derivative();
            List<ComplexNumber> roots = new List<ComplexNumber>();

            for (int row = 0; row < input.Height; row++)
            {
                for (int column = 0; column < input.Width; column++)
                {
                    double x = input.MinX + column * stepX;
                    double y = input.MinY + row * stepY;

                    ComplexNumber point = CreatePoint(x, y);

                    int iterations = RunNewtonMethod(
                        polynomial,
                        derivative,
                        ref point);

                    int rootIndex = FindRootIndex(roots, point);

                    Color color = CreateColor(rootIndex, iterations);

                    bitmap.SetPixel(column, row, color);
                }
            }

            return bitmap;
        }

        private static ComplexNumber CreatePoint(double x, double y)
        {
            ComplexNumber point = new ComplexNumber
            {
                Real = x,
                Imaginary = y
            };

            if (point.Real == 0)
            {
                point.Real = 0.0001;
            }

            if (point.Imaginary == 0)
            {
                point.Imaginary = 0.0001;
            }

            return point;
        }

        private static int RunNewtonMethod(
            Polynomial polynomial,
            Polynomial derivative,
            ref ComplexNumber point)
        {
            int iterations = 0;

            for (int iteration = 0; iteration < 30; iteration++)
            {
                ComplexNumber difference =
                    polynomial.Eval(point).Divide(derivative.Eval(point));

                point = point.Subtract(difference);

                if (difference.GetSquaredMagnitude() >= 0.5)
                {
                    iteration--;
                }

                iterations++;
            }

            return iterations;
        }

        private static int FindRootIndex(
            List<ComplexNumber> roots,
            ComplexNumber point)
        {
            for (int index = 0; index < roots.Count; index++)
            {
                double realDifference = point.Real - roots[index].Real;
                double imaginaryDifference = point.Imaginary - roots[index].Imaginary;

                double distanceSquared =
                    realDifference * realDifference +
                    imaginaryDifference * imaginaryDifference;

                if (distanceSquared <= 0.01)
                {
                    return index;
                }
            }

            roots.Add(point);

            return roots.Count;
        }

        private static Color CreateColor(int rootIndex, int iterations)
        {
            Color color = Colors[rootIndex % Colors.Length];

            return Color.FromArgb(
                Math.Min(Math.Max(0, color.R - iterations * 2), 255),
                Math.Min(Math.Max(0, color.G - iterations * 2), 255),
                Math.Min(Math.Max(0, color.B - iterations * 2), 255)
            );
        }
    }
}