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
        //DataTable dt = new DataTable();
        public Administrador_Articulo()
        {
            InitializeComponent();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gbGrupos.Text = comboBox1.Text;
            if (gbGrupos.Text == "Tipos")
            {
                label8.Visible = true;
                lblGrupo.Visible = true;
                dataGridView1.DataSource = mysql.tiposAll();
            }
            else
            {
                label8.Visible = false;
                lblGrupo.Visible = false;
                dataGridView1.DataSource = mysql.gruposAll();
            }
        }

        private void tipos()
        {
            dataGridView1.DataSource = mysql.tiposAll();
        }

        private  void grupos()
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || lblId.Text == dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()) return;
            lblId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            lblTipo.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            if (comboBox1.Text == "Tipos") lblGrupo.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
    }
}
