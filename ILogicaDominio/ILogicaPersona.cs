using Dominio;

namespace ILogicaDominio
{
    public interface ILogicaPersona
    {
        public Persona Obtener(int persona_id);
        public void Guardar(Persona social);        
    }
}