import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from './material.module';
import { CrudActionComponent } from './components/crud-action/crud-action.component';



@NgModule({
  declarations: [CrudActionComponent],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports:[
    MaterialModule,
    CrudActionComponent
  ]
})
export class SharedModule { }
