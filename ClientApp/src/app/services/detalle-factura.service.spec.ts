import { TestBed } from '@angular/core/testing';

import { DetalleFacturaService } from './detalle-factura.service';

describe('DetalleFacturaService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DetalleFacturaService = TestBed.get(DetalleFacturaService);
    expect(service).toBeTruthy();
  });
});
