using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TallerMecanicoLibrary.Domain;

namespace TallerMecanicoLibrary.Data
{
    public class ProductoData
    {
        String connectionString;

        public ProductoData(string connectionString)
        {
            this.connectionString = connectionString;
        }

       public List<ProductoRequerido> getPorMaterial(String material)
        {
            String sqlSelect = "Select id_producto,material, cantidad,pedido,p.precio,p.id_detalle_trabajo " +
                " from ProductoRequerido p where  material like '%" + material + "%'" ;
            Console.WriteLine(sqlSelect);
            SqlDataAdapter daProducto = new SqlDataAdapter(sqlSelect, new SqlConnection(connectionString));

            DataSet dsProducto = new DataSet();
            daProducto.Fill(dsProducto, "ProductoRequerido");
            Dictionary<Int32, ProductoRequerido> dictionary = new Dictionary<Int32, ProductoRequerido>();
            ProductoRequerido producto = null;
            foreach (DataRow row in dsProducto.Tables["ProductoRequerido"].Rows)
            {
                Int32 id = Int32.Parse(row["id_producto"].ToString());
                if (dictionary.ContainsKey(id) == false)
                {
                    producto = new ProductoRequerido();
                    producto.IdProducto = id;
                    producto.Material = row["material"].ToString();
                    producto.Cantidad = Int32.Parse(row["cantidad"].ToString());
                    producto.Pedido = Int32.Parse(row["pedido"].ToString());
                    producto.Precio = (float)Double.Parse(row["precio"].ToString());
                    dictionary.Add(id, producto);
                } // if

            } // for
            return dictionary.Values.ToList<ProductoRequerido>();
        }
        public List<ProductoRequerido> getAll()
        {

            String sqlSelect = "Select id_producto,material, cantidad,pedido,p.precio,p.id_detalle_trabajo " +
                " from ProductoRequerido p ";
            Console.WriteLine(sqlSelect);
            SqlDataAdapter daProducto = new SqlDataAdapter(sqlSelect, new SqlConnection(connectionString));

            DataSet dsProducto = new DataSet();
            daProducto.Fill(dsProducto, "ProductoRequerido");
            Dictionary<Int32, ProductoRequerido> dictionary = new Dictionary<Int32, ProductoRequerido>();
            ProductoRequerido producto = null;
            foreach (DataRow row in dsProducto.Tables["ProductoRequerido"].Rows)
            {
                Int32 id = Int32.Parse(row["id_producto"].ToString());
                if (dictionary.ContainsKey(id) == false)
                {
                    producto = new ProductoRequerido();
                    producto.IdProducto = id;
                    producto.Material = row["material"].ToString();
                    producto.Cantidad = Int32.Parse(row["cantidad"].ToString());
                    producto.Pedido = Int32.Parse(row["pedido"].ToString());
                    producto.Precio = (float)Double.Parse(row["precio"].ToString());               
                    dictionary.Add(id, producto);
                } // if

            } // for
            return dictionary.Values.ToList<ProductoRequerido>();
        }
        public List<Cliente> getClientePorCedula(String identificacion)
        {

            String sqlSelect = "	Select  cod_cliente,num_identificacion,nombre,apellidos,correo,telefono,telefono_celular,direccion "
                    + " from Cliente "
                    + " Where num_identificacion like '%" + identificacion + "%'";
            Console.Write(sqlSelect);
            SqlDataAdapter daVehiculos = new SqlDataAdapter(sqlSelect, new SqlConnection(connectionString));

            DataSet dsCliente = new DataSet();
            daVehiculos.Fill(dsCliente, "Cliente");
            Dictionary<Int32, Cliente> dictionary = new Dictionary<Int32, Cliente>();
            Cliente cliente = null;
            foreach (DataRow row in dsCliente.Tables["Cliente"].Rows)
            {
                Int32 id = Int32.Parse(row["cod_cliente"].ToString());
                if (dictionary.ContainsKey(id) == false)
                {
                    cliente = new Cliente();
                    cliente.CodCliente = id;
                    cliente.NumIdentificacion = row["num_identificacion"].ToString();
                    cliente.Nombre = row["nombre"].ToString();
                    cliente.Apellidos = row["apellidos"].ToString();
                    cliente.Correo = row["correo"].ToString();
                    cliente.Telefono = row["telefono"].ToString();
                    cliente.TelefonoCelular = row["telefono_celular"].ToString();
                    cliente.Direccion = row["direccion"].ToString();
                    /*  DateTime fecha = Convert.ToDateTime(row["anio"]);
                      vehiculo.Año = fecha;
                      */
                    dictionary.Add(id, cliente);
                } // if

            } // for
            return dictionary.Values.ToList<Cliente>();
        }
        public List<Cliente> getClientePorNombre(String nombre)
        {

            String sqlSelect = "	Select  cod_cliente,num_identificacion,nombre,apellidos,correo,telefono,telefono_celular,direccion "
                    + " from Cliente "
                    + " Where nombre like '%" + nombre + "%'";
            Console.Write(sqlSelect);
            SqlDataAdapter daVehiculos = new SqlDataAdapter(sqlSelect, new SqlConnection(connectionString));

            DataSet dsCliente = new DataSet();
            daVehiculos.Fill(dsCliente, "Cliente");
            Dictionary<Int32, Cliente> dictionary = new Dictionary<Int32, Cliente>();
            Cliente cliente = null;
            foreach (DataRow row in dsCliente.Tables["Cliente"].Rows)
            {
                Int32 id = Int32.Parse(row["cod_cliente"].ToString());
                if (dictionary.ContainsKey(id) == false)
                {
                    cliente = new Cliente();
                    cliente.CodCliente = id;
                    cliente.NumIdentificacion = row["num_identificacion"].ToString();
                    cliente.Nombre = row["nombre"].ToString();
                    cliente.Apellidos = row["apellidos"].ToString();
                    cliente.Correo = row["correo"].ToString();
                    cliente.Telefono = row["telefono"].ToString();
                    cliente.TelefonoCelular = row["telefono_celular"].ToString();
                    cliente.Direccion = row["direccion"].ToString();
                    /*  DateTime fecha = Convert.ToDateTime(row["anio"]);
                      vehiculo.Año = fecha;
                      */
                    dictionary.Add(id, cliente);
                } // if

            } // for
            return dictionary.Values.ToList<Cliente>();
        }

    }
}
