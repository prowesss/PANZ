import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthRoutingModule } from './auth-routing.module';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { SharedModule } from '../shared/shared.module';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    LoginComponent,
    SignupComponent],
  imports: [
    CommonModule,
    AuthRoutingModule,
    HttpClientModule,
    SharedModule
  ],
  exports: [
    SignupComponent,
    LoginComponent
  ],
})
export class AuthModule { }
