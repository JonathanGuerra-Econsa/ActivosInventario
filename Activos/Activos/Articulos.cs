using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Activos
{
    public partial class Articulos : Form
    {
        ConsultasMysql mysql = new ConsultasMysql();

        private void Articulos_Load(object sender, EventArgs e)
        {
            #region datos
            dataGridView1.DataSource = mysql.consultaArticulo();
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
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
            #endregion
            #region Combo box de Departamento
            DataTable departamentos = new DataTable();
            departamentos = mysql.departamentos();

            DataRow nulo4 = departamentos.NewRow();
            nulo4["nombre"] = "Escoger Departamento...";
            nulo4["idD"] = 0;
            departamentos.Rows.InsertAt(nulo4, 0);

            cmbDepto.DisplayMember = "nombre";
            cmbDepto.ValueMember = "idD";
            cmbDepto.DataSource = departamentos;

            cmbDepto.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbDepto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection deptoData = new AutoCompleteStringCollection();
            foreach (DataRow row in departamentos.Rows)
            {
                deptoData.Add(row["nombre"].ToString());
            }
            cmbDepto.AutoCompleteCustomSource = deptoData;
            #endregion
            #region Combo box de Empresa
            DataTable empresa = new DataTable();
            empresa.Columns.Add("idEm", typeof(Int32));
            empresa.Columns.Add("nombre", typeof(string));

            DataRow nuloem = empresa.NewRow();
            nuloem["nombre"] = "Escoger Estado...";
            nuloem["idEm"] = 0;
            empresa.Rows.Add(nuloem);

            DataRow unhesa = empresa.NewRow();
            unhesa["nombre"] = "Unhesa";
            unhesa["idEm"] = 1;
            empresa.Rows.Add(unhesa);

            DataRow proquima = empresa.NewRow();
            proquima["nombre"] = "Proquima";
            proquima["idEm"] = 2;
            empresa.Rows.Add(proquima);

            cmbEmpresa.DisplayMember = "nombre";
            cmbEmpresa.ValueMember = "idEm";
            cmbEmpresa.DataSource = empresa;

            cmbEmpresa.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbEmpresa.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection empresaData = new AutoCompleteStringCollection();
            foreach (DataRow row in estados.Rows)
            {
                empresaData.Add(row["nombre"].ToString());
            }
            cmbEmpresa.AutoCompleteCustomSource = empresaData;
            #endregion
            #region Combo box de Subgrupo
            DataTable subgrupo = new DataTable();
            subgrupo = mysql.subgrupo(5);

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
            cmbSubgrupo.AutoCompleteCustomSource = subgrupoData;
            #endregion
        }

        private void cmbDepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepto.SelectedValue.ToString() == 0.ToString())
            {
                label11.Visible = false;
                cmbUser.Visible = false;
            }
            else
            {
                label11.Visible = true;
                cmbUser.Visible = true;
            }
            DataTable usuarios = new DataTable();
            usuarios = mysql.usuarios(Convert.ToInt32(cmbDepto.SelectedValue));

            DataRow nulo1 = usuarios.NewRow();
            nulo1["nombre"] = "Escoger Usuario...";
            nulo1["idU"] = 0;
            usuarios.Rows.InsertAt(nulo1, 0);

            cmbUser.DisplayMember = "nombre";
            cmbUser.ValueMember = "idU";
            cmbUser.DataSource = usuarios;

            cmbUser.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbUser.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection userData = new AutoCompleteStringCollection();
            foreach (DataRow row in usuarios.Rows)
            {
                userData.Add(row["nombre"].ToString());
            }
            cmbUser.AutoCompleteCustomSource = userData;

            ArmarConsulta(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Agregar_Articulo nuevoForm = new Agregar_Articulo();
            nuevoForm.opcion = 2;
            nuevoForm.ShowDialog();
            Limpiar(sender, e);
            ArmarConsulta(sender, e);
        }

        private void ArmarConsulta(object sender, EventArgs e)
        {
            if (cmbSubgrupo.SelectedValue == null) return;
            StringBuilder consulta = new StringBuilder();
            consulta.Append("WHERE ");

            if (cmbEstado.SelectedValue.ToString() != 0.ToString() && cmbEstado.SelectedValue.ToString() != null) consulta.Append("e.idEstado = " + cmbEstado.SelectedValue);
            if (cmbSubgrupo.SelectedValue.ToString() != 0.ToString() && cmbSubgrupo.SelectedValue.ToString() != null)
            {
                if (consulta.ToString() != "WHERE ") consulta.Append(" AND ");
                consulta.Append("s.idSubgrupo = " + cmbSubgrupo.SelectedValue);
            }
            if (cmbDepto.SelectedValue.ToString() != 0.ToString() && cmbSubgrupo.SelectedValue.ToString() != null)
            {
                if (consulta.ToString() != "WHERE ") consulta.Append(" AND ");
                consulta.Append("d.idDepartamento = " + cmbDepto.SelectedValue);
            }
            if (cmbUser.SelectedValue.ToString() != 0.ToString() && cmbUser.SelectedValue.ToString() != null)
            {
                if (consulta.ToString() != "WHERE ") consulta.Append(" AND ");
                consulta.Append("u.idUsuario = " + cmbUser.SelectedValue);
            }
            if (cmbTipo.SelectedValue.ToString() != 0.ToString() && cmbTipo.SelectedValue.ToString() != null)
            {
                if (consulta.ToString() != "WHERE ") consulta.Append(" AND ");
                consulta.Append("c.idTipo = " + cmbTipo.SelectedValue);
            }
            if (cmbEmpresa.SelectedValue.ToString() != 0.ToString() && cmbEmpresa.SelectedValue.ToString() != null)
            {
                if (consulta.ToString() != "WHERE ") consulta.Append(" AND ");
                consulta.Append("em.nombre = '" + cmbEmpresa.Text + "'");
            }
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                if (consulta.ToString() != "WHERE ") consulta.Append(" AND ");
                consulta.Append("a.idActivo = " + textBox1.Text);
            }
            if (consulta.ToString() == "WHERE ") consulta = new StringBuilder();

            dataGridView1.DataSource = mysql.consultaArticulo(consulta.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.DataSource != null)
                {
                    dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                    dataGridView1.MultiSelect = true;
                    dataGridView1.SelectAll();
                    DataObject dataObj = dataGridView1.GetClipboardContent();
                    if (dataObj != null)
                        Clipboard.SetDataObject(dataObj);

                    Microsoft.Office.Interop.Excel.Application xlexcel;
                    Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                    Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                    object misValue = System.Reflection.Missing.Value;
                    xlexcel = new Excel.Application();
                    xlWorkBook = xlexcel.Workbooks.Add(misValue);
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    //Convierto en string todo el formato
                    Excel.Range filas = xlWorkSheet.Rows;
                    filas.NumberFormat = "@";
                    filas.Select();

                    Excel.Range rango = (Excel.Range)xlWorkSheet.Cells[1, 1];
                    rango.Select();
                    xlWorkSheet.PasteSpecial(rango, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                    //  la primera fila en negrita, centrada y con fondo gris
                    Excel.Range fila1 = (Excel.Range)xlWorkSheet.Rows[1];
                    fila1.Select();
                    fila1.EntireRow.Font.Bold = true;
                    fila1.EntireRow.HorizontalAlignment = HorizontalAlignment.Center;
                    // si la primera celda de la primera columna está vacía, elimino la primera columna
                    Excel.Range c1f1 = (Excel.Range)xlWorkSheet.Cells[1, 1];
                    if (c1f1.Text == "")
                    {
                        Excel.Range columna1 = (Excel.Range)xlWorkSheet.Columns[1];
                        columna1.Select();
                        columna1.Delete();
                    }

                    //selecciono la primera celda de la primera columna
                    Excel.Range c1 = (Excel.Range)xlWorkSheet.Cells[1, 1];
                    c1.Select();
                    xlexcel.Cells.Select();
                    xlexcel.Cells.EntireColumn.AutoFit();
                    xlexcel.Visible = true;
                    dataGridView1.ClearSelection();
                    dataGridView1.MultiSelect = false;
                }
                else
                {
                    MessageBox.Show("No hay nada en la tabla...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Articulos()
        {
            InitializeComponent();
        }

        private void Limpiar(object sender, EventArgs e)
        {
            cmbUser.SelectedValue = 0;
            cmbTipo.SelectedValue = 0;
            cmbSubgrupo.SelectedValue = 0;
            cmbEstado.SelectedValue = 0;
            cmbDepto.SelectedValue = 0;
            textBox1.Text = "";
            cmbEmpresa.SelectedValue = 0;
            ArmarConsulta(sender, e);
        }

        private void cmbSubgrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Combo box de Tipo
            DataTable tipos = new DataTable();
            tipos = mysql.tipos(Convert.ToInt32(cmbSubgrupo.SelectedValue));

            DataRow nulo2 = tipos.NewRow();
            nulo2["nombre"] = "Escoger Tipo...";
            nulo2["idT"] = 0;
            tipos.Rows.InsertAt(nulo2, 0);

            cmbTipo.DisplayMember = "nombre";
            cmbTipo.ValueMember = "idT";
            cmbTipo.DataSource = tipos;

            cmbTipo.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbTipo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection tipoData = new AutoCompleteStringCollection();
            foreach (DataRow row in tipos.Rows)
            {
                tipoData.Add(row["nombre"].ToString());
            }
            cmbTipo.AutoCompleteCustomSource = tipoData;
            #endregion

            ArmarConsulta(sender,e);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            ArmarConsulta(sender, e);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dataGridView1.CurrentRow.Index;
            Agregar_Activo agregar = new Agregar_Activo();
            agregar.opcion = 2;
            agregar.ID = dataGridView1.Rows[row].Cells["ID"].Value.ToString();
            agregar.ShowDialog();
            ArmarConsulta(sender, e);
        }
    }
}
