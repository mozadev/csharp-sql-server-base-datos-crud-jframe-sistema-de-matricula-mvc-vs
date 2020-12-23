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
    public class nCurso
    {
        dCurso ObjCurso;
        public nCurso()
        {
            ObjCurso = new dCurso();
        }
        public void Registrarcurso(string nombrecurso)
        {
            Curso curso = new Curso(){ Nombre = nombrecurso};
            ObjCurso .insertar(curso);
        }

        public void EliminarCurso(int id)
        {
            
            ObjCurso.eliminar(id);
        }
        public DataTable ListartodosCursos()
        {
            return ObjCurso.Listartodo();
            
        }
        public DataTable Listacursonombre(string nombre)
        {


            return ObjCurso.BuscarCursoNombre(nombre);
        }

        public void Modificarcurso(int idcurso, string nombrecurso)
        {
            Curso curso = new Curso()
            {
                Idcurso = idcurso,
                Nombre = nombrecurso
            };
            ObjCurso.modificar(curso);

        }

    }
}
