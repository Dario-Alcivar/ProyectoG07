using Microsoft.IdentityModel.Tokens;
using PlayLandProyect;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Grupo_3_PlayLand_BE.SharedCode
{
    public class CreacionToken
    {
        private readonly IConfiguration _configuration;
        public  string CrearToken(LoginUsuario user)
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
                Expires = System.DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}
