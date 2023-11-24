import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from './material.module';
import { CrudActionComponent } from './components/crud-action/crud-action.component';
import { MembershipTypeCardComponent } from './components/membership-type-card/membership-type-card.component';
import { MemberCheckoutComponent } from './components/member-checkout/member-checkout.component';



@NgModule({
  declarations: [CrudActionComponent, MembershipTypeCardComponent, MemberCheckoutComponent],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports: [
    MaterialModule,
    CrudActionComponent,
    MembershipTypeCardComponent,
    MemberCheckoutComponent
  ]
})
export class SharedModule { }
