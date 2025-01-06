import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItensRodadaComponent } from './itens-rodada.component';

describe('ItensRodadaComponent', () => {
  let component: ItensRodadaComponent;
  let fixture: ComponentFixture<ItensRodadaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ItensRodadaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ItensRodadaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
