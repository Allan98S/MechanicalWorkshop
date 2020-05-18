using System;
using System.Collections.Generic;
using System.Text;

namespace TallerMecanicoLibrary.Domain
{
    public class DetalleVehiculo
    {
        int idDetalleVehiculo;
        int cantidad;
        string observaciones;
        TipoDetalle tipoDetalle;
        Estado estado;

        public DetalleVehiculo()
        {
            this.TipoDetalle = new TipoDetalle();
            this.estado = new Estado();
        }

        public int IdDetalleVehiculo { get => idDetalleVehiculo; set => idDetalleVehiculo = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public TipoDetalle TipoDetalle { get => tipoDetalle; set => tipoDetalle = value; }
        public Estado Estado { get => estado; set => estado = value; }

        public String toString()
        {
            return "IdDetalle " + this.idDetalleVehiculo + " Cantidad " + this.cantidad + " Observaciones " + this.observaciones
                +" Detalle "+this.tipoDetalle.toString()+" Estado "+this.estado.toString();
        }
    }
}
