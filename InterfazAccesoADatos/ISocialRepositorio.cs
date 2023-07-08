using Dominio;

namespace InterfazAccesoADatos
{
    public interface ISocialRepositorio
    {
        public List<Social> ObtenerLista(int persona_id);
        public void Guardar(Social social);
        public void Eliminar(int id);
    }
}