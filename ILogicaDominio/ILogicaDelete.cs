using Dominio;

namespace ILogicaDominio
{
    public interface ILogicaDelete<in T>
    {        
        public void Delete(T item);        
    }
}