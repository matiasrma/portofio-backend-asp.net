﻿using Dominio;
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
    public class SkillRepositorio : ISkillRepositorio
    {
        private readonly IConexionDB conexionDB;
        private readonly MySqlConnection conexion;

        public SkillRepositorio(IConexionDB _conexionDB)
        {
            this.conexionDB = _conexionDB;
            this.conexion = this.conexionDB.Open();
        }

        public List<Skill> ObtenerLista(int persona_id)
        {
            string cadena = "SELECT \n" +
                "id, \n" +
                "img_skill, \n" +
                "nombre_skill, \n" +
                "percentage_skill, \n" +
                "show_img, \n" +
                "persona_id \n" +
                "FROM skill \n" +
                "WHERE persona_id = @persona_id;";

            try
            {
                MySqlCommand comando = new MySqlCommand(cadena, conexion);
                comando.Parameters.Add("@persona_id", MySqlDbType.String).Value = persona_id;
                MySqlDataReader consulta = comando.ExecuteReader();

                List<Skill> lista = new List<Skill>();

                while (consulta.Read())
                {
                    Skill skill = new Skill();

                    if (!consulta.IsDBNull(0)) { skill.Id = consulta.GetInt32(0); }
                    if (!consulta.IsDBNull(1)) { skill.img_skill = consulta.GetString(1); }
                    if (!consulta.IsDBNull(2)) { skill.nombre_skill = consulta.GetString(2); }
                    if (!consulta.IsDBNull(3)) { skill.percentage_skill = consulta.GetInt32(3); }
                    if (!consulta.IsDBNull(4)) { skill.show_img = consulta.GetByte(4); }
                    if (!consulta.IsDBNull(5)) { skill.persona_id = consulta.GetInt32(5); }

                    lista.Add(skill);
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

        public void Guardar(List<Skill> lista)
        {
            string cadena = "INSERT INTO skill (\n" +
                "id, \n" +
                "img_skill, \n" +
                "nombre_skill, \n" +
                "percentage_skill, \n" +
                "show_img, \n" +
                "persona_id \n" +
                ") VALUES \n";

            lista.ForEach(skill =>
            {
                cadena += "('" +
                skill.Id + "', \n'" +
                skill.img_skill + "', \n'" +
                skill.nombre_skill + "', \n'" +
                skill.percentage_skill + "', \n" +
                skill.show_img + ", \n" +
                "@persona_id), \n";
            });

            cadena = cadena.Substring(0, cadena.Length - 3);

            cadena +=
                " ON DUPLICATE KEY UPDATE \n" +
                "id = VALUES (id), \n" +
                "img_skill = VALUES (img_skill), \n" +
                "nombre_skill = VALUES (nombre_skill), \n" +
                "percentage_skill = VALUES (percentage_skill), \n" +
                "show_img = VALUES (show_img), \n" +
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

        public void Eliminar(List<Skill> lista)
        {            
            string cadena = "DELETE FROM skill WHERE id IN ('";

            lista.ForEach(skill =>
            {
                cadena += skill.Id + "', '";
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
