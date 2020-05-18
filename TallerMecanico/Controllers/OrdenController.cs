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
    [Route("api/taller/orden")]
    public class OrdenController: Controller
    {
        private readonly IConfiguration configuration;
        public OrdenController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpGet]
        public IEnumerable<OrdenTrabajo> GetAll()
        {
            OrdenData ordenData =
                new OrdenData(configuration.GetConnectionString("TallerContext").ToString());
            return ordenData.getOrdenCompleta();
        }

        [HttpGet("{id}", Name = "getOrdenPercial")]
        public IEnumerable<OrdenTrabajo> getOrdenPercial(int id)
        {
            OrdenData ordenData =
                new OrdenData(configuration.GetConnectionString("TallerContext").ToString());
            return ordenData.getOrdenCompleta();
        }
  
        [HttpPost]
        public OrdenTrabajo Post([FromBody]OrdenTrabajo orden)
        {
        // Console.Write("HOLA " + orden.ListaDetalleVehiculo[1].Estado.Descripcion);
            OrdenData ordenData =
              new OrdenData(configuration.GetConnectionString("TallerContext").ToString());
            return ordenData.insertar(orden);
        }

       
    }
}
