import { Component, OnInit} from '@angular/core';
import { FormBuilder, Validators} from '@angular/forms';
import { AuthService } from '../../auth.service';
import { loginCredential } from '../../models/auth.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit{
  invalidLogin?: boolean;
  loginForm: any;
  
  constructor(private fb: FormBuilder, private authService: AuthService){}

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
        console.log('Success');
         //go to home screen
      },
      error(err) {
        console.error("Error", err);
      },
    });
   
  }



}
