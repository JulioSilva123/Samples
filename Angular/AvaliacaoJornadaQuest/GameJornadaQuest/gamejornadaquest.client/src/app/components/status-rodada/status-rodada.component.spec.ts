import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StatusRodadaComponent } from './status-rodada.component';

describe('StatusRodadaComponent', () => {
  let component: StatusRodadaComponent;
  let fixture: ComponentFixture<StatusRodadaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [StatusRodadaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StatusRodadaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
