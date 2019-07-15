import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ClienteService } from '../services/cliente.service';
import { Cliente } from '../models/cliente';
import { Location } from '@angular/common';

@Component({
  selector: 'app-cliente-edit-elim',
  templateUrl: './cliente-edit-elim.component.html',
  styleUrls: ['./cliente-edit-elim.component.css']
})
export class ClienteEditElimComponent implements OnInit {

  cliente: Cliente;
  stask: string;
  constructor
    (
      private route: ActivatedRoute,
      private clienteService: ClienteService,
      private location: Location
    ) { }
  ngOnInit() {
    this.get();
  }

  get(): void {
    const id =
      +this.route.snapshot.paramMap.get('cliente_id');
    this.clienteService.get(id)
      .subscribe(hero => this.cliente = hero);
  }
  update(): void {
    this.clienteService.update(this.cliente)
      .subscribe(() => this.goBack());
  }
  delete(): void {
    this.clienteService.delete(this.cliente)
      .subscribe(() => this.goBack());
  }
  goBack(): void {
    this.location.back();
  }

}
