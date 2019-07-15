import { Component, OnInit } from '@angular/core';
import { ProductoService } from '../services/producto.service';
import { Producto } from '../models/producto';
import { CheckboxControlValueAccessor } from '@angular/forms';
import { Alert } from 'selenium-webdriver';
import { DetalleFacturaService } from '../services/detalle-factura.service';
import { DetalleFactura } from '../models/detalle-factura';
import { ClienteService } from '../services/cliente.service';
import { Cliente } from '../models/cliente';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-detalle-fadd',
  templateUrl: './detalle-fadd.component.html',
  styleUrls: ['./detalle-fadd.component.css']
})
export class DetalleFAddComponent implements OnInit {
  detalleFactura: DetalleFactura;
  clientes: Cliente[];
  cliente: Cliente;
  producto: Producto;
  productos: Producto[];
  constructor(private route: ActivatedRoute, private productoService: ProductoService, private detalleFacturaService: DetalleFacturaService, private clienteService: ClienteService) { }
  canti = 1;
  ngOnInit() {
    this.productos = this.productoService.getComprar();
    this.getAlll();
    this.producto = { producto_id: '', producto_nombre: '', producto_precio: 0, producto_descripcion: '', producto_imagen: '', producto_costo: 0, producto_iva: 0, producto_estado: false };
    this.detalleFactura = { detalle_id: '', detalle_cantidad: 0, detalle_precio_ven: 0, detalle_fecha_det: null, detalle_subtotal: 0, detalle_cod_factura: '', detalle_cod_producto: '' };
  }
  getAlll() {
    this.clienteService.getCliente().subscribe(clientes => this.clientes = clientes);
  }

  getCliente(id: number) {
    this.clienteService.get(id)
  }

  buy() {
    const compra = this.productos.filter(compras => compras.producto_estado);
    localStorage.clear();
    localStorage.setItem('compra', JSON.stringify(compra));
    alert(JSON.stringify(localStorage.getItem('compra')));
  }
}
