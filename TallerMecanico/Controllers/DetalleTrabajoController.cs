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
    [Route("api/taller/detalleTrabajo")]
    public class DetalleTrabajoController : Controller
    {
        private readonly IConfiguration configuration;
        public DetalleTrabajoController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


         
        // POST: api/peliculas
        [HttpPost("{idOrden}")]
        public DetalleTrabajo Post(int idOrden,[FromBody]DetalleTrabajo detalleTrabajoT)
        {
            Console.Write("Controlador "+ detalleTrabajoT.toString());
            DetalleTrabajoData detalleTrabajo =
              new DetalleTrabajoData(configuration.GetConnectionString("TallerContext").ToString());
            return detalleTrabajo.insertar(idOrden,detalleTrabajoT);
            
        }
        
        // PUT: api/peliculas/5
        [HttpPut("{codCliente}")]
        public Cliente Put(int codCliente, [FromBody]Cliente cliente)
        {
            ClienteData clienteData =
               new ClienteData(configuration.GetConnectionString("TallerContext").ToString());
            return clienteData.modificar(codCliente, cliente);
        }

        // DELETE: api/peliculas/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
