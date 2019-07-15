import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductoEditElimComponent } from './producto-edit-elim.component';

describe('ProductoEditElimComponent', () => {
  let component: ProductoEditElimComponent;
  let fixture: ComponentFixture<ProductoEditElimComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductoEditElimComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductoEditElimComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
