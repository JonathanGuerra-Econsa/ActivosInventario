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
    public partial class DashboardArticulos : Form
    {
        ConsultasMysql mysql = new ConsultasMysql();
        public int idAr;

        public DashboardArticulos()
        {
            InitializeComponent();
        }

        private void DashboardArticulos_Load(object sender, EventArgs e)
        {
            #region combobox articulos
            #region Combo box de Estado
            DataTable estados = new DataTable();
            estados = mysql.estados();

            DataRow nulo3 = estados.NewRow();
            nulo3["nombre"] = "";
            nulo3["idE"] = 0;
            estados.Rows.InsertAt(nulo3, 0);

            cmbArEstado.DisplayMember = "nombre";
            cmbArEstado.ValueMember = "idE";
            cmbArEstado.DataSource = estados;

            cmbArEstado.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbArEstado.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection estadoData = new AutoCompleteStringCollection();
            foreach (DataRow row in estados.Rows)
            {
                estadoData.Add(row["nombre"].ToString());
            }
            cmbArEstado.AutoCompleteCustomSource = estadoData;
            #endregion

            #region Combo box de Departamento
            DataTable departamentos = new DataTable();
            departamentos = mysql.departamentos();

            DataRow nulo4 = departamentos.NewRow();
            nulo4["nombre"] = "";
            nulo4["idD"] = 0;
            departamentos.Rows.InsertAt(nulo4, 0);

            cmbArDepto.DisplayMember = "nombre";
            cmbArDepto.ValueMember = "idD";
            cmbArDepto.DataSource = departamentos;

            cmbArDepto.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbArDepto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection deptoData = new AutoCompleteStringCollection();
            foreach (DataRow row in departamentos.Rows)
            {
                deptoData.Add(row["nombre"].ToString());
            }
            cmbArDepto.AutoCompleteCustomSource = deptoData;
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

            cmbArEmpresa.DisplayMember = "nombre";
            cmbArEmpresa.ValueMember = "idEm";
            cmbArEmpresa.DataSource = empresa;

            cmbArEmpresa.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbArEmpresa.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection empresaData = new AutoCompleteStringCollection();
            foreach (DataRow row in estados.Rows)
            {
                empresaData.Add(row["nombre"].ToString());
            }
            cmbArEmpresa.AutoCompleteCustomSource = empresaData;
            #endregion

            #region Combo box de Status
            DataTable status = new DataTable();
            status = mysql.status();

            DataRow nulo10 = status.NewRow();
            nulo10["nombre"] = "";
            nulo10["idS"] = 0;
            status.Rows.InsertAt(nulo10, 0);

            cmbArStatus.DisplayMember = "nombre";
            cmbArStatus.ValueMember = "idS";
            cmbArStatus.DataSource = status;

            cmbArStatus.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbArStatus.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection statusData = new AutoCompleteStringCollection();
            foreach (DataRow row in status.Rows)
            {
                statusData.Add(row["nombre"].ToString());
            }
            cmbArStatus.AutoCompleteCustomSource = statusData;
            #endregion


            #region Combo box de Grupo
            DataTable subgrupo = new DataTable();
            subgrupo = mysql.gruposAll();

            DataRow nulo1 = subgrupo.NewRow();
            nulo1["Grupo"] = "";
            nulo1["ID"] = 0;
            subgrupo.Rows.InsertAt(nulo1, 0);

            cmbArGrupo.DisplayMember = "Grupo";
            cmbArGrupo.ValueMember = "ID";
            cmbArGrupo.DataSource = subgrupo;

            cmbArGrupo.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbArGrupo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection subgrupoData = new AutoCompleteStringCollection();
            foreach (DataRow row in subgrupo.Rows)
            {
                subgrupoData.Add(row["Grupo"].ToString());
            }
            cmbArGrupo.AutoCompleteCustomSource = subgrupoData;
            #endregion
            #endregion
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
    }
}
