import { Injectable, Inject } from '@angular/core';
import { Cliente } from '../models/cliente';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of, observable } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  addCliente(cliente: Cliente): Observable<Cliente> {
    return this.http.post<Cliente>(this.baseUrl + 'api/cliente', cliente, httpOptions).pipe(
      tap((newCliente: Cliente) => this.log(`added NewSocio w/ id=${newCliente.cliente_id}`)),
      catchError(this.handleError<Cliente>('addCliente'))
    );
  }

  getCliente(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(this.baseUrl + 'api/Cliente')
      .pipe(
        tap(_ => this.log("Lista Cargada")),
        catchError(this.handleError<Cliente[]>('getCliente', []))
      );
  }

  get(id: number): Observable<Cliente> {

    const url = `${this.baseUrl + 'api/cliente'}/${id}`;

    return this.http.get<Cliente>(url).pipe(
      tap(_ => this.log(`fetched Socio id=${id}`)),
      catchError(this.handleError<Cliente>(`get id=${id}`))
    );
  }

  update (cliente: Cliente): Observable<any> {
    const url =
    
    `${this.baseUrl + 'api/cliente'}/${cliente.cliente_id}`;
    return this.http.put(url, cliente, httpOptions).pipe(
    tap(_ => this.log(`updated libro isbn=${cliente.cliente_id}`)),
    catchError(this.handleError<any>('libro'))
    );
    }


  delete (cliente: Cliente | number): Observable<Cliente> {
    const id = typeof cliente === 'number' ? cliente : cliente.cliente_id;
    const url =
    
    `${this.baseUrl + 'api/cliente'}/${id}`;
    
    return this.http.delete<Cliente>(url, httpOptions).pipe(
    tap(_ => this.log(`deleted libro isbn=${id}`)),
    catchError(this.handleError<Cliente>('deleteTask'))
    );
    }


  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      this.log(`${operation} Fallo Listado: ${error.message}`);
      return of(result as T);
    };
  }

  private log(message: string) {
    alert(`ServicioCliente: ${message}`);
  }
}
