using Core.Models;
using System.IO;

namespace DataSource
{
    /// <summary>
    /// PGM 形式の取り扱い
    /// </summary>
    public class PgmFileModel : IStorageModel
    {
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="dots">描画データ</param>
        public void Save(int[,] dots)
        {
            var maxIm = dots.GetLength(0);
            var maxRe = dots.GetLength(1);
            using (var writer = new StreamWriter("image.pgm"))
            {
                writer.WriteLine("P2");
                writer.WriteLine($"{maxIm} {maxRe}");
                writer.WriteLine("255");
                for (int row = 0; row < maxIm; row++)
                {
                    for (int col = 0; col < maxRe; col++)
                    {
                        writer.Write($"{dots[row, col]}\t");
                    }
                    writer.WriteLine();
                }
            }
        }
    }
}
