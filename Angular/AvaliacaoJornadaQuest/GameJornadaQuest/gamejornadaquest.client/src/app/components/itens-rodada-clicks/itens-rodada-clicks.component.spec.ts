import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItensRodadaClicksComponent } from './itens-rodada-clicks.component';

describe('ItensRodadaClicksComponent', () => {
  let component: ItensRodadaClicksComponent;
  let fixture: ComponentFixture<ItensRodadaClicksComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ItensRodadaClicksComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ItensRodadaClicksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
