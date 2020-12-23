using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public  class Alumno
    {
        public int Idalumno { get; set; }
        public string  Nombre { get; set; }
        public string Apellido { get; set; }
        public Curso curso { get; set; }
        public Profesor profesor { get; set; }
      

    }
}
