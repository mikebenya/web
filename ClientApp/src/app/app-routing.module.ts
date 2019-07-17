import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { ClienteAddComponent } from './cliente-add/cliente-add.component';
import { ClienteListComponent } from './cliente-list/cliente-list.component';
import { ClienteEditElimComponent } from './cliente-edit-elim/cliente-edit-elim.component';
import { ProductoAddComponent } from './producto-add/producto-add.component';
import { ProductoListComponent } from './producto-list/producto-list.component';
import { DetalleFAddComponent } from './detalle-fadd/detalle-fadd.component';
import { FacturaAddComponent } from './factura-add/factura-add.component';
import { MenuComponent } from './menu/menu.component';
import { FacturaListComponent } from './factura-list/factura-list.component';

const routes: Routes = [
  { path:'clientesAdd', component:ClienteAddComponent },
  { path:'menu', component:MenuComponent },
  { path:'clientesList', component:ClienteListComponent },
  { path:'clientesEditElim/:cliente_id', component:ClienteEditElimComponent },
  { path:'productoAdd', component:ProductoAddComponent },
  { path:'productoList', component:ProductoListComponent },
  { path:'detalle', component:DetalleFAddComponent },
  { path:'detalle/:cliente_id', component:DetalleFAddComponent },
  { path:'factura', component:FacturaAddComponent },
  { path:'facturaLista', component:FacturaListComponent },
  ];



  @NgModule({
    imports: [ RouterModule.forRoot(routes) ],
    exports: [ RouterModule ]
  })
export class AppRoutingModule { }