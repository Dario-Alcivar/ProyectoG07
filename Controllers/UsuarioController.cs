
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using Newtonsoft.Json;
using PlayLandProyect;
using System.Xml.Linq;
using Grupo_3_PlayLand_BE.SharedCode;
using System.Data;
using PlayLandProyect.Helpers;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Grupo_3_PlayLand_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [Route("login")]
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginUsuario usuario)
        {
            var cadenaConexion = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];
            XDocument xml = DBXmlMethods.getXML(usuario);
            DataSet resultado = await DBXmlMethods.ejecutaBase(cadenaConexion, TransaccionesConstantes.USUARIO, "LOGIN", xml.ToString());
            if(resultado.Tables.Count > 0)
            {
                try
                {
                    if (resultado.Tables[0].Rows.Count > 0)
                    {
                        RespuestaSp respuesta = new RespuestaSp();
                        respuesta.respuesta = "200";
                        respuesta.token = CrearToken(usuario);
                        respuesta.idCliente = resultado.Tables[0].Rows[0]["id"].ToString();
                        return Ok(respuesta);
                    }
                    else
                    {
                        RespuestaSp respuesta = new RespuestaSp();
                        respuesta.respuesta = "Fallo inicio de sesión";
                        return Ok(respuesta);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return BadRequest();

                }
            }
            return BadRequest();
        }

        [Route("crear")]
        [HttpPost]
        public async Task<ActionResult> Crearuser([FromBody] Usuario usuario)
        {
            var cadenaConexion = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];
            XDocument xml = DBXmlMethods.getXML(usuario);
            DataSet resultado = await DBXmlMethods.ejecutaBase(cadenaConexion, TransaccionesConstantes.USUARIO, "CREAR_USUARIO", xml.ToString());
            return Ok(JsonConvert.SerializeObject(resultado, Newtonsoft.Json.Formatting.Indented));
        }

        private string CrearToken(LoginUsuario user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, "idUser"),
                new Claim(ClaimTypes.Name, user.correo),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.
                                        GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = System.DateTime.Now.AddDays(2),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}
