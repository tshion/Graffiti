# Graffiti
色々なプログラミング言語の試し書きリポジトリ。

## 開発環境の整備メモ
基本的には[Visual Studio Code] でプロジェクトルートを開き、実行環境を整備することで、試すことが出来ます。

### 全体の整備メモ
* [anyenv](https://github.com/anyenv/anyenv)
* [EditorConfig](https://editorconfig.org/)
* [git](https://git-scm.com/)
* [make](https://www.gnu.org/software/make/manual/make.html)
* [Visual Studio Code]

### 各ディレクトリーの整備メモ
* <details>
    <summary>android/</summary>

    1. (任意) [JetBrains Toolbox App](https://www.jetbrains.com/ja-jp/toolbox-app/) をインストールする
    2. [Android Studio] をインストールする
        * 手順1 を実行した場合は、そのツールからインストールする
  </details>
* <details>
    <summary>c/</summary>

    * macOS, WSL(Ubuntu)
        1. gcc をインストールする
        2. https://code.visualstudio.com/docs/languages/cpp に従ってセットアップする
    * Windows
        1. [Visual Studio] をインストールする
  </details>
* <details>
    <summary>cpp/</summary>

    * Docker
        1. VSCode タスク`C++: edit in docker` を実行する
    * macOS, WSL(Ubuntu)
        1. g++ をインストールする
        2. https://code.visualstudio.com/docs/languages/cpp に従ってセットアップする
    * Windows
        1. [Visual Studio] をインストールする
  </details>
* <details>
    <summary>csharp/</summary>

    * 全般
        1. [dotnet](https://dotnet.microsoft.com/ja-jp/) をインストールする
        2. https://code.visualstudio.com/docs/languages/csharp に従ってセットアップする
    * Windows
        1. [Visual Studio] をインストールする
  </details>
* <details>
    <summary>docker/</summary>

    1. [Docker](https://dotnet.microsoft.com/ja-jp/) をインストールする
    2. https://code.visualstudio.com/docs/containers/overview に従ってセットアップする
  </details>
* <details>
    <summary>go/</summary>

    * 全般
        1. (任意) [goenv](https://github.com/go-nv/goenv) をインストールする
        2. [Go 言語](https://go.dev/) をインストールする
            * バージョンは[.go-version](./go-version) を参照してください
        3. https://code.visualstudio.com/docs/languages/go に従ってセットアップする
    * Docker
        1. VSCode タスク`Go: edit in docker` を実行する
  </details>
* <details>
    <summary>html/</summary>

    WEB ブラウザをインストールする。
  </details>
* <details>
    <summary>java/</summary>

    1. (任意) [jenv](https://github.com/jenv/jenv) をインストールする
    2. [java](https://www.java.com/ja/) をインストールする
        * バージョンは[.java-version](./.java-version) を参照してください
        * (任意) jenv で入手したものを登録し、切り替える
    3. https://code.visualstudio.com/docs/languages/java に従ってセットアップする
  </details>
* <details>
    <summary>javascript/</summary>

    1. (任意) [nodenv] をインストールする
    2. [Node.js] をインストールする
        * バージョンは[.node-version](./.node-version) を参照してください
    3. `npm ci` を実行する
  </details>
* <details>
    <summary>MSVSIPInstaller/</summary>

    * Windows
        1. [Visual Studio] をインストールする
        2. [Microsoft Visual Studio Installer Projects 2022](https://marketplace.visualstudio.com/items?itemName=VisualStudioClient.MicrosoftVisualStudio2022InstallerProjects) をインストールする
  </details>
* <details>
    <summary>php/</summary>

    1. (任意) [phpenv](https://github.com/phpenv/phpenv) をインストールする
    2. [PHP](https://www.php.net/) をインストールする
        * バージョンは[.php-version](./.php-version) を参照してください
  </details>
* <details>
    <summary>ruby/</summary>

    * 全般
        1. (任意) [rbnv](https://github.com/rbenv/rbenv) をインストールする
        2. [Ruby](https://www.ruby-lang.org/ja/) をインストールする
            * バージョンは[.ruby-version](./.ruby-version) を参照してください
        3. https://code.visualstudio.com/docs/languages/ruby に従ってセットアップする
    * Docker
        1. VSCode タスク`Ruby: edit in docker` を実行する
  </details>
* <details>
    <summary>shell/</summary>

    shell を実行できる環境で試してください。
  </details>
* <details>
    <summary>swift/</summary>

    1. [Swift](https://www.swift.org/) をインストールする
        * バージョンは[.swift-version](./.swift-version) を参照してください
    2. https://marketplace.visualstudio.com/items?itemName=sswg.swift-lang に従ってセットアップする
  </details>
* <details>
    <summary>typescript/</summary>

    1. (任意) [nodenv] をインストールする
    2. [Node.js] をインストールする
        * バージョンは[.node-version](./.node-version) を参照してください
    3. `npm ci` を実行する
  </details>
* <details>
    <summary>xcode/</summary>

    * macOS
        1. [Xcode](https://developer.apple.com/documentation/xcode) をインストールする
  </details>



## コンテンツ一覧
パス | 起動方法 | 概要
--- | --- | ---
[android/](./android/) | ([Android Studio] で`android/` を開く) | Android 関連の試し書き
[c/](./c/) | (ディレクトリ内を確認してください) | C 言語の試し書き
[cpp/](./cpp/) | (ディレクトリ内を確認してください) | C++ の試し書き
[csharp/](./csharp/) | ([Visual Studio] で`Graffiti.sln` を開く) | C# の試し書き
[docker/gulp/](./docker/gulp/) | `./docker/gulp/docker-compose.yml` を`Compose up` する | Docker を利用したGulp タスクの実行
[docker/ng-multi.sh](./docker/ng-multi.sh) | `sh ./docker/ng-multi.sh` | Docker を利用して、Ionic + Angular マルチプロジェクト構成の生成
[go/mandelbrot.go](./go/mandelbrot.go) | `go run ./go/mandelbrot.go` | Go でマンデルブロ集合の算出
[html/](./html/) | (ディレクトリ内を確認してください) | HTML 関連サンプル
[java/mandelbrot](./java/mandelbrot/) | `make java/run-mandelbrot` | Java でマンデルブロ集合の算出
[javascript/rxjs-server.js](./javascript/rxjs-server.js) | `node ./javascript/rxjs-server.js` | RxJS サンプル用のサーバー起動
[MSVSIPInstaller/](./MSVSIPInstaller/) | (VS でプロジェクトを右クリックしてビルド → インストールを実行する) | Microsoft Visual Studio Installer Projects の実装サンプル
[php/hello.php](./php/hello.php) | `php ./php/hello.php` | PHP のHello World
[ruby/hello.rb](./ruby/hello.rb) | `ruby ./ruby/hello.rb` | Ruby のHello World
[ruby/yaml_to_json.rb](./ruby/yaml_to_json.rb) | `ruby ./ruby/yaml_to_json.rb` | Ruby でYaml からJSON 出力する
[shell/ngMulti-capacitor.sh](./shell/ngMulti-capacitor.sh) | `sh ./shell/ngMulti-capacitor.sh` | Ionic + Angular マルチプロジェクト構成の生成シェル
[shell/ngSingle-capacitor.sh](./shell/ngSingle-capacitor.sh) | `sh ./shell/ngSingle-capacitor.sh` | Ionic プロジェクトの生成シェル
[swift/FileIOs/](./swift/FileIOs/) | VSCode タスク`Debug FileIOs` を実行する | Swift でファイル入出力の試し書き
[swift/HelloWorld/](./swift/HelloWorld/) | `swift test` | Swift でユニットテストの試し書き
[swift/Mandelbrot/](./swift/Mandelbrot/) | VSCode タスク`Debug Mandelbrot` を実行する | Swift でマンデルブロ集合の算出
[swift/UrlSession/](./swift/UrlSession/) | VSCode タスク`Debug UrlSession` を実行する | Swift で通信処理の試し書き
[typescript/rxjs/](./typescript/rxjs/) | package.json から`start` を実行する | RxJS の試し書き
[typescript/vscode-extension/](./typescript/vscode-extension/) | VSCode 起動タスク`Run: vscode-extension` を実行する | VSCode 拡張機能の実装サンプル
[typescript/vscode-web-extension/](./typescript/vscode-web-extension/) | VSCode の起動タスク`VSC WE: Run` を実行する | VSCode の自作Web 拡張機能の試し書き
[xcode/MySavingReminders/](./xcode/MySavingReminders/) | `make xcode-init-my-saving-reminders` 実行後に、Xcode で該当パスを開く | リマインダーを行うiOS アプリの試し書き



## 備考
### お題メモ
* [Hello World](./docs/hello_world.md)
* [マンデルブロ集合の算出](./docs/mandelbrot.md)

### 注意事項
* Docker コンテナ内で、ファイル生成した際にパーミッションの取り扱いが変わる可能性があります
    * ディレクトリー削除できない場合は、コマンドで対応してください



[Android Studio]: https://developer.android.com/studio
[Node.js]: https://nodejs.org/ja
[nodenv]: https://github.com/nodenv/nodenv
[Visual Studio]: https://visualstudio.microsoft.com/
[Visual Studio Code]: https://code.visualstudio.com/
