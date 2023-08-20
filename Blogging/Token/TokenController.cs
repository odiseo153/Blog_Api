using Blogging.DTOS;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Blogging.Token
{
    public class TokenController
    {
        public static string keys = "alwkdawkldawndlandladnlakndwdlawldkdnlakdnlkadnndkadnkalndnlwkldnwdakldkwalnakd";
        public static string GenerarToken(UsuarioCreateDTO user)
        {

            var claims = new []{
                new Claim(ClaimTypes.Name,user.Nombre),
                new Claim(ClaimTypes.NameIdentifier,user.Clave)
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keys));
            var creeds = new SigningCredentials(key, SecurityAlgorithms.Aes128CbcHmacSha256);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(120),
               signingCredentials: creeds
            );
            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return token;

        }

        
    }
}
