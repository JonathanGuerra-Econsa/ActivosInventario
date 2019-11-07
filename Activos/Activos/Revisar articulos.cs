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
        bool activo = false;

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

            //Combo box de USUARIOS
            DataTable usuarios = new DataTable();
            usuarios = mysql.usuarios();

            user.DisplayMember = "nombre";
            user.ValueMember = "idU";
            user.DataSource = usuarios;

            //Combo box de Categoria
            DataTable categorias = new DataTable();
            categorias = mysql.categorias();;

            cat.DisplayMember = "nombre";
            cat.ValueMember = "idC";
            cat.DataSource = categorias;

            //Combo box de Estado
            DataTable estados = new DataTable();
            estados = mysql.estados();

            status.DisplayMember = "nombre";
            status.ValueMember = "idE";
            status.DataSource = estados;

            //Combo box de Empresa
            DataTable empresas = new DataTable();
            empresas = mysql.empresas();

            Emp.DisplayMember = "nombre";
            Emp.ValueMember = "idEm";
            Emp.DataSource = empresas;
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
            date.Value = Convert.ToDateTime(datos.Rows[0]["Fecha De Ingreso"]);
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
            if (activo)
            {
                cat.Enabled = false;
                status.Enabled = false;
                user.Enabled = false;
                date.Enabled = false;
                desc.Enabled = false;
                Emp.Enabled = false;
                button1.Text = "Editar";
                activo = false;
                button2.Visible = false;
            }
            else
            {
                cat.Enabled = true;
                status.Enabled = true;
                user.Enabled = true;
                date.Enabled = true;
                desc.Enabled = true;
                Emp.Enabled = true;
                button1.Text = "Guardar";
                activo = true;
                button2.Visible = true;
            }
        }
    }
}
