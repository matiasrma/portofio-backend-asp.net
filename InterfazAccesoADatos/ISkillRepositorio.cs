using Dominio;

namespace InterfazAccesoADatos
{
    public interface ISkillRepositorio
    {
        public List<Skill> ObtenerLista(int persona_id);
        public void Guardar(Skill skill);
        public void Eliminar(int id);
    }
}