import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Vendedor } from '../models/vendedor';
import { VendedorService } from '../services/vendedor.service';

@Component({
  selector: 'app-factura-add',
  templateUrl: './factura-add.component.html',
  styleUrls: ['./factura-add.component.css']
})
export class FacturaAddComponent implements OnInit {
  vendedores:Vendedor[];
  fecha: Date = new Date();
  fechaDeHoy = this.fecha.getDate() + '/0' + (1+this.fecha.getMonth()) + '/' + this.fecha.getFullYear();
  constructor(private route: ActivatedRoute,private vendedorService: VendedorService) { }
  ngOnInit() {
    this.getAll();
    
  }

  getAll(){
    this.vendedorService.getvendedor().subscribe(vendedores=>this.vendedores=vendedores);
    }
}
