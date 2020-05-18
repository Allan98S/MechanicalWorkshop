using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TallerMecanicoLibrary.Domain;


namespace TallerMecanicoLibrary.Data
{
    public class VehiculoData
    {
        String connectionString;

        public VehiculoData(string connnectionString)
        {
            this.connectionString = connnectionString;
        }
        public Vehiculo Insertar(Vehiculo vehiculo)
        {

            //PRIMER COMANDO
            SqlCommand cmdVehiculo = new SqlCommand();
            cmdVehiculo.CommandText = "Autoshop_InsertarVehiculo";
            cmdVehiculo.CommandType = System.Data.CommandType.StoredProcedure;
            cmdVehiculo.Parameters.Add(new SqlParameter("@numPlaca", vehiculo.NumPlaca));
            cmdVehiculo.Parameters.Add(new SqlParameter("@color", vehiculo.Color));
            cmdVehiculo.Parameters.Add(new SqlParameter("@marca", vehiculo.Marca));
            cmdVehiculo.Parameters.Add(new SqlParameter("@estilo", vehiculo.Estilo));
            cmdVehiculo.Parameters.Add(new SqlParameter("@anio", vehiculo.Anio));
            cmdVehiculo.Parameters.Add(new SqlParameter("@potencia", vehiculo.Potencia));
            cmdVehiculo.Parameters.Add(new SqlParameter("@cilindraje", vehiculo.Cilindraje));
            cmdVehiculo.Parameters.Add(new SqlParameter("@capacidad", vehiculo.Capacidad));
            cmdVehiculo.Parameters.Add(new SqlParameter("@peso", vehiculo.Peso));
            cmdVehiculo.Parameters.Add(new SqlParameter("@numChasis", vehiculo.NumChasis));
            cmdVehiculo.Parameters.Add(new SqlParameter("@numMotor", vehiculo.NumMotor));
            cmdVehiculo.Parameters.Add(new SqlParameter("@observaciones", vehiculo.Observaciones));

            SqlConnection connection = new SqlConnection(connectionString);
            SqlTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
        
                cmdVehiculo.Connection = connection;
                cmdVehiculo.Transaction = transaction;
                cmdVehiculo.ExecuteNonQuery();
               

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
            return vehiculo;
        }

        public Vehiculo modificar(int codVehiculo, Vehiculo vehiculo)
        {
            SqlCommand cmdVehiculo = new SqlCommand();
            cmdVehiculo.CommandText = "AutoShop_ModificarVehiculo";
            cmdVehiculo.CommandType = System.Data.CommandType.StoredProcedure;
            cmdVehiculo.Parameters.Add(new SqlParameter("@codVehiculo", codVehiculo));
            cmdVehiculo.Parameters.Add(new SqlParameter("@numPlaca", vehiculo.NumPlaca));
            cmdVehiculo.Parameters.Add(new SqlParameter("@color", vehiculo.Color));
            cmdVehiculo.Parameters.Add(new SqlParameter("@marca", vehiculo.Marca));
            cmdVehiculo.Parameters.Add(new SqlParameter("@estilo", vehiculo.Estilo));
            cmdVehiculo.Parameters.Add(new SqlParameter("@anio", vehiculo.Anio));
            cmdVehiculo.Parameters.Add(new SqlParameter("@potencia", vehiculo.Potencia));
            cmdVehiculo.Parameters.Add(new SqlParameter("@cilindraje", vehiculo.Cilindraje));
            cmdVehiculo.Parameters.Add(new SqlParameter("@capacidad", vehiculo.Capacidad));
            cmdVehiculo.Parameters.Add(new SqlParameter("@peso", vehiculo.Peso));
            cmdVehiculo.Parameters.Add(new SqlParameter("@numChasis", vehiculo.NumChasis));
            cmdVehiculo.Parameters.Add(new SqlParameter("@numMotor", vehiculo.NumMotor));
            cmdVehiculo.Parameters.Add(new SqlParameter("@observaciones", vehiculo.Observaciones));

            SqlConnection connection = new SqlConnection(connectionString);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                cmdVehiculo.Connection = connection;
                cmdVehiculo.Transaction = transaction;
                cmdVehiculo.ExecuteNonQuery();

                transaction.Commit();
            }
            catch(SqlException e)
            {
                if (transaction != null) transaction.Rollback();
                throw e;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }//finally

