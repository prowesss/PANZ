import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewPaymentMethodComponent } from './view-payment-method.component';

describe('ViewPaymentMethodComponent', () => {
  let component: ViewPaymentMethodComponent;
  let fixture: ComponentFixture<ViewPaymentMethodComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewPaymentMethodComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewPaymentMethodComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
