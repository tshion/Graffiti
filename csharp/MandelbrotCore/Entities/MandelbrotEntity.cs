namespace MandelbrotCore.Entities
{
    /// <summary>
    /// マンデルブロ集合を描画する際のパラメータ
    /// </summary>
    public class MandelbrotEntity
    {
        /// <summary>
        /// 発散判定のための閾値
        /// </summary>
        public int DivergenceBorder { get; set; }

        /// <summary>
        /// 最大計算回数
        /// </summary>
        public int GiveUpBorder { get; set; }

        /// <summary>
        /// 描画範囲(虚数)
        /// </summary>
        public double[] RangeImage { get; set; }

        /// <summary>
        /// 描画範囲(実数)
        /// </summary>
        public double[] RangeReal { get; set; }
    }
}
