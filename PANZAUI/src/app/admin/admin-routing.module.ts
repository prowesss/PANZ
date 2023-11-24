import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainPageComponent } from './pages/user-manage/main-page/main-page.component';
import { ViewUserComponent } from './pages/user-manage/view-user/view-user.component';
import { EditUserComponent } from './pages/user-manage/edit-user/edit-user.component';
import { CreateUserComponent } from './pages/user-manage/create-user/create-user.component';
import { MainMembershipTypeComponent } from './pages/membership-type-manage/main-membership-type/main-membership-type.component';
import { ViewMembershipTypeComponent } from './pages/membership-type-manage/view-membership-type/view-membership-type.component';
import { MainPaymentMethodComponent } from './pages/payment-method-manage/main-payment-method/main-payment-method.component';
import { MemberCheckoutComponent } from '../shared/components/member-checkout/member-checkout.component';
import { MainMembersComponent } from './pages/member-manage/main-members/main-members.component';
import { ViewMemberComponent } from './pages/member-manage/view-member/view-member.component';

const routes: Routes = [
  { path: 'users', component: MainPageComponent },
  { path: 'user/:id', component: ViewUserComponent },
  { path: 'user/edit/:id', component: EditUserComponent },
  { path: 'user', component: CreateUserComponent },
  { path: 'membership-types', component: MainMembershipTypeComponent},
  { path: 'membership-type/:id', component: ViewMembershipTypeComponent},
  { path: 'payment-methods', component: MainPaymentMethodComponent},
  { path: 'payment-method/:id', component: MainPaymentMethodComponent},
  { path: 'checkout', component: MemberCheckoutComponent},
  { path: 'members', component: MainMembersComponent},
  { path: 'member/:id', component: ViewMemberComponent},




];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
