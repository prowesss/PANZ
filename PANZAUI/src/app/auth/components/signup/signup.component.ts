import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../../auth.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent {

  signupForm: FormGroup;
  hide = true;

  constructor(
    private fb: FormBuilder,
    private auth: AuthService,
    private router: Router,
    private snackBar: MatSnackBar
  ) {
    this.signupForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  onSignup() {
    if (this.signupForm.valid) {
      this.auth.signUp(this.signupForm.value)
        .subscribe({
          next: (res => {
            this.signupForm.reset();
            this.router.navigate(['login']);
            this.openSnackBar('Signed up successfully. Please log in.');
          }),
          error: (err => {
            const errorMessage = err?.error?.message || 'An error occurred';
            alert(errorMessage);
          })
        });

      console.log(this.signupForm.value);
    } 
  }

  openSnackBar(message: string) {
    this.snackBar.open(message, 'Close', {
      duration: 3000,
    });
  }
}
