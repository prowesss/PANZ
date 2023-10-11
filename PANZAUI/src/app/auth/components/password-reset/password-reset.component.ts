import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'app-password-reset',
  templateUrl: './password-reset.component.html',
  styleUrls: ['./password-reset.component.scss']
})
export class PasswordResetComponent {

  email: string = '';
  passwordResetForm: any;

  constructor(private router: Router, private fb: FormBuilder, private snackBar: MatSnackBar) {}

  ngOnInit(): void {
    this.buildForm();
  }

  buildForm() {
    this.passwordResetForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
    });
  }

  resetPassword() {
    if (this.passwordResetForm.valid) {
      const email = this.passwordResetForm.value.email;
      console.log('Resetting password for email:', email);
      this.snackBar.open(`Password reset link sent to ${email}`, 'Close', {
        duration: 5000,
      });
    } else {
      console.log('Form is invalid. Please correct the errors.');
    }
  }

  backToLogin() {
    this.router.navigate(['/login']);
  }
}
