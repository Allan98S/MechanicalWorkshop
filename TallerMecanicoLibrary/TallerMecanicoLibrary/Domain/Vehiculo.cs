using System;
using System.Collections.Generic;
using System.Text;

namespace TallerMecanicoLibrary.Domain
{
    public class Vehiculo
    {
        int codVehiculo;
        string numPlaca;
        string color;
        string marca;
        string estilo;
        string anio;
        string potencia;
        string cilindraje;
        int capacidad;
        float peso;
        int numChasis;
        int numMotor;
        string observaciones;

        public string NumPlaca { get => numPlaca; set => numPlaca = value; }
        public string Color { get => color; set => color = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Estilo { get => estilo; set => estilo = value; }
        public string Anio { get => anio; set => anio = value; }
        public string Potencia { get => potencia; set => potencia = value; }
        public string Cilindraje { get => cilindraje; set => cilindraje = value; }
        public int Capacidad { get => capacidad; set => capacidad = value; }
        public float Peso { get => peso; set => peso = value; }
        public int NumChasis { get => numChasis; set => numChasis = value; }
        public int NumMotor { get => numMotor; set => numMotor = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public int CodVehiculo { get => codVehiculo; set => codVehiculo = value; }

        public Vehiculo(int codVehiculo, string numPlaca, string color, string marca, string estilo,
                string anio, string potencia, string cilindraje, int capacidad, float peso,
                int numChasis, int numMotor, string observaciones)
        {
            this.codVehiculo = codVehiculo;
            this.numPlaca = numPlaca;
            this.color = color;
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

        public Vehiculo()
        {

        }

        public override string ToString()
        {
            return " Codigo vehiculo " + this.codVehiculo + "Num placa " + this.numPlaca + " Color " + this.color + " Marca " + this.marca + " Estilo " + this.estilo + " Año " + this.anio +
            " Potencia " + this.potencia + " Capacidada " + this.capacidad + " Peso " + this.peso + " Numero chasis " + this.numChasis + " Numero motor " +
            this.numMotor + " Observaciones " + this.observaciones;
        }
    }
}

