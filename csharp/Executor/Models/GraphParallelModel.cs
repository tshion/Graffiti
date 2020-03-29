using System.Numerics;
using System.Threading.Tasks;

namespace Executor.Models
{
    /// <summary>
    /// グラフ生成モデル(並列処理版)
    /// </summary>
    class GraphParallelModel : IGraphModel
    {
        /// <summary>
        /// マンデルブロ集合を生成する
        /// </summary>
        /// <param name="max">最大値</param>
        /// <param name="min">最小値</param>
        /// <param name="size">一辺の大きさ</param>
        /// <param name="limit">閾値</param>
        /// <param name="maxCycle">最大試行回数</param>
        public int[,] MakeMandelbrotSet(
            Complex max,
            Complex min,
            int size,
            int limit = 100,
            int maxCycle = 500
        )
        {
            var scale = new Complex(
                (max.Real - min.Real) / (size - 1),
                (max.Imaginary - min.Imaginary) / (size - 1)
            );

            var table = new Complex[size];
            table[0] = min;
            for (int i = 1; i < size; i++)
            {
                table[i] = new Complex(
                    table[i - 1].Real + scale.Real,
                    table[i - 1].Imaginary + scale.Imaginary
                );
            }

            var result = new int[size, size];
            Parallel.For(0, size, row =>
            {
                for (int col = 0; col < size; col++)
                {
                    var history = new Complex[maxCycle];
                    history[0] = new Complex(0, 0);
                    for (int cycle = 1; cycle < maxCycle; cycle++)
                    {
                        history[cycle] = Complex.Pow(history[cycle - 1], 2.0) + new Complex(table[row].Real, table[col].Imaginary);
                        if (limit <= Complex.Abs(history[cycle]))
                        {
                            result[row, col] = (cycle % 255) + 1;
                            break;
                        }
                    }
                };
            });
            return result;
        }
    }
}
