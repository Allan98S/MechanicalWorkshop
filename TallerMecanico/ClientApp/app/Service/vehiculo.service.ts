import { Injectable, Inject, EventEmitter } from '@angular/core';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { Http, RequestOptions, Headers, Response, URLSearchParams } from '@angular/http';
import { Vehiculo } from '../Model/vehiculo';

@Injectable()
export class VehiculoService {
    vehiculoSelected = new EventEmitter<Vehiculo>();
    vehiculoActual: Vehiculo;
    private url: 'http://localhost:62319';
    private vehiculos: Vehiculo[] = new Array<Vehiculo>();

    constructor(private http: Http) {

    }
    getAllVehiculos(): Observable<Vehiculo[]> {
        return this.http.get("/api/taller/vehiculos/").map(response => response.json());
   
    }

    getVehiculosPorPlaca(placa: String): Vehiculo[] {
        this.http.get("/api/taller/vehiculos/" + placa).subscribe((response) => this.vehiculos = response.json());
        return this.vehiculos;
    }

    setVehiculoActual(vehiculo: Vehiculo): void {
        this.vehiculoActual = vehiculo;
    }

    getVehiculoActual(): Vehiculo {
        return this.vehiculoActual;
    }

    modificar(vehiculo: Vehiculo): Promise<Vehiculo> {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json; charset=utf-8');
        console.log("/api/vehiculos/" + vehiculo.codVehiculo, vehiculo, { headers: headers });
        return this.http.put("/api/taller/vehiculos/"+  vehiculo.codVehiculo, vehiculo, { headers: headers }).toPromise().then(this.extractData);
    }
    registrar(vehiculo: Vehiculo): Promise<Vehiculo> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        return this.http.post("/api/taller/vehiculos/", vehiculo, options).toPromise().then(this.extractData);
    }

    private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }
}