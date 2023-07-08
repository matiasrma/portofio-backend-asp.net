using Dominio;

namespace ILogicaDominio
{
    public interface ILogicaExperiencia
    {
        public List<Experiencia> ObtenerLista(int persona_id);
        public void Guardar(Experiencia social);
        public void Eliminar(int id);
    }
}