using System.Numerics;

namespace Executor.Models
{
    /// <summary>
    /// グラフ生成モデルの定義
    /// </summary>
    public interface IGraphModel
    {
        /// <summary>
        /// マンデルブロ集合を生成する
        /// </summary>
        /// <param name="max">最大値</param>
        /// <param name="min">最小値</param>
        /// <param name="size">一辺の大きさ</param>
        /// <param name="limit">閾値</param>
        /// <param name="maxCycle">最大試行回数</param>
        int[,] MakeMandelbrotSet(
            Complex max,
            Complex min,
            int size,
            int limit,
            int maxCycle
        );
    }
}
