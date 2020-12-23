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
    public partial class frmProfesor : Form
    {

        nProfesor nprofesor = new nProfesor();
        nCurso ncurs = new nCurso();

        public frmProfesor()
        {
            InitializeComponent();
        }

        private void frmProfesor_Load(object sender, EventArgs e)
        {
            ListarProfesor();
            ListarCursos();
        }

        private void ListarProfesor()
        {
            dataprofesor.DataSource = nprofesor.ListartodosProfesors();

        }

        private void ListarCursos()
        {
            cboCurso.DataSource = ncurs.ListartodosCursos();
            cboCurso.DisplayMember = "nombre";
            cboCurso.ValueMember = "idcurso";

        }




        private void BuscarProfesorXCurso(string c )
        {

            dataprofesor.DataSource = nprofesor.ListaProfesorxCurso(cboCurso.Text);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            BuscarProfesorXCurso(cboCurso.Text);
        }

        private void BuscarProfesorXNombre(string nombreprofesor)
        {

            dataprofesor.DataSource = nprofesor.ListaProfesornombre(txtBuscarNombre.Text);
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarProfesorXNombre(txtBuscarNombre.Text);
        }



        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                nprofesor.Registrarprofesor(txtnombre.Text,cboCurso.Text,cboTipoContrato.Text);
                MessageBox.Show("registro ok");
                ListarProfesor();
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
                nprofesor.ModificarProfesor(int.Parse(lblidprofesor.Text), txtnombre.Text, cboCurso.Text, cboTipoContrato.Text);
                MessageBox.Show("Modificado OK");
                ListarProfesor();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                nprofesor.EliminarProfesor(int.Parse(lblidprofesor.Text));
                MessageBox.Show("eliminado ok");
                ListarProfesor();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void dataprofesor_Click(object sender, EventArgs e)
        {
            lblidprofesor.Text = dataprofesor.CurrentRow.Cells[0].Value.ToString();
            txtnombre.Text = dataprofesor.CurrentRow.Cells[1].Value.ToString();
            cboCurso.Text= dataprofesor.CurrentRow.Cells[2].Value.ToString();
            cboTipoContrato.Text = dataprofesor.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnCargarDatos_Click(object sender, EventArgs e)
        {
            ListarProfesor();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
