using Dominio;
using ILogicaDominio;
using InterfazAccesoADatos;
using System.Text;
using XSystem.Security.Cryptography;

namespace LogicaDominio
{
    public class LogicaSkill : ILogicaSkill
    {
        private readonly ISkillRepositorio skillRepositorio;

        public LogicaSkill(ISkillRepositorio skillRepositorio)
        {
            this.skillRepositorio = skillRepositorio;
        }

        public List<Skill> ObtenerLista(int persona_id)
        {
            return this.skillRepositorio.ObtenerLista(persona_id);
        }

        public void Guardar(Skill skill)
        {
            this.skillRepositorio.Guardar(skill);
        }

        public void Eliminar(int id)
        {
            this.skillRepositorio.Eliminar(id);
        }
    }
}