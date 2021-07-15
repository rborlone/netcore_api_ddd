using ApiDemo.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace ApiDemo.Domain.Model.UsuarioAggregate
{
    /// <summary>
    /// Clase Usuario Servicio
    /// </summary>
    public class UsuarioService : IUsuarioService
    {
        /// <summary>
        /// Metodo para Loguear un usuario y generar el token.
        /// </summary>
        /// <param name="usuario">Recibe el Usuario.</param>
        /// <param name="keystr">Recibe el Key de la configuracion.</param>
        /// <returns></returns>
        public string LoginToken(Usuario usuario, string keystr)
        {
            try
            {
                // Leemos el secret_key desde nuestro appseting
                var secretKey = keystr;
                var key = Encoding.ASCII.GetBytes(secretKey);

                // Creamos los claims (pertenencias, características) del usuario
                ClaimsIdentity claims = new ClaimsIdentity();

                claims.AddClaim(new Claim(ClaimTypes.Name, usuario.UserId));
                claims.AddClaim(new Claim(ClaimTypes.Email, usuario.Email));
                //var id = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);



                //claims.AddClaim(new Claim() { })
                //{
                //    new Claim(ClaimTypes.NameIdentifier, user.UserId),
                //    new Claim(ClaimTypes.Email, user.Email)
                //};

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    // Nuestro token va a durar un día
                    Expires = DateTime.UtcNow.AddDays(1),
                    // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var createdToken = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(createdToken);
            }
            catch (ApiDemoDomainException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
