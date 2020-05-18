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
    [Route("api/taller/cliente")]
    public class ClienteController : Controller
    {
        private readonly IConfiguration configuration;
        public ClienteController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpGet]
        public IEnumerable<Cliente> GetAll()
        {
            ClienteData clienteData =
                new ClienteData(configuration.GetConnectionString("TallerContext").ToString());
            return clienteData.getAll();
        }
        // GET: api/peliculas/love
        [HttpGet("{identificacion}", Name = "GetPorIdentificacion")]
        public IEnumerable<Cliente> GetPorIdentificacion(String identificacion)
        { 
            ClienteData clienteData =
                new ClienteData(configuration.GetConnectionString("TallerContext").ToString());
            return clienteData.getClientePorCedula(identificacion);
        }


        // POST: api/peliculas
        [HttpPost]
        public Cliente Post([FromBody]Cliente cliente)
        {
            ClienteData clienteData =
              new ClienteData(configuration.GetConnectionString("TallerContext").ToString());
            return clienteData.insertar(cliente);
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
            Console.Write("ENTRA AL CONTROLLER" + id);
            ClienteData clienteData =
              new ClienteData(configuration.GetConnectionString("TallerContext").ToString());
             clienteData.suprimir(id);
        }
    }
}
