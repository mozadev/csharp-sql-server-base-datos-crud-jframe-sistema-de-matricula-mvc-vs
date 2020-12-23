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
    public class nProfesor
    {
        dProfesor ObjProfesor;
        public nProfesor()
        {
            ObjProfesor = new dProfesor();
        }
        public void Registrarprofesor(string nombreProfesor, string curso, string tipoContrato)
        {
            Profesor Profesor = new Profesor()

            {
                Nombre = nombreProfesor,
                curso = curso,
                TipoContrato = tipoContrato,

            };

            ObjProfesor.insertar(Profesor);
        }

        public void EliminarProfesor(int id)
        {

            ObjProfesor.eliminar(id);
        }
        public DataTable ListartodosProfesors()
        {
            return ObjProfesor.Listartodo();

        }
        public DataTable ListaProfesornombre(string nombre)
        {


            return ObjProfesor.BuscarprofesorNombre(nombre);
        }

        public DataTable ListaProfesorxCurso(string curso)
        {


            return ObjProfesor.BuscarprofesorCurso(curso);
        }


        public void ModificarProfesor(int idProfesor, string nombreProfesor, string curso, string tipoContrato)
        {
            Profesor Profesor = new Profesor()
            {
                Idprofesor = idProfesor,
                Nombre = nombreProfesor,
                curso = curso,
                TipoContrato = tipoContrato,
            };
            ObjProfesor.modificar(Profesor);

        }



        public DataTable ListaProfesorxCursoParaMatricula(string curso)
        {


            return ObjProfesor.BuscarprofesorCursoParaMatricula(curso);
        }

    }
}
