using Dominio;

namespace ILogicaDominio
{
    public interface ILogicaDeleteList<T>
    {        
        public void Delete(List<T> list);        
    }
}