using Dominio;
using Excepciones;
using InterfazAccesoADatos;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos.Repositorio
{
    public class AcercaDeRepositorio : IAcercaDeRepositorio
    {
        private readonly IConexionDB conexionDB;
        private readonly MySqlConnection conexion;

        public AcercaDeRepositorio(IConexionDB _conexionDB)
        {
            this.conexionDB = _conexionDB;
            this.conexion = this.conexionDB.Open();
        }

        public AcercaDe Obtener(int id)
        {
            string cadena = "SELECT \n" +
                "id, \n" +                
                "textoacd \n" +
                "FROM acerca_de \n" +
                "WHERE id = @id;";

            try
            {
                MySqlCommand comando = new MySqlCommand(cadena, conexion);
                comando.Parameters.Add("@id", MySqlDbType.String).Value = id;
                MySqlDataReader consulta = comando.ExecuteReader();

                AcercaDe acercaDe = new AcercaDe();

                while (consulta.Read())
                {

                    if (!consulta.IsDBNull(0)) { acercaDe.Id = consulta.GetInt32(0); }
                    if (!consulta.IsDBNull(1)) { acercaDe.textoacd = consulta.GetString(1); }

                }

                conexion.Close();
                return acercaDe;

            }
            catch (MySqlException e)
            {
                conexion.Close();
                throw new ExcepcionErrorDeSintaxisSQL(e.Message);
            }

        }

        public void Guardar(AcercaDe acercaDe)
        {
            string cadena = "INSERT INTO acerca_de (\n" +
                "id, \n" +
                "textoacd \n" +                
                ") VALUES (\n" +
                "@id, \n" +
                "@textoacd \n" +                
                ") ON DUPLICATE KEY UPDATE \n" +
                "id = VALUES (id), \n" +
                "textoacd = VALUES (textoacd);";

            try
            {
                MySqlCommand comando = new MySqlCommand(cadena, conexion);
                comando.Parameters.Add("@id", MySqlDbType.Int32).Value = acercaDe.Id;
                comando.Parameters.Add("@textoacd", MySqlDbType.String).Value = acercaDe.textoacd;
                comando.ExecuteNonQuery();

                conexion.Close();

            }
            catch (MySqlException e)
            {
                conexion.Close();
                throw new ExcepcionErrorDeSintaxisSQL(e.Message);
            }

        }

    }
}
