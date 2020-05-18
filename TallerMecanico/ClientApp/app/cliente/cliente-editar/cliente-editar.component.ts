import { Component, OnInit } from "@angular/core"
import { ClienteService } from "../../Service/cliente.service";
import { Cliente } from "../../Model/cliente";

@Component({
    selector: 'app-cliente-editar',
    templateUrl: './cliente-editar.component.html',
    styleUrls: ['./cliente-editar.component.css']
})
export class ClienteEditarComponent implements OnInit {
    private cliente: Cliente[] = new Array<Cliente>();
    private identificacion?: string;
    private nombre?: string;
    private apellidos?: string;
    private telefono?: string;
    private telefonoCelular?: string;
    private direccion?: string;
    private email?: string;
    private codCliente?: number;
    private estado: boolean = false;

    constructor(private clienteService: ClienteService) {
        this.cliente[0] = this.clienteService.getClienteActual();
        //console.log(this.cliente[0].codCliente);
        this.codCliente = this.cliente[0].codCliente;
        this.identificacion = this.cliente[0].numIdentificacion;
        this.nombre = this.cliente[0].nombre;
        this.apellidos = this.cliente[0].apellidos;
        this.telefono = this.cliente[0].telefono;
        this.telefonoCelular = this.cliente[0].telefonoCelular;
        this.direccion = this.cliente[0].direccion;
        this.email = this.cliente[0].correo;

    }
    ngOnInit() {

    }

    modificarDatos(): void {
        var cliente: Cliente = new Cliente(this.codCliente, this.identificacion, this.nombre, this.apellidos, this.telefono, this.telefonoCelular,
            this.direccion, this.email);
        console.log(cliente.codCliente);
        this.clienteService.modificar(cliente);
        this.estado = true;
        this.cliente = new Array<Cliente>();
    }

    getEstado(): boolean {
        return this.estado;
    }
}