using Dominio;
using ILogicaDominio;
using InterfazAccesoADatos;
using System.Text;
using XSystem.Security.Cryptography;

namespace LogicaDominio
{
    public class LogicaAcercaDe : ILogicaAcercaDe
    {
        private readonly IAcercaDeRepositorio acercaDeRepositorio;

        public LogicaAcercaDe(IAcercaDeRepositorio _acercaDeRepositorio)
        {
            this.acercaDeRepositorio = _acercaDeRepositorio;
        }

        public AcercaDe Obtener(int id)
        {
            return this.acercaDeRepositorio.Obtener(id);
        }

        public void Guardar(AcercaDe acercaDe)
        {
            this.acercaDeRepositorio.Guardar(acercaDe);
        }

    }
}