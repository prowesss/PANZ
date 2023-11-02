import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';
import { MatSnackBar } from '@angular/material/snack-bar';


@Injectable({
  providedIn: 'root'
})
export class AuthGuardGuard implements CanActivate {
  constructor(private authService : AuthService, private router: Router, private snackBar: MatSnackBar) {

  }
  canActivate():boolean{
    if(this.authService.isLoggedIn()){
      return true;  
    }else{
      this.router.navigate(['login'])
      this.openSnackBar('login first');
      return false;
    }
  }
  openSnackBar(message: string) {
    this.snackBar.open(message, 'Close', {
      duration: 3000,
    });
  }

}
