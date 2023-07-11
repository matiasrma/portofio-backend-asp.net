using Dominio;
using Excepciones;
using InterfazAccesoADatos;
using MySqlConnector;
using System;
using System.Collections;
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

        public void Guardar(List<Experiencia> lista)
        {
            string cadena = "INSERT INTO experiencia (\n" +
                "id, \n" +
                "descripcion_exp, \n" +
                "img_exp, \n" +
                "nombre_exp, \n" +
                "tiempo_exp, \n" +
                "persona_id \n" +
                ") VALUES \n";

            lista.ForEach(exp =>
            {
                cadena += "('" +
                exp.Id + "', \n'" +
                exp.descripcion_exp + "', \n'" +
                exp.img_exp + "', \n'" +
                exp.nombre_exp + "', \n'" +
                exp.tiempo_exp + "', \n" +
                "@persona_id), \n";
            });

            cadena = cadena.Substring(0, cadena.Length - 3);

            cadena +=    
                " ON DUPLICATE KEY UPDATE \n" +
                "id = VALUES (id), \n" +
                "descripcion_exp = VALUES (descripcion_exp), \n" +
                "img_exp = VALUES (img_exp), \n" +
                "nombre_exp = VALUES (nombre_exp), \n" +
                "tiempo_exp = VALUES (tiempo_exp), \n" +
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

        public void Eliminar(List<Experiencia> lista)
        {
            string cadena = "DELETE FROM experiencia WHERE id IN ('";

            lista.ForEach(exp =>
            {
                cadena += exp.Id + "', '";
            });

            cadena = cadena.Substring(0, cadena.Length-3) + ") ";
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
