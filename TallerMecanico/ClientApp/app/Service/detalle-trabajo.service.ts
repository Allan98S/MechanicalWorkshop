import { Injectable, Inject, EventEmitter } from '@angular/core';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { Http, RequestOptions, Headers, Response, URLSearchParams } from '@angular/http';
import { DetalleTrabajo } from '../Model/DetalleTrabajo';
import { OrdenTrabajo } from '../Model/ordenTrabajo';

@Injectable()
export class DetalleTrabajoService {
    private url: 'http://localhost:62319';
    private ordenActual: OrdenTrabajo;
    constructor(private http: Http) {

    }

    setOrden(orden: OrdenTrabajo) {
        this.ordenActual = orden;
    }

    registrarDetalleTrabajo(detalleTrabajo: DetalleTrabajo, idOrden: number): Promise<DetalleTrabajo> {
        //this.ordenActual.listaDetallesTrabajo.push(detalleTrabajo);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        return this.http.post("/api/taller/detalleTrabajo/" + idOrden,detalleTrabajo, options).toPromise().then(this.extractData);
    }

    private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }
}