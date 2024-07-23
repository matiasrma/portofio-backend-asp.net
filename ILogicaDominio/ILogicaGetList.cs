using Dominio;

namespace ILogicaDominio
{
    public interface ILogicaGetList<T>
    {
        public List<T> Obtener(int Id);        
    }
}