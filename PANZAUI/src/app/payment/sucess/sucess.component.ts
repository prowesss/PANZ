import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PaymentService } from '../services/payment.service';

@Component({
  templateUrl: './sucess.component.html',
  styleUrls: ['./sucess.component.scss']
})
export class SucessComponent implements OnInit {
  memberId!: string;
  sessionId!: string;

  constructor(private route: ActivatedRoute,private router: Router, private paymentService: PaymentService) { }
  
  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.route.queryParams.subscribe(params => {
      this.memberId = params['memberId'];
      this.sessionId = params['sessionId'];
    });

    if(this.sessionId){
      this.paymentService.paymentSuccess(this.memberId, this.sessionId).subscribe({
        next: (result: any) => {
          this.router.navigate(['/member/view', this.memberId]);
        },
        error: (error: any) => {}
      });
    }else{
      this.router.navigate(['/member/view', this.memberId]);
    }
  }

  navigateToProfile() {
    // Assuming you have a route named 'profile'
    this.router.navigate(['/member/view', this.memberId]);
  }
}
