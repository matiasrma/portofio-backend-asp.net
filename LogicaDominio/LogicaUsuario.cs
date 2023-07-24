using Dominio;
using Excepciones;
using ILogicaDominio;
using InterfazAccesoADatos;
using LogicaDominio.Common;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XSystem.Security.Cryptography;

namespace LogicaDominio
{
    public class LogicaUsuario : ILogicaUsuario
    {
        private readonly IUsuarioRepositorio usuarioRepositorio;
        private readonly AppSettings _appSettings;

        public LogicaUsuario(IUsuarioRepositorio usuarioRepositorio, IOptions<AppSettings> appSettings)
        {
            this.usuarioRepositorio = usuarioRepositorio;
            this._appSettings = appSettings.Value;
        }

        public Usuario Login(string nombre_usuario, string password)
        {
            password = GetMD5(password);
            Usuario usuario = this.usuarioRepositorio.Login(nombre_usuario, password);
            
            if(usuario.email != null)
            {
                usuario.token = GetToken(usuario);
            } else
            {
                throw new ExcepcionUsuarioPassword("Error de usuario o contraseña");
            }

            return usuario;
        }

        public string GetMD5(string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bytes = ASCIIEncoding.Default.GetBytes(str);
            byte[] encoded = md5.ComputeHash(bytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < encoded.Length; i++)
                sb.Append(encoded[i].ToString("x2"));

            return sb.ToString();
        }

        private string GetToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuario.nombre_usuario),
                        new Claim(ClaimTypes.Email, usuario.email),
                    }
                    ),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}