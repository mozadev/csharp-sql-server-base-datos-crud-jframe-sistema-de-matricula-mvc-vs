using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using CapaEntidad; // hace referencia a capa entidades

namespace CapaDatos
{
    public class dAlumno
    {
        DataBase db = new DataBase();
        SqlConnection cn; // perimite conectarme a la base de datos

        public void Insertar(Alumno o)
        {
            cn = db.ConectaDb();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into alumno(nombre,apellido,idcurso,idprofesor)values(@nombre,@apellido,@idcurso,@idprofesor)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;

            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = o.Nombre;
            cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = o.Apellido;
            cmd.Parameters.Add("@idcurso", SqlDbType.Int).Value = o.curso.Idcurso;
            cmd.Parameters.Add("@idprofesor", SqlDbType.Int).Value = o.profesor.Idprofesor;
            cmd.ExecuteNonQuery();


        }

        public void Modificar(Alumno o)
        {
            cn = db.ConectaDb();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update alumno set nombre=@nombre,apellido=@apellido,idcurso=@idcurso,idprofesor=@idprofesor  where idalumno=@idalumno";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;

            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = o.Nombre;
            cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = o.Apellido;

            cmd.Parameters.Add("@idcurso", SqlDbType.Int).Value = o.curso.Idcurso;
            cmd.Parameters.Add("@idprofesor", SqlDbType.Int).Value = o.profesor.Idprofesor;
            cmd.Parameters.Add("@idalumno", SqlDbType.Int).Value = o.Idalumno;

            cmd.ExecuteNonQuery();

        }

        public void Eliminar(int idalumno)
        {
            cn = db.ConectaDb();
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "delete from alumno where idalumno=@idalumno";
            cm.CommandType = CommandType.Text;
            cm.Connection = cn;

            cm.Parameters.Add("@idalumno", SqlDbType.Int).Value = idalumno;
            cm.ExecuteNonQuery();

        }

        public DataTable ListarTodoAlumnos()
        {
            cn = db.ConectaDb();
            SqlDataAdapter  da = new SqlDataAdapter("select alu.idalumno, alu.Nombre, alu.Apellido,cu.Nombre as curso,prof.Nombre as profesor ,cu.idcurso, prof.idprofesor from curso as cu, profesor as prof, alumno as alu where cu.Idcurso=alu.Idcurso and prof.Idprofesor=alu.Idprofesor ", cn);
            da.SelectCommand.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;


        }
        public DataTable ListarAlumnosxCurso(String nombrecurso)
        {
            cn = db.ConectaDb();
           SqlDataAdapter da = new SqlDataAdapter("select alu.idalumno, alu.Nombre, alu.Apellido,cu.Nombre as curso,prof.Nombre as profesor  , cu.idcurso, prof.idprofesor from curso as cu, profesor as prof, alumno as alu where cu.Idcurso=alu.Idcurso and prof.Idprofesor=alu.Idprofesor and cu.nombre=@nombrecurso ", cn);
            da.SelectCommand.CommandType = CommandType.Text;

            da.SelectCommand.Parameters.Add("@nombrecurso", SqlDbType.VarChar).Value = nombrecurso;


            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable ListarAlumnosxProfesor(String nombreprofesor)
        {
            cn = db.ConectaDb();
            SqlDataAdapter da = new SqlDataAdapter("select alu.idalumno, alu.Nombre, alu.Apellido,cu.Nombre as curso,prof.Nombre as profesor  ,  cu.idcurso , prof.idprofesor from curso as cu, profesor as prof, alumno as alu where cu.Idcurso=alu.Idcurso and prof.Idprofesor=alu.Idprofesor and prof.nombre=@nombreprofesor ", cn);
            da.SelectCommand.CommandType = CommandType.Text;

            da.SelectCommand.Parameters.Add("@nombreprofesor", SqlDbType.VarChar).Value = nombreprofesor;


            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


    }
}
