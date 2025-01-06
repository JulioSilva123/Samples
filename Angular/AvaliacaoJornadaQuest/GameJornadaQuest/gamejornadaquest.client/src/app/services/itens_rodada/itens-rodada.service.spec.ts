import { TestBed } from '@angular/core/testing';

import { ItensRodadaService } from './itens-rodada.service';

describe('ItensRodadaService', () => {
  let service: ItensRodadaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ItensRodadaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
