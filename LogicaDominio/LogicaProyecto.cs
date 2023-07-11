using Dominio;
using ILogicaDominio;
using InterfazAccesoADatos;
using System.Text;
using XSystem.Security.Cryptography;

namespace LogicaDominio
{
    public class LogicaProyecto : ILogicaProyecto
    {
        private readonly IProyectoRepositorio skillRepositorio;

        public LogicaProyecto(IProyectoRepositorio skillRepositorio)
        {
            this.skillRepositorio = skillRepositorio;
        }

        public List<Proyecto> ObtenerLista(int persona_id)
        {
            return this.skillRepositorio.ObtenerLista(persona_id);
        }

        public void Guardar(List<Proyecto> lista)
        {
            this.skillRepositorio.Guardar(lista);
        }

        public void Eliminar(List<Proyecto> lista)
        {
            this.skillRepositorio.Eliminar(lista);
        }
    }
}