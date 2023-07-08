using Dominio;

namespace ILogicaDominio
{
    public interface ILogicaSocial
    {
        public List<Social> ObtenerLista(int persona_id);
        public void Guardar(Social social);
        public void Eliminar(int id);
    }
}