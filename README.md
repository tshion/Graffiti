# MandelbrotSetCreator
色々な言語で、ただひたすらに[マンデルブロ集合][wiki_mandelbrot]を描くリポジトリ。

言語 | 開発環境用Docker | コード整形 | デバッグ
--- | --- | :---: | :---:
C++ | [gcc][dh_gcc] | × | ×
Swift | [tshion/swift-repl][dh_swift_repl] | × | ×



## 開発作業
### 必要なもの
* Docker Desktop
* Visual Studio Code
    * [Docker][vscode_docker]
    * [Remote Development][vscode_remote]

### 基本的な流れ
1. Docker Desktop を起動する
2. Visual Studio Code のタスク実行し、作業対象の言語イメージを起動する
3. Visual Studio Code から手順２で起動したコンテナにリモート接続する



## 関連リンク
* Docker イメージ
    * [gcc][dh_gcc]
    * [tshion/swift-repl][dh_swift_repl]
* Visual Studio Code 拡張機能
    * [Docker][vscode_docker]
    * [Remote Development][vscode_remote]
* [マンデルブロ集合 - Wikipedia][wiki_mandelbrot] (2019/12/04)



[dh_gcc]: https://hub.docker.com/_/gcc
[dh_swift_repl]: https://hub.docker.com/r/tshion/swift-repl

[vscode_docker]: https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-docker
[vscode_remote]: https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.vscode-remote-extensionpack

[wiki_mandelbrot]: https://ja.wikipedia.org/wiki/%E3%83%9E%E3%83%B3%E3%83%87%E3%83%AB%E3%83%96%E3%83%AD%E9%9B%86%E5%90%88
