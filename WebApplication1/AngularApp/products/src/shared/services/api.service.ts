import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams, HttpErrorResponse } from '@angular/common/http';
import { throwError, Observable } from 'rxjs';
import {
  catchError,
} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private httpClient: HttpClient) {
  }

  private setHeaders(): HttpHeaders {
    const headersConfig = {
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    };
    return new HttpHeaders(headersConfig);
  }

  private formatErrors(error: any): Observable<never> {
    // TODO Process Http errors
    // if (error.status === 401) {
    //   window.location.replace('/account/login');
    // }
    // if (error.status === 403) {
    //   window.location.replace('/home');
    // }
    return throwError(error);
  }

  get(path: string, params: HttpParams = new HttpParams()): Observable<any> {
    return this.httpClient.get(`${path}`, { headers: this.setHeaders(), params: params })
      .pipe(catchError((error: HttpErrorResponse) => this.formatErrors(error)));
  }

  put(path: string, body: any = {}): Observable<any> {
    return this.httpClient.put(`${path}`, JSON.stringify(body), { headers: this.setHeaders() })
      .pipe(catchError((error: HttpErrorResponse) => this.formatErrors(error)));
  }

  post(path: string, body: any = {}): Observable<any> {
    return this.httpClient.post(`${path}`, JSON.stringify(body), { headers: this.setHeaders() })
      .pipe(catchError((error: HttpErrorResponse) => this.formatErrors(error)));
  }

  delete(path: string): Observable<any> {
    return this.httpClient.delete(`${path}`, { headers: this.setHeaders() })
      .pipe(catchError((error: HttpErrorResponse) => this.formatErrors(error)));
  }
}
