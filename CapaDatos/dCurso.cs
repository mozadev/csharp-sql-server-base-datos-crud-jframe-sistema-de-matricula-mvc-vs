using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using CapaEntidad;



namespace CapaDatos
{
    public class dCurso
    {
        
        DataBase db = new DataBase();
        SqlConnection cn;
        public void insertar(Curso obj) 
        {
            cn = db.ConectaDb(); 
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Curso(Nombre) VALUES(@nombre)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
           
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.Nombre;
          
            cmd.ExecuteNonQuery();
            
        }
        public void modificar(Curso obj)
        {
            cn = db.ConectaDb();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE Curso SET Nombre=@nombre where idcurso=@idcurso";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            cmd.Parameters.Add("@idcurso", SqlDbType.Int).Value = obj.Idcurso;// seteando los valores, 
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.Nombre;
            cmd.ExecuteNonQuery();
           
        }

        public void eliminar( int id)
        {
            cn = db.ConectaDb();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE from curso where idcurso=@idcurso";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            cmd.Parameters.Add("@idcurso", SqlDbType.Int).Value = id;
            cmd.ExecuteNonQuery ();
        }
        
         public DataTable BuscarCursoNombre(string nombre)
        {
            cn = db.ConectaDb();
           
            SqlDataAdapter da = new SqlDataAdapter("select idcurso,nombre from curso where nombre=@nombre ", cn);
            
            da.SelectCommand.CommandType = CommandType.Text;
           
            da.SelectCommand.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
           

            DataTable dt = new DataTable();
           
            da.Fill(dt);
            return dt;

        }

        public DataTable Listartodo()
        {
            
            cn = db.ConectaDb();
            SqlDataAdapter da = new SqlDataAdapter("select idcurso, nombre from curso", cn);
           
            
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
