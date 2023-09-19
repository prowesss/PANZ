import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../../auth.service';
import { RolesEnum } from 'src/app/utils/role.enum';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent {

  signupForm: FormGroup;
  hide= true;

  constructor(private fb: FormBuilder, private auth: AuthService) {
    this.signupForm = this.fb.group({
      role: [''],
      email: ['', [Validators.required, Validators.email]],
      username: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  onSignup(){
    if(this.signupForm.valid){
      this.signupForm.controls['role'].setValue(RolesEnum.MEMBER);
      this.auth.signUp(this.signupForm.value)
      .subscribe({
        next:(res=>{
          alert(res.message)
        }),
        error:(err=>{
          alert(err?.error.message)
        })
      })

      console.log(this.signupForm.value);
    }else{
      
    }
  }
}
