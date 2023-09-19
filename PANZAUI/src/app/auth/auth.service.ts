import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { loginCredential, userCredential } from './models/auth.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl: string = "https://localhost:7106/api/authentication/"
  constructor(private http: HttpClient) { }

  signUp(userObj: any) {
    return this.http.post<any>(`${this.baseUrl}register`, userObj)
  }

  login(userObj: loginCredential): Observable<userCredential> {
    return this.http.post<userCredential>(`${this.baseUrl}login`, userObj).pipe(
      tap((response) => {
        if (response.token) {
          // Store the token in local storage
          localStorage.setItem('jwtToken', response.token);
        }
      })
    );
  }

  logout(): void {
    // Remove the token from local storage upon logout
    localStorage.removeItem('jwtToken');
  }

  isLoggedIn(): boolean {
    // Check if the token exists in local storage to determine if the user is logged in
    return !!localStorage.getItem('jwtToken');
  }

  getToken(): string | null {
    // Retrieve the token from local storage
    return localStorage.getItem('jwtToken');
  }
}