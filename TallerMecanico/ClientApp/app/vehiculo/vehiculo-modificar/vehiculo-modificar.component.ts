import { Component, OnInit, Input } from '@angular/core';

import { VehiculoService } from '../../Service/vehiculo.service';
import { Vehiculo } from '../../Model/vehiculo';

@Component({
    selector: 'app-vehiculo-modificar',
    templateUrl: './vehiculo-modificar.component.html',
    styleUrls: ['./vehiculo-modificar.component.css']
})
export class VehiculoModificarComponent implements OnInit {
   // @Input() vehiculo: Vehiculo;
    private vehiculo: Vehiculo[] = new Array<Vehiculo>();
    numVehiculo: number;
    placa: string;
    color: string;
    marca: string;
    estilo: string;
    anio: string;
    potencia: string;
    cilindraje: string;
    capacidad: number;
    peso: number;
    numChasis: number;
    numMotor: number;
    observaciones: string;

    constructor(private vehiculoService: VehiculoService) {
        this.vehiculo[0] = this.vehiculoService.getVehiculoActual();
        //console.log(this.vehiculo[0].marca);
        this.numVehiculo = this.vehiculo[0].codVehiculo;
        this.placa = this.vehiculo[0].numPlaca;
        this.color = this.vehiculo[0].color;
        this.marca = this.vehiculo[0].marca;
        this.estilo = this.vehiculo[0].estilo;
        this.anio = this.vehiculo[0].anio;
        this.potencia = this.vehiculo[0].potencia;
        this.cilindraje = this.vehiculo[0].cilindraje;
        this.capacidad = this.vehiculo[0].capacidad;
        this.peso = this.vehiculo[0].peso;
        this.observaciones = this.vehiculo[0].observaciones;
        this.numChasis = this.vehiculo[0].numChasis;
        this.numMotor = this.vehiculo[0].numMotor;




    }

    ngOnInit() {
  
    }

    modificarDatos(): void {
        var vehiculo: Vehiculo = new Vehiculo(this.numVehiculo, this.placa, this.color, this.marca, this.estilo, this.anio, this.potencia, this.cilindraje
            , this.capacidad, this.peso, this.numChasis, this.numMotor, this.observaciones);
      
        this.vehiculoService.modificar(vehiculo);

        alert('Ok');
        this.vehiculo = new Array<Vehiculo>();
    }

}
