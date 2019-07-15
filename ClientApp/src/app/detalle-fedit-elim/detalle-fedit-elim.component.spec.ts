import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalleFEditElimComponent } from './detalle-fedit-elim.component';

describe('DetalleFEditElimComponent', () => {
  let component: DetalleFEditElimComponent;
  let fixture: ComponentFixture<DetalleFEditElimComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetalleFEditElimComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetalleFEditElimComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
