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
    public class SocialRepositorio : ISocialRepositorio
    {
        private readonly IConexionDB conexionDB;
        private readonly MySqlConnection conexion;

        public SocialRepositorio(IConexionDB _conexionDB)
        {
            this.conexionDB = _conexionDB;
            this.conexion = this.conexionDB.Open();
        }

        public List<Social> ObtenerLista(int persona_id)
        {
            string cadena = "SELECT \n" +
                "id, \n" +
                "img_social, \n" +
                "show_img, \n" +
                "url_social, \n" +
                "persona_id \n" +
                "FROM social \n" +
                "WHERE persona_id = @persona_id;";

            try
            {
                MySqlCommand comando = new MySqlCommand(cadena, conexion);
                comando.Parameters.Add("@persona_id", MySqlDbType.String).Value = persona_id;
                MySqlDataReader consulta = comando.ExecuteReader();

                List<Social> lista = new List<Social>();

                while (consulta.Read())
                {
                    Social social = new Social();

                    if (!consulta.IsDBNull(0)) { social.Id = consulta.GetInt32(0); }
                    if (!consulta.IsDBNull(1)) { social.img_social = consulta.GetString(1); }
                    if (!consulta.IsDBNull(2)) { social.show_img = consulta.GetByte(2); }
                    if (!consulta.IsDBNull(3)) { social.url_social = consulta.GetString(3); }
                    if (!consulta.IsDBNull(4)) { social.persona_id = consulta.GetInt32(4); }

                    lista.Add(social);
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

        public void Guardar(Social social)
        {
            string cadena = "INSERT INTO social (\n" +
                "id, \n" +
                "img_social, \n" +
                "show_img, \n" +
                "url_social, \n" +
                "persona_id \n" +
                ") VALUES (\n" +
                "@id, \n" +
                "@img_social, \n" +
                "@show_img, \n" +
                "@url_social, \n" +
                "@persona_id \n" +
                ") ON DUPLICATE KEY UPDATE (\n" +
                "id = VALUES (id), \n" +
                "img_social = VALUES (img_social), \n" +
                "show_img = VALUES (show_img), \n" +
                "url_social = VALUES (url_social), \n" +
                "persona_id = VALUES (persona_id);";

            try
            {
                MySqlCommand comando = new MySqlCommand(cadena, conexion);
                comando.Parameters.Add("@id", MySqlDbType.Int32).Value = social.Id;
                comando.Parameters.Add("@img_social", MySqlDbType.String).Value = social.img_social;
                comando.Parameters.Add("@show_img", MySqlDbType.Byte).Value = social.show_img;
                comando.Parameters.Add("@url_social", MySqlDbType.String).Value = social.url_social;
                comando.Parameters.Add("@persona_id", MySqlDbType.Int32).Value = social.persona_id;
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
            string cadena = "DELETE FROM social WHERE id = @Id;";

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
