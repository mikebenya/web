import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../services/cliente.service';
import { Cliente } from '../models/cliente';


@Component({
  selector: 'app-cliente-list',
  templateUrl: './cliente-list.component.html',
  styleUrls: ['./cliente-list.component.css']
})
export class ClienteListComponent implements OnInit {

  clientes:Cliente[];
  constructor(private clienteService: ClienteService) { }
  filterPost = '';

  ngOnInit() {
    this.getAll();
    }
    getAll(){
    this.clienteService.getCliente().subscribe(clientes=>this.clientes=clientes);
    }

}
