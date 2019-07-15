import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalleFAddComponent } from './detalle-fadd.component';

describe('DetalleFAddComponent', () => {
  let component: DetalleFAddComponent;
  let fixture: ComponentFixture<DetalleFAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetalleFAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetalleFAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
