import { Component, OnInit } from '@angular/core';
import { MemberService } from '../member/services/member.service';
import { AuthService } from '../auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  userInfo: any;
  constructor(private memberService: MemberService, private authService: AuthService, private router: Router) {

  }

  ngOnInit(): void {
    this.authService.user$.subscribe((user) => {
      this.userInfo = user;
      if (user?.isLoggedIn) {
       this.getMembershipDetailsByUserId();
      }else{
        this.router.navigate(['/member/create'])
      }
    });

  }
  getMembershipDetailsByUserId() {
    this.memberService.getMembershipDetailsByUserId(this.userInfo.id).subscribe({
      next: (result: any) => {
        if (result) {
          this.router.navigate(['/member/view', result.id]);
        }
        this.router.navigate(['/member/create']);
      },
      error: (error: any) => { 
        this.router.navigate(['/member/create']);
      }
    });
  }
}
