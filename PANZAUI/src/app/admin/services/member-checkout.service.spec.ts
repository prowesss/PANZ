import { TestBed } from '@angular/core/testing';

import { MemberCheckoutService } from './member-checkout.service';

describe('MemberCheckoutService', () => {
  let service: MemberCheckoutService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MemberCheckoutService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
