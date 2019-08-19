using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RotiseriaDesktop
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void nuevaCategoríaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNuevaCategoria frmNuevaCategoria = new frmNuevaCategoria();
            frmNuevaCategoria.ShowDialog();
        }

        private void gestiónCategoríaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestionCategoria frmGestionCategoria = new frmGestionCategoria();
            frmGestionCategoria.ShowDialog();
        }
    }
}
