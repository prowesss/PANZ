import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { loginCredential, userCredential } from './models/auth.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private usernameSubject: BehaviorSubject<string> = new BehaviorSubject<string>('');
  username$ = this.usernameSubject.asObservable();

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

  setUsername(username: string) {
    this.usernameSubject.next(username);
  }
  
  getUsername(): string {
    return this.usernameSubject.value;
  }

  storeToken(tokenValue: string) {
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