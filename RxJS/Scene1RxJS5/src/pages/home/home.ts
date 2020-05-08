import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Storage } from '@ionic/storage';
import "rxjs/add/observable/concat";
import "rxjs/add/observable/from";
import "rxjs/add/observable/fromPromise";
import { Observable } from 'rxjs/Observable';
import { concatMap, concatMapTo, tap, } from "rxjs/operators";

import { Endpoint1Response } from '../../services/entities/endpoint1-response';
import { Endpoint2Response } from '../../services/entities/endpoint2-response';

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
  private readonly KEY_ID = "HomePage_id"


  constructor(
    private http: HttpClient,
    private storage: Storage,
  ) {
    this.challenge1()
      .then(() => {
        this.challenge2()

        // challenge3() はchallenge2() 内でコール
        // this.challenge3()
      })
  }


  /**
   * Promise で実装
   */
  async challenge1() {
    const log = (message: string) => {
      console.log(`challenge1: ${message}`)
    }

    log("start")

    log("call endpoint1, start")
    const res1 = await this.http.get<Endpoint1Response>(this.url1()).toPromise()
    log(`call endpoint1, finish :: ${JSON.stringify(res1)}`)

    log("save id, start")
    const saveResult = await this.storage.set(this.KEY_ID, res1.id)
    log(`save id, finish :: ${JSON.stringify(saveResult)}`)

    log("load id, start")
    const loadResult = await this.storage.get(this.KEY_ID)
    log(`load id, finish :: ${loadResult}`)

    log("call endpoint2, start")
    const res2 = await this.http.get<Endpoint2Response>(this.url2(loadResult)).toPromise()
    log(`call endpoint2, finish :: ${JSON.stringify(res2)}`)

    log("finish")
  }

  /**
   * RxJS で実装
   */
  challenge2() {
    const log = (message: string) => {
      console.log(`challenge2: ${message}`)
    }

    log("start")

    log("call endpoint1, start")
    this.http.get<Endpoint1Response>(this.url1())
      .pipe(
        tap((res1: Endpoint1Response) => {
          log(`call endpoint1, finish :: ${JSON.stringify(res1)}`)
        }),
        concatMap((res1: Endpoint1Response) => {
          log("save id, start")
          return Observable.fromPromise(this.storage.set(this.KEY_ID, res1.id))
            .pipe(
              tap((saveResult: any) => {
                log(`save id, finish :: ${JSON.stringify(saveResult)}`)
              }),
            )
        }),
        tap((x: any) => {
          log("load id, start")
        }),
        concatMapTo(
          Observable.fromPromise(this.storage.get(this.KEY_ID))
            .pipe(
              tap((loadResult: any) => {
                log(`load id, finish :: ${loadResult}`)
              }),
            )
        ),
        concatMap((loadResult: any) => {
          log("call endpoint2, start")
          return this.http.get<Endpoint2Response>(this.url2(loadResult))
            .pipe(
              tap((res2: Endpoint2Response) => {
                log(`call endpoint2, finish :: ${JSON.stringify(res2)}`)
              })
            )
        }),
      )
      .subscribe(
        (value: any) => {
          log("finish")

          this.challenge3()
        }
      )
  }

  /**
   * RxJS で実装
   * ※エンドポイントごとにストリームが切られた場合を想定
   * ※想定挙動とは違うので注意が必要
   */
  challenge3() {
    const log = (message: string) => {
      console.log(`challenge3: ${message}`)
    }

    log("start")

    Observable
      .concat(
        // endpoint1
        Observable.from("a")
          .pipe(
            tap((x: any) => log("call endpoint1, start")),
            concatMapTo(this.http.get<Endpoint1Response>(this.url1())),
            tap((res1: Endpoint1Response) => {
              log(`call endpoint1, finish :: ${JSON.stringify(res1)}`)
            }),
            tap((res1: Endpoint1Response) => log("save id, start")),
            concatMap((res1: Endpoint1Response) => {
              return Observable.fromPromise(this.storage.set(this.KEY_ID, res1.id))
            }),
            tap((saveResult: any) => {
              log(`save id, finish :: ${JSON.stringify(saveResult)}`)
            }),
          ),

        // endpoint2
        Observable.from("a")
          .pipe(
            tap((x: any) => log("load id, start")),
            concatMapTo(Observable.fromPromise(this.storage.get(this.KEY_ID))),
            tap((loadResult: any) => log(`load id, finish :: ${loadResult}`)),
            tap((loadResult: any) => log("call endpoint2, start")),
            concatMap((loadResult: any) => {
              return this.http.get<Endpoint2Response>(this.url2(loadResult))
            }),
            tap((res2: Endpoint2Response) => {
              log(`call endpoint2, finish :: ${JSON.stringify(res2)}`)
            }),
          ),
      )
      .subscribe(
        (value: any) => {
          log("finish")
        }
      )
  }



  private url1(): string {
    return `${this.BASE_URL}/endpoint1.json`
  }
  private url2(id: string): string {
    return `${this.BASE_URL}/endpoint2/${id}.json`
  }
}
