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
    public partial class Agregar_Departamento : Form
    {
        public Agregar_Departamento()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseas agregar este departamento?", "Agregar Departamento", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                MessageBox.Show("Departamento agregado correctamente", "Departamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
    }
}
