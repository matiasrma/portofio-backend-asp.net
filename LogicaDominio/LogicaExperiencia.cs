using Dominio;
using ILogicaDominio;
using InterfazAccesoADatos;
using System.Text;
using XSystem.Security.Cryptography;

namespace LogicaDominio
{
    public class LogicaExperiencia : ILogicaExperiencia
    {
        private readonly IExperienciaRepositorio experienciaRepositorio;

        public LogicaExperiencia(IExperienciaRepositorio experienciaRepositorio)
        {
            this.experienciaRepositorio = experienciaRepositorio;
        }

        public List<Experiencia> ObtenerLista(int persona_id)
        {
            return this.experienciaRepositorio.ObtenerLista(persona_id);
        }

        public void Guardar(Experiencia experiencia)
        {
            this.experienciaRepositorio.Guardar(experiencia);
        }

        public void Eliminar(int id)
        {
            this.experienciaRepositorio.Eliminar(id);
        }
    }
}