import { TestBed } from '@angular/core/testing';

import { MaestraFacturaService } from './maestra-factura.service';

describe('MaestraFacturaService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: MaestraFacturaService = TestBed.get(MaestraFacturaService);
    expect(service).toBeTruthy();
  });
});
