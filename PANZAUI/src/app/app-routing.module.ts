import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './auth/components/login/login.component';
import { SignupComponent } from './auth/components/signup/signup.component';
import { PasswordResetComponent } from './auth/components/password-reset/password-reset.component';
import { AdminLayoutComponent } from './admin/components/admin-layout/admin-layout.component';
import { DashboardComponent } from './admin/pages/dashboard/dashboard.component';
import { AuthGuardGuard } from './guards/auth-guard.guard';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent },
  { path:'dashboard', component: DashboardComponent, canActivate: [AuthGuardGuard]},
  { path: 'password-reset', component: PasswordResetComponent },
  {
    path: 'admin',
    component: AdminLayoutComponent,
    loadChildren: () =>
      import('./admin/admin.module').then((m) => m.AdminModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
