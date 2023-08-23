using Grupo_3_PlayLand_BE.SharedCode;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PlayLandProyect;
using System.Data;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Grupo_3_PlayLand_BE.Controllers
{ 
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {

        [Route("consulta-carito")]
        [HttpPost]
        public async Task<ActionResult> GetJuegos([FromBody] Carrito carrito)
        {
            var cadenaConexion = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];
            XDocument xml = DBXmlMethods.getXML(carrito);
            DataSet resultadoAuspiciantes = await DBXmlMethods.ejecutaBase(cadenaConexion, TransaccionesConstantes.CARRITO, carrito.transaccion, xml.ToString());
            return Ok(JsonConvert.SerializeObject(resultadoAuspiciantes, Newtonsoft.Json.Formatting.Indented));
        }

        [Route("anadir-carrito")]
        [HttpPost]
        public async Task<ActionResult> GeAnadirCarrito([FromBody] Carrito carrito)
        {
            var cadenaConexion = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];
            XDocument xml = DBXmlMethods.getXML(carrito);
            DataSet resultadoAuspiciantes = await DBXmlMethods.ejecutaBase(cadenaConexion, TransaccionesConstantes.CARRITO, carrito.transaccion, xml.ToString());
            return Ok(JsonConvert.SerializeObject(resultadoAuspiciantes, Newtonsoft.Json.Formatting.Indented));
        }
        [Route("anadir-carrito-cantidad")]
        [HttpPost]
        public async Task<ActionResult> GeAnadirCarritoCantidad([FromBody] Carrito carrito)
        {
            var cadenaConexion = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];
            XDocument xml = DBXmlMethods.getXML(carrito);
            DataSet resultadoAuspiciantes = await DBXmlMethods.ejecutaBase(cadenaConexion, TransaccionesConstantes.CARRITO, carrito.transaccion, xml.ToString());
            return Ok(JsonConvert.SerializeObject(resultadoAuspiciantes, Newtonsoft.Json.Formatting.Indented));
        }
        [Route("eliminar-carrito")]
        [HttpPost]
        public async Task<ActionResult> DeleteCarrito([FromBody] Carrito carrito)
        {
            var cadenaConexion = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];
            XDocument xml = DBXmlMethods.getXML(carrito);
            DataSet resultadoAuspiciantes = await DBXmlMethods.ejecutaBase(cadenaConexion, TransaccionesConstantes.CARRITO, carrito.transaccion, xml.ToString());
            return Ok(JsonConvert.SerializeObject(resultadoAuspiciantes, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
