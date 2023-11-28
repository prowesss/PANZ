import { Component } from "@angular/core";

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.scss']
})
export class SideNavComponent {
  navState: 'collapsed' | 'expanded' = 'expanded';
  contentMargin = 80;

  navigationItems = [
    { label: 'Full Name', icon: 'menu', routerLink: '/', show: true },
    { label: 'Dashboard', icon: 'dashboard', routerLink: '/dashboard', show: true },
    { label: 'Member', icon: 'people', routerLink: '/admin/members', show: true },
    { label: 'Membership Type', icon: 'people', routerLink: '/admin/membership-types', show: true },
    { label: 'Payment Methods', icon: 'payment', routerLink: '/admin/payment-methods', show: true },
    { label: 'User', icon: 'person', routerLink: '/admin/users', show: true },
    { label: 'Role', icon: 'security', routerLink: '/admin/roles', show: true },
    // Add more items as needed
  ];


  constructor() {
  }

  toggleNav() {
    this.navState = this.navState !== 'expanded' ? 'expanded' : 'collapsed';

    if(this.navState !== 'expanded'){
      this.contentMargin = 80;
    }else{
      this.contentMargin = 250;
    }
  }
}
