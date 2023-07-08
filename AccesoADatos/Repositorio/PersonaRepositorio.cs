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
    public class PersonaRepositorio : IPersonaRepositorio
    {
        private readonly IConexionDB conexionDB;
        private readonly MySqlConnection conexion;

        public PersonaRepositorio(IConexionDB _conexionDB)
        {
            this.conexionDB = _conexionDB;
            this.conexion = this.conexionDB.Open();
        }

        public Persona Obtener(int id)
        {
            string cadena = "SELECT \n" +
                "id, \n" +
                "apellido, \n" +
                "banner, \n" +
                "correo, \n" +
                "descripcion, \n" +
                "img, \n" +
                "intereses, \n" +
                "nombre, \n" +
                "ubicacion \n" +
                "FROM persona \n" +
                "WHERE id = @id;";

            try
            {
                MySqlCommand comando = new MySqlCommand(cadena, conexion);
                comando.Parameters.Add("@id", MySqlDbType.String).Value = id;
                MySqlDataReader consulta = comando.ExecuteReader();

                Persona persona = new Persona();

                while (consulta.Read())
                {

                    if (!consulta.IsDBNull(0)) { persona.Id = consulta.GetInt32(0); }
                    if (!consulta.IsDBNull(1)) { persona.apellido = consulta.GetString(1); }
                    if (!consulta.IsDBNull(2)) { persona.banner = consulta.GetString(2); }
                    if (!consulta.IsDBNull(3)) { persona.correo = consulta.GetString(3); }
                    if (!consulta.IsDBNull(4)) { persona.descripcion = consulta.GetString(4); }
                    if (!consulta.IsDBNull(5)) { persona.img = consulta.GetString(5); }
                    if (!consulta.IsDBNull(6)) { persona.intereses = consulta.GetString(6); }
                    if (!consulta.IsDBNull(7)) { persona.nombre = consulta.GetString(7); }
                    if (!consulta.IsDBNull(8)) { persona.ubicacion = consulta.GetString(8); }

                }

                conexion.Close();
                return persona;

            }
            catch (MySqlException e)
            {
                conexion.Close();
                throw new ExcepcionErrorDeSintaxisSQL(e.Message);
            }

        }

        public void Guardar(Persona persona)
        {
            string cadena = "INSERT INTO social (\n" +
                "id, \n" +
                "apellido, \n" +
                "banner, \n" +
                "correo, \n" +
                "descripcion, \n" +
                "img, \n" +
                "intereses, \n" +
                "nombre, \n" +
                "ubicacion \n" +
                ") VALUES (\n" +
                "@id, \n" +
                "@apellido, \n" +
                "@banner, \n" +
                "@correo, \n" +
                "@descripcion, \n" +
                "@img, \n" +
                "@intereses, \n" +
                "@nombre, \n" +
                "@ubicacion \n" +
                ") ON DUPLICATE KEY UPDATE (\n" +
                "id = VALUES (id), \n" +
                "apellido = VALUES (apellido), \n" +
                "banner = VALUES (banner), \n" +
                "correo = VALUES (correo), \n" +
                "descripcion = VALUES (descripcion), \n" +
                "img = VALUES (img), \n" +
                "intereses = VALUES (intereses), \n" +
                "nombre = VALUES (nombre), \n" +
                "ubicacion = VALUES (ubicacion);";

            try
            {
                MySqlCommand comando = new MySqlCommand(cadena, conexion);
                comando.Parameters.Add("@id", MySqlDbType.Int32).Value = persona.Id;
                comando.Parameters.Add("@apellido", MySqlDbType.String).Value = persona.apellido;
                comando.Parameters.Add("@banner", MySqlDbType.String).Value = persona.banner;
                comando.Parameters.Add("@correo", MySqlDbType.String).Value = persona.correo;
                comando.Parameters.Add("@descripcion", MySqlDbType.String).Value = persona.descripcion;
                comando.Parameters.Add("@img", MySqlDbType.String).Value = persona.img;
                comando.Parameters.Add("@intereses", MySqlDbType.String).Value = persona.intereses;
                comando.Parameters.Add("@nombre", MySqlDbType.String).Value = persona.nombre;
                comando.Parameters.Add("@ubicacion", MySqlDbType.String).Value = persona.ubicacion;
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
            string cadena = "DELETE FROM persona WHERE id = @Id;";

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
