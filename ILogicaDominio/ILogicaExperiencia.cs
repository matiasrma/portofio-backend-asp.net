using Dominio;

namespace ILogicaDominio
{
    public interface ILogicaExperiencia
    {
        public List<Experiencia> ObtenerLista(int persona_id);
        public void Guardar(List<Experiencia> lista);
        public void Eliminar(List<Experiencia> lista);
    }
}