export class Cliente {
    codCliente?: number;
    numIdentificacion?: string;
    nombre?: string;
    apellidos?: string;
    telefono?: string;
    telefonoCelular?: string;
    direccion?: string;
    correo?: string;
    //Using Parameter Unpacking
    constructor(codCliente?: number, numIdentificacion?: string, nombre?: string, apellidos?: string, telefono?: string, telefonoCelular?: string, direccion?: string,
        correo?: string) {
        this.codCliente = codCliente;
        this.numIdentificacion = numIdentificacion;
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.telefono = telefono;
        this.telefonoCelular = telefonoCelular;
        this.direccion = direccion;
        this.correo = correo;


        
            
    }
}