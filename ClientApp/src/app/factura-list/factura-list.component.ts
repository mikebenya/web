import { Component, OnInit } from '@angular/core';
import { MaestraFactura } from '../models/maestra-factura';
import { FacturaMaestroService } from '../services/factura-maestro.service';

@Component({
  selector: 'app-factura-list',
  templateUrl: './factura-list.component.html',
  styleUrls: ['./factura-list.component.css']
})
export class FacturaListComponent implements OnInit {

  Facturas: MaestraFactura[];
  constructor(private facturaService: FacturaMaestroService) { }

  ngOnInit() {
    this.getVentas();
  }

  getVentas() {
    this.facturaService.getCliente().subscribe(Facturas => this.Facturas = Facturas);
  }
}
