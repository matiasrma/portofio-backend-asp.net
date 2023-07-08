using Dominio;
using ILogicaDominio;
using InterfazAccesoADatos;
using System.Text;
using XSystem.Security.Cryptography;

namespace LogicaDominio
{
    public class LogicaUsuario : ILogicaUsuario
    {
        private readonly IUsuarioRepositorio usuarioRepositorio;

        public LogicaUsuario(IUsuarioRepositorio usuarioRepositorio)
        {
            this.usuarioRepositorio = usuarioRepositorio;
        }

        public Usuario Login(string nombre_usuario, string password)
        {
            password = GetMD5(password);
            return this.usuarioRepositorio.Login(nombre_usuario, password);
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
    }
}