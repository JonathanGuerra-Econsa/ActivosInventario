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
    public partial class Control_Articulo : Form
    {
        public string option, ID;
        ConsultasMysql mysql = new ConsultasMysql();

        public Control_Articulo()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Control_Articulo_Load(object sender, EventArgs e)
        {
            llenarCombobox();
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
            DataTable dt = mysql.tipo(ID);
            textBox1.Text = dt.Rows[0][1].ToString();
            comboBox1.SelectedValue = dt.Rows[0][2].ToString();
        }

        private void llenarCombobox()
        {
            DataTable dt = mysql.gruposAll();

            comboBox1.DisplayMember = "Grupo";
            comboBox1.ValueMember = "ID";
            comboBox1.DataSource = dt;

            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection grupoData = new AutoCompleteStringCollection();
            foreach (DataRow row in dt.Rows)
            {
                grupoData.Add(row["Grupo"].ToString());
            }
            comboBox1.AutoCompleteCustomSource = grupoData;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null) MessageBox.Show("Debe seleccionar un grupo valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (textBox1.Text == "") MessageBox.Show("No debe dejar la descripcion vacia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (option == "1")
            {
                if (mysql.addTipo(textBox1.Text, comboBox1.SelectedValue.ToString()))
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
                if (mysql.editTipo(textBox1.Text, comboBox1.SelectedValue.ToString(), label2.Text))
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
    }
}
