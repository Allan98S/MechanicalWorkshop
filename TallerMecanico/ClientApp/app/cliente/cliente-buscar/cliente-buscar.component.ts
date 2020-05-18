import { Component, OnInit } from "@angular/core"
import { ClienteService } from "../../Service/cliente.service";
import { Cliente } from "../../Model/cliente";
import { Router } from "@angular/router";
@Component({
    selector: 'app-cliente-buscar',
    templateUrl: './cliente-buscar.component.html',
    styleUrls: ['./cliente-buscar.component.css']
})
export class ClienteListaComponent implements OnInit {
    private clientes: Cliente[] = new Array<Cliente>();
    private identificacion: String;

    constructor(private clienteService: ClienteService, private router: Router) {

    }
    ngOnInit() {

    }

    getClientePorIdentificacion(identificacion: string) {
        //console.log(identificacion);
        this.clientes = this.clienteService.getClientePorId(identificacion);

        //console.log(this.clientes[0].numIdentificacion);

    }
    modificarDatos(cliente: Cliente): void {
        this.clienteService.setClienteActual(cliente);
        //this.router.navigate(['/editarCliente']);
    }


}