import { Injectable, Inject, EventEmitter } from '@angular/core';
import { Http, Headers, Response, URLSearchParams, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { OrdenTrabajo } from '../Model/ordenTrabajo';

@Injectable()
export class OrdenTrabajoService {

    private url = 'http://localhost:62319';

    constructor(private http: Http) { }

    getAllOrdenes(): Observable<OrdenTrabajo[]> {
        return this.http.get("/api/taller/orden/"+1).map(response => response.json());

    }

    registrarOrden(orden: OrdenTrabajo): Promise<OrdenTrabajo> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        return this.http.post("/api/taller/orden/", orden, options).toPromise().then(this.extractData);
    }
    private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }
}

