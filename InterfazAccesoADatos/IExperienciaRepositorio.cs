using Dominio;

namespace InterfazAccesoADatos
{
    public interface IExperienciaRepositorio
    {
        public List<Experiencia> ObtenerLista(int persona_id);
        public void Guardar(List<Experiencia> lista);
        public void Eliminar(List<Experiencia> lista);
    }
}