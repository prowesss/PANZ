import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MainMembershipTypeComponent } from './main-membership-type.component';

describe('MainMembershipTypeComponent', () => {
  let component: MainMembershipTypeComponent;
  let fixture: ComponentFixture<MainMembershipTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MainMembershipTypeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MainMembershipTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
