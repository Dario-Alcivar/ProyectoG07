using Grupo_3_PlayLand_BE.SharedCode;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PlayLandProyect;
using PlayLandProyect.Helpers;
using System.Data;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Grupo_3_PlayLand_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JuegosController : ControllerBase
    {
        [Route("consulta-juegos")]
        [HttpGet]
        public async Task<ActionResult> GetJuegos()
        {
            var cadenaConexion = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];
            DataSet resultadoAuspiciantes = await DBXmlMethods.ejecutaBase(cadenaConexion, TransaccionesConstantes.CONSULTA_JUEGOS, "CONSULTA_JUEGOS_TODOS");
            return Ok(JsonConvert.SerializeObject(resultadoAuspiciantes, Newtonsoft.Json.Formatting.Indented));
        }

        [Route("consulta-juegos-aleotorios")]
        [HttpGet]
        public async Task<ActionResult> GetJuegosAleatorios()
        {
            var cadenaConexion = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];
            DataSet resultadoAuspiciantes = await DBXmlMethods.ejecutaBase(cadenaConexion, TransaccionesConstantes.CONSULTA_JUEGOS, "CONSULTA_JUEGOS_ALEATORIOS");
            return Ok(JsonConvert.SerializeObject(resultadoAuspiciantes, Newtonsoft.Json.Formatting.Indented));
        }

        [Route("consulta-juegos-descuento")]
        [HttpGet]
        public async Task<ActionResult> GetJuegosDescuento()
        {
            var cadenaConexion = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];
            DataSet resultadoAuspiciantes = await DBXmlMethods.ejecutaBase(cadenaConexion, TransaccionesConstantes.CONSULTA_JUEGOS, "CONSULTA_JUEGOS_DESCUENTOS");
            return Ok(JsonConvert.SerializeObject(resultadoAuspiciantes, Newtonsoft.Json.Formatting.Indented));
        }

        [Route("consulta-juegos-colecciones")]
        [HttpGet]
        public async Task<ActionResult> GetJuegosColecciones()
        {
            var cadenaConexion = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];
            DataSet resultadoAuspiciantes = await DBXmlMethods.ejecutaBase(cadenaConexion, TransaccionesConstantes.CONSULTA_JUEGOS, "CONSULTA_JUEGOS_COLECCIONES");
            return Ok(JsonConvert.SerializeObject(resultadoAuspiciantes, Newtonsoft.Json.Formatting.Indented));
        }

        [Route("consulta-juegos-id")]
        [HttpPost]
        public async Task<ActionResult> GetJuegosID([FromBody] XmlConsultaJuegos juegos)
        {
            var cadenaConexion = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];
            XDocument xml = DBXmlMethods.getXML(juegos);
            DataSet resultadoAuspiciantes = await DBXmlMethods.ejecutaBase(cadenaConexion, TransaccionesConstantes.CONSULTA_JUEGOS, juegos.transaccion,xml.ToString());
            return Ok(JsonConvert.SerializeObject(resultadoAuspiciantes, Newtonsoft.Json.Formatting.Indented));
        }

        [Route("consulta-juegos-nombre")]
        [HttpPost]
        public async Task<ActionResult> GetJuegosNombre([FromBody] XmlConsultaJuegos juegos)
        {
            var cadenaConexion = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];
            XDocument xml = DBXmlMethods.getXML(juegos);
            DataSet resultadoAuspiciantes = await DBXmlMethods.ejecutaBase(cadenaConexion, TransaccionesConstantes.CONSULTA_JUEGOS, juegos.transaccion, xml.ToString());
            return Ok(JsonConvert.SerializeObject(resultadoAuspiciantes, Newtonsoft.Json.Formatting.Indented));
        }

        [Route("consulta-juegos-requsitos")]
        [HttpPost]
        public async Task<ActionResult> GetJuegosRequesitos([FromBody] XmlConsultaJuegos juegos)
        {
            var cadenaConexion = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];
            XDocument xml = DBXmlMethods.getXML(juegos);
            DataSet resultadoAuspiciantes = await DBXmlMethods.ejecutaBase(cadenaConexion, TransaccionesConstantes.CONSULTA_JUEGOS, juegos.transaccion, xml.ToString());
            return Ok(JsonConvert.SerializeObject(resultadoAuspiciantes, Newtonsoft.Json.Formatting.Indented));
        }

        [Route("consulta-juegos-lanzamientos")]
        [HttpPost]
        public async Task<ActionResult> GetJuegosLanzamientos([FromBody] XmlConsultaJuegos juegos)
        {
            var cadenaConexion = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];
            XDocument xml = DBXmlMethods.getXML(juegos);
            DataSet resultadoAuspiciantes = await DBXmlMethods.ejecutaBase(cadenaConexion, TransaccionesConstantes.CONSULTA_JUEGOS, juegos.transaccion, xml.ToString());
            return Ok(JsonConvert.SerializeObject(resultadoAuspiciantes, Newtonsoft.Json.Formatting.Indented));
        }

    }
}
