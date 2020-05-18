using System;
using System.Collections.Generic;
using System.Text;

namespace TallerMecanicoLibrary.Domain
{
   public  class TipoDetalle
    {
        int idTipoDetalle;
        string descripcion;

        public TipoDetalle()
        {
        }
        public TipoDetalle(int idTipoDetalle, string descripcion)
        {
            this.idTipoDetalle = idTipoDetalle;
            this.descripcion = descripcion;
        }

        public int IdTipoDetalle { get => idTipoDetalle; set => idTipoDetalle = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }

        public String toString()
        {
            return "IdTipoDetalle " + this.idTipoDetalle + " Descripcion " + this.descripcion;
        }
    }

}
