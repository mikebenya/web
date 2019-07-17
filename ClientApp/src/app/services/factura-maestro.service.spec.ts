import { TestBed } from '@angular/core/testing';

import { FacturaMaestroService } from './factura-maestro.service';

describe('FacturaMaestroService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: FacturaMaestroService = TestBed.get(FacturaMaestroService);
    expect(service).toBeTruthy();
  });
});
