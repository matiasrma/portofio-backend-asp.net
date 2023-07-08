using MySqlConnector;

namespace AccesoADatos
{
    public interface IConexionDB
    {
        MySqlConnection Open();
        void Close();
    }
}