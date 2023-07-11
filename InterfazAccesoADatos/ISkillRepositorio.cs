using Dominio;

namespace InterfazAccesoADatos
{
    public interface ISkillRepositorio
    {
        public List<Skill> ObtenerLista(int persona_id);
        public void Guardar(List<Skill> lista);
        public void Eliminar(List<Skill> lista);
    }
}