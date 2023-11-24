import { TestBed } from '@angular/core/testing';

import { MembershipPaymentStatusService } from './membership-payment-status.service';

describe('MembershipPaymentStatusService', () => {
  let service: MembershipPaymentStatusService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MembershipPaymentStatusService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
