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
    public partial class frmCurso : Form
    {
        nCurso ncurso = new nCurso();

        public frmCurso()
        {
            InitializeComponent();
        }


        private void frmPais_Load(object sender, EventArgs e)
        {
            ListarCurso();
        }



        private void ListarCurso()
        {
            datacurso.DataSource = ncurso.ListartodosCursos();

        }

        private void BuscarCursoXNombre(string nombrecurso)
        {

            datacurso.DataSource = ncurso.Listacursonombre(txtBuscarNombre.Text);
        }

      



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarCursoXNombre(txtBuscarNombre.Text);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
               ncurso.Registrarcurso(txtnombre.Text);
                MessageBox.Show("registro ok");
                ListarCurso();
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
                ncurso.Modificarcurso(int.Parse(lblidcurso.Text), txtnombre.Text);
                MessageBox.Show("Modificado OK");
                ListarCurso();
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
                ncurso.EliminarCurso(int.Parse(lblidcurso.Text));
                MessageBox.Show("eliminado ok");
                ListarCurso();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);    
            }
        }

        private void datapais_Click(object sender, EventArgs e)
        {
            lblidcurso.Text = datacurso.CurrentRow.Cells[0].Value.ToString();
            txtnombre.Text = datacurso.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnCargarDatos_Click(object sender, EventArgs e)
        {
            ListarCurso();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
