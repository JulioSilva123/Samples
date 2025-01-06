import { TestBed } from '@angular/core/testing';

import { ItensRodadaClicksService } from './itens-rodada-clicks.service';

describe('ItensRodadaClicksService', () => {
  let service: ItensRodadaClicksService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ItensRodadaClicksService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
