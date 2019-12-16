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
        }

        #region Para poner color a los tabs, no esta en uso
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
        #endregion

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

            #region combobox activos
            #region Combo box de Grupos
            DataTable grupo = new DataTable();
            grupo = mysql.grupos();

            DataRow nulo1 = grupo.NewRow();
            nulo1["nombre"] = "";
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
            cmbGrupo.SelectedValue = 0;
            #endregion

            #region Combo box de Status
            DataTable status = new DataTable();
            status = mysql.status();

            DataRow nulo10 = status.NewRow();
            nulo10["nombre"] = "";
            nulo10["idS"] = 0;
            status.Rows.InsertAt(nulo10, 0);

            cmbStatus.DisplayMember = "nombre";
            cmbStatus.ValueMember = "idS";
            cmbStatus.DataSource = status;

            cmbStatus.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbStatus.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection statusData = new AutoCompleteStringCollection();
            foreach (DataRow row in status.Rows)
            {
                statusData.Add(row["nombre"].ToString());
            }
            cmbStatus.AutoCompleteCustomSource = statusData;
            #endregion

            #region Combo box de Estado
            DataTable estados = new DataTable();
            estados = mysql.estados();

            DataRow nulo3 = estados.NewRow();
            nulo3["nombre"] = "";
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
            cmbDepto.SelectedValue = 0;
            #endregion
            #endregion

            #region combobox articulos
            #region Combo box de Estado
            estados = new DataTable();
            estados = mysql.estados();

            nulo3 = estados.NewRow();
            nulo3["nombre"] = "";
            nulo3["idE"] = 0;
            estados.Rows.InsertAt(nulo3, 0);

            cmbArEstado.DisplayMember = "nombre";
            cmbArEstado.ValueMember = "idE";
            cmbArEstado.DataSource = estados;

            cmbArEstado.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbArEstado.AutoCompleteSource = AutoCompleteSource.CustomSource;
            estadoData = new AutoCompleteStringCollection();
            foreach (DataRow row in estados.Rows)
            {
                estadoData.Add(row["nombre"].ToString());
            }
            cmbArEstado.AutoCompleteCustomSource = estadoData;
            #endregion

            #region Combo box de Departamento
            departamentos = new DataTable();
            departamentos = mysql.departamentos();

            nulo4 = departamentos.NewRow();
            nulo4["nombre"] = "";
            nulo4["idD"] = 0;
            departamentos.Rows.InsertAt(nulo4, 0);

            cmbArDepto.DisplayMember = "nombre";
            cmbArDepto.ValueMember = "idD";
            cmbArDepto.DataSource = departamentos;

            cmbArDepto.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbArDepto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            deptoData = new AutoCompleteStringCollection();
            foreach (DataRow row in departamentos.Rows)
            {
                deptoData.Add(row["nombre"].ToString());
            }
            cmbArDepto.AutoCompleteCustomSource = deptoData;
            #endregion

            #region Combo box de Empresa
            empresa = new DataTable();
            empresa.Columns.Add("idEm", typeof(Int32));
            empresa.Columns.Add("nombre", typeof(string));

            nuloem = empresa.NewRow();
            nuloem["nombre"] = "";
            nuloem["idEm"] = 0;
            empresa.Rows.Add(nuloem);

            unhesa = empresa.NewRow();
            unhesa["nombre"] = "Unhesa";
            unhesa["idEm"] = 1;
            empresa.Rows.Add(unhesa);

            proquima = empresa.NewRow();
            proquima["nombre"] = "Proquima";
            proquima["idEm"] = 2;
            empresa.Rows.Add(proquima);

            cmbArEmpresa.DisplayMember = "nombre";
            cmbArEmpresa.ValueMember = "idEm";
            cmbArEmpresa.DataSource = empresa;

            cmbArEmpresa.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbArEmpresa.AutoCompleteSource = AutoCompleteSource.CustomSource;
            empresaData = new AutoCompleteStringCollection();
            foreach (DataRow row in estados.Rows)
            {
                empresaData.Add(row["nombre"].ToString());
            }
            cmbArEmpresa.AutoCompleteCustomSource = empresaData;
            #endregion

            #region Combo box de Status
            status = new DataTable();
            status = mysql.status();

            nulo10 = status.NewRow();
            nulo10["nombre"] = "";
            nulo10["idS"] = 0;
            status.Rows.InsertAt(nulo10, 0);

            cmbArStatus.DisplayMember = "nombre";
            cmbArStatus.ValueMember = "idS";
            cmbArStatus.DataSource = status;

            cmbArStatus.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbArStatus.AutoCompleteSource = AutoCompleteSource.CustomSource;
            statusData = new AutoCompleteStringCollection();
            foreach (DataRow row in status.Rows)
            {
                statusData.Add(row["nombre"].ToString());
            }
            cmbArStatus.AutoCompleteCustomSource = statusData;
            #endregion


            #region Combo box de Grupo
            DataTable subgrupo = new DataTable();
            subgrupo = mysql.gruposAll();

            nulo1 = subgrupo.NewRow();
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

            #region config
            MinimizeBox = false;
            MaximizeBox = false;
            CenterToScreen();
            DatosActivos();
            DatosArticulos();
            tabControl2.Controls.Remove(tabPage4);
            tabControl1.Controls.Remove(tabPage2);
            if (opcion == 2)
            {
                button7.Enabled = false;
            }
            #endregion
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
        
        private void button7_Click(object sender, EventArgs e)
        {
            Lectura lectura = new Lectura();
            lectura.invIdAc = idA;
            lectura.invIdArt = idAr;
            lectura.ShowDialog();
            ActualizarButton(sender, e);
            ActualizarArticulo(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.Controls.Add(tabPage2);
            tabControl1.SelectedTab = tabPage2;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab != tabPage2)tabControl1.Controls.Remove(tabPage2);
        }

        private void ActualizarArticulo(object sender, EventArgs e)
        {
            ArmarConsultaArticulo(sender, e);
            DatosArticulos();
        }

        #region activos

        private void ArmarConsulta(object sender, EventArgs e)
        {
            if (cmbDepto.SelectedValue == null) return;
            StringBuilder consulta = new StringBuilder();
            consulta.Append(" AND ");
            if (cmbEstado.SelectedValue.ToString() != 0.ToString() && cmbEstado.SelectedValue.ToString() != null)
            {
                if (Convert.ToInt32(cmbEstado.SelectedValue) > 0)consulta.Append("e.idEstado = " + cmbEstado.SelectedValue);
                else consulta.Append("e.idEstado IS NULL");
            }
            if (cmbEmpresa.SelectedValue.ToString() != 0.ToString() && cmbEmpresa.SelectedValue.ToString() != null)
            {
                if (consulta.ToString() != " AND ") consulta.Append(" AND ");
                consulta.Append("em.idEmpresa = " + cmbEmpresa.SelectedValue);
            }
            if (cmbStatus.SelectedValue.ToString() != 0.ToString() && cmbStatus.SelectedValue.ToString() != null)
            {
                if (consulta.ToString() != " AND ") consulta.Append(" AND ");
                consulta.Append("s.idStatus = " + cmbStatus.SelectedValue);
            }
            if (cmbUser.SelectedValue.ToString() != 0.ToString() && cmbUser.SelectedValue.ToString() != null)
            {
                if (consulta.ToString() != " AND ") consulta.Append(" AND ");
                consulta.Append("u.idUsuario = " + cmbUser.SelectedValue);
            }
            if (cmbTipo.SelectedValue.ToString() != 0.ToString() && cmbTipo.SelectedValue.ToString() != null)
            {
                if (consulta.ToString() != " AND ") consulta.Append(" AND ");
                consulta.Append("t.idTipo = " + cmbTipo.SelectedValue);
            }
            if (cmbSubgrupo.SelectedValue.ToString() != 0.ToString() && cmbSubgrupo.SelectedValue.ToString() != null)
            {
                if (consulta.ToString() != " AND ") consulta.Append(" AND ");
                consulta.Append("sub.idSubgrupo = " + cmbSubgrupo.SelectedValue);
            }
            if (cmbGrupo.SelectedValue.ToString() != 0.ToString() && cmbGrupo.SelectedValue.ToString() != null)
            {
                if (consulta.ToString() != " AND ") consulta.Append(" AND ");
                consulta.Append("g.idGrupo = " + cmbGrupo.SelectedValue);
            }
            if (cmbDepto.SelectedValue.ToString() != 0.ToString() && cmbDepto.SelectedValue.ToString() != null)
            {
                if (consulta.ToString() != " AND ") consulta.Append(" AND ");
                consulta.Append("u.idDepartamento = " + cmbDepto.SelectedValue);
            }
            if (consulta.ToString() == " AND ") consulta = new StringBuilder();
            dataGridView1.DataSource = mysql.consultaActivoDetalle(idA, consulta.ToString());
        }

        private void ActualizarButton(object sender, EventArgs e)
        {
            ArmarConsulta(sender, e);
            DatosActivos();
        }

        private void cmbDepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable usuarios = new DataTable();
            usuarios = mysql.usuarios(Convert.ToInt32(cmbDepto.SelectedValue));

            DataRow nulo1 = usuarios.NewRow();
            nulo1["nombre"] = "";
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

        private void cmbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable subgrupo = new DataTable();
            subgrupo = mysql.subgrupo(Convert.ToInt32(cmbGrupo.SelectedValue));

            DataRow nulo1 = subgrupo.NewRow();
            nulo1["nombre"] = "";
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

            ArmarConsulta(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cmbEmpresa.SelectedValue = 0;
            cmbStatus.SelectedValue = 0;
            cmbEstado.SelectedValue = 0;
            cmbUser.SelectedValue = 0;
            cmbTipo.SelectedValue = 0;
            cmbSubgrupo.SelectedValue = 0;
            cmbGrupo.SelectedValue = 0;
            cmbDepto.SelectedValue = 0;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dataGridView1.CurrentRow.Index;
            Agregar_Activo agregar = new Agregar_Activo();
            agregar.opcion = 3;
            agregar.inventario = idA;
            agregar.ID = dataGridView1.Rows[row].Cells["idActivo"].Value.ToString();
            agregar.ShowDialog();
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
        #endregion

        #region articulos
        private ArrayList NoContadosArticulos(int id)
        {
            ArrayList noContados = new ArrayList();
            int cont = mysql.ArticulosRevisados(id), noCont = mysql.ArticulosNoRevisados(id);
            noContados.Add(cont);
            noContados.Add(noCont);
            return noContados;
        }

        private void DatosArticulos()
        {
            ArrayList noContados = NoContadosArticulos(idAr), datos = new ArrayList();
            datos.Add("Revisados");
            datos.Add("No Revisados");
            chart1.Series[0].Points.DataBindXY(datos, noContados);
            if ((Convert.ToInt32(noContados[0]) + Convert.ToInt32(noContados[1])) != 0) label6.Text = ((Convert.ToInt32(noContados[0]) * 100) / (Convert.ToInt32(noContados[0]) + Convert.ToInt32(noContados[1]))).ToString() + '%';
            else label6.Text = "0%";
            label3.Text = noContados[0].ToString();
            label9.Text = noContados[1].ToString();
        }

        private void ArmarConsultaArticulo(object sender, EventArgs e)
        {
            if (cmbArGrupo.SelectedValue == null) return;
            StringBuilder consulta = new StringBuilder();
            consulta.Append(" AND ");
            if (cmbArEstado.SelectedValue.ToString() != 0.ToString() && cmbArEstado.SelectedValue.ToString() != null)
            {
                if (Convert.ToInt32(cmbArEstado.SelectedValue) > 0) consulta.Append("e.idEstado = " + cmbArEstado.SelectedValue);
                else consulta.Append("e.idEstado IS NULL");
            }
            if (cmbArEmpresa.SelectedValue.ToString() != 0.ToString() && cmbArEmpresa.SelectedValue.ToString() != null)
            {
                if (consulta.ToString() != " AND ") consulta.Append(" AND ");
                consulta.Append("em.idEmpresa = " + cmbArEmpresa.SelectedValue);
            }
            if (cmbArStatus.SelectedValue.ToString() != 0.ToString() && cmbArStatus.SelectedValue.ToString() != null)
            {
                if (consulta.ToString() != " AND ") consulta.Append(" AND ");
                consulta.Append("s.idStatus = " + cmbArStatus.SelectedValue);
            }
            if (cmbArUser.SelectedValue.ToString() != 0.ToString() && cmbArUser.SelectedValue.ToString() != null)
            {
                if (consulta.ToString() != " AND ") consulta.Append(" AND ");
                consulta.Append("u.idUsuario = " + cmbArUser.SelectedValue);
            }
            if (cmbArTipo.SelectedValue.ToString() != 0.ToString() && cmbArTipo.SelectedValue.ToString() != null)
            {
                if (consulta.ToString() != " AND ") consulta.Append(" AND ");
                consulta.Append("t.idTipoArticulo = " + cmbArTipo.SelectedValue);
            }
            if (cmbArGrupo.SelectedValue.ToString() != 0.ToString() && cmbArGrupo.SelectedValue.ToString() != null)
            {
                if (consulta.ToString() != " AND ") consulta.Append(" AND ");
                consulta.Append("g.idGrupoArticulo = " + cmbArGrupo.SelectedValue);
            }
            if (cmbArDepto.SelectedValue.ToString() != 0.ToString() && cmbArDepto.SelectedValue.ToString() != null)
            {
                if (consulta.ToString() != " AND ") consulta.Append(" AND ");
                consulta.Append("u.idDepartamento = " + cmbArDepto.SelectedValue);
            }
            if (consulta.ToString() == " AND ") consulta = new StringBuilder();
            dataGridView2.DataSource = mysql.consultaArticuloDetalle(idAr, consulta.ToString());
        }

        private void cmbArGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable tipos = new DataTable();
            tipos = mysql.tiposArticulo(Convert.ToInt32(cmbArGrupo.SelectedValue));

            DataRow nulo1 = tipos.NewRow();
            nulo1["nombre"] = "";
            nulo1["idT"] = 0;
            tipos.Rows.InsertAt(nulo1, 0);

            cmbArTipo.DisplayMember = "nombre";
            cmbArTipo.ValueMember = "idT";
            cmbArTipo.DataSource = tipos;

            cmbArTipo.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbArTipo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection tipoData = new AutoCompleteStringCollection();
            foreach (DataRow row in tipos.Rows)
            {
                tipoData.Add(row["nombre"].ToString());
            }
            cmbArTipo.AutoCompleteCustomSource = tipoData;

            ArmarConsulta(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cmbArEstado.SelectedValue = 0;
            cmbArStatus.SelectedValue = 0;
            cmbArEmpresa.SelectedValue = 0;
            cmbArDepto.SelectedValue = 0;
            cmbArUser.SelectedValue = 0;
            cmbArGrupo.SelectedValue = 0;
            cmbArTipo.SelectedValue = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbArDepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable usuarios = new DataTable();
            usuarios = mysql.usuarios(Convert.ToInt32(cmbArDepto.SelectedValue));

            DataRow nulo1 = usuarios.NewRow();
            nulo1["nombre"] = "";
            nulo1["idU"] = 0;
            usuarios.Rows.InsertAt(nulo1, 0);

            cmbArUser.DisplayMember = "nombre";
            cmbArUser.ValueMember = "idU";
            cmbArUser.DataSource = usuarios;

            cmbArUser.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbArUser.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection userData = new AutoCompleteStringCollection();
            foreach (DataRow row in usuarios.Rows)
            {
                userData.Add(row["nombre"].ToString());
            }
            cmbArUser.AutoCompleteCustomSource = userData;

            ArmarConsulta(sender, e);
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dataGridView2.CurrentRow.Index;
            Agregar_Articulo agregar = new Agregar_Articulo();
            agregar.opcion = 3;
            //agregar.inventario = idAr;
            agregar.ID = Convert.ToInt32(dataGridView2.Rows[row].Cells["idArticulo"].Value);
            agregar.ShowDialog();
        }
        #endregion
    }
}
