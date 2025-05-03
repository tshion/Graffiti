> [!WARNING]
> TypeScript 7 でGo 言語による実装に差し代わるようなので、このAPI は使えなくなるかもしれません
> https://github.com/microsoft/typescript-go/issues/516

# compiler
TypeScript Compiler API の試し書き。
お題として下記の流れで使えるものを作ってみる。

1. TypeScript でデータ構造を記述する
1. Compiler API で解析してAST を生成する
1. AST から各種実装へ変換する
    * デフォルトのデータ -> JSON
    * 編集UI -> HTML

## 取り扱う書式
以下のようなデータを取り扱う。

* 色
* 数値
    * 整数
    * 小数
* 定数
* 文字列
* 論理値

``` typescript
/**
 * データ構造のサンプル
 */
class DataSample {

    /** 色 */
    a1: Color = "#FFFFFF";

    /** 色 */
    a2: Color = "#99FFFFFF";

    /** 整数 */
    b1: Int = 1;

    /** 小数 */
    c1: Double = 1.0;

    /** 緯度 */
    lat: Latitude = 35.658099;

    /** 経度 */
    lon: Longitude = 139.741357;

    /** 定数(整数) */
    d1: 0 | 1 | 2 = 1;

    /** 定数(文字列) */
    d2: "North" | "East" | "South" | "West" = "East";

    /** 文字列 */
    e1: string = "e1 text";

    /** 論理値 */
    f1: boolean = false;
}
```
