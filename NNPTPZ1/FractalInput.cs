using System;

namespace NNPTPZ1
{
    /// <summary>
    /// Contains input parameters required for fractal generation.
    /// </summary>
    internal class FractalInput
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public double MinX { get; set; }
        public double MaxX { get; set; }
        public double MinY { get; set; }
        public double MaxY { get; set; }

        public string OutputPath { get; set; }

        public static FractalInput Parse(string[] args)
        {
            if (args == null || args.Length < 7)
            {
                throw new ArgumentException(
                    "Usage: NNPTPZ1 <width> <height> <minX> <maxX> <minY> <maxY> <output>");
            }

            return new FractalInput
            {
                Width = int.Parse(args[0]),
                Height = int.Parse(args[1]),
                MinX = double.Parse(args[2]),
                MaxX = double.Parse(args[3]),
                MinY = double.Parse(args[4]),
                MaxY = double.Parse(args[5]),
                OutputPath = args[6]
            };
        }
    }
}