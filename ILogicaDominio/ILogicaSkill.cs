using Dominio;

namespace ILogicaDominio
{
    public interface ILogicaSkill
    {
        public List<Skill> ObtenerLista(int persona_id);
        public void Guardar(Skill skill);
        public void Eliminar(int id);
    }
}