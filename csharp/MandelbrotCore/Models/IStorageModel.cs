namespace MandelbrotCore.Models
{
    /// <summary>
    /// ストレージロジックの定義
    /// </summary>
    public interface IStorageModel
    {
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="dots">描画データ</param>
        void Save(int[,] dots);
    }
}
