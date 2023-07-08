using Dominio;

namespace InterfazAccesoADatos
{
    public interface IUsuarioRepositorio
    {
        public Usuario Login(string nombre_usuario, string password);
    }
}