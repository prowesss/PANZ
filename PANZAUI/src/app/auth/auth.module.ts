import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthRoutingModule } from './auth-routing.module';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { SharedModule } from '../shared/shared.module';
import { HttpClientModule } from '@angular/common/http';
import { PasswordResetComponent } from './components/password-reset/password-reset.component';
import { NavComponent } from './components/nav/nav.component';


@NgModule({
  declarations: [
    LoginComponent,
    SignupComponent,
    PasswordResetComponent,
    NavComponent,
    ],
  imports: [
    CommonModule,
    AuthRoutingModule,
    HttpClientModule,
    SharedModule
  ],
  exports: [
    SignupComponent,
    LoginComponent,
    NavComponent
  ],
})
export class AuthModule { }
