import { Component, OnInit } from '@angular/core';
import { ProductoService } from '../services/producto.service';
import { Producto } from '../models/producto';
import { DetalleFacturaService } from '../services/detalle-factura.service';
import { FacturaDetalle } from '../models/FacturaDetalle';
import { CheckboxControlValueAccessor } from '@angular/forms';
import { Alert } from 'selenium-webdriver';
@Component({
  selector: 'app-producto-list',
  templateUrl: './producto-list.component.html',
  styleUrls: ['./producto-list.component.css']
})
export class ProductoListComponent implements OnInit {

  detalleFacturas : FacturaDetalle[];
  producto : Producto;
  productos: Producto[];
  constructor(private productoService: ProductoService, private detalleFacturaService: DetalleFacturaService) { }
  filterPost = '';
  detalles: FacturaDetalle[];
  ngOnInit() {
    this.getAll();
    this.producto = { producto_id: '', producto_nombre: '',  producto_precio: 0, producto_descripcion: '', producto_imagen: '',producto_costo:0 ,producto_iva:0 ,producto_estado:false};
    
  }


  getAll() {
    this.productoService.getProducto().subscribe(productos => this.productos = productos);
  }

  buy(){
    const compra = this.productos.filter(compras => compras.producto_estado === true );
   
 
    localStorage.clear();
    localStorage.setItem('compra',JSON.stringify(compra));
    alert(JSON.stringify(localStorage.getItem('compra')));
   
  }

}