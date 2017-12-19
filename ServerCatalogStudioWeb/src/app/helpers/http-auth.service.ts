import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
@Injectable()
export class HttpAuthService {

  constructor(private http: Http) { }

  get<T>(uri: string, headersArgs?: IHeader[]): Observable<T> {
    return this.http.get(uri, this.agregarHeaders()).map(res => res.json() as T);
  }

  post(uri: string, body: any, headersArgs?: IHeader[]): Observable<Response> {
    return this.http.post(uri, body, this.agregarHeaders());
  }

  put(uri: string, body: any, headersArgs?: IHeader[]): Observable<Response> {
    return this.http.put(uri, body, this.agregarHeaders());
  }

  delete(uri: string, headersArgs?: IHeader[]): Observable<Response> {
    return this.http.delete(uri, this.agregarHeaders(headersArgs));
  }

  private agregarHeaders(headersArgs?: IHeader[]): RequestOptions {
    let headers = new Headers();
    this.agregarTokenHeader(headers);

    if (Array.isArray(headersArgs)) {
      headersArgs.forEach(args => headers.append(args.name, args.value))
    }
    return new RequestOptions({ headers: headers });
  }

  public agregarTokenHeader(headers: Headers) {
    let currentUser = JSON.parse(localStorage.getItem('auth'));
    if (currentUser && currentUser.token) {
      headers.append('Authorization', 'Bearer ' + currentUser.token);
    }
  }

  public ObtenerError(err: any){
    console.log(err);
  }

}

export interface IHeader {
  name: "";
  value: ""
}


