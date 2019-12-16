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
    public partial class Agregar_Activo : Form
    {
        #region Variables
        //----------------------------------------------------------*Variables*---------------------------------------------------//
        ConsultasMySQL_JG consultasMySQL =new  ConsultasMySQL_JG();
        public string ID;
        public int opcion, inventario;
        //--------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Load
        //------------------------------------------------------------ Inicio LOAD -----------------------------------------------//
        public Agregar_Activo()
        {
            InitializeComponent();
        }
        private void Agregar_Activo_Load(object sender, EventArgs e)
        {
            if (opcion == 1)
            {
                llenarComboBox();
                lbID.Text = "";
                btnSet.Visible = true;
                btnEditar.Visible = false;
            }
            else if (opcion == 2)
            {
                metodoMostrar();
            }
            else if (opcion == 3)
            {
                metodoMostrar();
                btnEditar.Visible = true;
                btnEditar.Text = "Historial";
            }
        }
        //--------------------------------------------------------------------- --------------------------------------------------------------//
        #endregion
        #region Llenar ComboBox()
        //------------------------------------------------------------------------------ Llenar los ComboBox que Necesita Activos -------------------------------------------------------------------------------//
        private void llenarComboBox()
        {
            cmbEstado.DataSource = consultasMySQL.verEstados();
            cmbEstado.DisplayMember = "Estado";
            cmbEstado.ValueMember = "ID";

            cmbTipo.DataSource = consultasMySQL.verTipos();
            cmbTipo.DisplayMember = "Tipo";
            cmbTipo.ValueMember = "ID";

            cmbEmpresa.DataSource = consultasMySQL.verEmpresa();
            cmbEmpresa.DisplayMember = "Empresa";
            cmbEmpresa.ValueMember = "ID";

            cmbGrupo.DataSource = consultasMySQL.verGrupos();
            cmbGrupo.DisplayMember = "Nombre";
            cmbGrupo.ValueMember = "ID";

            cmbDepartamento.DataSource = consultasMySQL.verDepartamentos();
            cmbDepartamento.DisplayMember = "Departamento";
            cmbDepartamento.ValueMember = "ID";

            string idDepartamento = cmbDepartamento.SelectedValue.ToString();
            cmbUsuario.Text = "";
            cmbUsuario.DataSource = consultasMySQL.filtrarUsuarioDep(idDepartamento);
            cmbUsuario.DisplayMember = "Nombre";
            cmbUsuario.ValueMember = "ID";

            string idGrupo = cmbGrupo.SelectedValue.ToString();
            cmbSubGrupo.DataSource = consultasMySQL.verSubGrupo(idGrupo);
            cmbSubGrupo.DisplayMember = "Nombre";
            cmbSubGrupo.ValueMember = "ID";
        }
        //--------------------------------------------------------------------------------------------------- -------------------------------------------------------------------------------//
        #endregion
        #region Click en Botón Agregar
        //---------------------------------------------------------------------------------- Click en Botón agregar -------------------------------------------------------------------------------//
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            btnSet.Visible = true;
            btnEditar.Visible = false;
            lbID.Text = "";
            txtDescripcion.Text = "";
            cmbUsuario.Text = "";
            cmbEstado.Text = "";
            cmbTipo.Text = "";
            cmbEmpresa.Text = "";
            dtFecha.Text = DateTime.Now.ToString();
        }
        //--------------------------------------------------------------------------------------------------- -------------------------------------------------------------------------------//
        #endregion
        #region Botón Cancelar
        //--------------------------------------------------------------- Llama a actualizarDGV() -------------------------------------------------------------------------------//
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea cancelar la edición de este activo?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                metodoMostrar();
                btnCancelar.Visible = false;
            }
        }
        //--------------------------------------------------------------------------------------------------- -------------------------------------------------------------------------------//
        #endregion
        #region Botón que actualiza los activos seleccionados
        //------------------------------------------------ Actualiza el activo seleccionado y actualiza el DataGridView de Activos -----------------------------------//
        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (opcion == 3)
            {
                Historial historial = new Historial();
                historial.id = Convert.ToInt32(lbID.Text);
                historial.opcion = 1;
                historial.inventario = inventario;
                historial.ShowDialog();
                return;
            }
            txtDescripcion.Enabled = true;
            cmbEstado.Enabled = true;
            cmbTipo.Enabled = true;
            cmbEmpresa.Enabled = true;
            dtFecha.Enabled = true;
            cmbUsuario.Enabled = true;
            cmbGrupo.Enabled = true;
            cmbSubGrupo.Enabled = true;
            cmbDepartamento.Enabled = true;
            nuValor.Enabled = true;
            txtFPC.Enabled = true;
            dtDepreciacion.Enabled = true;
            nuPorcentaje.Enabled = true;
            nuDepreciacionAcumulada.Enabled = true;
            nuValorResidual.Enabled = true;
            nuValorLibros.Enabled = true;
            btnActualiza.Visible = true;
            btnEditar.Visible = false;
            btnCancelar.Visible = true;
        }
        //--------------------------------------------------------------------------------------------------- -------------------------------------------------------------------------------//
        //-----------------------------------------------------------------------------------------Actualizar() ---------------------------------------------------------------------//
        private void btnActualiza_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea actualizar este activo con esta nueva información?", "Actualizar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string des = txtDescripcion.Text;
                    string idusuario = Convert.ToString(cmbUsuario.SelectedValue);
                    string idestado = Convert.ToString(cmbEstado.SelectedValue);
                    string idtipo = Convert.ToString(cmbTipo.SelectedValue);
                    string idempresa = Convert.ToString(cmbEmpresa.SelectedValue);
                    string fecha_compra = dtFecha.Value.ToString("yyyy-MM-dd");
                    string valor = Convert.ToString(nuValor.Value);
                    string fpc = txtFPC.Text;
                    string fechadep= dtDepreciacion.Value.ToString("yyyy-MM-dd");
                    string porcentajedep = Convert.ToString(nuPorcentaje.Value);
                    string depacumulada = Convert.ToString(nuDepreciacionAcumulada.Value);
                    string valorresidual = Convert.ToString(nuValorResidual.Value);
                    string valorlibros= Convert.ToString(nuValorLibros.Value);
                    string idsubgrupo = Convert.ToString(cmbSubGrupo.SelectedValue);
                    string idactivo = lbID.Text;
                    consultasMySQL.updateActivo(des, idusuario, idestado, idtipo, idempresa, fecha_compra, valor, fpc, fechadep, porcentajedep, depacumulada, valorresidual, valorlibros, idsubgrupo, idactivo);
                    MessageBox.Show("Activo Actualizado !", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    metodoMostrar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Botón que Guarda un nuevo activo
        //-------------------------------------------------------------- Guarda un nuevo Activo -------------------------------------------------------------------------------//
        private void btnSet_Click(object sender, EventArgs e)
        {
            if(txtDescripcion.Text != "" & cmbEstado.SelectedIndex != -1 & cmbTipo.SelectedIndex != -1 
                & cmbEmpresa.SelectedIndex != -1 & dtFecha.Value != null & cmbUsuario.SelectedIndex != -1 
                & cmbSubGrupo.SelectedIndex != -1 & nuValor.Value != 0 & txtFPC.Text != "" & dtDepreciacion.Value != null )
            {
                if (MessageBox.Show("Desea guardar este activo?", "Guardar Activo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    try
                    {
                        string descricpion = txtDescripcion.Text;
                        string idEstado = cmbEstado.SelectedValue.ToString();
                        string idTipo = cmbTipo.SelectedValue.ToString();
                        string idEmpresa = cmbEmpresa.SelectedValue.ToString();
                        string fecha_compra = dtFecha.Value.ToString("yyyy-MM-dd");
                        string idUsuario = cmbUsuario.SelectedValue.ToString();
                        string idSubgrupo = cmbSubGrupo.SelectedValue.ToString();
                        string valor = nuValor.Value.ToString();
                        string fpc = txtFPC.Text;
                        string fecha_depreciacion = dtDepreciacion.Value.ToString("yyyy-MM-dd");
                        string porcentajeDep = nuPorcentaje.Value.ToString();
                        string depAcumulada = nuDepreciacionAcumulada.Value.ToString();
                        string valorResidual = nuValorResidual.Value.ToString();
                        string valorLibro = nuValorLibros.Value.ToString();
                        consultasMySQL.agregarActivo(descricpion, idUsuario, idEstado, idTipo, idEmpresa, fecha_compra, valor, fpc, fecha_depreciacion, porcentajeDep, depAcumulada, valorResidual, valorLibro, idSubgrupo);
                        MessageBox.Show("Activo Guardado con éxtio", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor llene el formulario completamente", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region SelectedIndexChanged
        //--------------------------------------- CmbUsuario ---------------------------------------------//
        private void cmbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idUsuario = cmbUsuario.SelectedValue.ToString();
            consultasMySQL.buscarUsuario(idUsuario);
            lbPuesto.Text = consultasMySQL.puestoUsuario;
        }
        //-------------------------------------------------------------------------------------------------//
        //--------------------------------------- cmbGrupo ---------------------------------------------//
        private void cmbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idGrupo = cmbGrupo.SelectedValue.ToString();
            cmbSubGrupo.DataSource = consultasMySQL.verSubGrupo(idGrupo);
            cmbSubGrupo.DisplayMember = "Nombre";
            cmbSubGrupo.ValueMember = "ID";
        }
        //---------------------------------------------------------------------------------------------------//
        //----------------------------------------cmbDepto----------------------------------------------//
        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idDepartamento = cmbDepartamento.SelectedValue.ToString();
            cmbUsuario.Text = "";
            cmbUsuario.DataSource = consultasMySQL.filtrarUsuarioDep(idDepartamento);
            cmbUsuario.DisplayMember = "Nombre";
            cmbUsuario.ValueMember = "ID";
        }
        //---------------------------------------------------------------------------------------------------//
        #endregion
        #region Método Mostrar
        private void metodoMostrar()
        {
            llenarComboBox();
            txtDescripcion.Enabled = false; ;
            cmbEstado.Enabled = false;
            cmbTipo.Enabled = false;
            cmbEmpresa.Enabled = false;
            dtFecha.Enabled = false;
            cmbUsuario.Enabled = false;
            cmbGrupo.Enabled = false;
            cmbSubGrupo.Enabled = false;
            cmbDepartamento.Enabled = false;
            nuValor.Enabled = false;
            txtFPC.Enabled = false;
            dtDepreciacion.Enabled = false;
            nuPorcentaje.Enabled = false;
            nuDepreciacionAcumulada.Enabled = false;
            nuValorResidual.Enabled = false;
            nuValorLibros.Enabled = false;

            btnEditar.Visible = true;
            btnActualiza.Visible = false;
            btnCancelar.Visible = false;
            btnSet.Visible = false;
            asignacionDeVariables();
        }
        #endregion
        #region asignacion de variables
        public void asignacionDeVariables()
        {
            lbID.Text = ID;
            consultasMySQL.detalleActivo(ID);
            txtDescripcion.Text = consultasMySQL.descripcion;
            cmbEstado.Text= consultasMySQL.estado;
            cmbTipo.Text = consultasMySQL.tipo;
            cmbEmpresa.Text = consultasMySQL.empresa;
            cmbDepartamento.Text = consultasMySQL.departamentoUsuario;
            dtFecha.Value = Convert.ToDateTime(consultasMySQL.fecha_compra);
            cmbUsuario.Text = consultasMySQL.usuario;
            lbPuesto.Text = consultasMySQL.puestoUsuario;
            cmbGrupo.Text = consultasMySQL.grupo;
            cmbSubGrupo.Text = consultasMySQL.subgrupo;
            nuValor.Value = Convert.ToDecimal(consultasMySQL.valor);
            txtFPC.Text = consultasMySQL.fpc;
            dtDepreciacion.Value = Convert.ToDateTime(consultasMySQL.fechaDep);
            nuPorcentaje.Value = Convert.ToDecimal(consultasMySQL.porcentajeDep);
            nuDepreciacionAcumulada.Value = Convert.ToDecimal(consultasMySQL.depAcumulada);
            nuValorResidual.Value = Convert.ToDecimal(consultasMySQL.valorResidual);
            nuValorLibros.Value = Convert.ToDecimal(consultasMySQL.valorLibros);
        }
        #endregion

    }
}
