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
    public partial class Activos : Form
    {
        ConsultasMysql mysql = new ConsultasMysql();

        public Activos()
        {
            InitializeComponent();
        }

        private void Activos_Load(object sender, EventArgs e)
        {
            //datos
            dataGridView1.DataSource = mysql.consulta("activo");
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[18].Visible = false;
            dataGridView1.Columns[20].Visible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;

            #region Combo box de Grupos
            DataTable grupo = new DataTable();
            grupo = mysql.grupo();

            DataRow nulo1 = grupo.NewRow();
            nulo1["nombre"] = "Escoger Grupo...";
            nulo1["idG"] = 0;
            grupo.Rows.InsertAt(nulo1, 0);

            cmbGrupo.DisplayMember = "nombre";
            cmbGrupo.ValueMember = "idG";
            cmbGrupo.DataSource = grupo;

            cmbGrupo.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbGrupo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection grupoData = new AutoCompleteStringCollection();
            foreach (DataRow row in grupo.Rows)
            {
                grupoData.Add(row["nombre"].ToString());
            }
            cmbGrupo.AutoCompleteCustomSource = grupoData;
            #endregion
            #region Combo box de Estado
            DataTable estados = new DataTable();
            estados = mysql.estados();

            DataRow nulo3 = estados.NewRow();
            nulo3["nombre"] = "Escoger Estado...";
            nulo3["idE"] = 0;
            estados.Rows.InsertAt(nulo3, 0);

            cmbEstado.DisplayMember = "nombre";
            cmbEstado.ValueMember = "idE";
            cmbEstado.DataSource = estados;

            cmbEstado.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbEstado.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection estadoData = new AutoCompleteStringCollection();
            foreach (DataRow row in estados.Rows)
            {
                estadoData.Add(row["nombre"].ToString());
            }
            cmbEstado.AutoCompleteCustomSource = estadoData;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            #endregion
            #region Combo box de Tipo
            DataTable tipos = new DataTable();
            tipos = mysql.tipos();

            DataRow nulo2 = tipos.NewRow();
            nulo2["nombre"] = "Escoger Tipo...";
            nulo2["idT"] = 0;
            tipos.Rows.InsertAt(nulo2, 0);

            cmbTipo.DisplayMember = "nombre";
            cmbTipo.ValueMember = "idE";
            cmbTipo.DataSource = tipos;

            cmbTipo.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbTipo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection tipoData = new AutoCompleteStringCollection();
            foreach (DataRow row in tipos.Rows)
            {
                tipoData.Add(row["nombre"].ToString());
            }
            cmbTipo.AutoCompleteCustomSource = estadoData;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            #endregion
        }

        private void ArmarConsulta(object sender, EventArgs e)
        {            
            if (cmbEstado.SelectedValue == null) return;
            StringBuilder consulta = new StringBuilder();
            consulta.Append("WHERE ");
            #region comentarios 2
            //if (!(string.IsNullOrEmpty(textBox7.Text))) consulta.Append("a.descripcion like '%" + textBox7.Text + "%' AND ");
            //if (cmbUsuario.SelectedValue.ToString() != 0.ToString() && cmbUsuario.SelectedValue.ToString() != null) consulta.Append("u.idUsuario like '%" + cmbUsuario.SelectedValue + "%' AND ");
            //if (cmbCat.SelectedValue.ToString() != 0.ToString() && cmbCat.SelectedValue.ToString() != null) consulta.Append("c.idCategoria like '%" + cmbCat.SelectedValue + "%' AND ");
            if (cmbEstado.SelectedValue.ToString() != 0.ToString() && cmbEstado.SelectedValue.ToString() != null)
            {
                if (consulta.ToString() != "WHERE ")  ;
                consulta.Append("e.idEstado = " + cmbEstado.SelectedValue);
            }
            //consulta.Append("a.fecha_ingreso BETWEEN '"+ dateInicio.Value.Date.ToString("yyyy-MM-dd") + "' AND '" + dateFinal.Value.Date.ToString("yyyy-MM-dd") + "' ORDER BY idActivo");
            if (consulta.ToString() == "WHERE ") consulta = new StringBuilder();
                        
            //DataRowView dv = (DataRowView)cmbUsuario.SelectedItem;
            //int id = (int)dv.Row["idU"];;
            #endregion
            Console.WriteLine(consulta);
            dataGridView1.DataSource = mysql.consulta("activo",consulta.ToString());
        }

        private void limpiarDatos(object sender, EventArgs e)
        {
            //cmbEstado.SelectedValue = 0;
            //cmbCat.SelectedValue = 0;
            //cmbUsuario.SelectedValue = 0;
            //textBox7.Text = "";
            //dateInicio.Value = fechaI;
            //dateFinal.Value = fechaF;
        }

        private void cmbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGrupo.SelectedValue == null) return;
            DataTable subgrupo = new DataTable();
            subgrupo = mysql.subgrupo(Convert.ToInt32(cmbGrupo.SelectedValue));

            DataRow nulo1 = subgrupo.NewRow();
            nulo1["nombre"] = "Escoger SubGrupo...";
            nulo1["idS"] = 0;
            subgrupo.Rows.InsertAt(nulo1, 0);

            cmbSubgrupo.DisplayMember = "nombre";
            cmbSubgrupo.ValueMember = "idS";
            cmbSubgrupo.DataSource = subgrupo;

            cmbSubgrupo.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbSubgrupo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection subgrupoData = new AutoCompleteStringCollection();
            foreach (DataRow row in subgrupo.Rows)
            {
                subgrupoData.Add(row["nombre"].ToString());
            }
            cmbGrupo.AutoCompleteCustomSource = subgrupoData;

            ArmarConsulta(sender,e);
        }
    }
}
