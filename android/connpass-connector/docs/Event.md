# Event

## Properties
Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**eventId** | [**kotlin.Int**](.md) | イベントID |  [optional]
**title** | [**kotlin.String**](.md) | タイトル |  [optional]
**&#x60;catch&#x60;** | [**kotlin.String**](.md) | キャッチ |  [optional]
**description** | [**kotlin.String**](.md) | 概要(HTML形式) |  [optional]
**eventUrl** | [**kotlin.String**](.md) | connpass.com 上のURL |  [optional]
**hashTag** | [**kotlin.String**](.md) | Twitterのハッシュタグ |  [optional]
**startedAt** | [**java.time.LocalDateTime**](java.time.LocalDateTime.md) | イベント開催日時 (ISO-8601形式) |  [optional]
**endedAt** | [**java.time.LocalDateTime**](java.time.LocalDateTime.md) | イベント開催日時 (ISO-8601形式) |  [optional]
**limit** | [**kotlin.Int**](.md) | 定員 |  [optional]
**eventType** | [**kotlin.String**](.md) | イベント参加タイプ |  [optional]
**series** | [**OneOfEventSeries**](OneOfEventSeries.md) | 検索結果のイベントリスト |  [optional]
**address** | [**kotlin.String**](.md) | 開催場所 |  [optional]
**place** | [**kotlin.String**](.md) | 開催会場 |  [optional]
**lat** | [**kotlin.Double**](.md) | 開催会場の緯度 |  [optional]
**lon** | [**kotlin.Double**](.md) | 開催会場の経度 |  [optional]
**ownerId** | [**kotlin.Int**](.md) | 管理者のID |  [optional]
**ownerNickname** | [**kotlin.String**](.md) | 管理者のニックネーム |  [optional]
**ownerDisplayName** | [**kotlin.String**](.md) | 管理者の表示名 |  [optional]
**accepted** | [**kotlin.Int**](.md) | 参加者数 |  [optional]
**waiting** | [**kotlin.Int**](.md) | 補欠者数 |  [optional]
**updatedAt** | [**java.time.LocalDateTime**](java.time.LocalDateTime.md) | 更新日時 (ISO-8601形式) |  [optional]
