import { TestBed } from '@angular/core/testing';

import { PolicyserviceService } from './policyservice.service';

describe('PolicyserviceService', () => {
  let service: PolicyserviceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PolicyserviceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
