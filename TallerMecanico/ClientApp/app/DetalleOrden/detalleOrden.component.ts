import { Component, OnInit } from '@angular/core';
import { Vehiculo } from '../Model/vehiculo';
import { VehiculoService } from '../Service/vehiculo.service';
import { ProductoRequerido } from '../Model/productoRequerido';
import { ProductoRequeridoService } from '../Service/producto.service';
import { DetalleTrabajo } from '../Model/DetalleTrabajo';
import { DetalleTrabajoService } from '../Service/detalle-trabajo.service';
import { OrdenTrabajo } from '../Model/ordenTrabajo';
import { OrdenTrabajoService } from '../Service/orden-trabajo.service';

@Component({
    selector: 'app-detalleOrden',
    templateUrl: './detalleOrden.component.html',
    styleUrls: ['./detalleOrden.component.css']
})
export class DetalleOrdenComponent implements OnInit {
    private vehiculos: Vehiculo[] = new Array<Vehiculo>();
    private productos: ProductoRequerido[] = new Array<ProductoRequerido>();
    private productosEscogidos: ProductoRequerido[] = new Array<ProductoRequerido>();
    material: string = '';
    descripcion: string = '';
    ordenes: OrdenTrabajo[] = new Array<OrdenTrabajo>();
    ordenEscogida: OrdenTrabajo;
    private estado: boolean = false;
    constructor(private vehiculoService: VehiculoService, private productoService: ProductoRequeridoService, private detalleTrabajoService: DetalleTrabajoService,
        private ordenService: OrdenTrabajoService) {
        this.vehiculoService.getAllVehiculos().subscribe(data => this.vehiculos = data);
        this.productoService.getAllProductos().subscribe(data => this.productos = data);
        //this.ordenActual = this.detalleTrabajoService.getOrdenActual();
        this.ordenService.getAllOrdenes().subscribe(data => this.ordenes = data);
        /* cambiar a getTotasOrdenes */
    }

    ngOnInit() {
    
    }

    setOrden(orden: OrdenTrabajo) {
        this.ordenEscogida = orden;
    }

    getProductosPorMaterial(): void {
        this.productoService.getProductosPorMaterial(this.material).subscribe(data => this.productos = data);
    }
    getAllVehiculos(): Vehiculo[]{
        return this.vehiculos;
    }
    agregar(producto: ProductoRequerido): void {
        this.productosEscogidos.push(producto);
    }
    getProductosEscogidos(): ProductoRequerido[] {
        console.log(this.productosEscogidos[0].material);
        return this.productosEscogidos;
    }
    registrar(): void {
        var precioTotal = this.precioTotal();
        console.log("Registrar "+ precioTotal);
        var detalleTrabajo: DetalleTrabajo = new DetalleTrabajo(0, precioTotal, this.descripcion, this.productosEscogidos);
        this.detalleTrabajoService.registrarDetalleTrabajo(detalleTrabajo, this.ordenEscogida.idOrden);// capturar idOrden escogida en el combo
        this.estado = true;
    }

    precioTotal(): number {
        var total: number = 0;
        
        for (let entry of this.productosEscogidos) {
            if (entry.precio != undefined) {
                total += entry.precio;
            }
        }
        console.log("Total " + total);
                    return total;
    }
    isEmpty(): boolean {
        if (this.productosEscogidos[0]== undefined) {
            return true;
        }
        return false;
    }

    getEstado(): boolean {
        return this.estado;
    }

}
