# RxJS
パス | 練習したいこと
--- | ---
scene1 | endpoint1 を叩いた後にendpoint2 を叩くのを順番にこなしたい
scene2 | 認証トークン周り



## シナリオ１について
ルートで`node ./javascript/rxjs-server.js` を実行した状態で、アプリから下記のシナリオが順番にこなされるかを検証する。

1. endpoint1.json を叩く
2. endpoint1.json の内容を保存する
3. 手順2 の内容を読み込み、次のURL のid を決定する
4. ```endpoint2/:id.json``` を叩く

※簡易的なテストは"[scene1.rest](./src/app/scene1/scene1.rest)" で記述しています。

## シナリオ２について
ルートで`node ./javascript/rxjs-server.js` を実行した状態で、アプリから下記のシナリオが順番にこなされるかを検証する。

1. ```/token``` をPOST で叩き、アクセストークンを保存する
2. 手順１で得たトークンを使って、```/secret1``` を叩く
3. 手順１で得たトークンを使って、```/secret2``` を叩く
4. 認証エラーになるので、```/token``` にPUT してトークンをリフレッシュする
5. 手順４で得たトークンを使って、```/secret2``` を叩く

※簡易的なテストは"[scene2.rest](./src/app/scene2/scene2.rest)" で記述しています。
