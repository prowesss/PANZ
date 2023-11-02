import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable} from 'rxjs';
import { tap } from 'rxjs/operators';
import { loginCredential,userCredential } from './models/auth.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl: string = "https://localhost:7106/api/authentication/"
  constructor(private http: HttpClient) { }

  signUp(userObj: any) {
    let user: any = {
      email: userObj.email,
      password: userObj.password
    }
    return this.http.post<any>(`${this.baseUrl}register`, user)
  }

  login(userObj: loginCredential): Observable<userCredential> {
    return this.http.post<userCredential>(`${this.baseUrl}login`, userObj)
  }

  storeToken(tokenValue: string){
    localStorage.setItem('token', tokenValue)
  }

  logout(): void {
    // Remove the token from local storage upon logout
    localStorage.removeItem('token');
  }

  isLoggedIn(): boolean {
    // Check if the token exists in local storage to determine if the user is logged in
    return !!localStorage.getItem('token');
  }

  getToken() {
    // Retrieve the token from local storage
    return localStorage.getItem('token');
  }
}