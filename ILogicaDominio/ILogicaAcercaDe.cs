using Dominio;

namespace ILogicaDominio
{
    public interface ILogicaAcercaDe
    {
        public AcercaDe Obtener(int id);
        public void Guardar(AcercaDe acercaDe);        
    }
}