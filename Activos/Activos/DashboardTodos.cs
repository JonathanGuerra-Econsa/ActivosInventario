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
        public int idA, idAr, opcion;
        int heightMax, widthMax;
        ConsultasMysql mysql = new ConsultasMysql(); 

        public DashboardTodos()
        {
            InitializeComponent();
            this.heightMax = Height;
            this.widthMax = Width;
            MinimizeBox = false;
            this.CenterToScreen();
            DatosActivos();
            DatosArticulos();
            tabControl2.Controls.Remove(tabPage4);
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
            dataGridView1.DataSource = mysql.consultaActivoDetalle(idA = 1);
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;


            dataGridView2.DataSource = mysql.consultaArticuloDetalle(idAr = 1);
            dataGridView2.Columns[2].Visible = false;
            dataGridView2.Columns[4].Visible = false;
            dataGridView2.Columns[6].Visible = false;
            dataGridView2.Columns[7].Visible = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
        }

        private void DatosArticulos()
        {            
            ArrayList noContados = NoContadosArticulos(), datos = new ArrayList();
            datos.Add("Revisados");
            datos.Add("No Revisados");
            chart1.Series[0].Points.DataBindXY(datos,noContados);
            label6.Text = ((Convert.ToInt32(noContados[0])*100)/(Convert.ToInt32(noContados[0]) + Convert.ToInt32(noContados[1]))).ToString() + '%';
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
            dataGridView1.DataSource = mysql.consultaActivoDetalle(idA = 1,consulta.ToString());
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
            dataGridView2.DataSource = mysql.consultaArticuloDetalle(idAr = 1, consulta.ToString());
        }

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

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl2.Controls.Add(tabPage4);
            tabControl2.Controls.Remove(tabPage3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl2.Controls.Add(tabPage3);
            tabControl2.Controls.Remove(tabPage4);
        }

        private ArrayList NoContadosArticulos()
        {
            ArrayList noContados = new ArrayList();
            int cont = mysql.ArticulosRevisados(), noCont = mysql.ArticulosNoRevisados();
            noContados.Add(cont);
            noContados.Add(noCont);
            return noContados;
        }

        private void DatosActivos()
        {
            ArrayList noContados = NoContadosActivos(), datos = new ArrayList();
            datos.Add("Revisados");
            datos.Add("No Revisados");
            chart2.Series[0].Points.DataBindXY(datos, noContados);
            label5.Text = ((Convert.ToInt32(noContados[0])*100)/(Convert.ToInt32(noContados[0]) + Convert.ToInt32(noContados[1]))).ToString() + '%';
            label2.Text = noContados[0].ToString();
            label7.Text = noContados[1].ToString();
        }

        private ArrayList NoContadosActivos()
        {
            ArrayList noContados = new ArrayList();
            int cont = mysql.ActivosRevisados(), noCont = mysql.ActivosNoRevisados();
            noContados.Add(cont);
            noContados.Add(noCont);
            return noContados;
        }
    }
}
