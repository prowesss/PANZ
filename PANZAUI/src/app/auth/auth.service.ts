// auth.service.ts
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Router } from '@angular/router';
import { loginCredential, userCredential } from './models/auth.model';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private userSubject: BehaviorSubject<any | null> = new BehaviorSubject<any | null>(null);
  user$: Observable<any | null> = this.userSubject.asObservable();
  private readonly TOKEN_KEY = 'token';
  private baseUrl: string = 'https://localhost:7106/api/authentication/';

  constructor(private http: HttpClient, private router: Router) {
    this.initializeUserFromToken();
  }

  private initializeUserFromToken(): void {
    const storedToken = localStorage.getItem(this.TOKEN_KEY);
    if (storedToken) {
      this.fetchUserDetails().subscribe(
        (userDetails) => {
          if (userDetails) {
            const user = {
              userId : userDetails.id,
              userName: userDetails.userName,
              isLoggedIn: true,
              isAdmin: userDetails.isAdmin || false, // Assuming "isAdmin" is a boolean claim
            };
            this.setUser(user);
          }
        },
        (error) => {
          console.error('Error fetching user details:', error);
        });
    } else {
      // If there is no stored token, set user as not logged in
      this.setUser(null);
    }
  }

  private setUser(user: any | null): void {
    this.userSubject.next(user);
  }

  private fetchUserDetails(): Observable<any> {
    const url = 'https://localhost:7106/api/user/userinfo';

    // Add the Authorization header with the token
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${this.getToken()}`,
    });

    return this.http.get<any>(url, { headers });
  }

  signUp(userObj: any): Observable<any> {
    const user: any = {
      email: userObj.email,
      password: userObj.password,
    };
    return this.http.post<any>(`${this.baseUrl}register`, user);
  }

  login(userObj: loginCredential): Observable<userCredential> {
    return this.http.post<userCredential>(`${this.baseUrl}login`, userObj).pipe(
      tap((response: any) => {
        const user = {
          userName: response.userName,
          isLoggedIn: true,
          isAdmin: response.isAdmin || false, // Assuming "isAdmin" is a boolean property
        };
        this.setUser(user);
        this.storeToken(response.token);
      })
    );
  }

  setUsername(username: string | null): void {
    const user = this.userSubject.value;
    if (user) {
      user.userName = username;
      this.setUser(user);
    }
  }

  getUsername(): string | null {
    const user = this.userSubject.value;
    return user ? user.userName : null;
  }

  private storeToken(tokenValue: string): void {
    localStorage.setItem(this.TOKEN_KEY, tokenValue);
  }

  logout(): void {
    localStorage.removeItem(this.TOKEN_KEY);
    this.setUser(null);
    this.router.navigate(['/']);
  }

  isLoggedIn(): boolean {
    const user = this.userSubject.value;
    return !!user?.isLoggedIn;
  }

  isAdmin(): boolean {
    const user = this.userSubject.value;
    return !!user?.isAdmin;
  }

  getToken(): string | null {
    return localStorage.getItem(this.TOKEN_KEY);
  }
}
