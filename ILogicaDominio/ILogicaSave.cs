using Dominio;

namespace ILogicaDominio
{
    public interface ILogicaSave<in T>
    {        
        public void Guardar(T item);        
    }
}