# Graffiti
色々なプログラミング言語の試し書きリポジトリ。

## 開発環境の整備メモ
基本的には[Visual Studio Code](https://code.visualstudio.com/) でプロジェクトルートを開き、
実行環境を整備することで、試すことが出来ます。

### 全体のメモ
* [anyenv](https://github.com/anyenv/anyenv)
* [EditorConfig](https://editorconfig.org/)
* `make`

### 各ディレクトリーのメモ
* <details>
    <summary>android/</summary>

    1. [Android Studio](https://developer.android.com/studio) をインストールする
    2. [android/](./android/) を開く
  </details>
* <details>
    <summary>cpp/</summary>

    * macOS, WSL(Ubuntu)
        1. g++ をインストールする
        2. https://code.visualstudio.com/docs/languages/cpp に従ってセットアップする
  </details>
* <details>
    <summary>csharp/</summary>

    * macOS, WSL(Ubuntu)
        1. dotnet をインストールする
        2. https://code.visualstudio.com/docs/languages/csharp に従ってセットアップする
    * Windows
        1. [Visual Studio] をインストールする
        2. [Graffiti.sln] を開く
  </details>
* <details>
    <summary>docker/</summary>

    1. Docker をインストールする
    2. https://code.visualstudio.com/docs/containers/overview に従ってセットアップする
  </details>
* <details>
    <summary>go/</summary>

    1. go をインストールする
        * バージョンは[.go-version](./go-version) を参照してください
    2. https://code.visualstudio.com/docs/languages/go に従ってセットアップする
  </details>
* <details>
    <summary>html/</summary>

    WEB ブラウザで各ファイルを開いてください。
  </details>
* <details>
    <summary>java/</summary>

    1. java をインストールする
        * バージョンは[.java-version](./.java-version) を参照してください
    2. https://code.visualstudio.com/docs/languages/java に従ってセットアップする
  </details>
* <details>
    <summary>javascript/</summary>

    1. Node.js をインストールする
        * バージョンは[.node-version](./.node-version) を参照してください
  </details>
* <details>
    <summary>MSVSIPInstaller/</summary>

    * Windows
        1. [Visual Studio] をインストールする
        2. [Microsoft Visual Studio Installer Projects 2022](https://marketplace.visualstudio.com/items?itemName=VisualStudioClient.MicrosoftVisualStudio2022InstallerProjects) をインストールする
        3. [Graffiti.sln] を開く
  </details>
* <details>
    <summary>php/</summary>

    1. PHP をインストールする
        * バージョンは[.php-version](./.php-version) を参照してください
  </details>
* <details>
    <summary>ruby/</summary>

    1. Ruby をインストールする
        * バージョンは[.ruby-version](./.ruby-version) を参照してください
    2. https://code.visualstudio.com/docs/languages/ruby に従ってセットアップする
  </details>
* <details>
    <summary>shell/</summary>

    shell を実行できる環境で試してください。
  </details>
* <details>
    <summary>swift/</summary>

    1. Swift をインストールする
        * バージョンは[.swift-version](./.swift-version) を参照してください
    2. https://marketplace.visualstudio.com/items?itemName=sswg.swift-lang に従ってセットアップする
  </details>
* <details>
    <summary>typescript/</summary>

    1. Node.js をインストールする
        * バージョンは[.node-version](./.node-version) を参照してください
    2. `npm ci` を実行する
  </details>
* <details>
    <summary>xcode/</summary>

    * macOS
        1. [Xcode](https://developer.apple.com/documentation/xcode) をインストールする
        2. [xcode/](./xcode/) 配下の各プロジェクトを開く
  </details>



## コンテンツ一覧
パス | 起動方法 | 概要
--- | --- | ---
[cpp/mandelbrot/](./cpp/mandelbrot/) | `make cpp-mandelbrot` | C++ でマンデルブロ集合の算出
[csharp/](./csharp/) | ([Visual Studio] で`Graffiti.sln` を開く) | C# の試し書き
[docker/gulp/](./docker/gulp/) | `./docker/gulp/docker-compose.yml` を`Compose up` する | Docker を利用したGulp タスクの実行
[docker/ng-multi.sh](./docker/ng-multi.sh) | `sh ./docker/ng-multi.sh` | Docker を利用して、Ionic + Angular マルチプロジェクト構成の生成
[go/mandelbrot.go](./go/mandelbrot.go) | `go run ./go/mandelbrot.go` | Go でマンデルブロ集合の算出
[html/](./html/) | (ディレクトリ内を確認してください) | HTML 関連サンプル
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



## 備考



[Graffiti.sln]: ./Graffiti.sln
[Visual Studio]: https://visualstudio.microsoft.com/
