using System;
using System.Collections.Generic;
using System.Text;

namespace TallerMecanicoLibrary.Domain
{
    public class DetalleTrabajo
    {
        int idDetalleTrabajo;
        float precioTotal;
        string descripcion;
        List<ProductoRequerido> listaProductosRequeridos;


        public DetalleTrabajo()
        {
            this.ListaProductosRequeridos = new List<ProductoRequerido>();

        }

        public int IdDetalleTrabajo { get => idDetalleTrabajo; set => idDetalleTrabajo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public List<ProductoRequerido> ListaProductosRequeridos { get => listaProductosRequeridos; set => listaProductosRequeridos = value; }
        public float PrecioTotal { get => precioTotal; set => precioTotal = value; }

        public String toStringLista()
        {
            String salida = "";
            foreach (var item in this.listaProductosRequeridos)
            {
                ProductoRequerido detalleAux = item;
                salida += detalleAux.ToString() + " ";
            }
            return salida;
        }

        public String toString()
        {
            return "IdDetalle " + this.idDetalleTrabajo + " Precio " + this.precioTotal + " Descripcion " + this.descripcion; 
        }
    }
}
