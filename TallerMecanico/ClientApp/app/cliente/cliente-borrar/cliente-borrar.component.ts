import { Component, OnInit } from "@angular/core"
import { ClienteService } from "../../Service/cliente.service";
import { Cliente } from "../../Model/cliente";
import { Router } from "@angular/router";
@Component({
    selector: 'app-cliente-borrar',
    templateUrl: './cliente-borrar.component.html',
    styleUrls: ['./cliente-borrar.component.css']
})
export class ClienteBorrarComponent implements OnInit {
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
    borrarDatos(cliente: Cliente): void {
        this.clienteService.borrarCliente(cliente);
        //this.router.navigate(['/editarCliente']);
    }


}