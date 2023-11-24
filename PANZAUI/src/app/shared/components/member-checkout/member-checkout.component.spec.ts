import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MemberCheckoutComponent } from './member-checkout.component';

describe('MemberCheckoutComponent', () => {
  let component: MemberCheckoutComponent;
  let fixture: ComponentFixture<MemberCheckoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MemberCheckoutComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MemberCheckoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
