import { Component, OnInit } from '@angular/core';
import { Cliente } from '../models/cliente';
import { ClienteService } from '../services/cliente.service';

@Component({
  selector: 'app-cliente-add',
  templateUrl: './cliente-add.component.html',
  styleUrls: ['./cliente-add.component.css']
})
export class ClienteAddComponent implements OnInit {

  cliente: Cliente;
  constructor(private clienteService: ClienteService) { }
  ngOnInit() {
    this.cliente = { cliente_id: '', cliente_nombre1: '',cliente_nombre2: '', cliente_apellido1: '',cliente_apellido2: '',cliente_calle:'', cliente_casa: '' ,cliente_barrio:'',cliente_fechaN:null, cliente_telefono: '' ,cliente_email:''};
    }
    
    add() {
      this.clienteService.addCliente(this.cliente)
      .subscribe(cliente => {
      alert('Se agrego un nuevo Socio')
      });
      }
}
