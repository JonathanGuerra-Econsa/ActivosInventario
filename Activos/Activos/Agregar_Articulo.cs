using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Activos
{
    public partial class Agregar_Articulo : Form
    {
        public Agregar_Articulo()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseas agregar este artículo?", "Agregar Artículo", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                MessageBox.Show("Artículo agregado correctamente", "Artículo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
    }
}