            return vehiculo;
        }





        
        public List<Vehiculo> getVehiculosPorPlaca(String placa)
        {

            String sqlSelect = "Select cod_vehiculo, num_placa,color, marca,estilo,anio,potencia,cilindraje,"
                    + " capacidad,peso,num_chasis,num_motor,observaciones from Vehiculo"
                    + " where  num_placa like '%" + placa + "%'";
            Console.Write(sqlSelect);
            SqlDataAdapter daVehiculos = new SqlDataAdapter(sqlSelect, new SqlConnection(connectionString));

            DataSet dsVehiculos = new DataSet();
            daVehiculos.Fill(dsVehiculos, "Vehiculo");
            Dictionary<Int32, Vehiculo> dictionary = new Dictionary<Int32, Vehiculo>();
            Vehiculo vehiculo = null;
            foreach (DataRow row in dsVehiculos.Tables["Vehiculo"].Rows)
            {
                Int32 id = Int32.Parse(row["cod_vehiculo"].ToString());
                if (dictionary.ContainsKey(id) == false)
                {
                    vehiculo = new Vehiculo();
                    vehiculo.CodVehiculo = id;
                    vehiculo.NumPlaca = row["num_placa"].ToString();
                    vehiculo.Color = row["color"].ToString();
                    vehiculo.Marca = row["marca"].ToString();
                    vehiculo.Estilo = row["estilo"].ToString();
                    /*  DateTime fecha = Convert.ToDateTime(row["anio"]);
                      vehiculo.Año = fecha;
                      */ 
                    vehiculo.Anio = row["anio"].ToString();
                    vehiculo.Potencia= row["potencia"].ToString();
                    vehiculo.Cilindraje = row["cilindraje"].ToString();
                    vehiculo.Capacidad = Int32.Parse(row["capacidad"].ToString());
                     vehiculo.Peso =(float) Double.Parse(row["peso"].ToString()); //rev si sirve
                    vehiculo.NumChasis = Int32.Parse(row["num_chasis"].ToString());
                    vehiculo.NumMotor= Int32.Parse(row["num_motor"].ToString());
                    vehiculo.Observaciones=row["observaciones"].ToString();

                    dictionary.Add(id, vehiculo);
                } // if
               
            } // for
            return dictionary.Values.ToList<Vehiculo>();
        } // GetAllMovies

        public List<Vehiculo> getAllVehiculos()
        {

            String sqlSelect = "Select cod_vehiculo, num_placa,color, marca,estilo,anio,potencia,cilindraje,"
                    + " capacidad,peso,num_chasis,num_motor,observaciones from Vehiculo";
            Console.Write(sqlSelect);
            SqlDataAdapter daVehiculos = new SqlDataAdapter(sqlSelect, new SqlConnection(connectionString));

            DataSet dsVehiculos = new DataSet();
            daVehiculos.Fill(dsVehiculos, "Vehiculo");
            Dictionary<Int32, Vehiculo> dictionary = new Dictionary<Int32, Vehiculo>();
            Vehiculo vehiculo = null;
            foreach (DataRow row in dsVehiculos.Tables["Vehiculo"].Rows)
            {
                Int32 id = Int32.Parse(row["cod_vehiculo"].ToString());
                if (dictionary.ContainsKey(id) == false)
                {
                    vehiculo = new Vehiculo();
                    vehiculo.CodVehiculo = id;
                    vehiculo.NumPlaca = row["num_placa"].ToString();
                    vehiculo.Color = row["color"].ToString();
                    vehiculo.Marca = row["marca"].ToString();
                    vehiculo.Estilo = row["estilo"].ToString();
                    vehiculo.Anio = row["anio"].ToString();
                    vehiculo.Potencia = row["potencia"].ToString();
                    vehiculo.Cilindraje = row["cilindraje"].ToString();
                    vehiculo.Capacidad = Int32.Parse(row["capacidad"].ToString());
                    vehiculo.Peso = (float)Double.Parse(row["peso"].ToString()); 
                    vehiculo.NumChasis = Int32.Parse(row["num_chasis"].ToString());
                    vehiculo.NumMotor = Int32.Parse(row["num_motor"].ToString());
                    vehiculo.Observaciones = row["observaciones"].ToString();

                    dictionary.Add(id, vehiculo);
                } // if

            } // for
            return dictionary.Values.ToList<Vehiculo>();
        }


    }

   
   

}
