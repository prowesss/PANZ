import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BlankComponent } from './layouts/blank/blank.component';
import { LayoutComponent } from './layouts/layout/layout.component';

const routes: Routes = [
  {
    path: 'auth',
    component: BlankComponent,
    loadChildren: () =>
      import('./auth/auth.module').then((x) => x.AuthModule)
  },
  {
    path: 'admin',
    component: LayoutComponent,
    loadChildren: () =>
      import('./admin/admin.module').then((m) => m.AdminModule,),
  },
  {
    path: 'member',
    component: LayoutComponent,
    loadChildren: () =>
      import('./member/member.module').then((m) => m.MemberModule,),
  },
  {
    path: 'payment',
    component: LayoutComponent,
    loadChildren: () =>
      import('./payment/payment.module').then((m) => m.PaymentModule,),
  },
  {
    path: '',
    component: LayoutComponent,
    loadChildren: () =>
      import('./home/home.module').then((m) => m.HomeModule,),
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
