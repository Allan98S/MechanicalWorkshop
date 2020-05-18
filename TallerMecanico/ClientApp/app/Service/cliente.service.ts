import { Injectable, Inject, EventEmitter } from '@angular/core';
import { Http, Headers, Response, URLSearchParams, RequestOptions} from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Cliente } from '../Model/cliente';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class ClienteService {
    private url = 'http://localhost:62319';
    private clientes: Cliente[] = new Array<Cliente>();
    private clienteActual: Cliente;
    constructor(private http: Http) { }

    setClienteActual(cliente: Cliente):void {
        this.clienteActual = cliente;
    }
    getClienteActual(): Cliente {
        return this.clienteActual;
    }

    getAllClientes(): Observable<Cliente[]> {
       return  this.http.get("/api/taller/cliente/").map(response => response.json());
       
    }

    getClientePorId(identificacion: string): Cliente[] {
        this.http.get( "/api/taller/cliente/" + identificacion).subscribe((response) => this.clientes = response.json());
        console.log( "/api/taller/cliente/" + identificacion);
        return this.clientes;
    }
    getClientePorNombre(nombre: string):Cliente[] {
        this.http.get("/api/taller/cliente/nombre" + nombre).subscribe((response) => this.clientes = response.json());
        return this.clientes;
    }

    modificar(cliente: Cliente): Promise<Cliente> {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json; charset=utf-8');
        console.log("/api/vehiculos/" + cliente.codCliente);
        return this.http.put("/api/taller/cliente/" + cliente.codCliente, cliente, { headers: headers }).toPromise().then(this.extractData);
    }

    registrarCliente(cliente: Cliente): Promise<Cliente> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        return this.http.post("/api/taller/cliente/", cliente, options).toPromise().then(this.extractData);
    }
    borrarCliente(cliente: Cliente): Promise<Cliente> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        console.log("/api/taller/cliente/" + cliente.codCliente, { headers: headers });
        return this.http.delete("/api/taller/cliente/" + cliente.codCliente, { headers: headers }).toPromise().then(this.extractData);
    }
  
    private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }
}