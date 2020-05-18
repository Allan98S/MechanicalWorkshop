import { Component, OnInit, Input } from '@angular/core';

import { VehiculoService } from '../../Service/vehiculo.service';
import { Vehiculo } from '../../Model/vehiculo';
import { ClienteService } from '../../Service/cliente.service';
import { Cliente } from '../../Model/cliente';

@Component({
    selector: 'app-vehiculo-registrar',
    templateUrl: './vehiculo-registrar.component.html',
    styleUrls: ['./vehiculo-registrar.component.css']
})
export class VehiculoRegistrarComponent implements OnInit {
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
    private estado: boolean = false;
    constructor(private vehiculoService: VehiculoService) {
       
    }

    ngOnInit() {
  
    }
  
    registrar(): void {
        var vehiculo: Vehiculo = new Vehiculo(this.numVehiculo, this.placa, this.color, this.marca, this.estilo, this.anio, this.potencia, this.cilindraje
            , this.capacidad, this.peso, this.numChasis, this.numMotor, this.observaciones);
        this.vehiculoService.registrar(vehiculo);
        this.estado = true;
    }
    getEstado(): boolean {
        return this.estado;
    }


}
