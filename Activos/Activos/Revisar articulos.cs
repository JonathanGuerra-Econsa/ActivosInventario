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
    public partial class Revisar_articulos : Form
    {
        ConsultasMysql mysql = new ConsultasMysql();
        DataTable datos = new DataTable();


        public Revisar_articulos()
        {
            InitializeComponent();
        }

        private void Revisar_articulos_Load(object sender, EventArgs e)
        {
            this.Height = 160;
            this.CenterToScreen();
            comboBox1.Items.Add("activo");
            comboBox1.Items.Add("articulo");
        }

        private void Busqueda()
        {
            try { 
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    ocultar();
                    return;
                }
                datos = mysql.buscar(comboBox1.Text, textBox1.Text);
                mostrar();
            }
            catch
            {
                ocultar();
                MessageBox.Show("El id '" + textBox1.Text + "' no se encuentra en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
                this.ActiveControl = textBox1;                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if (string.IsNullOrEmpty(comboBox1.Text)) return;
            Busqueda();
        }
        
        private void ocultar()
        {
            this.Height = 160;
            groupBox1.Visible = false;
            this.CenterToScreen();
        }

        private void mostrar()
        {
            this.Height = 381;
            groupBox1.Visible = true;
            desc.Text = datos.Rows[0]["Descripcion"].ToString();
            user.Text = datos.Rows[0]["Usuario"].ToString();
            status.Text = datos.Rows[0]["Estado"].ToString();
            cat.Text = datos.Rows[0]["Categoria"].ToString();
            Emp.Text = datos.Rows[0]["Empresa"].ToString();
            //groupBox1.Text = datos.Rows[0]["Descripcion"].ToString();
            this.CenterToScreen();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            timer1.Stop();
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            timer1.Start();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;
            if (string.IsNullOrEmpty(textBox1.Text)) return;
            Busqueda();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new editar().ShowDialog();
        }
    }
}
