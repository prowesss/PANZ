import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { loadStripe } from '@stripe/stripe-js';
import { MembershipPlan, Session } from 'src/app/models/member-checkout.model';

@Injectable({
  providedIn: 'root'
})
export class MemberCheckoutService {

  private stripePublicKey = 'pk_test_51OCMJLG05pyFeIhHkAilxasPB7kFbsKBhSUhMuQE8WbK9hDSzkKPGM8yfzcF7xozvTS9E4Gs53ffMu6DuFRQ89xF00ykvwWlRR';

  constructor(private http: HttpClient) { }

  getMembership(): Observable<MembershipPlan[]> {
    return this.http.get<MembershipPlan[]>('https://localhost:7106/api/membershipType');
  }

  requestMemberSession(priceId: string, memberId: string, quantity: number = 1): void {
    this.http.post<Session>('https://localhost:7106/api/stripe/create-checkout-session', {
      priceId: priceId,
      quantity: quantity,
      memberId: memberId
    })
      .subscribe((session: any) => {
        this.redirectToCheckout(session.sessionId);
      });
  }

  async redirectToCheckout(sessionId: string) {
    const stripe = await loadStripe(this.stripePublicKey);

    if (!stripe) {
      console.error('Failed to load Stripe');
      throw new Error('Failed to load Stripe');
    }

    const { error } = await stripe.redirectToCheckout({
      sessionId: sessionId,
    });

    if (error) {
      console.error(error);
    }
  }
}
