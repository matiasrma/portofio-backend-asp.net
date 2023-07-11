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

        public void Guardar(List<Experiencia> lista)
        {
            this.experienciaRepositorio.Guardar(lista);
        }

        public void Eliminar(List<Experiencia> lista)
        {
            this.experienciaRepositorio.Eliminar(lista);
        }
    }
}