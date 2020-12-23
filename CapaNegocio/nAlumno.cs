using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
   public class nAlumno
    {
        dAlumno alumnodao;
        public nAlumno()
        {
            alumnodao = new dAlumno();
        }
        public void Registraralumno(string nombrealumno,string apellido, int idcurso, int idprofesor)
        {
            Curso curso = new Curso()
            {
                Idcurso = idcurso
            };

            Profesor profesor = new Profesor()
            {
                Idprofesor = idprofesor
            };

            Alumno alumno = new Alumno()
            {
                Nombre = nombrealumno,
                Apellido = apellido,
                curso = curso,
                profesor= profesor,


            };
            alumnodao.Insertar(alumno);

        }

        public void ModificarAlumno(int idalumno, string nombrealumno, string
            apellido, int idcurso, int idprofesor)
        {
            Curso curso = new Curso()
            {
                Idcurso = idcurso
            };

            Profesor profesor = new Profesor()
            {
                Idprofesor = idprofesor
            };


            Alumno alumno = new Alumno()
            {
                Idalumno = idalumno,
                Nombre = nombrealumno,
                Apellido = apellido,
                curso = curso,
                profesor = profesor,
            };
            alumnodao.Modificar(alumno);
        }
        public void Eliminaralumno( int id)
        {
            alumnodao.Eliminar(id);
       
        }

        public DataTable ListarAlumnos()
        {
            return alumnodao.ListarTodoAlumnos();


        }



        public DataTable ListarAlumnosxCurso(string nombrecurso)
        {
            return alumnodao.ListarAlumnosxCurso(nombrecurso);
        }

        public DataTable ListarAlumnosxProfesor(string nombreprofesor)
        {
            return alumnodao.ListarAlumnosxProfesor(nombreprofesor);
        }

    }
}
