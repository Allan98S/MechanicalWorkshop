using System;
using System.Collections.Generic;
using System.Text;

namespace TallerMecanicoLibrary.Domain
{
   public class OrdenTrabajo
    {
        int idOrden;
        string descripcionSolicitudTrabajo;
        DateTime fecha;
        float precio;
        List<DetalleTrabajo> listaDetallesTrabajo;
        List<DetalleVehiculo> listaDetalleVehiculo;
        Cliente cliente;
        Vehiculo vehiculo;
        public OrdenTrabajo()
        {
            this.ListaDetallesTrabajo = new List<DetalleTrabajo>();
            this.ListaDetalleVehiculo = new List<DetalleVehiculo>();
            this.cliente = new Cliente();
            this.vehiculo = new Vehiculo();
         
        }

        public int IdOrden { get => idOrden; set => idOrden = value; }
        public string DescripcionSolicitudTrabajo { get => descripcionSolicitudTrabajo; set => descripcionSolicitudTrabajo = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public float Precio { get => precio; set => precio = value; }

        public Cliente Cliente { get => cliente; set => cliente = value; }
        public Vehiculo Vehiculo { get => vehiculo; set => vehiculo = value; }
        public List<DetalleVehiculo> ListaDetalleVehiculo { get => listaDetalleVehiculo; set => listaDetalleVehiculo = value; }
        public List<DetalleTrabajo> ListaDetallesTrabajo { get => listaDetallesTrabajo; set => listaDetallesTrabajo = value; }

        public String toStringLista()
        {
            String salida = "";
            foreach (var item in this.ListaDetallesTrabajo)
            {
                DetalleTrabajo detalleAux = item;
                salida += detalleAux.ToString() + " ";
            }
            return salida;
        }
        public String toStringLista2()
        {
            String salida = "";
            foreach (var item in this.listaDetalleVehiculo)
            {
                DetalleVehiculo detalleAux = item;
                salida += detalleAux.toString() + " ";
            }
            return salida;
        }

        public String toString()
        {
            return "Orden " + this.idOrden + " Descripcion " + this.descripcionSolicitudTrabajo + " Fecha " + this.fecha + " Precio " + this.precio + " Detalles Trabajo " +
             toStringLista() + " Cliente " + this.cliente.toString() + " Vehiculo " + this.vehiculo.ToString()+" Detalle Vehiculo "+toStringLista2();
        }


    }
}
