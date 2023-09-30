# @graffiti/vscode-extension-ui
VSCode 拡張機能のWebView に表示するUI の実装。

## 備考
* Lazy Loading は、VSCode WebView のセキュリティの都合で利用できない
    * 通常のLoading ではバンドルサイズが肥大化し、警告が出てしまうので、それを抑制している
