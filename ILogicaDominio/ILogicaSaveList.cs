using Dominio;

namespace ILogicaDominio
{
    public interface ILogicaSaveList<T>
    {        
        public void Guardar(List<T> list);        
    }
}