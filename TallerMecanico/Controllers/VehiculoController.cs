using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TallerMecanicoLibrary.Data;
using TallerMecanicoLibrary.Domain;

namespace TallerMecanico.Controllers
{
    [Produces("application/json")]
    [Route("api/taller/vehiculos")]
    public class VehiculoController : Controller
    {
        private readonly IConfiguration configuration;
        public VehiculoController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpGet]
        public IEnumerable<Vehiculo> GetAll()
        {
            VehiculoData vehiculoData =
                new VehiculoData(configuration.GetConnectionString("TallerContext").ToString());
            Console.Write("aLAN");
            return vehiculoData.getAllVehiculos();
        }
        // GET: api/vehiculos/111
        [HttpGet("{placa}", Name = "GetByPlaca")]
        public IEnumerable<Vehiculo> GetByTitle(String placa)
        {
            //System.Diagnostics.Debug.WriteLine(configuration.GetConnectionString("TallerContext").ToString());
            VehiculoData vehicuoData =
                new VehiculoData(configuration.GetConnectionString("TallerContext").ToString());
            return vehicuoData.getVehiculosPorPlaca(placa);
        }


        // POST: api/peliculas
        [HttpPost]
        public Vehiculo Post([FromBody]Vehiculo vehiculo)
        {
            VehiculoData vehicuoData =
               new VehiculoData(configuration.GetConnectionString("TallerContext").ToString());
            return vehicuoData.Insertar( vehiculo);
        }

        // PUT: api/peliculas/5
        [HttpPut("{codVehiculo}")]
        public Vehiculo Put(int codVehiculo, [FromBody]Vehiculo vehiculo)
        {
            Console.WriteLine(codVehiculo + " " + vehiculo.NumPlaca);
            VehiculoData vehicuoData =
                           new VehiculoData(configuration.GetConnectionString("TallerContext").ToString());
            return vehicuoData.modificar(codVehiculo, vehiculo);
        }

        // DELETE: api/peliculas/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
