import { TestBed } from '@angular/core/testing';

import { StatusRodadaService } from './status-rodada.service';

describe('StatusRodadaService', () => {
  let service: StatusRodadaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StatusRodadaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
