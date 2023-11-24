import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../../../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserManageService {


  private readonly httpHeader = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    }),
  };

  constructor(private http: HttpClient) { }

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>('https://localhost:7106/api/user/list');
  }

  getUserById(id: string): Observable<User> {
    return this.http.get<User>(`https://localhost:7106/api/user/${id}`);
  }

  editUser(user: User): Observable<User> {
    return this.http.post<User>(`https://localhost:7106/api/user/${user.id}`,
      {
        userId: user.id,
        userName: user.email,
        email: user.email,
        phoneNumber: user.phoneNumber
      });
  }



  deleteUser(id: String): Observable<any> {
    return this.http.delete<any>('https://localhost:7106/api/user/' + id,
      {
        headers: this.getHeaders()
      });

  }
  private getHeaders(): HttpHeaders {
    return new HttpHeaders({
      'Content-Type': 'application/json'
    });
  }

}
