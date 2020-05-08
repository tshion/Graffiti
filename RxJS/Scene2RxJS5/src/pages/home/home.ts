import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Storage } from '@ionic/storage';
import "rxjs/add/observable/concat";
import "rxjs/add/observable/from";
import "rxjs/add/observable/fromPromise";
import { Observable } from 'rxjs/Observable';
import { catchError, concatMap, concatMapTo, tap, } from "rxjs/operators";

import { SecretResponse } from '../../services/entities/secret-response';
import { TokenResponse } from '../../services/entities/token-response';

@Component({
  selector: 'page-home',
  template: `
  <ion-header>
    <ion-navbar>
      <ion-title>Ionic Blank</ion-title>
    </ion-navbar>
  </ion-header>

  <ion-content padding>
    The world is your oyster.
    <p>
      If you get lost, the <a href="http://ionicframework.com/docs/v3">docs</a> will be your guide.
    </p>
  </ion-content>
  `
})
export class HomePage {
  private readonly BASE_URL = "http://0.0.0.0:8887"
  private readonly KEY_TOKEN = "HomePage_token"
  private readonly KEY_TOKEN_REFRESH = "HomePage_token_refresh"


  constructor(
    private http: HttpClient,
    private storage: Storage,
  ) {
    this.challenge1()
      .then(() => {
        this.challenge2()
      })
  }


  /**
    * Promise パターンでの実装例
    */
  async challenge1() {
    const log = (message: string) => {
      console.log(`challenge1: ${message}`)
    }

    log("start")

    log("call token:post, start")
    const tokenRes = await this.http.post<TokenResponse>(this.urlToken(), null).toPromise()
    log(`call token:post, finish :: ${JSON.stringify(tokenRes)}`)

    log("save token:post, start")
    const saveResultToken1 = await this.storage.set(this.KEY_TOKEN, tokenRes.access_token)
    log(`save token:post, finish :: ${saveResultToken1}`)

    log("save refresh token:post, start")
    const saveResultTokenRefresh1 = await this.storage.set(this.KEY_TOKEN_REFRESH, tokenRes.refresh_token)
    log(`save refresh token:post, finish :: ${saveResultTokenRefresh1}`)

    log("load token, start")
    const loadResultToken1 = await this.storage.get(this.KEY_TOKEN)
    log(`load token, finish :: ${loadResultToken1}`)

    log("call secret1, start")
    const secret1Res = await this.http.get<SecretResponse>(this.urlSecret1(), {
      headers: new HttpHeaders(
        { "Authorization": loadResultToken1 }
      )
    }).toPromise()
    log(`call secret1, finish :: ${JSON.stringify(secret1Res)}`)

    log("call secret2-1, start")
    const secret2Res1 = await this.http.get<SecretResponse>(this.urlSecret2(), {
      headers: new HttpHeaders(
        { "Authorization": loadResultToken1 }
      )
    })
      .toPromise()
      .catch(err => log(`call secret2-1, finish :: ${JSON.stringify(err)}`))

    log("load refresh token, start")
    const loadResultTokenRefresh = await this.storage.get(this.KEY_TOKEN_REFRESH)
    log(`load refresh token, finish :: ${loadResultTokenRefresh}`)

    log("call token:put, start")
    const tokenRefreshRes = await this.http.put<TokenResponse>(this.urlToken(), {}, {
      headers: new HttpHeaders(
        { "Authorization": loadResultTokenRefresh }
      )
    }).toPromise()
    log(`call token:put, finish :: ${JSON.stringify(tokenRefreshRes)}`)

    log("save token after refreshed, start")
    const saveResultToken2 = await this.storage.set(this.KEY_TOKEN, tokenRefreshRes.access_token)
    log(`save token after refreshed, finish :: ${saveResultToken2}`)

    log("save refresh token after refreshed, start")
    const saveResultTokenRefresh2 = await this.storage.set(this.KEY_TOKEN_REFRESH, tokenRefreshRes.refresh_token)
    log(`save refresh token after refreshed, finish :: ${saveResultTokenRefresh2}`)

    log("load token after refreshed, start")
    const loadResultToken2 = await this.storage.get(this.KEY_TOKEN)
    log(`load token after refreshed, finish :: ${loadResultToken2}`)

    log("call secret2-2, start")
    const secret2Res2 = await this.http.get<SecretResponse>(this.urlSecret2(), {
      headers: new HttpHeaders(
        { "Authorization": loadResultToken2 }
      )
    }).toPromise()
    log(`call secret2-2, finish :: ${JSON.stringify(secret2Res2)}`)

    log("finish")
  }

