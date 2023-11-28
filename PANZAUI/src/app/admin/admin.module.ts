import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminRoutingModule } from './admin-routing.module';
import { MainPageComponent } from './pages/user-manage/main-page/main-page.component';
import { MainPageRolesComponent } from './pages/user-roles-manage/main-page-roles/main-page-roles.component';
import { CreateUserComponent } from './pages/user-manage/create-user/create-user.component';
import { EditUserComponent } from './pages/user-manage/edit-user/edit-user.component';
import { ViewUserComponent } from './pages/user-manage/view-user/view-user.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { AdminNavbarComponent } from './components/admin-navbar/admin-navbar.component';
import { AdminLayoutComponent } from './components/admin-layout/admin-layout.component';
import { MaterialModule } from '../shared/material.module';
import { SharedModule } from '../shared/shared.module';
import { DeleteUserComponent } from './pages/user-manage/delete-user/delete-user.component';
import { MainMembersComponent } from './pages/member-manage/main-members/main-members.component';
import { MainMembershipTypeComponent } from './pages/membership-type-manage/main-membership-type/main-membership-type.component';
import { ViewMembershipTypeComponent } from './pages/membership-type-manage/view-membership-type/view-membership-type.component';
import { MainPaymentMethodComponent } from './pages/payment-method-manage/main-payment-method/main-payment-method.component';
import { ViewPaymentMethodComponent } from './pages/payment-method-manage/view-payment-method/view-payment-method.component';
import { ViewMemberComponent } from './pages/member-manage/view-member/view-member.component';
import { LayoutModule } from '../layouts/layout.module';

@NgModule({
  declarations: [
    MainPageComponent,
    CreateUserComponent,
    EditUserComponent,
    MainPageRolesComponent,
    ViewUserComponent,
    DashboardComponent,
    AdminNavbarComponent,
    AdminLayoutComponent,
    DeleteUserComponent,
    MainMembersComponent,
    MainMembershipTypeComponent,
    ViewMembershipTypeComponent,
    MainPaymentMethodComponent,
    ViewPaymentMethodComponent,
    ViewMemberComponent,
  ],
  imports: [
    CommonModule,
    MaterialModule,
    SharedModule,
    AdminRoutingModule,
    LayoutModule
  ],
  exports: [
    AdminNavbarComponent,
    AdminLayoutComponent]
})
export class AdminModule { }
