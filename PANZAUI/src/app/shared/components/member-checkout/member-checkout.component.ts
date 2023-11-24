import { Component, Inject, OnInit } from '@angular/core';
import { MemberCheckoutService } from '../../../admin/services/member-checkout.service';
import { NgForm } from '@angular/forms';
import { PaymentMethod } from 'src/app/models/payment-method.model';
import { PaymentMethodEnum } from 'src/app/utils/enums/payment-method.enum';
import { MembershipType } from 'src/app/models/membership-type.model';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Member } from 'src/app/models/member.model';
import { PaymentService } from 'src/app/payment/services/payment.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-member-checkout',
  templateUrl: './member-checkout.component.html',
  styleUrls: ['./member-checkout.component.scss']
})
export class MemberCheckoutComponent implements OnInit {
  paymentMethods: PaymentMethod[] = [];
  selectedMembershipType!: MembershipType;
  member!: Member
  isLoading: boolean = true;

  constructor(
    private checkoutService: MemberCheckoutService,
    private paymentService: PaymentService,
    private router: Router,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }

  ngOnInit(): void {
    this.paymentMethods = this.data.paymentMethods;
    this.selectedMembershipType = this.data.selectedMembershipType;
    this.member = this.data.member;
    this.isLoading = false;
  }

  initiatePayment(paymentMethod: PaymentMethod) {
    switch (paymentMethod.name) {
      case PaymentMethodEnum.Bank:
        this.paymentService.paymentSuccess(this.member.id).subscribe(({
          next: () => {
            this.router.navigate(['/payment/success'], { queryParams: { memberId: this.member.id } });
          }
        }));
        break;
      case PaymentMethodEnum.Stripe:
        this.checkoutService.requestMemberSession(this.selectedMembershipType.stripePriceId, this.member.id);
        break;
      default:
        break;
    }
  }

  // onSubmit(form: NgForm) {
  //   const priceId = form.value.priceId;

  //   if (priceId) {
  //     this.checkoutService.requestMemberSession(priceId);
  //   } else {
  //     console.error('Invalid priceId:', priceId);
  //   }
  //   this.checkoutService.requestMemberSession(form.value.priceId);
  // }
}