  /**
   * RxJS での実装例
   */
  challenge2() {
    const log = (message: string) => {
      console.log(`challenge2: ${message}`)
    }

    log("start")

    log("call token:post, start")
    this.http.post<TokenResponse>(this.urlToken(), null)
      .pipe(
        tap((tokenRes: TokenResponse) => {
          log(`call token:post, finish :: ${JSON.stringify(tokenRes)}`)
        }),

        concatMap((tokenRes: TokenResponse) =>
          Observable.from("a")
            .pipe(
              tap((x: any) => log("save token:post, start")),
              concatMapTo(this.storage.set(this.KEY_TOKEN, tokenRes.access_token)),
              tap((saveResultToken1: any) => log(`save token:post, finish :: ${saveResultToken1}`)),

              tap((x: any) => log("save refresh token:post, start")),
              concatMapTo(this.storage.set(this.KEY_TOKEN_REFRESH, tokenRes.refresh_token)),
              tap((saveResultTokenRefresh1: any) => log(`save refresh token:post, finish :: ${saveResultTokenRefresh1}`)),
            )
        ),

        tap((x: any) => log("load token, start")),
        concatMapTo(this.storage.get(this.KEY_TOKEN)),
        tap((loadResultToken1: any) => log(`load token, finish :: ${loadResultToken1}`)),

        concatMap((loadResultToken1: any) =>
          Observable.from("a")
            .pipe(
              tap((x: any) => log("call secret1, start")),
              concatMapTo(this.http.get<SecretResponse>(this.urlSecret1(), {
                headers: new HttpHeaders(
                  { "Authorization": loadResultToken1 }
                )
              })),
              tap((secret1Res: SecretResponse) => log(`call secret1, finish :: ${JSON.stringify(secret1Res)}`)),

              tap((x: any) => log("call secret2-1, start")),
              concatMapTo(this.http.get<SecretResponse>(this.urlSecret2(), {
                headers: new HttpHeaders(
                  { "Authorization": loadResultToken1 }
                )
              })),
              catchError((err: any) => {
                log(`call secret2-1, finish :: ${JSON.stringify(err)}`)
                return Observable.from("a")
              }),
            )
        ),

        tap((x: any) => log("load refresh token, start")),
        concatMapTo(this.storage.get(this.KEY_TOKEN_REFRESH)),
        tap((loadResultTokenRefresh: any) => log(`load refresh token, finish :: ${loadResultTokenRefresh}`)),

        tap((x: any) => log("call token:put, start")),
        concatMap((loadResultTokenRefresh: any) =>
          this.http.put<TokenResponse>(this.urlToken(), {}, {
            headers: new HttpHeaders(
              { "Authorization": loadResultTokenRefresh }
            )
          })
        ),
        tap((tokenRefreshRes: any) => log(`call token:put, finish :: ${JSON.stringify(tokenRefreshRes)}`)),

        concatMap((tokenRefreshRes: TokenResponse) =>
          Observable.from("a")
            .pipe(
              tap((x: any) => log("save token after refreshed, start")),
              concatMapTo(this.storage.set(this.KEY_TOKEN, tokenRefreshRes.access_token)),
              tap((saveResultToken2: any) => log(`save token after refreshed, finish :: ${saveResultToken2}`)),

              tap((x: any) => log("save refresh token after refreshed, start")),
              concatMapTo(this.storage.set(this.KEY_TOKEN_REFRESH, tokenRefreshRes.refresh_token)),
              tap((saveResultTokenRefresh2: any) => log(`save refresh token after refreshed, finish :: ${saveResultTokenRefresh2}`)),
            )
        ),

        tap((x: any) => log("load token after refreshed, start")),
        concatMapTo(this.storage.get(this.KEY_TOKEN)),
        tap((loadResultToken2: any) => log(`load token after refreshed, finish :: ${loadResultToken2}`)),

        tap((x: any) => log("call secret2-2, start")),
        concatMap((loadResultToken2: any) =>
          this.http.get<SecretResponse>(this.urlSecret2(), {
            headers: new HttpHeaders(
              { "Authorization": loadResultToken2 }
            )
          })
        ),
        tap((secret2Res2: any) => log(`call secret2-2, finish :: ${JSON.stringify(secret2Res2)}`)),
      )
      .subscribe(() => {
        log("finish")
      })
  }



  private urlToken(): string {
    return `${this.BASE_URL}/token`
  }

  private urlSecret1(): string {
    return `${this.BASE_URL}/secret1`
  }

  private urlSecret2(): string {
    return `${this.BASE_URL}/secret2`
  }
}
