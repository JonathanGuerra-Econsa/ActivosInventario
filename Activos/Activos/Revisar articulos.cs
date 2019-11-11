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
            #region principal
            this.Height = 160;
            this.CenterToScreen();
            comboBox1.Items.Add("Activo");
            comboBox1.Items.Add("Articulo");
            #endregion

            #region set combobox's
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
            #endregion
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

        #region ocultar card
        private void ocultar()
        {
            this.Height = 160;
            groupBox1.Visible = false;
            this.CenterToScreen();
        }
        #endregion

        #region mostrar card
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
        #endregion

        #region verificacion
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
        #endregion

        #region botones
        private void button1_Click(object sender, EventArgs e)
        {
            if (activo)
            {
                //guarda cambios
                cat.Enabled = false;
                status.Enabled = false;
                user.Enabled = false;
                //date.Enabled = false;
                desc.Enabled = false;
                Emp.Enabled = false;
                button1.Text = "Editar";
                button1.Enabled = true;
                activo = false;
                button3.Enabled = true;
                button2.Visible = false;
                textBox1.Enabled = true;
                comboBox1.Enabled = true;
                if (mysql.editar(desc.Text, Convert.ToInt32(status.SelectedValue), Convert.ToInt32(cat.SelectedValue), Convert.ToInt32(Emp.SelectedValue),comboBox1.Text,Convert.ToInt32(textBox1.Text)))
                {
                    MessageBox.Show(comboBox1.Text+" Editado correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Error al editar el "+textBox1.Text+".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //activa guarda cambios
                cat.Enabled = true;
                status.Enabled = true;
                user.Enabled = false;
                //date.Enabled = true;
                desc.Enabled = true;
                Emp.Enabled = true;
                button1.Text = "Guardar";
                activo = true;
                button2.Visible = true;
                button3.Enabled = false;
                textBox1.Enabled = false;
                comboBox1.Enabled = false;
                button3.Text = "Traspaso";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (activo)
            {
                user.Enabled = false;
                //date.Enabled = false;
                button3.Text = "Traspaso";
                activo = false;
                button2.Visible = false;
                textBox1.Enabled = true;
                comboBox1.Enabled = true;
                button1.Enabled = true;
                bool result = mysql.traspaso(Convert.ToInt32(user.SelectedValue), comboBox1.Text, Convert.ToInt32(textBox1.Text));
                if (result)
                {
                    MessageBox.Show("Traspaso realizado correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Error al realizar el traspaso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                user.Enabled = true;
                //date.Enabled = true;
                button3.Text = "Realizar Traspaso";
                activo = true;
                button2.Visible = true;
                button1.Enabled = false;
                textBox1.Enabled = false;
                comboBox1.Enabled = false;
            }
        }
        #endregion

       
    }
}
