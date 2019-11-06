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
        ConsultasMySQL_JG consultasMySQL = new ConsultasMySQL_JG();
        public Agregar_Usuario()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" || txtPassword.Text != "" || txtUsuario.Text != "")
            {
                if (MessageBox.Show("Deseas agregar a este usuario?", "Agregar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    try
                    {
                        consultasMySQL.agregarUsuario(txtNombre.Text, txtUsuario.Text, txtPassword.Text, cmbDepartamento.SelectedValue.ToString());
                        MessageBox.Show("Usuario agregado correctamente", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Excepción Encontrada: " + ex);
                    }
                }
            }
            else
            {
                MessageBox.Show("Porfavor llene correctamente todos los campos debidamente", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Agregar_Usuario_Load(object sender, EventArgs e)
        {
            cmbDepartamento.DataSource = consultasMySQL.verDepartamentos();
            cmbDepartamento.DisplayMember = "Departamento";
            cmbDepartamento.ValueMember = "ID";
        }
    }
}
