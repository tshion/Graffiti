# Graffiti
色々なプログラミング言語の試し書きリポジトリ。

基本的には[Visual Studio Code](https://code.visualstudio.com/) でプロジェクトルートを開き、
実行環境を整備することで、試すことが出来ます。
詳細は各ディレクトリーを確認してください。

* [android/](./android/) → Android 関連の試し書き
    * [Android Studio](https://developer.android.com/studio) で[android/](./android/) を開いてください
* [cpp/](./cpp/) → C++ の試し書き
* [csharp/](./csharp/) → C# の試し書き
    * (オプション) [Visual Studio](https://visualstudio.microsoft.com/) で[Graffiti.sln](./Graffiti.sln) を開いてください
* [docker/](./docker/) → Docker 関連の試し書き
* [go/](./go/) → Go 言語の試し書き
* [html/](./html/) → HTML の試し書き
* [java/](./java/) → Java の試し書き
* [javascript/](./javascript/) → JavaScript の試し書き
* [MSVSIPInstaller/](./MSVSIPInstaller/) → Microsoft Visual Studio Installer Projects の実装サンプル
    * [Visual Studio](https://visualstudio.microsoft.com/) で[Graffiti.sln](./Graffiti.sln) を開いてください
* [php/](./php/) → PHP の試し書き
* [ruby/](./ruby/) → Ruby の試し書き
* [shell/](./shell/) → Shell の試し書き
* [swift/](./swift/) → Swift の試し書き
* [typescript/](./typescript/) → TypeScript の試し書き
* [xcode/](./xcode/) → Xcode 関連の試し書き
    * [Xcode](https://developer.apple.com/documentation/xcode) で、各プロジェクトを開いてください


## 取り扱いコンテンツの一覧

## 備考









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
[html/](./html/) | (ディレクトリ内を確認してください) | HTML 関連サンプル
[go/mandelbrot.go](./go/mandelbrot.go) | `go run ./go/mandelbrot.go` | Go でマンデルブロ集合の算出
[java/mandelbrot](./java/mandelbrot/) | `make java-mandelbrot` | Java でマンデルブロ集合の算出
[javascript/rxjs-server.js](./javascript/rxjs-server.js) | `node ./javascript/rxjs-server.js` | RxJS サンプル用のサーバー起動
[MSVSIPInstaller/](./MSVSIPInstaller/) | (VS でプロジェクトを右クリックしてビルド → インストールを実行する) | Microsoft Visual Studio Installer Projects の実装サンプル
[php/hello.php](./php/hello.php) | `php ./php/hello.php` | PHP のHello World
[ruby/hello.rb](./ruby/hello.rb) | `ruby ./ruby/hello.rb` | Ruby のHello World
[ruby/yaml_to_json.rb](./ruby/yaml_to_json.rb) | `ruby ./ruby/yaml_to_json.rb` | Ruby でYaml からJSON 出力する
[shell/ngMulti-capacitor.sh](./shell/ngMulti-capacitor.sh) | `sh ./shell/ngMulti-capacitor.sh` | Ionic + Angular マルチプロジェクト構成の生成シェル
[shell/ngSingle-capacitor.sh](./shell/ngSingle-capacitor.sh) | `sh ./shell/ngSingle-capacitor.sh` | Ionic プロジェクトの生成シェル
[swift/FileIOs/](./swift/FileIOs/) | `swift build` 後に、`.build/debug/FileIOs` を実行する | Swift でファイル入出力の試し書き
[swift/HelloWorld/](./swift/HelloWorld/) | `swift test` | Swift でユニットテストの試し書き
[swift/Mandelbrot/](./swift/Mandelbrot/) | `swift build` 後に、`.build/debug/Mandelbrot` を実行する | Swift でマンデルブロ集合の算出
[swift/UrlSession/](./swift/UrlSession/) | `swift build` 後に、`.build/debug/UrlSession` を実行する | Swift で通信処理の試し書き
[typescript/rxjs/](./typescript/rxjs/) | package.json から`start` を実行する | RxJS の試し書き
[typescript/vscode-web-extension/](./typescript/vscode-web-extension/) | VSCode の起動タスク`VSC WE: Run` を実行する | VSCode の自作Web 拡張機能の試し書き
[xcode/MySavingReminders/](./xcode/MySavingReminders/) | `make xcode-init-my-saving-reminders` 実行後に、Xcode で該当パスを開く | リマインダーを行うiOS アプリの試し書き
