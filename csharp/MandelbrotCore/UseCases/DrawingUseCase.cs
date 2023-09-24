using MandelbrotCore.Entities;
using MandelbrotCore.Models;
using System.Diagnostics;

namespace MandelbrotCore.UseCases
{
    /// <summary>
    /// 描画フロー
    /// </summary>
    public class DrawingUseCase
    {
        private IGraphModel graph;
        private IStorageModel storage;


        public DrawingUseCase(
            IGraphModel graph,
            IStorageModel storage
        )
        {
            this.graph = graph;
            this.storage = storage;
        }


        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="conditions">描画パラメータ</param>
        /// <returns>描画データ</returns>
        public int[,] DrawImage(MandelbrotEntity conditions)
        {
            Debug.WriteLine($"Start {nameof(DrawImage)}");
            var watch = Stopwatch.StartNew();
            var result = graph.MakeMandelbrotSet(conditions);
            watch.Stop();
            Debug.WriteLine($"Finish {nameof(DrawImage)}: {watch.ElapsedMilliseconds}[ms]");
            return result;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="dots">描画データ</param>
        public void SaveImage(int[,] dots)
        {
            Debug.WriteLine($"Start {nameof(SaveImage)}");
            var watch = Stopwatch.StartNew();
            storage.Save(dots);
            watch.Stop();
            Debug.WriteLine($"Finish {nameof(SaveImage)}: {watch.ElapsedMilliseconds}[ms]");
        }
    }
}
