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
   public class dProfesor
    {

        DataBase db = new DataBase();
        SqlConnection cn;
        public void insertar(Profesor obj)
        {
            cn = db.ConectaDb();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO profesor (Nombre,curso,TipoContrato) VALUES(@nombre,@curso,@TipoContrato)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;

            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.Nombre;
            cmd.Parameters.Add("@curso", SqlDbType.VarChar).Value = obj.curso;
            cmd.Parameters.Add("@TipoContrato", SqlDbType.VarChar).Value = obj.TipoContrato;

            cmd.ExecuteNonQuery();

        }
        public void modificar(Profesor obj)
        {
            cn = db.ConectaDb();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE profesor SET Nombre=@nombre,curso=@curso,TipoContrato=@TipoContrato  where idprofesor=@idprofesor";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            cmd.Parameters.Add("@idprofesor", SqlDbType.Int).Value = obj.Idprofesor;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.Nombre;
            cmd.Parameters.Add("@curso", SqlDbType.VarChar).Value = obj.curso;
            cmd.Parameters.Add("@TipoContrato", SqlDbType.VarChar).Value = obj.TipoContrato;

            cmd.ExecuteNonQuery();

        }

        public void eliminar(int id)
        {
            cn = db.ConectaDb();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE from profesor where idprofesor=@idprofesor";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            cmd.Parameters.Add("@idprofesor", SqlDbType.Int).Value = id;
            cmd.ExecuteNonQuery();
        }

        public DataTable BuscarprofesorNombre(string nombre)
        {
            cn = db.ConectaDb();

            SqlDataAdapter da = new SqlDataAdapter("select idprofesor,nombre,curso,TipoContrato from profesor where nombre=@nombre ", cn);

            da.SelectCommand.CommandType = CommandType.Text;

            da.SelectCommand.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;


            DataTable dt = new DataTable();

            da.Fill(dt);
            return dt;
        }

        public DataTable BuscarprofesorCurso(string curso)
        {
            cn = db.ConectaDb();

            SqlDataAdapter da = new SqlDataAdapter("select idprofesor,nombre,curso,TipoContrato from profesor where curso=@curso ", cn);

            da.SelectCommand.CommandType = CommandType.Text;

            da.SelectCommand.Parameters.Add("@curso", SqlDbType.VarChar).Value = curso;


            DataTable dt = new DataTable();

            da.Fill(dt);
            return dt;
        }

        public DataTable Listartodo()
        {

            cn = db.ConectaDb();
            SqlDataAdapter da = new SqlDataAdapter("select idprofesor, nombre,curso,TipoContrato from profesor", cn);


            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }



        public DataTable BuscarprofesorCursoParaMatricula(string  curso)
        {
            cn = db.ConectaDb();

            SqlDataAdapter da = new SqlDataAdapter("select idprofesor,nombre,curso,TipoContrato from profesor where curso=@curso ", cn);

            da.SelectCommand.CommandType = CommandType.Text;

            da.SelectCommand.Parameters.Add("@curso", SqlDbType.VarChar).Value = curso;


            DataTable dt = new DataTable();

            da.Fill(dt);
            return dt;
        }


    }
}
