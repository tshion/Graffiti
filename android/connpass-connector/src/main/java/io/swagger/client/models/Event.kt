/**
 * connpass API
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: (see docs)
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */
package io.swagger.client.models


/**
 * 
 * @param eventId イベントID
 * @param title タイトル
 * @param &#x60;catch&#x60; キャッチ
 * @param description 概要(HTML形式)
 * @param eventUrl connpass.com 上のURL
 * @param hashTag Twitterのハッシュタグ
 * @param startedAt イベント開催日時 (ISO-8601形式)
 * @param endedAt イベント開催日時 (ISO-8601形式)
 * @param limit 定員
 * @param eventType イベント参加タイプ
 * @param series 検索結果のイベントリスト
 * @param address 開催場所
 * @param place 開催会場
 * @param lat 開催会場の緯度
 * @param lon 開催会場の経度
 * @param ownerId 管理者のID
 * @param ownerNickname 管理者のニックネーム
 * @param ownerDisplayName 管理者の表示名
 * @param accepted 参加者数
 * @param waiting 補欠者数
 * @param updatedAt 更新日時 (ISO-8601形式)
 */
data class Event (

    /* イベントID */
    val eventId: kotlin.Int? = null,
    /* タイトル */
    val title: kotlin.String? = null,
    /* キャッチ */
    val `catch`: kotlin.String? = null,
    /* 概要(HTML形式) */
    val description: kotlin.String? = null,
    /* connpass.com 上のURL */
    val eventUrl: kotlin.String? = null,
    /* Twitterのハッシュタグ */
    val hashTag: kotlin.String? = null,
    /* イベント開催日時 (ISO-8601形式) */
    val startedAt: java.time.LocalDateTime? = null,
    /* イベント開催日時 (ISO-8601形式) */
    val endedAt: java.time.LocalDateTime? = null,
    /* 定員 */
    val limit: kotlin.Int? = null,
    /* イベント参加タイプ */
    val eventType: kotlin.String? = null,
    /* 検索結果のイベントリスト */
    val series: OneOfEventSeries? = null,
    /* 開催場所 */
    val address: kotlin.String? = null,
    /* 開催会場 */
    val place: kotlin.String? = null,
    /* 開催会場の緯度 */
    val lat: kotlin.Double? = null,
    /* 開催会場の経度 */
    val lon: kotlin.Double? = null,
    /* 管理者のID */
    val ownerId: kotlin.Int? = null,
    /* 管理者のニックネーム */
    val ownerNickname: kotlin.String? = null,
    /* 管理者の表示名 */
    val ownerDisplayName: kotlin.String? = null,
    /* 参加者数 */
    val accepted: kotlin.Int? = null,
    /* 補欠者数 */
    val waiting: kotlin.Int? = null,
    /* 更新日時 (ISO-8601形式) */
    val updatedAt: java.time.LocalDateTime? = null
) {
}