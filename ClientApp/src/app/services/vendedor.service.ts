import { Injectable, Inject } from '@angular/core';
import { Vendedor } from '../models/vendedor';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of, observable } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})

export class VendedorService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }


  addvendedor(vendedor: Vendedor): Observable<Vendedor> {
    return this.http.post<Vendedor>(this.baseUrl + 'api/vendedor', vendedor, httpOptions).pipe(
      tap((newVendedor: Vendedor) => this.log(`se agregó id=${newVendedor.vendedor_id}`)),
      catchError(this.handleError<Vendedor>('addVendedor'))
    );
  }

  getvendedor(): Observable<Vendedor[]> {
    return this.http.get<Vendedor[]>(this.baseUrl + 'api/vendedor')
      .pipe(
        tap(_ => this.log("busqueda")),
        catchError(this.handleError<Vendedor[]>('getProducto', []))
      );
  }

  get(id: number): Observable<Vendedor> {

    const url = `${this.baseUrl + 'api/vendedor'}/${id}`;

    return this.http.get<Vendedor>(url).pipe(
      tap(_ => this.log(`fallo busqueda id=${id}`)),
      catchError(this.handleError<Vendedor>(`get id=${id}`))
    );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      this.log(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }

  private log(message: string) {
    alert(`SocioService: ${message}`);
  }

}


