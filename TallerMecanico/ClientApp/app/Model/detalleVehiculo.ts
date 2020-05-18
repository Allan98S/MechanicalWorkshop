import { TipoDetalle } from "./TipoDetalle";
import { Estado } from "./estado";

export class DetalleVehiculo {
    idDetalleVehiculo: number;
    cantidad: number;
    observaciones: string;
    tipoDetalle: TipoDetalle;
    estado: Estado;

    constructor(idDetalleVehiculo: number, cantidad: number, observaciones: string, tipoDetalle: TipoDetalle, estado: Estado) {
        this.idDetalleVehiculo = idDetalleVehiculo;
        this.cantidad = cantidad;
        this.observaciones = observaciones;
        this.tipoDetalle = tipoDetalle;
        this.estado = estado;
    }

}