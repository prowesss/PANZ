import { Component, OnInit} from '@angular/core';
import { FormBuilder, Validators} from '@angular/forms';
import { AuthService } from '../../auth.service';
import { loginCredential } from '../../models/auth.model';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit{
  invalidLogin?: boolean;
  loginForm: any;
  loggedIn?: boolean;
  
  constructor(
    private fb: FormBuilder, 
    private authService: AuthService, 
    private router: Router,  
    private snackBar: MatSnackBar){}

  ngOnInit(): void {
    this.buildForm();
  }

  buildForm() {
   this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  onLogin(){
    const credentials: loginCredential = {
      username : this.loginForm.value.username,
      password : this.loginForm.value.password
    }
   
    this.authService.login(credentials).subscribe({
      next:(data) => {
        this.loginForm.reset();
        this.router.navigate(['']);
        this.openSnackBar('Login Successful');
      },
      error(err) {
        console.error("Error", err);
      },
    });
   
  }

  openSnackBar(message: string) {
    this.snackBar.open(message, 'Close', {
      duration: 3000,
    });
  }

}
