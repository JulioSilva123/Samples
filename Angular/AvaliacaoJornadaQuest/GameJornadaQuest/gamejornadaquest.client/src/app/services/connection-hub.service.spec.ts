import { TestBed } from '@angular/core/testing';

import { ConnectionHubService } from './connection-hub.service';

describe('ConnectionHubService', () => {
  let service: ConnectionHubService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ConnectionHubService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
