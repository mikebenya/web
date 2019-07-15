import { Injectable, Inject } from '@angular/core';
import { Producto } from '../models/producto';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of, observable } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class ProductoService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  addComprar(producto: Producto){
    let productos:Producto[]=[];
    if(localStorage.getItem('productos')!=null){
      productos=JSON.parse(localStorage.getItem('productos'));
    }
    productos.push(producto);
    localStorage.setItem('productos',JSON.stringify(productos));
  }

  getComprar():Producto[]{
    return JSON.parse(localStorage.getItem('compra'));
  }

  addProducto(producto: Producto): Observable<Producto> {
    return this.http.post<Producto>(this.baseUrl + 'api/producto', producto, httpOptions).pipe(
      tap((newProducto: Producto) => this.log(`se agregó id=${newProducto.producto_id}`)),
      catchError(this.handleError<Producto>('addProducto'))
    );
  }

  getProducto(): Observable<Producto[]> {
    return this.http.get<Producto[]>(this.baseUrl + 'api/producto')
      .pipe(
        tap(_ => this.log("busqueda")),
        catchError(this.handleError<Producto[]>('getProducto', []))
      );
  }

  get(id: number): Observable<Producto> {

    const url = `${this.baseUrl + 'api/producto'}/${id}`;

    return this.http.get<Producto>(url).pipe(
      tap(_ => this.log(`fallo busqueda id=${id}`)),
      catchError(this.handleError<Producto>(`get id=${id}`))
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


