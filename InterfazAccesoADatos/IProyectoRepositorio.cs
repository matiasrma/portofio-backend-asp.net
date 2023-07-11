using Dominio;

namespace InterfazAccesoADatos
{
    public interface IProyectoRepositorio
    {
        public List<Proyecto> ObtenerLista(int persona_id);
        public void Guardar(List<Proyecto> lista);
        public void Eliminar(List<Proyecto> lista);
    }
}