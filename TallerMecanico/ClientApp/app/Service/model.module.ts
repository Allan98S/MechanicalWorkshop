import { NgModule } from '@angular/core';
import { ClienteService } from './cliente.service';
import { VehiculoService } from './vehiculo.service';
import { ProductoRequeridoService } from './producto.service';
import { DetalleTrabajoService } from './detalle-trabajo.service';
import { OrdenTrabajoService } from './orden-trabajo.service';
/*Decorator*/
@NgModule({
    providers: [ClienteService, VehiculoService, ProductoRequeridoService, DetalleTrabajoService, OrdenTrabajoService]
})

export class ModelModule { }