import { DetalleTrabajo } from "./DetalleTrabajo";

export class ProductoRequerido {
    idProducto: number;
    material: string;
    cantidad: number;
    precio: number;
    

    constructor(idProducto: number, material: string, cantidad: number, precio: number, ) {
        this.idProducto = idProducto;
        this.material = material;
        this.cantidad = cantidad;
        this.precio = precio;
     
    }

}