import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../models/loginmodel';

@Injectable({
    providedIn: 'root'
  })
  
  export class LoginService {
    baseUrl = 'https://digitalbookmanagementservice.azure-api.net/token/TokenAuthentication';
    
    constructor(private http: HttpClient) { }
    
    ValidateUser(user: User):Observable<User> {
        return this.http.post<User>(this.baseUrl, user);
    }

    LogoutCurrentUser(){
        localStorage.clear();
    }

    GetUserName() {
        return localStorage.getItem('currentUserName');
    }

    IsUserAuthenticated() {
        return localStorage.getItem('isUserAuthenticated');
    }

    GetUserType() {
        return localStorage.getItem('currentUserType');
    }

  }