using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DataBase // hace una conexion a la base de datos
    {
        private SqlConnection conn;
        public SqlConnection ConectaDb()
        {
            try
            {
                string cadenaconexion = "Server=CEMO\\SQLEXPRESS;Database=db Trabajo Final Matricula;Trusted_Connection=True;";
                conn = new SqlConnection(cadenaconexion);
                conn.Open();
                return conn;
            }
            catch (SqlException e)
            {

                return null ;
            }

        }
        public void DesconectaDb()
        {
            conn.Close();
        }
    }
}
