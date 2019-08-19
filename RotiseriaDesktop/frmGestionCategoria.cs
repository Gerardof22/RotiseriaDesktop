using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;

namespace RotiseriaDesktop
{
    public partial class frmGestionCategoria : Form
    {
        RotiseriaContext db = new RotiseriaContext();

        public frmGestionCategoria()
        {
            InitializeComponent();
            this.cargarGrillaCategoria();
            this.ocultarColumna();
        }

        private void ocultarColumna()
        {
            dgvGestionCategoria.Columns[0].Visible = false;
        }

        private void cargarGrillaCategoria()
        {
            dgvGestionCategoria.DataSource = db.Categorias.ToList();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNuevaCategoria frmNuevaCategoria = new frmNuevaCategoria();
            frmNuevaCategoria.ShowDialog();
            this.cargarGrillaCategoria();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DataGridViewCellCollection filaActual = dgvGestionCategoria.CurrentRow.Cells;
            int idSeleccionado = (int)filaActual[0].Value;
            String categoriaSeleccionada = (String)filaActual[1].Value;
            DialogResult result = MessageBox.Show("Está seguro que desea eliminar la categoría " + categoriaSeleccionada + "?", "Eliminar categoría", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                if(dgvGestionCategoria.SelectedCells.Count > 0)
                {
                    Categoria categoria = db.Categorias.Find(idSeleccionado);
                    db.Categorias.Remove(categoria);
                    db.SaveChanges();
                    MessageBox.Show("Sea ha eliminado la categoría " + categoriaSeleccionada + " correctamente.", "Categoría", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarGrillaCategoria();
                }
                else
                {
                    MessageBox.Show("No ha seleccionado ninguna categoría.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewCellCollection celdasFilaActual = dgvGestionCategoria.CurrentRow.Cells;
                int idSeleccionado = (int)celdasFilaActual[0].Value;
                Console.WriteLine(idSeleccionado);
                //obtenemos la fila seleccionada actualmente
                int filaSeleccionada = dgvGestionCategoria.CurrentCell.RowIndex;
                frmNuevaCategoria modificarCategoria = new frmNuevaCategoria(idSeleccionado);
                modificarCategoria.ShowDialog();
                cargarGrillaCategoria();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido la siguiente excepción.\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvGestionCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGestionCategoria.CurrentRow != null)
            {
                DataGridViewCellCollection celdasFilaActual = dgvGestionCategoria.CurrentRow.Cells;

                int idSeleccionado = (int)celdasFilaActual[0].Value;
            }
        }
    }
}
