namespace Excepciones
{
    public class ExcepcionErrorDeSintaxisSQL : ExcepcionGenerica
    {
        public const string message = "Error de sintaxis en la consulta SQL, revise: ";
        public ExcepcionErrorDeSintaxisSQL(string msg) : base(message + msg) { }
    }
}