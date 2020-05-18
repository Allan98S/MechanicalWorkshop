using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TallerMecanicoLibrary.Domain;

namespace TallerMecanicoLibrary.Data
{
    public class OrdenData
    {
        String connectionString;
        OrdenTrabajo orden = new OrdenTrabajo();

        public OrdenData(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public OrdenTrabajo insertar(OrdenTrabajo orden) {
          SqlCommand cmdOrdenTrabajo= new SqlCommand();
            cmdOrdenTrabajo.CommandText = "Autoshop_InsertarOrden";
            cmdOrdenTrabajo.CommandType = System.Data.CommandType.StoredProcedure;
            cmdOrdenTrabajo.Parameters.Add(new SqlParameter("@descripcion", orden.DescripcionSolicitudTrabajo));
            cmdOrdenTrabajo.Parameters.Add(new SqlParameter("@fecha", orden.Fecha));
            cmdOrdenTrabajo.Parameters.Add(new SqlParameter("@precioTotal", orden.Precio));
            cmdOrdenTrabajo.Parameters.Add(new SqlParameter("@numIdentificacion", orden.Cliente.NumIdentificacion));
            cmdOrdenTrabajo.Parameters.Add(new SqlParameter("@numPlaca", orden.Vehiculo.NumPlaca));
            SqlParameter parIdOrden = new SqlParameter("@idOrden", System.Data.SqlDbType.Int);
            parIdOrden.Direction = System.Data.ParameterDirection.Output;
            cmdOrdenTrabajo.Parameters.Add(parIdOrden);

            SqlCommand cmdTipoDetalle = new SqlCommand();
            cmdTipoDetalle.CommandText = "Autoshop_InsertarTipoDetalle";
            cmdTipoDetalle.CommandType = System.Data.CommandType.StoredProcedure;

            SqlCommand cmdEstado = new SqlCommand();
            cmdEstado.CommandText = "Autoshop_InsertarEstado";
            cmdEstado.CommandType = System.Data.CommandType.StoredProcedure;

            SqlCommand cmdDetalleVehiculo = new SqlCommand();
            cmdDetalleVehiculo.CommandText = "Autoshop_InsertarDetalleVehiculo";
            cmdDetalleVehiculo.CommandType = System.Data.CommandType.StoredProcedure;

            SqlConnection connection = new SqlConnection(connectionString);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                cmdOrdenTrabajo.Connection = connection;
                cmdOrdenTrabajo.Transaction = transaction;

                cmdTipoDetalle.Connection = connection;
                cmdTipoDetalle.Transaction = transaction;

                cmdEstado.Connection = connection;
                cmdEstado.Transaction = transaction;

                cmdDetalleVehiculo.Connection = connection;
                cmdDetalleVehiculo.Transaction = transaction;

                cmdOrdenTrabajo.ExecuteNonQuery();
                int idOrden= Convert.ToInt32(cmdOrdenTrabajo.Parameters["@idOrden"].Value);
                //Console.Write("JUJURIJ "+idOrden);
                
                foreach(var item in orden.ListaDetalleVehiculo)
                {
                    Console.Write("BANDERA BANDERA");
                    cmdEstado.Parameters.Add(new SqlParameter("@descripcion", item.Estado.Descripcion));
                    SqlParameter parEstadoId = new SqlParameter("@idEstado", System.Data.SqlDbType.Int);
                    parEstadoId.Direction = System.Data.ParameterDirection.Output;
                    cmdEstado.Parameters.Add(parEstadoId);
                    cmdEstado.ExecuteNonQuery();
                    int idEstado = Convert.ToInt32(cmdEstado.Parameters["@idEstado"].Value);
                    cmdEstado.Parameters.Clear();

                    cmdTipoDetalle.Parameters.Add(new SqlParameter("@descripcion", item.TipoDetalle.Descripcion));
                    SqlParameter parTipoDetalleId = new SqlParameter("@idTipoDetalle", System.Data.SqlDbType.Int);
                    parTipoDetalleId.Direction = System.Data.ParameterDirection.Output;
                    cmdTipoDetalle.Parameters.Add(parTipoDetalleId);
                    cmdTipoDetalle.ExecuteNonQuery();
                    int idTipoDetalle = Convert.ToInt32(cmdTipoDetalle.Parameters["@idTipoDetalle"].Value);
                    cmdTipoDetalle.Parameters.Clear();

                    cmdDetalleVehiculo.Parameters.Add(new SqlParameter("@cantidad", item.Cantidad));
                    cmdDetalleVehiculo.Parameters.Add(new SqlParameter("@observaciones", item.Observaciones));
                    cmdDetalleVehiculo.Parameters.Add(new SqlParameter("@idOrdenTrabajo", idOrden));
                    cmdDetalleVehiculo.Parameters.Add(new SqlParameter("@idTipoDetalle", idTipoDetalle));
                    cmdDetalleVehiculo.Parameters.Add(new SqlParameter("@idEstado", idEstado));

                    SqlParameter parIdDetalleVehiculo = new SqlParameter("@idDetalleVehiculo", System.Data.SqlDbType.Int);
                    parIdDetalleVehiculo.Direction = System.Data.ParameterDirection.Output;
                    cmdDetalleVehiculo.Parameters.Add(parIdDetalleVehiculo);
                    cmdDetalleVehiculo.ExecuteNonQuery();
                    cmdDetalleVehiculo.Parameters.Clear();


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
            return orden;
        }
        public List<OrdenTrabajo> getOrdenCompleta()
        {
            List<OrdenTrabajo> ordenCompleta = new List<OrdenTrabajo>();
            List<OrdenTrabajo> ordenes = ordenInicial();
            foreach (var orden in ordenes)
            {
                orden.ListaDetallesTrabajo = getDetalleTrabajo(orden.IdOrden);
                orden.ListaDetalleVehiculo = getDetalleVehiculo(orden.IdOrden);
                ordenCompleta.Add(orden);
            }
            return ordenCompleta;
        }
        public List<OrdenTrabajo> ordenInicial()
        {
            String sqlSelect = "Select o.id_orden_trabajo, o.descripcion_solicitud_trabajo,o.fecha,o.precio_total,c.num_identificacion,c.cod_cliente,c.nombre,c.apellidos,c.correo, " +
                " c.telefono,c.telefono_celular,c.direccion,c.cod_cliente,o.num_placa,v.cod_vehiculo,	v.color,v.marca,v.estilo,v.anio,v.potencia,v.cilindraje,v.capacidad, " +
                " v.peso,v.num_chasis,v.num_motor,v.observaciones " +
                " from OrdenTrabajo o ,Cliente c, Vehiculo v where c.num_identificacion=o.num_identificacion AND v.num_placa= o.num_placa ";
          //  Console.Write(sqlSelect);
            SqlDataAdapter daOrden = new SqlDataAdapter(sqlSelect, new SqlConnection(connectionString));

            DataSet dsOrden = new DataSet();
            daOrden.Fill(dsOrden, "OrdenTrabajo");

            Dictionary<Int32, OrdenTrabajo> dictionary = new Dictionary<Int32, OrdenTrabajo>();
            OrdenTrabajo orden = null;
            foreach (DataRow row in dsOrden.Tables["OrdenTrabajo"].Rows)
            {
                Int32 id = Int32.Parse(row["id_orden_trabajo"].ToString());
                if (dictionary.ContainsKey(id) == false)
                {
                    orden = new OrdenTrabajo();
                    orden.IdOrden = id;
                    orden.DescripcionSolicitudTrabajo = row["descripcion_solicitud_trabajo"].ToString();
                    DateTime fecha = Convert.ToDateTime(row["fecha"]);
                    orden.Fecha = fecha;
                    orden.Precio = (float)Double.Parse(row["precio_total"].ToString());

                    int codCliente = Int32.Parse(row["cod_cliente"].ToString());
                    if (codCliente > 0)
                    {

                        orden.Cliente.CodCliente = codCliente;
                        orden.Cliente.NumIdentificacion = row["num_identificacion"].ToString();
                        orden.Cliente.Nombre = row["nombre"].ToString();
                        orden.Cliente.Apellidos = row["apellidos"].ToString();
                        orden.Cliente.Correo = row["correo"].ToString();
                        orden.Cliente.Telefono = row["telefono"].ToString();
                        orden.Cliente.TelefonoCelular = row["telefono_celular"].ToString();
                        orden.Cliente.Direccion = row["direccion"].ToString();

                    }

                    int codVehiculo = Int32.Parse(row["cod_vehiculo"].ToString());
                    if (codVehiculo > 0)
                    {
                        orden.Vehiculo.CodVehiculo = codVehiculo;
                        orden.Vehiculo.NumPlaca = row["num_placa"].ToString();
                        orden.Vehiculo.Color = row["color"].ToString();
                        orden.Vehiculo.Marca = row["marca"].ToString();
                        orden.Vehiculo.Estilo = row["estilo"].ToString();
                        orden.Vehiculo.Anio = row["anio"].ToString();
                        orden.Vehiculo.Potencia = row["potencia"].ToString();
                        orden.Vehiculo.Cilindraje = row["cilindraje"].ToString();
                        orden.Vehiculo.Capacidad = Int32.Parse(row["capacidad"].ToString());
                        orden.Vehiculo.Peso = (float)Double.Parse(row["peso"].ToString());
                        orden.Vehiculo.NumChasis = Int32.Parse(row["num_chasis"].ToString());
                        orden.Vehiculo.NumMotor = Int32.Parse(row["num_motor"].ToString());
                        orden.Vehiculo.Observaciones = row["observaciones"].ToString();


                    }
                    dictionary.Add(id, orden);
                }//if
               
            }//for
            return dictionary.Values.ToList<OrdenTrabajo>();

        }

        public List<DetalleVehiculo> getDetalleVehiculo(int idOrden)
        {
            String sqlSelect = "Select  dv.id_detalle_vehiculo,dv.cantidad,dv.observaciones,t.id_tipo_detalle,t.descripcion as'DescripcionTipoDetalle',e.id_estado,e.descripcion " +
            " from DetalleVehiculo dv, TipoDetalle t,Estado e, OrdenTrabajo o where o.id_orden_trabajo=dv.id_orden_trabajo AND " +
            " dv.id_detalle_vehiculo= t.id_tipo_detalle AND e.id_estado= dv.id_estado  AND dv.id_orden_trabajo like '%" + idOrden + "%'";

            SqlDataAdapter daDetalleVehiculo = new SqlDataAdapter(sqlSelect, new SqlConnection(connectionString));
            DataSet dsDetalleVehiculo = new DataSet();
            daDetalleVehiculo.Fill(dsDetalleVehiculo, "DetalleVehiculo");

            Dictionary<Int32, DetalleVehiculo> dictionary = new Dictionary<Int32, DetalleVehiculo>();
            DetalleVehiculo detalleVehiculo = null;
            foreach (DataRow row in dsDetalleVehiculo.Tables["DetalleVehiculo"].Rows)
            {
                Int32 id = Int32.Parse(row["id_detalle_vehiculo"].ToString());
                if (dictionary.ContainsKey(id) == false)
                {
                    detalleVehiculo = new DetalleVehiculo();
                    detalleVehiculo.IdDetalleVehiculo = id;
                    detalleVehiculo.Cantidad = Int32.Parse(row["cantidad"].ToString());
                    detalleVehiculo.Observaciones= row["observaciones"].ToString();
                    detalleVehiculo.Estado.IdEstado= Int32.Parse(row["id_estado"].ToString());
                    detalleVehiculo.Estado.Descripcion= row["descripcion"].ToString();
                    detalleVehiculo.TipoDetalle.IdTipoDetalle= Int32.Parse(row["id_tipo_detalle"].ToString());
                    detalleVehiculo.TipoDetalle.Descripcion= row["DescripcionTipoDetalle"].ToString();
                    dictionary.Add(id, detalleVehiculo);
                }
            }
            return dictionary.Values.ToList<DetalleVehiculo>();
        }
        public List<DetalleTrabajo> getDetalleTrabajo(int idOrden)
        {
            String sqlSelect = "Select dt.id_detalle_trabajo,dt.descripcion,dt.precio,p.id_producto,p.material,p.pedido,p.precio as 'PrecioProducto'  from DetalleTrabajo dt, OrdenTrabajo o,ProductosPedidos p " +
                "  where dt.id_orden_trabajo=o.id_orden_trabajo AND dt.id_detalle_trabajo = p.id_detalle_trabajo AND o.id_orden_trabajo like '%" + idOrden + "%'";
            Console.Write(sqlSelect);
            SqlDataAdapter daDetalleTrabajo = new SqlDataAdapter(sqlSelect, new SqlConnection(connectionString));
            DataSet dsDetalleTrabajo = new DataSet();
            daDetalleTrabajo.Fill(dsDetalleTrabajo, "DetalleTrabajo");

            Dictionary<Int32, DetalleTrabajo> dictionary = new Dictionary<Int32, DetalleTrabajo>();
            DetalleTrabajo detalleTrabajo = null;
            foreach (DataRow row in dsDetalleTrabajo.Tables["DetalleTrabajo"].Rows)
            {
                Int32 id = Int32.Parse(row["id_detalle_trabajo"].ToString());
                if (dictionary.ContainsKey(id) == false)
                {
                    detalleTrabajo = new DetalleTrabajo();
                    detalleTrabajo.IdDetalleTrabajo = id;
                    detalleTrabajo.Descripcion = row["descripcion"].ToString();
                    detalleTrabajo.PrecioTotal= (float)Double.Parse(row["precio"].ToString());
                    dictionary.Add(id, detalleTrabajo);
                }
                int productoId= Int32.Parse(row["id_producto"].ToString());
                if (productoId > 0)
                {
                    ProductoRequerido producto = new ProductoRequerido();
                    producto.IdProducto = productoId;
                    producto.Cantidad = 1;
                    producto.Material= row["material"].ToString();
                    producto.Pedido= Int32.Parse(row["pedido"].ToString());
                    producto.Precio = (float)Double.Parse(row["PrecioProducto"].ToString());
                    detalleTrabajo.ListaProductosRequeridos.Add(producto);
                }
             


            }
            return dictionary.Values.ToList<DetalleTrabajo>();
        }

        public List<OrdenTrabajo> getOrdenParcial()
        {
            String sqlSelect = " Select o.id_orden_trabajo, descripcion_solicitud_trabajo,fecha,precio_total,o.num_identificacion,o.num_placa, " +
                "   c.nombre,c.cod_cliente   ,c.apellidos,c.correo,c.telefono,c.telefono_celular,c.direccion,c.cod_cliente,o.num_placa, " +
                "   v.cod_vehiculo,v.color,   v.marca,v.estilo,v.anio,v.potencia,v.cilindraje,v.capacidad,v.peso,v.num_chasis,v.num_motor, " +
                "  v.observaciones,  dv.id_detalle_vehiculo,dv.cantidad, dv.observaciones,e.id_estado,e.descripcion as 'DescripcionEstado',  " +
                " t.id_tipo_detalle, t.descripcion as 'DescripcionTipoDetalle'  " +
                "  from OrdenTrabajo o, DetalleVehiculo dv, Estado e, TipoDetalle t,Cliente c,Vehiculo v  " +
                "    where  dv.id_orden_trabajo= o.id_orden_trabajo AND  dv.id_tipo_detalle= t.id_tipo_detalle AND  dv.id_estado=e.id_estado " +
                "  AND o.num_identificacion=c.num_identificacion  AND o.num_placa=v.num_placa ";

            Console.Write(sqlSelect);
            SqlDataAdapter daOrden = new SqlDataAdapter(sqlSelect, new SqlConnection(connectionString));

            DataSet dsOrden = new DataSet();
            daOrden.Fill(dsOrden, "OrdenTrabajo");

            Dictionary<Int32, OrdenTrabajo> dictionary = new Dictionary<Int32, OrdenTrabajo>();
            OrdenTrabajo orden = null;
            foreach (DataRow row in dsOrden.Tables["OrdenTrabajo"].Rows)
            {
                Int32 id = Int32.Parse(row["id_orden_trabajo"].ToString());
                if (dictionary.ContainsKey(id) == false)
                {
                    orden = new OrdenTrabajo();
                    orden.IdOrden = id;
                    orden.DescripcionSolicitudTrabajo = row["descripcion_solicitud_trabajo"].ToString();
                    DateTime fecha = Convert.ToDateTime(row["fecha"]);
                    orden.Fecha = fecha;
                //    orden.Precio = (float)Double.Parse(row["precio_total"].ToString());

                    int codCliente = Int32.Parse(row["cod_cliente"].ToString());
                    if (codCliente > 0)
                    {

                        orden.Cliente.CodCliente = codCliente;
                        orden.Cliente.NumIdentificacion = row["num_identificacion"].ToString();
                        orden.Cliente.Nombre = row["nombre"].ToString();
                        orden.Cliente.Apellidos = row["apellidos"].ToString();
                        orden.Cliente.Correo = row["correo"].ToString();
                        orden.Cliente.Telefono = row["telefono"].ToString();
                        orden.Cliente.TelefonoCelular = row["telefono_celular"].ToString();
                        orden.Cliente.Direccion = row["direccion"].ToString();
                        
                    }

                    int codVehiculo = Int32.Parse(row["cod_vehiculo"].ToString());
                    if (codVehiculo > 0)
                    {
                        orden.Vehiculo.CodVehiculo = codVehiculo;
                        orden.Vehiculo.NumPlaca= row["num_placa"].ToString();
                        orden.Vehiculo.Color = row["color"].ToString();
                        orden.Vehiculo.Marca = row["marca"].ToString();
                        orden.Vehiculo.Estilo = row["estilo"].ToString();
                        orden.Vehiculo.Anio= row["anio"].ToString();
                        orden.Vehiculo.Potencia = row["potencia"].ToString();
                        orden.Vehiculo.Cilindraje = row["cilindraje"].ToString();
                        orden.Vehiculo.Capacidad = Int32.Parse(row["capacidad"].ToString());
                        orden.Vehiculo.Peso = (float)Double.Parse(row["peso"].ToString());
                        orden.Vehiculo.NumChasis = Int32.Parse(row["num_chasis"].ToString());
                        orden.Vehiculo.NumMotor = Int32.Parse(row["num_motor"].ToString());
                        orden.Vehiculo.Observaciones = row["observaciones"].ToString();


                    }

                    int idDetalleVehiculo = Int32.Parse(row["id_detalle_vehiculo"].ToString());
                    if (idDetalleVehiculo > 0)
                    {
                        DetalleVehiculo detalleVehiculo = new DetalleVehiculo();
                        detalleVehiculo.IdDetalleVehiculo = idDetalleVehiculo;
                        detalleVehiculo.Cantidad = Int32.Parse(row["cantidad"].ToString());
                        detalleVehiculo.Observaciones = row["observaciones"].ToString();
                        detalleVehiculo.TipoDetalle = new TipoDetalle(Int32.Parse(row["id_tipo_detalle"].ToString()), row["DescripcionTipoDetalle"].ToString());
                        detalleVehiculo.Estado = new Estado(Int32.Parse(row["id_estado"].ToString()), row["DescripcionEstado"].ToString());
                        orden.ListaDetalleVehiculo = new List<DetalleVehiculo>();
                        orden.ListaDetalleVehiculo.Add(detalleVehiculo);
                        //Console.Write("AAAA "+orden.ListaDetalleVehiculo.Count);
                    }
                    dictionary.Add(id, orden);
                }//if
            }//for
            return dictionary.Values.ToList<OrdenTrabajo>();
        }

        public List<OrdenTrabajo> getAll()
        {

            String sqlSelect = "Select o.id_orden_trabajo, descripcion_solicitud_trabajo,fecha,precio_total,o.num_identificacion,o.num_placa,c.nombre,c.cod_cliente, " +
                "  c.apellidos,c.correo,c.telefono,c.telefono_celular,c.direccion,c.cod_cliente,o.num_placa,v.cod_vehiculo,v.color, " +
                "  v.marca,v.estilo,v.anio,v.potencia,v.cilindraje,v.capacidad,v.peso,v.num_chasis,v.num_motor,v.observaciones, "+
                " dv.id_detalle_vehiculo,dv.cantidad, dv.observaciones,e.id_estado,e.descripcion as 'DescripcionEstado',t.id_tipo_detalle, t.descripcion as 'DescripcionTipoDetalle',  " +
                " dt.id_detalle_trabajo,dt.precio,dt.descripcion, p.id_producto,p.material,p.pedido,p.precio as 'PrecioProducto' " +
                " from OrdenTrabajo o, DetalleVehiculo dv, Estado e, TipoDetalle t, DetalleTrabajo dt, ProductosPedidos p,Cliente c,Vehiculo v " +
                "   where  o.id_orden_trabajo=dt.id_orden_trabajo AND  dt.id_detalle_trabajo=p.id_detalle_trabajo AND " +
                "   dv.id_orden_trabajo= o.id_orden_trabajo AND dv.id_tipo_detalle= t.id_tipo_detalle AND " +
                " dv.id_estado=e.id_estado AND o.num_identificacion=c.num_identificacion AND o.num_placa=v.num_placa ";


            Console.Write(sqlSelect);
            SqlDataAdapter daOrden = new SqlDataAdapter(sqlSelect, new SqlConnection(connectionString));

            DataSet dsOrden = new DataSet();
            daOrden.Fill(dsOrden, "OrdenTrabajo");

            Dictionary<Int32, OrdenTrabajo> dictionary = new Dictionary<Int32, OrdenTrabajo>();
            OrdenTrabajo orden = null;
            foreach (DataRow row in dsOrden.Tables["OrdenTrabajo"].Rows)
            {
                Int32 id = Int32.Parse(row["id_orden_trabajo"].ToString());
                if (dictionary.ContainsKey(id) == false)
                {
                    orden = new OrdenTrabajo();
                    orden.IdOrden = id;
                    orden.DescripcionSolicitudTrabajo = row["descripcion_solicitud_trabajo"].ToString();
                    DateTime fecha = Convert.ToDateTime(row["fecha"]);
                    orden.Fecha = fecha;
                 //   orden.Precio = (float)Double.Parse(row["precio_total"].ToString());
                    
                    int codCliente= Int32.Parse(row["cod_cliente"].ToString());
                    if (codCliente > 0)
                    {
                       
                        orden.Cliente.CodCliente = codCliente;
                        orden.Cliente.NumIdentificacion = row["num_identificacion"].ToString();
                        orden.Cliente.Nombre= row["nombre"].ToString();
                        orden.Cliente.Apellidos = row["apellidos"].ToString();
                        orden.Cliente.Correo = row["correo"].ToString();
                        orden.Cliente.Telefono = row["telefono"].ToString();
                        orden.Cliente.TelefonoCelular = row["telefono_celular"].ToString();
                        orden.Cliente.Direccion = row["direccion"].ToString();
                    }

                    int codVehiculo= Int32.Parse(row["cod_vehiculo"].ToString());
                    if (codVehiculo > 0)
                    {
                        orden.Vehiculo.CodVehiculo = codVehiculo;
                        orden.Vehiculo.Color = row["color"].ToString();
                        orden.Vehiculo.Marca = row["marca"].ToString();
                        orden.Vehiculo.Estilo = row["estilo"].ToString();
                        orden.Vehiculo.Potencia = row["potencia"].ToString();
                        orden.Vehiculo.Cilindraje = row["cilindraje"].ToString();
                        orden.Vehiculo.Capacidad = Int32.Parse(row["capacidad"].ToString());
                        orden.Vehiculo.Peso= (float)Double.Parse(row["peso"].ToString());
                        orden.Vehiculo.NumChasis = Int32.Parse(row["num_chasis"].ToString());
                        orden.Vehiculo.NumMotor = Int32.Parse(row["num_motor"].ToString());
                        orden.Vehiculo.Observaciones = row["observaciones"].ToString();


                    }
                    int idDetalleVehiculo = Int32.Parse(row["id_detalle_vehiculo"].ToString());
                    if (idDetalleVehiculo > 0)
                    {
                        DetalleVehiculo detalleVehiculo = new DetalleVehiculo();
                        detalleVehiculo.IdDetalleVehiculo = idDetalleVehiculo;
                        detalleVehiculo.Cantidad = Int32.Parse(row["cantidad"].ToString());
                        detalleVehiculo.Observaciones= row["observaciones"].ToString();
                        detalleVehiculo.TipoDetalle = new TipoDetalle(Int32.Parse(row["id_tipo_detalle"].ToString()), row["DescripcionTipoDetalle"].ToString());
                        detalleVehiculo.Estado = new Estado(Int32.Parse(row["id_estado"].ToString()), row["DescripcionEstado"].ToString());
                        orden.ListaDetalleVehiculo.Add(detalleVehiculo);
                    }
                    int idDetalleTrabajo = Int32.Parse(row["id_detalle_vehiculo"].ToString());
                    if (idDetalleTrabajo > 0)
                    {
                        DetalleTrabajo detalleTrabajo = new DetalleTrabajo();
                        detalleTrabajo.IdDetalleTrabajo = idDetalleTrabajo;
                        detalleTrabajo.PrecioTotal= (float)Double.Parse(row["precio"].ToString());
                        detalleTrabajo.Descripcion= row["descripcion"].ToString();
                        ProductoRequerido producto = new ProductoRequerido();
                        producto.IdProducto= Int32.Parse(row["id_producto"].ToString());
                        producto.Material= row["material"].ToString();
                        producto.Pedido= Int32.Parse(row["pedido"].ToString());
                        producto.Precio = (float)Double.Parse(row["PrecioProducto"].ToString());
                        detalleTrabajo.ListaProductosRequeridos.Add(producto);
                        orden.ListaDetallesTrabajo.Add(detalleTrabajo);
                    }




                    dictionary.Add(id, orden);
                } // if

            } // for
            return dictionary.Values.ToList<OrdenTrabajo>();
        } // GetAllMovies









    }


    }
    

