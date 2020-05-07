using Core.Entities;
using Core.UseCases;
using DataSource;
using System.Linq;

namespace Executor
{
    class Program
    {
        static void Main(string[] args)
        {
            var useCase = new DrawingUseCase(
                //new GraphModel(),
                new GraphParallelModel(),
                new PgmFileModel()
            );

            var minIm = -1.00;
            var minRe = -1.50;
            var pixelIm = 1024;
            var pixelRe = 1024;
            var scaleIm = (1.00 - minIm) / pixelIm;
            var scaleRe = (0.50 - minRe) / pixelRe;

            var result = useCase.DrawImage(new MandelbrotEntity
            {
                DivergenceBorder = 100,
                GiveUpBorder = 500,
                RangeImage = Enumerable.Range(0, pixelIm).Select(i => scaleIm * i + minIm).ToArray(),
                RangeReal = Enumerable.Range(0, pixelRe).Select(i => scaleRe * i + minRe).ToArray(),
            });

            useCase.SaveImage(result);
        }
    }
}
