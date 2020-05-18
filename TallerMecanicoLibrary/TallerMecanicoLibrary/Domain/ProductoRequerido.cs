using System;
using System.Collections.Generic;
using System.Text;

namespace TallerMecanicoLibrary.Domain
{
    public class ProductoRequerido
    {
        int idProducto;
        string material;
        int cantidad;
        int pedido;
        float precio;
     

        public ProductoRequerido()
        {
           
        }

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public string Material { get => material; set => material = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int Pedido { get => pedido; set => pedido = value; }
        public float Precio { get => precio; set => precio = value; }
       

        public String toString()
        {
            return "IdProducto " + this.idProducto + " Material " + this.material + " Cantidad " + this.cantidad + " Pedido " + this.pedido + " Precio " + this.Precio;
        }
    }
}