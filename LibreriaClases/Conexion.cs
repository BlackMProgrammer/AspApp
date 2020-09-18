using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace LibreriaClases
{
    public class Conexion
    {
        private string connsetting;
        private string mensaje;

        public Conexion(string config) 
        {
            connsetting = config;
        }

        protected DataTable Buscar(string sqlscript) 
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = this.connsetting;
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlscript, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable tabla = new DataTable();
                tabla.Load(reader);
                reader.Close();
                cmd = null;
                conn.Close();
                return tabla;
            }
            catch (SqlException e)
            {
                mensaje = e.Message;
              return null;
            }

        }

        public DataTable Buscar(string entidad, string columnas, string criterio)
        {
            if (columnas == "")
                columnas = "*";
            string SQL = "SELECT TOP 10 \n" + columnas;
            SQL += "\n FROM " + entidad;
            SQL += "\n WHERE " + criterio;
            /*el order by normal.... pudiera ser 1,2 */
            return Buscar(SQL);
        }

        protected bool cambiar(string chgsql)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = this.connsetting;
                SqlCommand cmd = new SqlCommand(chgsql, conn);
                cmd.ExecuteNonQuery();
                cmd = null;
                conn.Close();
                return true;
            }
            catch(SqlException e) {
                mensaje = e.Message;
                return false;
            }
        }
    }
}
