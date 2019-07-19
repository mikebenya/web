import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductoService } from '../services/producto.service';
import { Producto } from '../models/producto';
import { Location } from '@angular/common';

@Component({
  selector: 'app-producto-edit-elim',
  templateUrl: './producto-edit-elim.component.html',
  styleUrls: ['./producto-edit-elim.component.css']
})
export class ProductoEditElimComponent implements OnInit {

  producto: Producto;
  stask: string;
  constructor
    (
      private route: ActivatedRoute,
      private productoService: ProductoService,
      private location: Location
    ) { }
  ngOnInit() {
    this.get();
  }

  get(): void {
    const id =
      +this.route.snapshot.paramMap.get('producto_id');
    this.productoService.get(id)
      .subscribe(hero => this.producto = hero);
  }
  update(): void {
    this.productoService.update(this.producto)
      .subscribe(() => this.goBack());
  }
  delete(): void {
    this.productoService.delete(this.producto)
      .subscribe(() => this.goBack());
  }
  goBack(): void {
    this.location.back();
  }

}
