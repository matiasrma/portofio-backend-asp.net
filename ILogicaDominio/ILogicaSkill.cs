using Dominio;

namespace ILogicaDominio
{
    public interface ILogicaSkill
    {
        public List<Skill> ObtenerLista(int persona_id);
        public void Guardar(List<Skill> lista);
        public void Eliminar(List<Skill> lista);
    }
}