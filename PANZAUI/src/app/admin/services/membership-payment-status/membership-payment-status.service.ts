import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MembershipPaymentStatus } from 'src/app/models/membership-payment-status.model';

@Injectable({
  providedIn: 'root'
})
export class MembershipPaymentStatusService {
  private readonly httpHeader = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    }),
  };
  constructor(private http: HttpClient) { }

  getAllMembershipStatus(): Observable<MembershipPaymentStatus[]> {
    return this.http.get<MembershipPaymentStatus[]>('https://localhost:7106/api/membershipPaymentStatus');
  }
}
