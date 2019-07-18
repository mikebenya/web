import { Component, OnInit } from '@angular/core';
import { ProductoService } from '../services/producto.service';
import { Producto } from '../models/producto';
import { CheckboxControlValueAccessor } from '@angular/forms';
import { Alert } from 'selenium-webdriver';
import { DetalleFacturaService } from '../services/detalle-factura.service';
import { FacturaDetalle } from '../models/FacturaDetalle';
import { ClienteService } from '../services/cliente.service';
import { Cliente } from '../models/cliente';
import { ActivatedRoute } from '@angular/router';
import { MaestraFactura } from '../models/maestra-factura';
import { Vendedor } from '../models/vendedor';
import { VendedorService } from '../services/vendedor.service';
import { FacturaMaestroService } from '../services/factura-maestro.service';

@Component({
  selector: 'app-detalle-fadd',
  templateUrl: './detalle-fadd.component.html',
  styleUrls: ['./detalle-fadd.component.css']
})
export class DetalleFAddComponent implements OnInit {
  factura:MaestraFactura;
  detalles:FacturaDetalle[];
  vendedores:Vendedor[];
  clientes: Cliente[];
  productos: Producto[];
  fecha: Date = new Date();
  fechaDeHoy: string = this.fecha.getDate() + '/' + this.fecha.getMonth() + '/' + this.fecha.getFullYear();
  constructor(private facturaMaestroService: FacturaMaestroService,private route: ActivatedRoute, private productoService: ProductoService, private detalleFacturaService: DetalleFacturaService, private clienteService: ClienteService,private vendedorService: VendedorService) { }
  canti = 1;
  
  ngOnInit() {
    this.getAlll();
    this.getAllvendedor();
    this.factura = { maestro_id: '', maestro_fecha_fac: null, maestro_total: 0, maestro_cc_cliente: null, maestro_facDetalles: null, maestro_cc_vendedor: '', cliente: null,vendedor:null };
    this.productos = this.productoService.getComprar();
    //  this. llenarDetalles();
    this.listaDetalles();
  }

  getAlll() {
    this.clienteService.getCliente().subscribe(clientes => this.clientes = clientes);
  }
  

  getCliente(id: number) {
    this.clienteService.get(id)
  }

  addFactura() {
    this.facturaMaestroService.addFactura(this.factura)
    .subscribe(factura => {
    alert('Se agrego una factura')
    });
    }

  getAllvendedor(){
    this.vendedorService.getvendedor().subscribe(vendedores=>this.vendedores=vendedores);
    }

    listaDetalles(){
      var index=0;
      
      for (let item of this.productos) {
        this.detalles[index].detalle_id=item.producto_id;
        this.detalles[index].detalle_cod_producto=item.producto_id;
        this.detalles[index].producto=item;
        this.detalles[index].detalle_precio_ven=item.producto_precio;
        index+=1;
      }
      this.factura.maestro_facDetalles=this.detalles;
    }

    llenarDetalles(){
      for (let index = 0; index < this.productos.length,this.detalles=[]; index++) {
        const item = this.productos[index];
        this.detalles[index].detalle_id=item.producto_id;
        this.detalles[index].detalle_cod_producto=item.producto_id;
        this.detalles[index].producto=item;
        this.detalles[index].detalle_precio_ven=item.producto_precio;
      }
      this.factura.maestro_facDetalles=this.detalles;
    }

}
