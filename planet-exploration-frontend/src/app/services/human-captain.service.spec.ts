import { TestBed } from '@angular/core/testing';

import { HumanCaptainService } from './human-captain.service';

describe('HumanCaptainService', () => {
  let service: HumanCaptainService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HumanCaptainService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
