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
    public class ExperienciaRepositorio : IExperienciaRepositorio
    {
        private readonly IConexionDB conexionDB;
        private readonly MySqlConnection conexion;

        public ExperienciaRepositorio(IConexionDB _conexionDB)
        {
            this.conexionDB = _conexionDB;
            this.conexion = this.conexionDB.Open();
        }

        public List<Experiencia> ObtenerLista(int persona_id)
        {
            string cadena = "SELECT \n" +
                "id, \n" +
                "descripcion_exp, \n" +
                "img_exp, \n" +
                "nombre_exp, \n" +
                "tiempo_exp, \n" +
                "persona_id \n" +
                "FROM experiencia \n" +
                "WHERE persona_id = @persona_id;";

            try
            {
                MySqlCommand comando = new MySqlCommand(cadena, conexion);
                comando.Parameters.Add("@persona_id", MySqlDbType.String).Value = persona_id;
                MySqlDataReader consulta = comando.ExecuteReader();

                List<Experiencia> lista = new List<Experiencia>();

                while (consulta.Read())
                {
                    Experiencia experiencia = new Experiencia();

                    if (!consulta.IsDBNull(0)) { experiencia.Id = consulta.GetInt32(0); }
                    if (!consulta.IsDBNull(1)) { experiencia.descripcion_exp = consulta.GetString(1); }
                    if (!consulta.IsDBNull(2)) { experiencia.img_exp = consulta.GetString(2); }
                    if (!consulta.IsDBNull(3)) { experiencia.nombre_exp = consulta.GetString(3); }
                    if (!consulta.IsDBNull(4)) { experiencia.tiempo_exp = consulta.GetString(4); }
                    if (!consulta.IsDBNull(5)) { experiencia.persona_id = consulta.GetInt32(5); }

                    lista.Add(experiencia);
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

        public void Guardar(Experiencia experiencia)
        {
            string cadena = "INSERT INTO experiencia (\n" +
                "id, \n" +
                "descripcion_exp, \n" +
                "img_exp, \n" +
                "nombre_exp, \n" +
                "tiempo_exp, \n" +
                "persona_id \n" +
                ") VALUES (\n" +
                "@id, \n" +
                "@descripcion_exp, \n" +
                "@img_exp, \n" +
                "@nombre_exp, \n" +
                "@tiempo_exp, \n" +
                "@persona_id \n" +
                ") ON DUPLICATE KEY UPDATE (\n" +
                "id = VALUES (id), \n" +
                "descripcion_exp = VALUES (descripcion_exp), \n" +
                "img_exp = VALUES (img_exp), \n" +
                "nombre_exp = VALUES (nombre_exp), \n" +
                "tiempo_exp = VALUES (tiempo_exp), \n" +
                "persona_id = VALUES (persona_id);";

            try
            {
                MySqlCommand comando = new MySqlCommand(cadena, conexion);
                comando.Parameters.Add("@id", MySqlDbType.Int32).Value = experiencia.Id;
                comando.Parameters.Add("@descripcion_exp", MySqlDbType.String).Value = experiencia.descripcion_exp;
                comando.Parameters.Add("@img_exp", MySqlDbType.Byte).Value = experiencia.img_exp;
                comando.Parameters.Add("@nombre_exp", MySqlDbType.String).Value = experiencia.nombre_exp;
                comando.Parameters.Add("@tiempo_exp", MySqlDbType.Int32).Value = experiencia.tiempo_exp;
                comando.Parameters.Add("@persona_id", MySqlDbType.Int32).Value = experiencia.persona_id;
                comando.ExecuteNonQuery();

                conexion.Close();

            }
            catch (MySqlException e)
            {
                conexion.Close();
                throw new ExcepcionErrorDeSintaxisSQL(e.Message);
            }

        }

        public void Eliminar(int Id)
        {
            string cadena = "DELETE FROM experiencia WHERE id = @Id;";

            try
            {
                MySqlCommand comando = new MySqlCommand(cadena, conexion);
                comando.Parameters.Add("@id", MySqlDbType.Int32).Value = Id;
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
