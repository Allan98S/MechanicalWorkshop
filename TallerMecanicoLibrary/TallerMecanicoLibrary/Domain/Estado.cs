using System;
using System.Collections.Generic;
using System.Text;

namespace TallerMecanicoLibrary.Domain
{
    public class Estado
    {
        int idEstado;
        string descripcion;

        public Estado()
        {
        }
        public Estado(int idEstado, string descripcion)
        {
            this.idEstado = idEstado;
            this.descripcion = descripcion;

        }

        public int IdEstado { get => idEstado; set => idEstado = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }

        public String toString()
        {
            return "IdEstado " + this.idEstado + " Descripcion " + this.descripcion;
        }
    }
}
