using Dominio;

namespace InterfazAccesoADatos
{
    public interface IExperienciaRepositorio
    {
        public List<Experiencia> ObtenerLista(int persona_id);
        public void Guardar(Experiencia social);
        public void Eliminar(int id);
    }
}