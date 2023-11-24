import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  constructor(private http: HttpClient) { }

  private baseUrl: string = "https://localhost:7106/api/member/"


  paymentSuccess(memberId: string, sessionId?: string): Observable<any> {
    let url = `${this.baseUrl}payment/success?memberid=${memberId}`;
    if (sessionId) {
      url += `&sessionid=${sessionId}`;
    }
    return this.http.post<any>(url, null);
  }

}
