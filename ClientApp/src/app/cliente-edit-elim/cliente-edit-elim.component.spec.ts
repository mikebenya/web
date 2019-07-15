import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ClienteEditElimComponent } from './cliente-edit-elim.component';

describe('ClienteEditElimComponent', () => {
  let component: ClienteEditElimComponent;
  let fixture: ComponentFixture<ClienteEditElimComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ClienteEditElimComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ClienteEditElimComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
