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
        ConsultasMySQL_JG consultasMySQL = new ConsultasMySQL_JG();
        public Agregar_Departamento()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtDepartamento.Text != "")
            {
                if (MessageBox.Show("Deseas agregar este departamento?", "Agregar Departamento", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    try
                    {
                        consultasMySQL.agregarDepartamento(txtDepartamento.Text);
                        MessageBox.Show("Departamento agregado correctamente", "Departamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Exepción encontrada: " + ex);
                    }
                }
            }
            else
            {
                MessageBox.Show("Escriba el nombre del Departamento", "Valor Vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
