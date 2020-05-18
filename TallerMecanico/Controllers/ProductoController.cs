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
    [Route("api/taller/producto")]
    public class ProductoController : Controller
    {
        private readonly IConfiguration configuration;
        public ProductoController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpGet]
        public IEnumerable<ProductoRequerido> GetAll()
        {
            ProductoData productoData =
                new ProductoData(configuration.GetConnectionString("TallerContext").ToString());
            return productoData.getAll();
        }
        [HttpGet("{material}", Name = "GetByMaterial")]
        public IEnumerable<ProductoRequerido> GetByMaterial(String material) {
            ProductoData productoData =
                  new ProductoData(configuration.GetConnectionString("TallerContext").ToString());
            return productoData.getPorMaterial(material);


        }
    }
}
