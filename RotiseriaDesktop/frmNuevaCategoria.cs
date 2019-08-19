using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RotiseriaDesktop
{
    public partial class frmNuevaCategoria : Form
    {
        RotiseriaContext db = new RotiseriaContext();
        Categoria categoria = new Categoria();
        Categoria categoriaModificada;
        private int idModificado = 0;

        public frmNuevaCategoria()
        {
            InitializeComponent();
        }

        public frmNuevaCategoria(int id)
        {
            InitializeComponent();
            this.idModificado = id;
            this.cargarDatos();
        }

        private void cargarDatos()
        {
            categoriaModificada = db.Categorias.Find(idModificado);
            txtNombre.Text = categoriaModificada.Nombre;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if(idModificado == 0)
                {
                    categoria.Nombre = txtNombre.Text;
                    db.Categorias.Add(categoria);
                    db.SaveChanges();
                    MessageBox.Show("Dato guardado correctamente", "Categoría", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    if(categoriaModificada != null)
                    {
                        var categoriaMod = db.Categorias.First<Categoria>();
                        categoriaMod.Nombre = txtNombre.Text;
                        db.SaveChanges();
                        MessageBox.Show(categoriaModificada.Nombre + " modificado correctamente", "Categoría", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido el siguiente excepción\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
