using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmAlumno : Form
    {
        nAlumno nalumn = new nAlumno();
        nCurso ncurs = new nCurso();
        nProfesor nprofe = new nProfesor();

        public frmAlumno()
        {
            InitializeComponent();

        }

        private void frmPasajero_Load(object sender, EventArgs e)
        {
            ListarAlumnos();
            ListarCursos();
            //ListarProfesores();
           
        }

        private void ListarAlumnos()
        {
            dataalumnos.DataSource = nalumn.ListarAlumnos();
           
        }

        private void ListarCursos()
        {
            cboCurso.DataSource = ncurs.ListartodosCursos();
            cboCurso.DisplayMember = "nombre";
            cboCurso.ValueMember = "idcurso";

        }

        //private void ListarProfesores()
        //{
        //    cboProfesor.DataSource = nprofe.ListartodosProfesors();
        //    cboProfesor.DisplayMember = "nombre";
        //    cboProfesor.ValueMember = "idprofesor";

        //}

        private void ListarProfesoresparaMatricula(string nombrecursov)
        {
            lstboxProfesor.DataSource = nprofe.ListaProfesorxCursoParaMatricula(cboCurso.Text);
            lstboxProfesor.DisplayMember = "nombre";
            lstboxProfesor.ValueMember = "idprofesor";

        }

        private void cboCurso_SelectedIndexChanged(object sender, EventArgs e)
        {

            ListarProfesoresparaMatricula(cboCurso.SelectedItem.ToString());
        }



        //private void cboCurso_Click(object sender, EventArgs e)
        //{
        //    ListarProfesoresparaMatricula(cboCurso.SelectedItem.ToString());
        //}


        private void button4_Click(object sender, EventArgs e)// buscar
        {
            ListarAlumnoxCurso(cboCurso.SelectedItem.ToString());
        }

        private void ListarAlumnoxCurso(string  nombrecurso)
        {

            dataalumnos.DataSource = nalumn.ListarAlumnosxCurso(cboCurso.Text);
        }




        private void ListarAlumnoxProfesor(string nombreprofesor)
        {

            dataalumnos.DataSource = nalumn.ListarAlumnosxProfesor(lstboxProfesor.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListarAlumnoxProfesor(lstboxProfesor.SelectedItem.ToString());
        }




        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                nalumn.Registraralumno(txtnombre.Text, txtapellido.Text, int.Parse(cboCurso.SelectedValue.ToString()),
                    int.Parse(lstboxProfesor.SelectedValue.ToString()));
                MessageBox.Show("Registro OK");
                ListarAlumnos();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

       




        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                nalumn.ModificarAlumno(int.Parse(lblidalumno.Text), txtnombre.Text, txtapellido.Text, int.Parse(cboCurso.SelectedValue.ToString()),
                    int.Parse(lstboxProfesor.SelectedValue.ToString()));
                MessageBox.Show("Actualizado OK");
                ListarAlumnos();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void datapasajero_Click(object sender, EventArgs e)
        {
            lblidalumno.Text = dataalumnos.CurrentRow.Cells[0].Value.ToString();
            txtnombre.Text = dataalumnos.CurrentRow.Cells[1].Value.ToString();
            txtapellido.Text = dataalumnos.CurrentRow.Cells[2].Value.ToString();
            cboCurso.Text = dataalumnos.CurrentRow.Cells[3].Value.ToString();
            lstboxProfesor.Text = dataalumnos.CurrentRow.Cells[4].Value.ToString();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                nalumn.Eliminaralumno(int.Parse(lblidalumno.Text));
                MessageBox.Show("Elimino OK");
                ListarAlumnos();
            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message);    
            }
        }

        private void btnCargarDatos_Click(object sender, EventArgs e)
        {
            ListarAlumnos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

    }
}
