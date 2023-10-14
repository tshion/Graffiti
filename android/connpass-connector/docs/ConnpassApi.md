# ConnpassApi

All URIs are relative to *https://connpass.com/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**v1EventGet**](ConnpassApi.md#v1EventGet) | **GET** /v1/event | イベントサーチAPI

<a name="v1EventGet"></a>
# **v1EventGet**
> GetEventResponse v1EventGet(eventId, keyword, keywordOr, ym, ymd, nickname, ownerNickname, seriesId, start, order, count, format)

イベントサーチAPI

### Example
```kotlin
// Import classes:
//import io.swagger.client.infrastructure.*
//import io.swagger.client.models.*;

val apiInstance = ConnpassApi()
val eventId : kotlin.Array<kotlin.Int> =  // kotlin.Array<kotlin.Int> | イベントID
val keyword : kotlin.Array<kotlin.String> =  // kotlin.Array<kotlin.String> | キーワード (AND)
val keywordOr : kotlin.Array<kotlin.String> =  // kotlin.Array<kotlin.String> | キーワード (OR)
val ym : kotlin.Array<kotlin.String> =  // kotlin.Array<kotlin.String> | イベント開催年月
val ymd : kotlin.Array<kotlin.String> =  // kotlin.Array<kotlin.String> | イベント開催年月日
val nickname : kotlin.Array<kotlin.String> =  // kotlin.Array<kotlin.String> | 参加者のニックネーム
val ownerNickname : kotlin.Array<kotlin.String> =  // kotlin.Array<kotlin.String> | 管理者のニックネーム
val seriesId : kotlin.Array<kotlin.Int> =  // kotlin.Array<kotlin.Int> | グループID
val start : kotlin.Int = 56 // kotlin.Int | 検索の開始位置
val order : java.math.BigDecimal =  // java.math.BigDecimal | 検索結果の表示順
val count : kotlin.Int = 56 // kotlin.Int | 取得件数
val format : kotlin.String = format_example // kotlin.String | レスポンス形式
try {
    val result : GetEventResponse = apiInstance.v1EventGet(eventId, keyword, keywordOr, ym, ymd, nickname, ownerNickname, seriesId, start, order, count, format)
    println(result)
} catch (e: ClientException) {
    println("4xx response calling ConnpassApi#v1EventGet")
    e.printStackTrace()
} catch (e: ServerException) {
    println("5xx response calling ConnpassApi#v1EventGet")
    e.printStackTrace()
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **eventId** | [**kotlin.Array&lt;kotlin.Int&gt;**](kotlin.Int.md)| イベントID | [optional]
 **keyword** | [**kotlin.Array&lt;kotlin.String&gt;**](kotlin.String.md)| キーワード (AND) | [optional]
 **keywordOr** | [**kotlin.Array&lt;kotlin.String&gt;**](kotlin.String.md)| キーワード (OR) | [optional]
 **ym** | [**kotlin.Array&lt;kotlin.String&gt;**](kotlin.String.md)| イベント開催年月 | [optional]
 **ymd** | [**kotlin.Array&lt;kotlin.String&gt;**](kotlin.String.md)| イベント開催年月日 | [optional]
 **nickname** | [**kotlin.Array&lt;kotlin.String&gt;**](kotlin.String.md)| 参加者のニックネーム | [optional]
 **ownerNickname** | [**kotlin.Array&lt;kotlin.String&gt;**](kotlin.String.md)| 管理者のニックネーム | [optional]
 **seriesId** | [**kotlin.Array&lt;kotlin.Int&gt;**](kotlin.Int.md)| グループID | [optional]
 **start** | **kotlin.Int**| 検索の開始位置 | [optional] [default to 1]
 **order** | [**java.math.BigDecimal**](.md)| 検索結果の表示順 | [optional] [default to 1]
 **count** | **kotlin.Int**| 取得件数 | [optional] [default to 10] [enum: 1, 100]
 **format** | **kotlin.String**| レスポンス形式 | [optional] [default to json]

### Return type

[**GetEventResponse**](GetEventResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

