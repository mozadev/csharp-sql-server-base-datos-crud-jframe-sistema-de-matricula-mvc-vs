using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void alumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAlumno frmalumnos = new frmAlumno();
            frmalumnos.Show();
        }

        private void cursoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmCurso frmcurso = new frmCurso();
            frmcurso.Show();
        }

        private void profesorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProfesor  frmprofesor = new frmProfesor();
            frmprofesor.Show();
        }
    }
}
