export class Vehiculo {
    codVehiculo: number;
    numPlaca: string;
    color: string;
    marca: string;
    estilo: string;
    anio: string;
    potencia: string;
    cilindraje: string;
    capacidad: number;
    peso:number;
    numChasis:number;
    numMotor: number;
    observaciones: string;

    constructor(codVehiculo: number, numPlaca: string, color: string, marca: string, estilo: string, anio: string, potencia: string, cilindraje: string,
        capacidad: number, peso: number, numChasis: number, numMotor: number, observaciones: string)
    {
      
        this.codVehiculo = codVehiculo;
        this.numPlaca = numPlaca;
        this.color = color
        this.marca = marca;
        this.estilo = estilo;
        this.anio = anio;
        this.potencia = potencia;
        this.cilindraje = cilindraje;
        this.capacidad = capacidad;
        this.peso = peso;
        this.numChasis = numChasis;
        this.numMotor = numMotor;
        this.observaciones = observaciones;


    }

}