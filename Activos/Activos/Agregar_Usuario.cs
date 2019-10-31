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
    public partial class Agregar_Usuario : Form
    {
        public Agregar_Usuario()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Deseas agregar a este usuario?", "Agregar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                MessageBox.Show("Usuario agregado correctamente", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
    }
}
