using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Excel = Microsoft.Office.Interop.Excel;

namespace Activos
{
    public partial class DashboardTodos : Form
    {
        public int idA , idAr, opcion;
        ConsultasMysql mysql = new ConsultasMysql(); 

        public DashboardTodos()
        {
            InitializeComponent();
            MinimizeBox = false;
            CenterToScreen();
            DatosActivos();
            DatosArticulos();
            tabControl2.Controls.Remove(tabPage4);
            if (opcion == 2)
            {
                button6.Enabled = false;
            }
        }

        //private void tabControl2_DrawItem(object sender, DrawItemEventArgs e)     //Para poner color a los tabs
        //{
        //    switch (e.Index)
        //    {
        //        case 0:
        //            e.Graphics.FillRectangle(new SolidBrush(Color.Red), e.Bounds);
        //            break;
        //        case 1:
        //            e.Graphics.FillRectangle(new SolidBrush(Color.Blue), e.Bounds);
        //            break;
        //        default:
        //            break;
        //    }

        //    // Then draw the current tab button text 
        //    Rectangle paddedBounds = e.Bounds;
        //    paddedBounds.Inflate(-2, -2);
        //    e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, this.Font, SystemBrushes.HighlightText, paddedBounds);
        //}

        private void DashboardTodos_Load(object sender, EventArgs e)
        {
            #region datos de datagrid
            dataGridView1.DataSource = mysql.consultaActivoDetalle(idA);
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[17].Visible = false;
            dataGridView1.Columns[19].Visible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;


            dataGridView2.DataSource = mysql.consultaArticuloDetalle(idAr);
            dataGridView2.Columns[2].Visible = false;
            dataGridView2.Columns[4].Visible = false;
            dataGridView2.Columns[6].Visible = false;
            dataGridView2.Columns[7].Visible = false;
            dataGridView2.Columns[9].Visible = false;
            dataGridView2.Columns[11].Visible = false;
            dataGridView2.Columns[13].Visible = false;
            dataGridView2.Columns[15].Visible = false;
            dataGridView2.Columns[17].Visible = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            #endregion

            #region Combo box de Estado
            DataTable estados = new DataTable();
            estados = mysql.estados();

            DataRow nulo3 = estados.NewRow();
            nulo3["nombre"] = "";
            nulo3["idE"] = 0;
            estados.Rows.InsertAt(nulo3, 0);

            nulo3 = estados.NewRow();
            nulo3["nombre"] = "Sin Revisar";
            nulo3["idE"] = DBNull.Value;
            estados.Rows.InsertAt(nulo3, 1);

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

            #region Combo box de Empresa
            DataTable empresa = new DataTable();
            empresa.Columns.Add("idEm", typeof(Int32));
            empresa.Columns.Add("nombre", typeof(string));

            DataRow nuloem = empresa.NewRow();
            nuloem["nombre"] = "";
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

            #region Combo box de Tipo
            DataTable tipos = new DataTable();
            tipos = mysql.tipos();

            DataRow nulo2 = tipos.NewRow();
            nulo2["nombre"] = "";
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

            #region Combo box de Departamento
            DataTable departamentos = new DataTable();
            departamentos = mysql.departamentos();

            DataRow nulo4 = departamentos.NewRow();
            nulo4["nombre"] = "";
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
        }

        private void DatosArticulos()
        {            
            ArrayList noContados = NoContadosArticulos(idAr), datos = new ArrayList();
            datos.Add("Revisados");
            datos.Add("No Revisados");
            chart1.Series[0].Points.DataBindXY(datos,noContados);
            if ((Convert.ToInt32(noContados[0]) + Convert.ToInt32(noContados[1])) != 0) label6.Text = ((Convert.ToInt32(noContados[0]) * 100) / (Convert.ToInt32(noContados[0]) + Convert.ToInt32(noContados[1]))).ToString() + '%';
            else label6.Text = "0%";
            label3.Text = noContados[0].ToString();
            label9.Text = noContados[1].ToString();
        }

        private void ArmarConsulta(object sender, EventArgs e)
        {
            StringBuilder consulta = new StringBuilder();
            consulta.Append(" AND ");
            if (true)
            {

            }
            if (true)
            {
                if (consulta.ToString() != " AND ") consulta.Append(" AND ");

            }
            if (consulta.ToString() == " AND ") consulta = new StringBuilder();
            dataGridView1.DataSource = mysql.consultaActivoDetalle(idA,consulta.ToString());
        }

        private void ArmarConsultaArticulo(object sender, EventArgs e)
        {
            StringBuilder consulta = new StringBuilder();
            consulta.Append(" AND ");
            if (true)
            {
               
            }
            if (true)
            {
                if (consulta.ToString() != " AND ") consulta.Append(" AND ");

            }
            if (consulta.ToString() == " AND ") consulta = new StringBuilder();
            dataGridView2.DataSource = mysql.consultaArticuloDetalle(idAr, consulta.ToString());
        }

        #region Excel
        private void excelAc_Click(object sender, EventArgs e)
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

        private void excelArt_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.DataSource != null)
                {
                    dataGridView2.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                    dataGridView2.MultiSelect = true;
                    dataGridView2.SelectAll();
                    DataObject dataObj = dataGridView2.GetClipboardContent();
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
                    dataGridView2.ClearSelection();
                    dataGridView2.MultiSelect = false;
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
        #endregion

        #region botones cambio de tab
        private void button2_Click(object sender, EventArgs e)
        {
            tabControl2.Controls.Add(tabPage4);
            tabControl2.SelectedTab = tabPage4;
            //tabControl2.Controls.Remove(tabPage3);
        }

        private void atrasActivos(object sender, EventArgs e)
        {
            //tabControl2.Controls.Add(tabPage3);
            if (tabControl2.SelectedTab != tabPage4)tabControl2.Controls.Remove(tabPage4);
        }
        #endregion

        private ArrayList NoContadosArticulos(int id)
        {
            ArrayList noContados = new ArrayList();
            int cont = mysql.ArticulosRevisados(id), noCont = mysql.ArticulosNoRevisados(id);
            noContados.Add(cont);
            noContados.Add(noCont);
            return noContados;
        }

        private void ActualizarButton(object sender, EventArgs e)
        {
            ArmarConsulta(sender, e);
            DatosActivos();
        }

        private void ActualizarArticulo(object sender, EventArgs e)
        {
            ArmarConsultaArticulo(sender, e);
            DatosArticulos();
        }

        private void DatosActivos()
        {
            ArrayList noContados = NoContadosActivos(idA), datos = new ArrayList();
            datos.Add("Revisados");
            datos.Add("No Revisados");
            chart2.Series[0].Points.DataBindXY(datos, noContados);
            if ((Convert.ToInt32(noContados[0]) + Convert.ToInt32(noContados[1])) != 0) label5.Text = ((Convert.ToInt32(noContados[0]) * 100) / (Convert.ToInt32(noContados[0]) + Convert.ToInt32(noContados[1]))).ToString() + '%';
            else label5.Text = "0%";
            label2.Text = noContados[0].ToString();
            label7.Text = noContados[1].ToString();
        }

        private ArrayList NoContadosActivos(int id)
        {
            ArrayList noContados = new ArrayList();
            int cont = mysql.ActivosRevisados(id), noCont = mysql.ActivosNoRevisados(id);
            noContados.Add(cont);
            noContados.Add(noCont);
            return noContados;
        }
    }
}
