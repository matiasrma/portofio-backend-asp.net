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
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly IConexionDB conexionDB;
        private readonly MySqlConnection conexion;

        public UsuarioRepositorio(IConexionDB _conexionDB)
        {
            this.conexionDB = _conexionDB;
            this.conexion = this.conexionDB.Open();
        }

        public Usuario Login(string username, string password)
        {
            string cadena = "SELECT email, nombre, nombre_usuario, password FROM usuario WHERE " +
                "nombre_usuario = @username AND password = @password;";

            try
            {
                MySqlCommand comando = new MySqlCommand(cadena, conexion);
                comando.Parameters.Add("@username", MySqlDbType.String).Value = username;
                comando.Parameters.Add("@password", MySqlDbType.String).Value = password;
                MySqlDataReader consulta = comando.ExecuteReader();

                Usuario usuario = new Usuario();

                while (consulta.Read())
                {
                    if (!consulta.IsDBNull(0)) { usuario.email = consulta.GetString(0); }
                    if (!consulta.IsDBNull(1)) { usuario.nombre = consulta.GetString(1); }
                    if (!consulta.IsDBNull(2)) { usuario.nombre_usuario = consulta.GetString(2); }
                    if (!consulta.IsDBNull(3)) { usuario.password = consulta.GetString(3); }
                }

                return usuario;

            }
            catch (MySqlException e)
            {
                throw new ExcepcionMotorBDCaido();
            }

        }
    }
}
