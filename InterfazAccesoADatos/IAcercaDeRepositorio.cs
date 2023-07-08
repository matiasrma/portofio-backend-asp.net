using Dominio;

namespace InterfazAccesoADatos
{
    public interface IAcercaDeRepositorio
    {
        public AcercaDe Obtener(int id);
        public void Guardar(AcercaDe acercaDe);
    }
}