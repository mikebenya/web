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
@Component({
  selector: 'app-detalle-fadd',
  templateUrl: './detalle-fadd.component.html',
  styleUrls: ['./detalle-fadd.component.css']
})
export class DetalleFAddComponent implements OnInit {
  detalleFactura: FacturaDetalle;
  vendedores:Vendedor[];
  clientes: Cliente[];
  producto: Producto;
  productos: Producto[];
  fecha: Date = new Date();
  fechaDeHoy: string = this.fecha.getDate() + '/' + this.fecha.getMonth() + '/' + this.fecha.getFullYear();
  constructor(private route: ActivatedRoute, private productoService: ProductoService, private detalleFacturaService: DetalleFacturaService, private clienteService: ClienteService,private vendedorService: VendedorService) { }
  canti = 1;
  ngOnInit() {
    this.productos = this.productoService.getComprar();
    this.getAlll();
    this.getproductos()
    this.getAllvendedor();
    this.producto = { producto_id: '', producto_nombre: '', producto_precio: 0, producto_descripcion: '', producto_imagen: '', producto_costo: 0, producto_iva: 0, producto_estado: false };
    this.detalleFactura = { detalle_id: '', detalle_cantidad: 0, detalle_precio_ven: 0, detalle_fecha_det: null, detalle_subtotal: 0, detalle_cod_factura: '', detalle_cod_producto: '',producto:this.producto,facturaMaestro:null };
  }
  getAlll() {
    this.clienteService.getCliente().subscribe(clientes => this.clientes = clientes);
  }
  getproductos() {
    this.productoService.getProducto().subscribe(productos => this.productos = this.productos);
  }

  getCliente(id: number) {
    this.clienteService.get(id)
  }

  getAllvendedor(){
    this.vendedorService.getvendedor().subscribe(vendedores=>this.vendedores=vendedores);
    }
  buy() {
    const compra = this.productos.filter(compras => compras.producto_estado);
    localStorage.clear();
    localStorage.setItem('compra', JSON.stringify(compra));
    alert(JSON.stringify(localStorage.getItem('compra')));
  }
}
