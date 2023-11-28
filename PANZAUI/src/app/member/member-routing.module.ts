import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EditMemberComponent } from './pages/edit-member/edit-member.component';
import { RegisterMemberComponent } from './pages/register-member/register-member.component';
import { ViewMemberComponent } from './pages/view-member/view-member.component';

const routes: Routes = [
{ path: 'edit/:id', component: EditMemberComponent },
{ path: 'create', component: RegisterMemberComponent },
{ path: 'view/:id', component: ViewMemberComponent },
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MemberRoutingModule { }
