using Dominio;

namespace InterfazAccesoADatos
{
    public interface IPersonaRepositorio
    {
        public Persona Obtener(int persona_id);
        public void Guardar(Persona social);
    }
}