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
    public partial class Bajas : Form
    {
        #region varibales
        ConsultasMySQL_JG consultasMysql = new ConsultasMySQL_JG();
        ConsultasMysql mysql = new ConsultasMysql();
        DateTime dateNow = DateTime.Now;
        string prueba;
        string titulo;
        string justificacion;
        string observacion;
        string idUsuario;
        string fecha;
        string idEstadoCaso;
        string idCaso;
        #endregion
        #region Load()
        public Bajas()
        {
            InitializeComponent();
        }
        private void Bajas_Load(object sender, EventArgs e)
        {
            lbFecha.Text = dateNow.ToString("dd/MM/yyyy HH:mm");

            DataGridViewCheckBoxColumn CheckBoxColumn = new DataGridViewCheckBoxColumn();
            CheckBoxColumn.HeaderText = "✓";
            dgvActivos.Columns.Add(CheckBoxColumn);

            dgvActivos.DataSource = consultasMysql.verActivos();
            dgvActivos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvActivos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvActivos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvActivos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            llenarCmbDepartamento();
            llenarCmb();
        }
        #endregion
        #region Check boton click
        private void chk_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvActivos.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = !(chk.Value == null ? false : (bool)chk.Value);
            }
        }
        #endregion
        #region btnEnviar
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (txtTitulo.Text != "" && txtJustificacion.Text != "" && txtObservacion.Text != "" && cmbUsuario.SelectedValue != null)
            {
                capturarID();
                titulo = txtTitulo.Text;
                justificacion = txtJustificacion.Text;
                observacion = txtObservacion.Text;
                idUsuario = cmbUsuario.SelectedValue.ToString();
                idEstadoCaso = "1";
                fecha = dateNow.ToString("yyyy-MM-dd HH:mm:ss");
                try
                {
                    consultasMysql.ingresarCaso(titulo, fecha, idUsuario, justificacion, observacion, idEstadoCaso);
                    idCaso = consultasMysql.obtenerIdCaso(fecha);
                    if (idCaso != "")
                    {
                        consultasMysql.ingresarDetalle(idCaso, prueba);
                        MessageBox.Show("Caso pedido con éxito", "Caso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepción en la consulta");
                }
            }
            else
            {
                MessageBox.Show("Ingrese todos los datos", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }
        #endregion
        #region capturarID()
        private void capturarID()
        {
            int contador = 0;
            foreach (DataGridViewRow row in dgvActivos.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    if (contador == 0)
                    {
                        prueba = row.Cells[1].Value.ToString();
                    }
                    else
                    {
                        prueba = prueba + "," + row.Cells[1].Value.ToString();
                    }
                    contador++;
                }
            }
        }
        #endregion
        #region llenarCmbDepartamento
        private void llenarCmbDepartamento()
        {
            cmbDepartamento.DataSource = consultasMysql.verDepartamentos();
            cmbDepartamento.DisplayMember = "Departamento";
            cmbDepartamento.ValueMember = "ID";

            string idDepartamento = cmbDepartamento.SelectedValue.ToString();
            cmbUsuario.Text = "";
            cmbUsuario.DataSource = consultasMysql.filtrarUsuarioDep(idDepartamento);
            cmbUsuario.DisplayMember = "Nombre";
            cmbUsuario.ValueMember = "ID";
        }
        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idDepartamento = cmbDepartamento.SelectedValue.ToString();
            cmbUsuario.Text = "";
            cmbUsuario.DataSource = consultasMysql.filtrarUsuarioDep(idDepartamento);
            cmbUsuario.DisplayMember = "Nombre";
            cmbUsuario.ValueMember = "ID";
        }
        #endregion
        #region llenarCmb
        public void llenarCmb()
        {
            #region Grupos
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
            #endregion
            #region estados
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
            #endregion
        }
        #endregion
        #region Departamento Selected Index Changed
        #region departamento
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
        }
        #endregion
        public void ArmarConsulta(object sender, EventArgs e)
        {
            functionActualizar();
        }
        public void functionActualizar()
        {
            if (cmbDepto.SelectedValue == null) return;
            StringBuilder consulta = new StringBuilder();
            consulta.Append("WHERE ");

            if (cmbEstado.SelectedValue.ToString() != 0.ToString() && cmbEstado.SelectedValue.ToString() != null) consulta.Append("e.idEstado = " + cmbEstado.SelectedValue);
            if (cmbGrupo.SelectedValue.ToString() != 0.ToString() && cmbGrupo.SelectedValue.ToString() != null)
            {
                if (consulta.ToString() != "WHERE ") consulta.Append(" AND ");
                consulta.Append("g.idGrupo = " + cmbGrupo.SelectedValue);
            }
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
                int n;
                if (consulta.ToString() != "WHERE ") consulta.Append(" AND ");
                if (int.TryParse(textBox1.Text, out n)) consulta.Append("a.idActivo = " + textBox1.Text);
                else
                {
                    textBox1.Text = textBox1.Text.Replace('\'', '-');
                    consulta.Append("a.codigo = '" + textBox1.Text + "'");
                }
            }
            ////----- En caso de que de error, pruebe con lo siguiente
            //DataRowView drv = cmbTipo.SelectedItem as DataRowView;
            //string value = string.Empty;
            //value = drv.Row["idT"].ToString();
            ////----
            //if (value.ToString() != 0.ToString() && value.ToString() != null)
            //{
            //    if(drv != null) { 
            //        if (consulta.ToString() != "WHERE ") consulta.Append(" AND ");t
            //        consulta.Append("c.idTipo = " + value);
            //    }
            //}
            if (consulta.ToString() == "WHERE ")
            {
                consulta.Append("a.idActivo NOT IN( SELECT idActivo FROM detalle_caso )");
            }
            else
            {
                if (consulta.ToString() != "WHERE ") consulta.Append(" AND ");
                consulta.Append("a.idActivo NOT IN( SELECT idActivo FROM detalle_caso )");
            }
            dgvActivos.DataSource = mysql.consulta(consulta.ToString());
            #region datos
            dgvActivos.Columns[4].Visible = false;
            dgvActivos.Columns[6].Visible = false;
            dgvActivos.Columns[8].Visible = false;

            dgvActivos.Columns[10].Visible = false;
            dgvActivos.Columns[11].Visible = false;
            dgvActivos.Columns[12].Visible = false;

            dgvActivos.Columns[13].Visible = false;
            dgvActivos.Columns[14].Visible = false;
            dgvActivos.Columns[15].Visible = false;
            dgvActivos.Columns[16].Visible = false;
            dgvActivos.Columns[17].Visible = false;

            dgvActivos.Columns[19].Visible = false;
            dgvActivos.Columns[21].Visible = false;
            dgvActivos.Columns[22].Visible = false;
            dgvActivos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvActivos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            #endregion
        }
        #endregion
        #region Selecteds Index Changeds
        #region grupo
        private void cmbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbTipo.SelectedValue == null) return;
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
        }
        #endregion
        #endregion
        #region botón buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ArmarConsulta(sender, e);
        }
        #endregion
        #region botón limpiar
        private void button2_Click(object sender, EventArgs e)
        {
            cmbUser.SelectedValue = 0;
            cmbTipo.SelectedValue = 0;
            cmbSubgrupo.SelectedValue = 0;
            cmbGrupo.SelectedValue = 0;
            cmbEstado.SelectedValue = 0;
            cmbDepto.SelectedValue = 0;
            textBox1.Text = "";
            cmbEmpresa.SelectedValue = 0;
            ArmarConsulta(sender, e);
        }
        #endregion
    }
}
