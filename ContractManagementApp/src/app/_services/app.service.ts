import { Injectable } from '@angular/core';
import { Subject, Observable, Observer } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Customer } from '../models/customer';

@Injectable({
  providedIn: 'root'
})

export class AppService {

  private userLoggedIn = new Subject<boolean>();

  private apiUrl = environment.apiUrl

  constructor(private http: HttpClient) {
    this.userLoggedIn.next(false);
  }

  setUserLoggedIn(userLoggedIn: boolean) {
    this.userLoggedIn.next(userLoggedIn);
  }

  getUserLoggedIn(): Observable<boolean> {
    return this.userLoggedIn.asObservable();
  }

  checkCustomer(id: string) {
    return this.http.get<boolean>(this.apiUrl + 'CheckCustomer?id=' + id);
  }

  GetCustomer(id: string) {
    return this.http.get<Customer>(this.apiUrl + 'GetCustomer?id=' + id);
  }
}
