import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PaymentMethod } from 'src/app/models/payment-method.model';

@Injectable({
  providedIn: 'root'
})
export class PaymentMethodService {
  private readonly httpHeader = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    }),
  };
  constructor(private http: HttpClient) { }

  getPaymentMethods(): Observable<PaymentMethod[]> {
    return this.http.get<PaymentMethod[]>('https://localhost:7106/api/payment');
  }

  getMembershipTypeById(id: string): Observable<PaymentMethod> {
    return this.http.get<PaymentMethod>(`https://localhost:7106/api/payment/${id}`);
  }
}