import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ViewUserComponent } from './pages/user-manage/view-user/view-user.component';

const routes: Routes = [
  { path: 'users', component: ViewUserComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
