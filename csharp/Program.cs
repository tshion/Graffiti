using System;
using System.Diagnostics;
using System.IO;
using System.Numerics;

namespace MandelbrotSet
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = 1024;
            var model = new GraphModel();

            Console.WriteLine("Start Calculation");
            var swCalculation = Stopwatch.StartNew();
            var map = model.MakeMandelbrotSetParallel(
                new Complex(0.50, 1.00),
                new Complex(-1.50, -1.00),
                size
            );
            swCalculation.Stop();
            Console.WriteLine($"Finish Calculation: {swCalculation.ElapsedMilliseconds}[ms]");

            Console.WriteLine("Start File Output");
            var swOutput = Stopwatch.StartNew();
            using (var writer = new StreamWriter("image.pgm"))
            {
                writer.WriteLine("P2");
                writer.WriteLine($"{size} {size}");
                writer.WriteLine("255");
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        writer.Write($"{map[row, col]}\t");
                    }
                    writer.WriteLine();
                }
            }
            swOutput.Stop();
            Console.WriteLine($"Finish File Output: {swOutput.ElapsedMilliseconds}[ms]");
        }
    }
}
