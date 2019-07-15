import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalleFListComponent } from './detalle-flist.component';

describe('DetalleFListComponent', () => {
  let component: DetalleFListComponent;
  let fixture: ComponentFixture<DetalleFListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetalleFListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetalleFListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
