import { Injectable, Inject, EventEmitter } from '@angular/core';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { Http, RequestOptions, Headers, Response, URLSearchParams } from '@angular/http';
import {ProductoRequerido  } from '../Model/productoRequerido';
@Injectable()
export class ProductoRequeridoService {
    private productoRequerido: ProductoRequerido[] = new Array<ProductoRequerido>();
    private url: 'http://localhost:62319';
    constructor(private http: Http) {

    }
    getAllProductos(): Observable<ProductoRequerido[]> {
       return this.http.get("/api/taller/producto/").map(response => response.json());
      
    }
    getProductosPorMaterial(material: string): Observable<ProductoRequerido[]> {
        return this.http.get("/api/taller/producto/" + material).map(response => response.json());
    }

}
