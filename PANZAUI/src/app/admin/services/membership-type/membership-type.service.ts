import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MembershipType } from 'src/app/models/membership-type.model';

@Injectable({
  providedIn: 'root'
})
export class MembershipTypeService {
  private readonly httpHeader = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    }),
  };
  constructor(private http: HttpClient) { }

  getMembershipTypes(): Observable<MembershipType[]> {
    return this.http.get<MembershipType[]>('https://localhost:7106/api/membershipType');
  }

  getMembershipTypeById(id: string): Observable<MembershipType> {
    return this.http.get<MembershipType>(`https://localhost:7106/api/membershipType/${id}`);
  }
}
