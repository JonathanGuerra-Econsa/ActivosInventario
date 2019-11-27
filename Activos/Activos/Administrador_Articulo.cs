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
    public partial class Administrador_Articulo : Form
    {
        ConsultasMysql mysql = new ConsultasMysql();

        public Administrador_Articulo()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void Administrador_Articulo_Load(object sender, EventArgs e)
        {
            #region combobox de eleccion de tipo o grupo
            DataTable datosCombobox = new DataTable();
            datosCombobox.Columns.Add("nombre");

            DataRow dato = datosCombobox.NewRow();
            dato["nombre"] = "Tipos";
            datosCombobox.Rows.Add(dato);
            dato = datosCombobox.NewRow();
            dato["nombre"] = "Grupos";
            datosCombobox.Rows.Add(dato);

            comboBox1.DisplayMember = "nombre";
            comboBox1.DataSource = datosCombobox;
            #endregion
            #region llamada de datos tipo
            tipos();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            #endregion
        }

        #region combobox, cambio de seleccion
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gbGrupos.Text = comboBox1.Text;
            if (gbGrupos.Text == "Tipos")
            {
                label8.Visible = true;
                lblGrupo.Visible = true;
                tipos();
            }
            else
            {
                label8.Visible = false;
                lblGrupo.Visible = false;
                grupos();
            }

            lblGrupo.Text = "";
            lblId.Text = "";
            lblTipo.Text = "";
        }
        #endregion

        #region "tipos" en datagrid
        private void tipos()
        {
            dataGridView1.DataSource = mysql.tiposAll();
        }
        #endregion

        #region "grupos" en datagrid
        private void grupos()
        {
            dataGridView1.DataSource = mysql.gruposAll();
        }
        #endregion

        #region "ver detalles" click de datagrid
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || lblId.Text == dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()) return;
            lblId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            lblTipo.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            if (comboBox1.Text == "Tipos") lblGrupo.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
        #endregion

        #region boton "agregar" o "editar"
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Tipos")
            {
                Control_Articulo view = new Control_Articulo();
                view.option = "1";
                view.ShowDialog();
                tipos();
            }
            else
            {
                Control_GrupoArticulo view = new Control_GrupoArticulo();
                view.option = "1";
                view.ShowDialog();
                grupos();
            }
        }
        #endregion

        #region boton "cancelar"
        private void button2_Click(object sender, EventArgs e)
        {
            if (lblId.Text == "")
            {
                MessageBox.Show("Debe seleccionar un dato para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox1.Text == "Tipos")
            {         
                Control_Articulo view = new Control_Articulo();
                view.ID = lblId.Text;
                view.option = "2";
                view.ShowDialog();
                tipos();
            }
            else
            {
                Control_GrupoArticulo view = new Control_GrupoArticulo();
                view.ID = lblId.Text;
                view.option = "2";
                view.ShowDialog();
                grupos();
            }
        }
        #endregion

        #region eliminar (comentado)
        //private void button3_Click(object sender, EventArgs e)
        //{
        //    DialogResult result = MessageBox.Show("¿Esta seguro de eliminar este " + comboBox1.Text.Replace("s", "") + "?", 
        //        "Eliminar " + comboBox1.Text.Replace("s", ""), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        //    if (result == DialogResult.Yes)
        //    {
        //        if(mysql.deleteGrupoTipoArticulo(comboBox1.Text, lblId.Text))
        //        {
        //            MessageBox.Show("Exito");
        //        }
        //        else
        //        {
        //            MessageBox.Show("Error al intentar eliminar. No lo intente de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}
        #endregion
    }
}
