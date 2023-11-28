import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Role } from 'src/app/models/role.model';

@Injectable({
  providedIn: 'root'
})
export class UserRolesService {
  private readonly httpHeader = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    }),
  };
  constructor(private http: HttpClient) { }


  getRoles(): Observable<Role[]> {
    return this.http.get<Role[]>('https://localhost:7106/api/role/getroles');
  }

  // getRolesById(id: string): Observable<Role> {
  //   return this.http.get<Role>(`https://localhost:7106/api/payment/${id}`);
  // }
}
