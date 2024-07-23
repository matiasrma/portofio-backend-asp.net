using Dominio;

namespace ILogicaDominio
{
    public interface ILogicaGet<out T>
    {
        public T Obtener(int Id);        
    }
}