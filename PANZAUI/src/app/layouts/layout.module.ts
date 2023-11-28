import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './navbar/navbar.component';
import { SharedModule } from '../shared/shared.module';
import { SideNavComponent } from './side-nav/side-nav.component';
import { RouterModule } from '@angular/router';
import { BlankComponent } from './blank/blank.component';
import { LayoutComponent } from './layout/layout.component';

@NgModule({
  declarations: [NavbarComponent, SideNavComponent, BlankComponent, LayoutComponent],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule
  ],
  exports: [NavbarComponent, SideNavComponent, BlankComponent, LayoutComponent]
})
export class LayoutModule { }
