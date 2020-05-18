import { DetalleTrabajo } from "./DetalleTrabajo";
import { DetalleVehiculo } from "./detalleVehiculo";
import { Cliente } from "./cliente";
import { Vehiculo } from "./vehiculo";

export class OrdenTrabajo {
    idOrden: number;
    descripcionSolicitudTrabajo: string;
    fecha: Date;
    precio: number;
    listaDetallesTrabajo: DetalleTrabajo[];
    listaDetalleVehiculo: DetalleVehiculo[];
    cliente: Cliente;
    vehiculo: Vehiculo;

    constructor(idOrden: number, descripcionSolicitudTrabajo: string, fecha: Date, precio: number, listaDetallesTrabajo: DetalleTrabajo[], listaDetalleVehiculo
        : DetalleVehiculo[], cliente: Cliente, vehiculo: Vehiculo) {
        this.idOrden = idOrden;
        this.descripcionSolicitudTrabajo = descripcionSolicitudTrabajo;
        this.fecha = fecha;
        this.precio = precio;
        this.listaDetallesTrabajo = listaDetallesTrabajo;
        this.listaDetalleVehiculo = listaDetalleVehiculo;
        this.cliente = cliente;
        this.vehiculo = vehiculo;
    }
    

}