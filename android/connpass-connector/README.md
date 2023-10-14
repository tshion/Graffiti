# io.swagger.client - Kotlin client library for connpass API

## Requires

* Kotlin 1.4.30
* Gradle 5.3

## Build

First, create the gradle wrapper script:

```
gradle wrapper
```

Then, run:

```
./gradlew check assemble
```

This runs all tests and packages the library.

## Features/Implementation Notes

* Supports JSON inputs/outputs, File inputs, and Form inputs.
* Supports collection formats for query parameters: csv, tsv, ssv, pipes.
* Some Kotlin and Java types are fully qualified to avoid conflicts with types defined in Swagger definitions.
* Implementation of ApiClient is intended to reduce method counts, specifically to benefit Android targets.

<a name="documentation-for-api-endpoints"></a>
## Documentation for API Endpoints

All URIs are relative to *https://connpass.com/api*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*ConnpassApi* | [**v1EventGet**](docs/ConnpassApi.md#v1eventget) | **GET** /v1/event | イベントサーチAPI

<a name="documentation-for-models"></a>
## Documentation for Models

 - [io.swagger.client.models.Event](docs/Event.md)
 - [io.swagger.client.models.GetEventResponse](docs/GetEventResponse.md)
 - [io.swagger.client.models.OneOfEventSeries](docs/OneOfEventSeries.md)
 - [io.swagger.client.models.Series](docs/Series.md)

<a name="documentation-for-authorization"></a>
## Documentation for Authorization

All endpoints do not require authorization.
