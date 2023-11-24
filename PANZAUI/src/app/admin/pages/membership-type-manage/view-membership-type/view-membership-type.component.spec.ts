import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewMembershipTypeComponent } from './view-membership-type.component';

describe('ViewMembershipTypeComponent', () => {
  let component: ViewMembershipTypeComponent;
  let fixture: ComponentFixture<ViewMembershipTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewMembershipTypeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewMembershipTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
