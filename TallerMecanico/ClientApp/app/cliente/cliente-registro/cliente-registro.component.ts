import { Component, OnInit } from "@angular/core"
import { ClienteService } from "../../Service/cliente.service";
import { Cliente } from "../../Model/cliente";

@Component({
    selector: 'app-cliente-registro',
    templateUrl: './cliente-registro.component.html',
    styleUrls: ['./cliente-registro.component.css']
})
export class ClienteRegistroComponent implements OnInit {
    private cliente: Cliente[] = new Array<Cliente>();
    private identificacion?: string;
    private nombre?: string;
    private apellidos?: string;
    private telefono?: string;
    private telefonoCelular?: string;
    private direccion?: string;
    private email?: string;
    private codVehiculo?: number;
    private estado: boolean = false;

    constructor(private clienteService: ClienteService) {
       

    }
    ngOnInit() {

    }

    onSubmit(): void {
        var cliente: Cliente = new Cliente(this.codVehiculo, this.identificacion, this.nombre, this.apellidos, this.telefono, this.telefonoCelular,
            this.direccion, this.email);
        this.clienteService.registrarCliente(cliente);
        this.estado = true;
        //this.cliente = new Array<Cliente>();
    }

    getEstado(): boolean {
        return this.estado;
    }
}