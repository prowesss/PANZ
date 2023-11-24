import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MembershipTypeCardComponent } from './membership-type-card.component';

describe('MembershipTypeCardComponent', () => {
  let component: MembershipTypeCardComponent;
  let fixture: ComponentFixture<MembershipTypeCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MembershipTypeCardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MembershipTypeCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
