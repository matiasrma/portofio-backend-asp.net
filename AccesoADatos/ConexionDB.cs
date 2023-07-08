using Excepciones;
using MySqlConnector;

namespace AccesoADatos
{
    public class ConexionDB : IConexionDB
    {
        private readonly MySqlConnection _connection;

        public ConexionDB(MySqlConnection connection)
        {
            _connection = connection;
        }

        public MySqlConnection Open()
        {
            try
            {
                _connection.Open();
                return _connection;
            }
            catch(Exception ex)
            {
                throw new ExcepcionMotorBDCaido();
            }
        }

        public void Close()
        {
            _connection.Close();
        }
    }
}