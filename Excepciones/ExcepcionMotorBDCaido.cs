namespace Excepciones
{
    public class ExcepcionMotorBDCaido : ExcepcionGenerica
    {
        public const string message = "El motor de la base de datos arrojo una excepcion, verifique que se encuentre activo";
        public ExcepcionMotorBDCaido(string msg = message) : base(msg) { }
    }
}