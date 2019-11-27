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
    public partial class Control_GrupoArticulo : Form
    {
        public string option, ID;
        ConsultasMysql mysql = new ConsultasMysql();

        public Control_GrupoArticulo()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void Control_GrupoArticulo_Load(object sender, EventArgs e)
        {
            if (option == "1")
            {
                button1.Text = "Agregar";
            }
            else
            {
                button1.Text = "Guardar Cambios";
                label1.Visible = true;
                label2.Visible = true;
                label2.Text = ID;
                busqueda();
            }
        }

        private void busqueda()
        {
            DataTable dt = mysql.grupo(ID);
            textBox1.Text = dt.Rows[0][1].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") MessageBox.Show("No debe dejar la descripcion vacia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (option == "1")
            {
                if (mysql.addGrupo(textBox1.Text))
                {
                    MessageBox.Show("Tipo agregado correctamente, volviendo al administrador.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Close();
                }
                else
                {
                    MessageBox.Show("Error al agregar el nuevo tipo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (mysql.editGrupo(textBox1.Text, label2.Text))
                {
                    MessageBox.Show("Tipo editado correctamente, volviendo al administrador.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Close();
                }
                else
                {
                    MessageBox.Show("Error al editar el nuevo tipo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
