using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TallerMecanicoLibrary.Domain;

namespace TallerMecanicoLibrary.Data
{
    public class DetalleTrabajoData
    {
        String connectionString;
        public DetalleTrabajoData(string connnectionString)
        {
            this.connectionString = connnectionString;
        }
        public DetalleTrabajo insertar(int idOrden,DetalleTrabajo detalleTrabajo)
        {
            Console.Write(detalleTrabajo.toString());
            SqlCommand cmdDetalleTrabajo = new SqlCommand();
            cmdDetalleTrabajo.CommandText = "Autoshop_InsertarDetalleTrabajo";
            cmdDetalleTrabajo.CommandType = System.Data.CommandType.StoredProcedure;
            cmdDetalleTrabajo.Parameters.Add(new SqlParameter("@precio ", detalleTrabajo.PrecioTotal));
            cmdDetalleTrabajo.Parameters.Add(new SqlParameter("@descripcion", detalleTrabajo.Descripcion));
            cmdDetalleTrabajo.Parameters.Add(new SqlParameter("@idOrdenTrabajo", idOrden));
            SqlParameter parCodDetalle = new SqlParameter("@codDetalle", System.Data.SqlDbType.Int);
            parCodDetalle.Direction = System.Data.ParameterDirection.Output;
            cmdDetalleTrabajo.Parameters.Add(parCodDetalle);


            SqlCommand cmdProductosDetalle = new SqlCommand();
            cmdProductosDetalle.CommandText = "Autoshop_InsertarProductosDetalle";
            cmdProductosDetalle.CommandType = System.Data.CommandType.StoredProcedure;


            SqlConnection connection = new SqlConnection(connectionString);
            SqlTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                cmdProductosDetalle.Connection = connection;
                cmdProductosDetalle.Transaction = transaction;
                cmdDetalleTrabajo.Connection = connection;
                cmdDetalleTrabajo.Transaction = transaction;
                cmdDetalleTrabajo.ExecuteNonQuery();
                int idDetalle = Convert.ToInt32(cmdDetalleTrabajo.Parameters["@codDetalle"].Value);

                foreach (var item in detalleTrabajo.ListaProductosRequeridos)
                {
                    cmdProductosDetalle.Parameters.Add(new SqlParameter("@id ", item.IdProducto));
                    cmdProductosDetalle.Parameters.Add(new SqlParameter("@precio ", item.Precio));
                    cmdProductosDetalle.Parameters.Add(new SqlParameter("@material ", item.Material));
                    cmdProductosDetalle.Parameters.Add(new SqlParameter("@idDetalleTrabajo ", idDetalle));
                    cmdProductosDetalle.ExecuteNonQuery();
                    cmdProductosDetalle.Parameters.Clear();
                }


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
            return detalleTrabajo;
        }
       
    }

    }

