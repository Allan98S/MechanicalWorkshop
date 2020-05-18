import { Component, OnInit } from '@angular/core';
import { VehiculoService } from '../../Service/vehiculo.service';
import { Vehiculo } from '../../Model/vehiculo';

@Component({
    selector: 'app-vehiculo-listar',
    templateUrl: './vehiculo-lista.component.html',
    styleUrls: ['./vehiculo-lista.component.css']
})
export class VehiculoListaComponent implements OnInit {
    private vehiculos: Vehiculo[] = new Array<Vehiculo>();
    private numeroPlaca: string;
    constructor(private vehiculoService: VehiculoService) {
    }

    ngOnInit() {
    
    }

    getVehiculosPorPlaca() {
        this.vehiculos = this.vehiculoService.getVehiculosPorPlaca(this.numeroPlaca);
    }
    modificarDatos(vehiculo: Vehiculo): void {
       // console.log(vehiculo.marca);
      //  this.vehiculoService.vehiculoSelected.emit(vehiculo);
        this.vehiculoService.setVehiculoActual(vehiculo);
    }

}
