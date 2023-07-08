using Dominio;

namespace ILogicaDominio
{
    public interface ILogicaUsuario
    {
        public Usuario Login(string nombre_usuario, string password);
    }
}