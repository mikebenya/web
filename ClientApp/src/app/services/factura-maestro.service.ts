import { Injectable, Inject } from '@angular/core';
import {HttpClient, HttpErrorResponse} from '@angular/common/http';
import { catchError, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { MaestraFactura } from '../models/maestra-factura';


@Injectable({
  providedIn: 'root'
})
export class FacturaMaestroService {

  private log( varMensaje: string) {
    alert('Mensaje de sistema:' + varMensaje);
  }
  constructor(@Inject('BASE_URL') private baseUrl: string, private http: HttpClient) { }

  getFacturas(): Observable<MaestraFactura[]>{
    return this.http.get<MaestraFactura[]>(this.baseUrl + 'api/FacturaMaestro')
    .pipe(
      catchError(this.handleError<MaestraFactura[]>('Facturas_GetFacturas', []) )
    );
  }

  addFactura(maestraFactura: MaestraFactura): Observable<MaestraFactura> {
    return this.http.post<MaestraFactura>(this.baseUrl + 'api/cliente', maestraFactura).pipe(
      tap((newFactura: MaestraFactura) => this.log(`added NewSocio w/ id=${newFactura.maestro_id}`)),
      catchError(this.handleError<MaestraFactura>('addCliente'))
    );
  }
  getCliente(): Observable<MaestraFactura[]> {
    return this.http.get<MaestraFactura[]>(this.baseUrl + 'api/FacturaMaestro')
      .pipe(
        tap(_ => this.log("Lista Cargada")),
        catchError(this.handleError<MaestraFactura[]>('getCliente', []))
      );
  }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: HttpErrorResponse): Observable<T> => {
  // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.status}`);
  // Let the app keep running by returning an empty result.
      return of(result as T);
  };
}
}
