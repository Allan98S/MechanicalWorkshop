using System;
using System.Collections.Generic;
using System.Text;

namespace TallerMecanicoLibrary.Domain
{
    public class Cliente
    {
        int codCliente;
        string numIdentificacion;
        string nombre;
        string apellidos;
        string telefono;
        string telefonoCelular;
        string direccion;
        string correo;

        public string NumIdentificacion { get => numIdentificacion; set => numIdentificacion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string TelefonoCelular { get => telefonoCelular; set => telefonoCelular = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Correo { get => correo; set => correo = value; }
        public int CodCliente { get => codCliente; set => codCliente = value; }

        public Cliente()
        {
        }
        public String toString()
        {
            return " Cod cliente "+this.codCliente+ " Identificacion " + this.numIdentificacion + " Nombre " + this.nombre + " Apellidos " + this.apellidos + " Telefono " + this.telefono + " Telefono Celular "
                + this.telefonoCelular + " Direccion " + this.direccion + " Correo " + this.correo;

        }
    }
}
