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
    public partial class Articulos : Form
    {
        ConsultasMysql mysql = new ConsultasMysql();
        DateTime fechaI = new DateTime(2000, 1, 1), fechaF = DateTime.Today, fechaAntI, fechaAntF;

        private void Articulos_Load(object sender, EventArgs e)
        {
            //datos
            dataGridView1.DataSource = mysql.consulta("articulo");
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[7].Visible = false;

            //DataRow nulo1 = usuarios.NewRow();
            //nulo1["nombre"] = "Escoger Usuario...";
            //nulo1["idU"] = 0;
            //usuarios.Rows.InsertAt(nulo1, 0);

            //cmbUsuario.DisplayMember = "nombre";
            //cmbUsuario.ValueMember = "idU";
            //cmbUsuario.DataSource = usuarios;

            //cmbUsuario.AutoCompleteMode = AutoCompleteMode.Suggest;
            //cmbUsuario.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //AutoCompleteStringCollection userData = new AutoCompleteStringCollection();
            //foreach (DataRow row in usuarios.Rows)
            //{
            //    userData.Add(row["nombre"].ToString());
            //}
            //cmbUsuario.AutoCompleteCustomSource = userData;

            ////Combo box de Categoria
            //DataTable categorias = new DataTable();
            //categorias = mysql.categorias();

            //DataRow nulo2 = categorias.NewRow();
            //nulo2["nombre"] = "Escoger Categoria...";
            //nulo2["idC"] = 0;
            //categorias.Rows.InsertAt(nulo2, 0);

            //cmbCat.DisplayMember = "nombre";
            //cmbCat.ValueMember = "idC";
            //cmbCat.DataSource = categorias;

            //cmbCat.AutoCompleteMode = AutoCompleteMode.Suggest;
            //cmbCat.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //AutoCompleteStringCollection catData = new AutoCompleteStringCollection();
            //foreach (DataRow row in categorias.Rows)
            //{
            //    catData.Add(row["nombre"].ToString());
            //}
            //cmbCat.AutoCompleteCustomSource = catData;

            //Combo box de Estado
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
        }

        public Articulos()
        {
            InitializeComponent();
        }

        private void Limpiar(object sender, EventArgs e)
        {
        }

        private void FormarConsulta(object sender, EventArgs e)
        {
           
        }
    }
}
