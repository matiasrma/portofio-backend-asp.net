using Dominio;
using ILogicaDominio;
using InterfazAccesoADatos;
using System.Text;
using XSystem.Security.Cryptography;

namespace LogicaDominio
{
    public class LogicaSocial : ILogicaSocial
    {
        private readonly ISocialRepositorio socialRepositorio;

        public LogicaSocial(ISocialRepositorio socialRepositorio)
        {
            this.socialRepositorio = socialRepositorio;
        }

        public List<Social> ObtenerLista(int persona_id)
        {
            return this.socialRepositorio.ObtenerLista(persona_id);
        }

        public void Guardar(Social social)
        {
            this.socialRepositorio.Guardar(social);
        }

        public void Eliminar(int id)
        {
            this.socialRepositorio.Eliminar(id);
        }
    }
}