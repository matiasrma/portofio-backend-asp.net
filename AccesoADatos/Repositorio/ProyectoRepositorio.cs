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
    public class ProyectoRepositorio : IProyectoRepositorio
    {
        private readonly IConexionDB conexionDB;
        private readonly MySqlConnection conexion;

        public ProyectoRepositorio(IConexionDB _conexionDB)
        {
            this.conexionDB = _conexionDB;
            this.conexion = this.conexionDB.Open();
        }

        public List<Proyecto> ObtenerLista(int persona_id)
        {
            string cadena = "SELECT \n" +
                "id, \n" +                
                "descripcion_proyecto, \n" +
                "nombre_proyecto, \n" +
                "url_proyecto, \n" +
                "persona_id \n" +
                "FROM proyecto \n" +
                "WHERE persona_id = @persona_id;";

            try
            {
                MySqlCommand comando = new MySqlCommand(cadena, conexion);
                comando.Parameters.Add("@persona_id", MySqlDbType.String).Value = persona_id;
                MySqlDataReader consulta = comando.ExecuteReader();

                List<Proyecto> lista = new List<Proyecto>();

                while (consulta.Read())
                {
                    Proyecto proyecto = new Proyecto();

                    if (!consulta.IsDBNull(0)) { proyecto.Id = consulta.GetInt32(0); }
                    if (!consulta.IsDBNull(1)) { proyecto.descripcion_proyecto = consulta.GetString(1); }
                    if (!consulta.IsDBNull(2)) { proyecto.nombre_proyecto = consulta.GetString(2); }
                    if (!consulta.IsDBNull(3)) { proyecto.url_proyecto = consulta.GetString(3); }
                    if (!consulta.IsDBNull(4)) { proyecto.persona_id = consulta.GetInt32(4); }

                    lista.Add(proyecto);
                }

                conexion.Close();
                return lista;

            }
            catch (MySqlException e)
            {
                conexion.Close();
                throw new ExcepcionErrorDeSintaxisSQL(e.Message);
            }

        }

        public void Guardar(List<Proyecto> lista)
        {
            string cadena = "INSERT INTO proyecto (\n" +
                "id, \n" +
                "descripcion_proyecto, \n" +
                "nombre_proyecto, \n" +
                "url_proyecto, \n" +
                "persona_id \n" +
                ") VALUES \n";

            lista.ForEach(proyecto =>
            {
                cadena += "('" +
                proyecto.Id + "', \n'" +
                proyecto.descripcion_proyecto + "', \n'" +
                proyecto.nombre_proyecto + "', \n'" +
                proyecto.url_proyecto + "', \n'" +
                "@persona_id), \n";
            });

            cadena = cadena.Substring(0, cadena.Length - 3);

            cadena +=
                " ON DUPLICATE KEY UPDATE \n" +
                "Id = VALUES (Id), \n" +
                "descripcion_proyecto = VALUES (descripcion_proyecto), \n" +
                "nombre_proyecto = VALUES (nombre_proyecto), \n" +
                "url_proyecto = VALUES (url_proyecto), \n" +
                "persona_id = VALUES (persona_id);";

            try
            {
                MySqlCommand comando = new MySqlCommand(cadena, conexion);
                comando.Parameters.Add("@persona_id", MySqlDbType.Int32).Value = lista[0].persona_id;
                comando.ExecuteNonQuery();

                conexion.Close();

            }
            catch (MySqlException e)
            {
                conexion.Close();
                throw new ExcepcionErrorDeSintaxisSQL(e.Message);
            }

        }

        public void Eliminar(List<Proyecto> lista)
        {            
            string cadena = "DELETE FROM proyecto WHERE id IN ('";

            lista.ForEach(proyecto =>
            {
                cadena += proyecto.Id + "', '";
            });

            cadena = cadena.Substring(0, cadena.Length - 3) + ") ";
            cadena += " AND persona_id = @persona_id";

            try
            {
                MySqlCommand comando = new MySqlCommand(cadena, conexion);
                comando.Parameters.Add("@persona_id", MySqlDbType.Int32).Value = lista[0].persona_id;
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
