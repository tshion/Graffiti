# MSRecipe
Microsoft 関連技術、主にC# 関連の落書き＆レシピ集

プロジェクト | VS | VS4Mac | VSCode | 概要
--- | :---: | :---: | :---: | ---
[BlazorWasmModule](./BlazorWasmModule) | 〇 | ? | ? | WebAssembly を得るためのプロジェクト
[ConsoleCore](./ConsoleCore) | ○ | ○ | ? | .NET Core のConsole Application Project
[ConsoleNET](./ConsoleNET) | ○ | × | ? | .NET Framework のConsole Application Project
[LibraryStandard] | × | × | × | .NET Standard のライブラリプロジェクト
[MSVSIPAction](./MSVSIPAction) | ○ | × | ? | [MSVSIPInstaller] のカスタムアクション定義
[MSVSIPInstaller] | ○ | × | ? | [Microsoft Visual Studio Installer Projects] を利用したインストーラプロジェクト
[NUnitLibraryStandard](./NUnitLibraryStandard) | ○ | ? | ? | [LibraryStandard] のテストプロジェクト

* VS 欄はVisual Studio で実行できるかどうか
* VS4Mac 欄はVisual Studio for Mac で実行できるかどうか
* VSCode 欄はVisual Studio Code で実行できるかどうか


## メモ
* インストーラカスタムアクションは複数クラスで定義できるけど、処理の解決順は不明


## Links
### 参考文献
* [Json.NET - Newtonsoft]
* [Microsoft Visual Studio Installer Projects]


[Json.NET - Newtonsoft]: https://www.newtonsoft.com/json
[LibraryStandard]: ./LibraryStandard
[Microsoft Visual Studio Installer Projects]: https://marketplace.visualstudio.com/items?itemName=VisualStudioClient.MicrosoftVisualStudio2017InstallerProjects
[MSVSIPInstaller]: ./MSVSIPInstaller
