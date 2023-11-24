import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MemberRoutingModule } from './member-routing.module';
import { EditMemberComponent } from './pages/edit-member/edit-member.component';
import { ViewMemberComponent } from './pages/view-member/view-member.component';
import { RegisterMemberComponent } from './pages/register-member/register-member.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    EditMemberComponent,
    ViewMemberComponent,
    RegisterMemberComponent,
  ],
  imports: [
    CommonModule,
    MemberRoutingModule,
    SharedModule
  ]
})
export class MemberModule { }
