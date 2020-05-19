using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LibraryStandard
{
    /// <summary>
    /// JSON.NET の実装集
    /// </summary>
    public class JsonNETRecipe
    {
        private List<JObject> AddJObjectPropsData => new List<JObject>
        {
            new JObject{ ["key1"] = "value1" },
            new JObject{ ["key2"] = "value2" },
            new JObject{ ["key3"] = "value3" }
        };


        /// <summary>
        /// JObject に対して、動的にプロパティ追加する例
        /// </summary>
        public void AddJObjectProps()
        {
            // データ追加するクエリ
            // 即時評価し、値を確定させる
            var query = AddJObjectPropsData.Select(item =>
            {
                item.Add("isSelected", true);
                return item;
            }).ToList();

            // データ評価
            for (int i = 1; i <= 2; i++)
            {
                foreach (var item in query)
                {
                    Debug.WriteLine($"{i}回目: {item}");
                }
            }
        }

        /// <summary>
        /// JObject に対して、動的にプロパティ追加し、エラーになる例
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public void AddJObjectPropsError()
        {
            // データ追加するクエリ
            var query = AddJObjectPropsData.Select(item =>
            {
                item.Add("isSelected", true);
                return item;
            });

            // データ評価
            for (int i = 1; i <= 2; i++)
            {
                foreach (var item in query)
                {
                    Debug.WriteLine($"{i}回目: {item}");
                }
            }
        }
    }
}
