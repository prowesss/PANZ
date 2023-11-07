import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainPageComponent } from './pages/user-manage/main-page/main-page.component';
import { ViewUserComponent } from './pages/user-manage/view-user/view-user.component';
import { EditUserComponent } from './pages/user-manage/edit-user/edit-user.component';

const routes: Routes = [
  { path: 'users', component: MainPageComponent },
  { path: 'user/:id', component: ViewUserComponent },
  { path: 'user/edit/:id', component: EditUserComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
