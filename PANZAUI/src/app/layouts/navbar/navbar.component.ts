import {Component, OnDestroy } from '@angular/core';
import { AuthService } from 'src/app/auth/auth.service';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnDestroy {
  loggedIn: boolean = false;
  isAdmin: boolean = false;
  username: string | null = null;

  private authSubscription: Subscription;

  constructor(private authService: AuthService,
    private router: Router) {

    this.authSubscription = this.authService.user$.subscribe((user) => {
      this.username = user?.userName;
      this.loggedIn = !!user?.userName;
      this.isAdmin = user?.isAdmin;
    });
  }

  navigateToHome(): void {
    this.router.navigate(['/']);
  }

  navigateToDashboard(): void {
    this.router.navigate(['/admin']);
  }

  navigateToLogin(): void {
    this.router.navigate(['/auth/login']);
  }

  navigateToRegister(): void {
    this.router.navigate(['/auth/signup']);
  }

  onLogout() {
    this.authService.logout();
  }

  isAdminRoute(): boolean {
    return window.location.pathname.includes('/admin');
  }

  ngOnDestroy(): void {
    this.authSubscription.unsubscribe();
  }

}
