using MandelbrotCore.Entities;

namespace MandelbrotCore.Models
{
    /// <summary>
    /// グラフ生成モデルの定義
    /// </summary>
    public interface IGraphModel
    {
        /// <summary>
        /// マンデルブロ集合を生成する
        /// </summary>
        /// <param name="conditions">描画条件</param>
        int[,] MakeMandelbrotSet(MandelbrotEntity conditions);
    }
}
