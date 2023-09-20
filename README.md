# Graffiti
色々な言語の落書きリポジトリ。



## 開発環境
本リポジトリはマルチプロジェクト構成になっており、
プロジェクトルートを下記IDE で開いて作業することを想定している。

* [Android Studio](https://developer.android.com/studio)
* [Visual Studio](https://visualstudio.microsoft.com/)
* **[Visual Studio Code](https://code.visualstudio.com/)**
* [Xcode](https://developer.apple.com/documentation/xcode)

また下記も併用している。

* [anyenv](https://github.com/anyenv/anyenv)
* [EditorConfig](https://editorconfig.org/)



## プロジェクト構成
パス | 起動方法 | 内容
--- | --- | ---
[cpp/mandelbrot/](./cpp/mandelbrot/) | `make cpp-mandelbrot` | C++ でマンデルブロ集合の算出
[csharp/](./csharp/) | (Visual Studio でGraffiti.sln を開いてください) | C# 関連の試し書き
[docker/gulp/](./docker/gulp/) | `./docker/gulp/docker-compose.yml` を`Compose up` する | Docker を利用したGulp タスクの実行
[docker/ng-multi.sh](./docker/ng-multi.sh) | `sh ./docker/ng-multi.sh` | Docker を利用して、Ionic + Angular マルチプロジェクト構成の生成
[html/](./html/) | (ディレクトリ内を確認してください) | HTML 関連サンプル
[go/mandelbrot.go](./go/mandelbrot.go) | `go run ./go/mandelbrot.go` | Go でマンデルブロ集合の算出
[java/mandelbrot](./java/mandelbrot/) | `make java-mandelbrot` | Java でマンデルブロ集合の算出
[javascript/rxjs-server.js](./javascript/rxjs-server.js) | `node ./javascript/rxjs-server.js` | RxJS サンプル用のサーバー起動
[php/hello.php](./php/hello.php) | `php ./php/hello.php` | PHP のHello World
[ruby/hello.rb](./ruby/hello.rb) | `ruby ./ruby/hello.rb` | Ruby のHello World
[ruby/yaml_to_json.rb](./ruby/yaml_to_json.rb) | `ruby ./ruby/yaml_to_json.rb` | Ruby でYaml からJSON 出力する
[shell/ngMulti-capacitor.sh](./shell/ngMulti-capacitor.sh) | `sh ./shell/ngMulti-capacitor.sh` | Ionic + Angular マルチプロジェクト構成の生成シェル
[shell/ngSingle-capacitor.sh](./shell/ngSingle-capacitor.sh) | `sh ./shell/ngSingle-capacitor.sh` | Ionic プロジェクトの生成シェル
[typescript/rxjs/](./typescript/rxjs/) | package.json から`start` を実行する | RxJS の試し書き
[typescript/vscode-web-extension/](./typescript/vscode-web-extension/) | VSCode の起動タスク`VSC WE: Run` を実行する | VSCode の自作Web 拡張機能の試し書き
