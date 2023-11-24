import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MembershipStatus } from 'src/app/models/membership-status.model';

@Injectable({
  providedIn: 'root'
})
export class MembershipStatusService {
  private readonly httpHeader = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    }),
  };
  constructor(private http: HttpClient) { }

  getAllMembershipStatus(): Observable<MembershipStatus[]> {
    return this.http.get<MembershipStatus[]>('https://localhost:7106/api/membershipStatus');
  }
}