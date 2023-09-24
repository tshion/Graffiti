using MandelbrotCore.Entities;
using MandelbrotCore.Models;
using System.Numerics;

namespace MandelbrotData
{
    /// <summary>
    /// グラフ生成モデル(並列処理版)
    /// </summary>
    public class GraphParallelModel : IGraphModel
    {
        /// <summary>
        /// マンデルブロ集合を生成する
        /// </summary>
        /// <param name="conditions">描画条件</param>
        public int[,] MakeMandelbrotSet(MandelbrotEntity conditions)
        {
            if (!conditions.RangeImage.Any() || !conditions.RangeReal.Any())
            {
                return new int[0, 0];
            }

            var result = new int[conditions.RangeImage.Length, conditions.RangeReal.Length];
            Parallel.For(0, conditions.RangeImage.Length, iIm =>
            {
                for (var iRe = 0; iRe < conditions.RangeReal.Length; iRe++)
                {
                    var constant = new Complex(
                        conditions.RangeReal[iRe],
                        conditions.RangeImage[iIm]
                    );

                    var history = new Complex[conditions.GiveUpBorder];
                    history[0] = new Complex(0, 0);
                    for (var trial = 1; trial < conditions.DivergenceBorder; trial++)
                    {
                        history[trial] = Complex.Pow(history[trial - 1], 2f) + constant;
                        if (conditions.DivergenceBorder <= Complex.Abs(history[trial]))
                        {
                            result[iIm, iRe] = (trial % 255) + 1;
                            break;
                        }
                    }
                }
            });
            return result;
        }
    }
}
