import { Component, OnInit } from '@angular/core';
import { ProductoService } from '../services/producto.service';
import { Producto } from '../models/producto';

@Component({
  selector: 'app-producto-add',
  templateUrl: './producto-add.component.html',
  styleUrls: ['./producto-add.component.css']
})
export class ProductoAddComponent implements OnInit {

  producto: Producto;
  productos: Producto[];
  constructor(private productoService: ProductoService) { }
  ngOnInit() {
    this.producto = { producto_id: '', producto_nombre: '', producto_precio: 0, producto_descripcion: '', producto_imagen: '', producto_costo: 0, producto_iva: 0, producto_estado: false,};
    // this.getAll();
  }

  add() {
    // this.cargarCodigo();
    this.productoService.addProducto(this.producto).subscribe(cliente => {alert('Se agrego un nuevo Socio')});
  }

  // getAll() {
  //   this.productoService.getProducto().subscribe(dep => this.productos = dep);
  // }
  // cargarCodigo() {
  //   var n = this.productos.length + 1;
  //   this.producto.producto_id = ''+n;
  // }
}
