import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { MainPageComponent } from './pages/user-manage/main-page/main-page.component';
import { CreateUserComponent } from './pages/user-manage/create-user/create-user.component';
import { EditUserComponent } from './pages/user-manage/edit-user/edit-user.component';
import { ViewUserComponent } from './pages/user-manage/view-user/view-user.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { AdminNavbarComponent } from './components/admin-navbar/admin-navbar.component';
import { AdminLayoutComponent } from './components/admin-layout/admin-layout.component';
import { MaterialModule } from '../shared/material.module';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    MainPageComponent,
    CreateUserComponent,
    EditUserComponent,
    ViewUserComponent,
    DashboardComponent,
    AdminNavbarComponent,
    AdminLayoutComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    SharedModule,
    AdminRoutingModule
  ],
  exports: [
    AdminNavbarComponent,
    AdminLayoutComponent]
})
export class AdminModule { }
