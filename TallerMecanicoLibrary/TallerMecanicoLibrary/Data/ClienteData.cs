using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TallerMecanicoLibrary.Domain;

namespace TallerMecanicoLibrary.Data
{
    public class ClienteData
    {
        String connectionString;

        public ClienteData(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public Cliente insertar(Cliente cliente)
        {
            SqlCommand cmdCliente = new SqlCommand();
            cmdCliente.CommandText = "Autoshop_InsertarCliente";
            cmdCliente.CommandType = System.Data.CommandType.StoredProcedure;
            cmdCliente.Parameters.Add(new SqlParameter("@numIdentificacion", cliente.NumIdentificacion));
            cmdCliente.Parameters.Add(new SqlParameter("@nombre", cliente.Nombre));
            cmdCliente.Parameters.Add(new SqlParameter("@apellidos", cliente.Apellidos));
            cmdCliente.Parameters.Add(new SqlParameter("@correo", cliente.Correo));
            cmdCliente.Parameters.Add(new SqlParameter("@telefono", cliente.Telefono));
            cmdCliente.Parameters.Add(new SqlParameter("@telefonoCelular", cliente.TelefonoCelular));
            cmdCliente.Parameters.Add(new SqlParameter("@direccion", cliente.Direccion));
            SqlParameter parCodCliente = new SqlParameter("@codCliente", System.Data.SqlDbType.Int);
            parCodCliente.Direction = System.Data.ParameterDirection.Output;
            cmdCliente.Parameters.Add(parCodCliente);
            SqlConnection connection = new SqlConnection(connectionString);
            SqlTransaction transaction = null;
             try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                cmdCliente.Connection = connection;
                cmdCliente.Transaction = transaction;
                cmdCliente.ExecuteNonQuery();
                transaction.Commit();
            }

            catch (SqlException ex)
            {
                if (transaction != null)
                    transaction.Rollback();
                throw ex;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }//finally
            return cliente;
        }

        public void suprimir(int codCliente)
        {
            Console.Write("ENTRA A BORRAR " + codCliente);
            SqlCommand cmdCliente = new SqlCommand();
            cmdCliente.CommandText = "Autoshop_SuprimirCliente";
            cmdCliente.CommandType = System.Data.CommandType.StoredProcedure;
            cmdCliente.Parameters.Add(new SqlParameter("@codCliente", codCliente));
            SqlConnection connection = new SqlConnection(connectionString);
            SqlTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                cmdCliente.Connection = connection;
                cmdCliente.Transaction = transaction;
                cmdCliente.ExecuteNonQuery();
                transaction.Commit();
            }

            catch (SqlException ex)
            {
                if (transaction != null)
                    transaction.Rollback();
                throw ex;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }//finally

        }
        public Cliente modificar(int codCliente, Cliente cliente)
        {
            SqlCommand cmdCliente = new SqlCommand();
            cmdCliente.CommandText = "Autoshop_ModificarCliente";
            cmdCliente.CommandType = System.Data.CommandType.StoredProcedure;
            cmdCliente.Parameters.Add(new SqlParameter("@codCliente", cliente.CodCliente));
            cmdCliente.Parameters.Add(new SqlParameter("@numIdentificacion", cliente.NumIdentificacion));
            cmdCliente.Parameters.Add(new SqlParameter("@nombre", cliente.Nombre));
            cmdCliente.Parameters.Add(new SqlParameter("@apellidos", cliente.Apellidos));
            cmdCliente.Parameters.Add(new SqlParameter("@correo", cliente.Correo));
            cmdCliente.Parameters.Add(new SqlParameter("@telefono", cliente.Telefono));
            cmdCliente.Parameters.Add(new SqlParameter("@telefonoCelular", cliente.TelefonoCelular));
            cmdCliente.Parameters.Add(new SqlParameter("@direccion", cliente.Direccion));
            SqlConnection connection = new SqlConnection(connectionString);
            SqlTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                cmdCliente.Connection = connection;
                cmdCliente.Transaction = transaction;
                cmdCliente.ExecuteNonQuery();
                transaction.Commit();
            }

            catch (SqlException ex)
            {
                if (transaction != null)
                    transaction.Rollback();
                throw ex;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }//finally
            return cliente;
        }
        public List<Cliente> getAll()
        {

            String sqlSelect = "Select  cod_cliente,num_identificacion,nombre,apellidos,correo,telefono,telefono_celular,direccion "
                    + " from Cliente ";
           

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
