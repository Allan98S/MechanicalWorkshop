import { Component, OnInit } from '@angular/core';
import { Vehiculo } from '../Model/vehiculo';
import { Cliente } from '../Model/cliente';
import { VehiculoService } from '../Service/vehiculo.service';
import { ClienteService } from '../Service/cliente.service';
import { DetalleVehiculo } from '../Model/detalleVehiculo';
import { Estado } from '../Model/estado';
import { TipoDetalle } from '../Model/TipoDetalle';
import { OrdenTrabajo } from '../Model/ordenTrabajo';
import { DetalleTrabajoService } from '../Service/detalle-trabajo.service';
import { OrdenTrabajoService } from '../Service/orden-trabajo.service';
import { DetalleTrabajo } from '../Model/DetalleTrabajo';

@Component({
    selector: 'app-ordenTrabajo',
    templateUrl: './ordenTrabajo.component.html',
    styleUrls: ['./ordenTrabajo.component.css']
})
export class OrdenTrabajoComponent implements OnInit {

    private vehiculos: Vehiculo[] = new Array<Vehiculo>();
    private clientes: Cliente[] = new Array<Cliente>();
    private detalleTrabajoVacia: DetalleTrabajo[] = new Array<DetalleTrabajo>();
    private listaTipoDetalles: TipoDetalle[] = new Array<TipoDetalle>();
    private detallesVehiculo: DetalleVehiculo[] = new Array<DetalleVehiculo>();
    private placas: String[] = new Array<String>(); 
    private clienteIdentificacion: string;
    private vehiculoPlaca: string;
    private fecha: string;
    private descripcion: string;
    private estado: string;
    private detalle: string;
    private observacion: string;
    private cliente: Cliente;
    private vehiculo: Vehiculo;
    private estado2: boolean = false;

    constructor(private vehiculoService: VehiculoService, private clienteService: ClienteService, private detalleTrabajoService: DetalleTrabajoService,
        private ordenService: OrdenTrabajoService) {
        this.vehiculoService.getAllVehiculos().subscribe(data => this.vehiculos = data);

        this.clienteService.getAllClientes().subscribe(data => this.clientes = data);
    }

    ngOnInit() {

        

    }

    getAllVehiculos(): Vehiculo[] {
        console.log(this.vehiculos.toString);
        return this.vehiculos;

    }


    getAllClientes(): Cliente[] {
        return this.clientes;
    }
    setCliente(cliente: Cliente) {
        this.cliente = cliente;
    }
    setVehiculo(vehiculo: Vehiculo) {
        this.vehiculo = vehiculo;
    }
    registrar(): void {
        var fecha = new Date(this.fecha);
        console.log('Registrar '+this.detallesVehiculo.length);
        var orden = new OrdenTrabajo(0, this.descripcion, fecha, 0, this.detalleTrabajoVacia, this.detallesVehiculo, this.cliente, this.vehiculo);
        this.ordenService.registrarOrden(orden);
        this.estado2 = true;
    }
    registrarDetalle(): void {
        var estado: Estado = new Estado(0, this.estado);
        var detalle: TipoDetalle = new TipoDetalle(0, this.detalle);
        var detalleVehiculo: DetalleVehiculo = new DetalleVehiculo(0, 1, this.observacion, detalle, estado);
        this.detallesVehiculo.push(detalleVehiculo);

    }
    getDetallesVehiculoRealizados(): DetalleVehiculo[] {
        console.log('Observaciones ' + this.detallesVehiculo[0].estado.descripcion);
        return this.detallesVehiculo;
    }
   

    isEmpty(): boolean {
        if (this.detallesVehiculo[0] == undefined) {
            return true;
        }
        return false;
    }
    getEstado(): boolean {
        return this.estado2;
    }


}