import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ClienteAddComponent } from './cliente-add/cliente-add.component';
import { ClienteListComponent } from './cliente-list/cliente-list.component';
import { ClienteEditElimComponent } from './cliente-edit-elim/cliente-edit-elim.component';
import { ProductoAddComponent } from './producto-add/producto-add.component';
import { ProductoListComponent } from './producto-list/producto-list.component';
import { ProductoEditElimComponent } from './producto-edit-elim/producto-edit-elim.component';
import { DetalleFAddComponent } from './detalle-fadd/detalle-fadd.component';
import { DetalleFListComponent } from './detalle-flist/detalle-flist.component';
import { DetalleFEditElimComponent } from './detalle-fedit-elim/detalle-fedit-elim.component';
import { AppRoutingModule } from './app-routing.module';
import { FacturaAddComponent } from './factura-add/factura-add.component';
import { FacturaListComponent } from './factura-list/factura-list.component';
import { FiltroPipe } from './filtro.pipe';
import { FiltroproductosPipe } from './filtro/filtroproductos.pipe';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ClienteAddComponent,
    ClienteListComponent,
    ClienteEditElimComponent,
    ProductoAddComponent,
    ProductoListComponent,
    ProductoEditElimComponent,
    DetalleFAddComponent,
    DetalleFListComponent,
    DetalleFEditElimComponent,
    FacturaAddComponent,
    FacturaListComponent,
    FiltroPipe,
    FiltroproductosPipe
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ]),
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
