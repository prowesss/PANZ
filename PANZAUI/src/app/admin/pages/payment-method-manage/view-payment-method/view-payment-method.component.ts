import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PaymentMethodService } from 'src/app/admin/services/payment-method/payment-method.service';
import { PaymentMethod } from 'src/app/models/payment-method.model';

@Component({
  selector: 'app-view-payment-method',
  templateUrl: './view-payment-method.component.html',
  styleUrls: ['./view-payment-method.component.scss']
})
export class ViewPaymentMethodComponent {
  public paymentMethod: PaymentMethod | undefined ;
  public isLoading = false;

  constructor(
    private paymentMethodService: PaymentMethodService,
    private route: ActivatedRoute,
    private router: Router
  ) { }


  ngOnInit(): void {
    this.isLoading = true;
    this.route.params.subscribe(params => {
      const paymentMethodId = params['id'];
      this.getMembershipType(paymentMethodId);
    });
  }


  getMembershipType(paymentMethodId: any) {
    this.paymentMethodService.getMembershipTypeById(paymentMethodId).subscribe({
      next:(paymentMethod: PaymentMethod) => {
        this.paymentMethod = paymentMethod;
        this.isLoading = true;
      }
    });
  }

  onBackClick(){
    this.router.navigate(['payment-methods'])
  }
}
