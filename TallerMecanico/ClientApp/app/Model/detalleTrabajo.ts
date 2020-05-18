import { ProductoRequerido } from "./productoRequerido";
import { OrdenTrabajo } from "./ordenTrabajo";

export class DetalleTrabajo {
    idDetalleTrabajo: number;
    precioTotal: number;
    descripcion: string;
    listaProductosRequeridos: ProductoRequerido[];
  

    constructor(idDetalleTrabajo: number, precioTotal: number, descripcion: string, listaProductosRequeridos: ProductoRequerido[]) {
        this.idDetalleTrabajo = idDetalleTrabajo;
        this.precioTotal = precioTotal;
        this.descripcion = descripcion;
        this.listaProductosRequeridos = listaProductosRequeridos;
      
    }
}