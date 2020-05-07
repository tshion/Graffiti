using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var jsonList1 = new List<JObject>
            {
                new JObject{ ["key1"] = "value1" },
                new JObject{ ["key2"] = "value2" },
                new JObject{ ["key3"] = "value3" }
            };

            var count = 1;
            try
            {
                // データ追加するクエリ
                var errorQuery = jsonList1.Select(item =>
                {
                    item.Add("isSelected", true);
                    return item;
                });

                // １回目の評価はOK
                Console.WriteLine($"{count} 回目の評価（エラーケース）");
                foreach (var item in errorQuery)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
                count++;

                // ２回目の評価は例外
                Console.WriteLine($"{count} 回目の評価（エラーケース）");
                foreach (var item in errorQuery)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"{count} 回目の評価でエラーが発生しました");
                Console.WriteLine($"{ex}{Environment.NewLine}");
            }



            // 成功するパターン
            var jsonList2 = new List<JObject>
            {
                new JObject{ ["key1"] = "value1" },
                new JObject{ ["key2"] = "value2" },
                new JObject{ ["key3"] = "value3" }
            };

            // 即時評価し、値を確定させる
            var successQuery = jsonList2.Select(item =>
            {
                item.Add("isSelected", true);
                return item;
            })
            .ToList();

            // 試行回数のリセット
            count = 1;

            // １回目の評価はOK
            Console.WriteLine($"{count} 回目の評価（正常）");
            foreach (var item in successQuery)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            count++;

            // ２回目の評価もOK
            Console.WriteLine($"{count} 回目の評価（正常）");
            foreach (var item in successQuery)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();



            // 終了待機
            Console.WriteLine($"{Environment.NewLine}終了するにはなにかキー入力してください");
            Console.ReadKey(true);
        }
    }
}
