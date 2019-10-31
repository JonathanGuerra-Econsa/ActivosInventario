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
    public partial class Agregar_Activo : Form
    {
        public Agregar_Activo()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseas agregar este activo?", "Agregar Activo", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                MessageBox.Show("Activo agregado correctamente", "Activo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
    }
}
