using Dominio;
using ILogicaDominio;
using InterfazAccesoADatos;
using System.Text;
using XSystem.Security.Cryptography;

namespace LogicaDominio
{
    public class LogicaPersona : ILogicaPersona
    {
        private readonly IPersonaRepositorio personaRepositorio;

        public LogicaPersona(IPersonaRepositorio personaRepositorio)
        {
            this.personaRepositorio = personaRepositorio;
        }

        public Persona Obtener(int persona_id)
        {
            return this.personaRepositorio.Obtener(persona_id);
        }

        public void Guardar(Persona persona)
        {
            this.personaRepositorio.Guardar(persona);
        }

    }
}