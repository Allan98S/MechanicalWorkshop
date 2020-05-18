import { Component, OnInit } from '@angular/core';
import { Vehiculo } from '../Model/vehiculo';
import { VehiculoService } from '../Service/vehiculo.service';
import { ProductoRequerido } from '../Model/productoRequerido';
import { ProductoRequeridoService } from '../Service/producto.service';
import { DetalleTrabajo } from '../Model/DetalleTrabajo';
import { DetalleTrabajoService } from '../Service/detalle-trabajo.service';
import { OrdenTrabajo } from '../Model/ordenTrabajo';
import { OrdenTrabajoService } from '../Service/orden-trabajo.service';
import { Cliente } from '../Model/cliente';
import { DetalleVehiculo } from '../Model/detalleVehiculo';

@Component({
    selector: 'app-reporte',
    templateUrl: './reporte.component.html',
    styleUrls: ['./reporte.component.css']
})
export class ReporteComponent implements OnInit {
    private vehiculo: Vehiculo[] = new Array<Vehiculo>();
    private productos: ProductoRequerido[] = new Array<ProductoRequerido>();
    private cliente: Cliente[] = new Array<Cliente>();
    private detalleVehiculo: DetalleVehiculo[] = new Array<DetalleVehiculo>();
    private detalleTrabajo: DetalleTrabajo[] = new Array<DetalleTrabajo>();
    private bandera: string = '';
    ordenes: OrdenTrabajo[] = new Array<OrdenTrabajo>();
    ordenEscogida: OrdenTrabajo;
    ordenArray: OrdenTrabajo[] = new Array<OrdenTrabajo>();
    precioTotal: number;
    constructor(private ordenService: OrdenTrabajoService) {
    
        this.ordenService.getAllOrdenes().subscribe(data => this.ordenes = data);
    }   

    ngOnInit() {

    }

    setOrden(orden: OrdenTrabajo): void {
        this.ordenEscogida = orden;
        this.ordenArray.push(this.ordenEscogida);
        this.bandera = 'true';
        this.precioTotal = this.ordenEscogida.precio;
        this.vehiculo.push(orden.vehiculo);
        this.cliente.push(orden.cliente);
        this.detalleTrabajo = (orden.listaDetallesTrabajo);
        this.detalleVehiculo = orden.listaDetalleVehiculo;
        this.obtieneProductos();
    }
    obtieneProductos(): void {
        for (var item of this.detalleTrabajo) {
            for (var item2 of item.listaProductosRequeridos) {
                this.productos.push(item2);
            }
        }
    }

    isEmpty(): boolean {
        if (this.bandera == 'true') {
            return false;
        }
        return true;
    }

    



}
