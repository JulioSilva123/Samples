import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RodadasComponent } from './rodadas.component';

describe('RodadasComponent', () => {
  let component: RodadasComponent;
  let fixture: ComponentFixture<RodadasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RodadasComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RodadasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
