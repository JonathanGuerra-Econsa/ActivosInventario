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
        bool detalle = true;

        public string ID;
        public int opcion;
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
                btnActualizar.Visible = false;
            }
            else
            {
                metodoMostrar();
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

            cmbUsuario.DataSource = consultasMySQL.verUsuarios();
            cmbUsuario.DisplayMember = "Usuario";
            cmbUsuario.ValueMember = "ID";

            cmbTipo.DataSource = consultasMySQL.verTipos();
            cmbTipo.DisplayMember = "Tipo";
            cmbTipo.ValueMember = "ID";

            cmbEmpresa.DataSource = consultasMySQL.verEmpresa();
            cmbEmpresa.DisplayMember = "Empresa";
            cmbEmpresa.ValueMember = "ID";

            cmbGrupo.DataSource = consultasMySQL.verGrupos();
            cmbGrupo.DisplayMember = "Nombre";
            cmbGrupo.ValueMember = "ID";
        }
        //--------------------------------------------------------------------------------------------------- -------------------------------------------------------------------------------//
        #endregion
        #region Click en Botón Agregar
        //---------------------------------------------------------------------------------- Click en Botón agregar -------------------------------------------------------------------------------//
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            btnSet.Visible = true;
            btnActualizar.Visible = false;
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
        }
        //--------------------------------------------------------------------------------------------------- -------------------------------------------------------------------------------//
        #endregion
        #region Botón que actualiza los activos seleccionados
        //------------------------------------------------ Actualiza el activo seleccionado y actualiza el DataGridView de Activos -----------------------------------//
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if(detalle == true)
            {
                dtFecha.Enabled = false;
            }
            else
            {
                if(MessageBox.Show("Deseas Modificar este Activo?", "Actualizar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    try
                    {
                        consultasMySQL.updateActivo(txtDescripcion.Text, cmbUsuario.SelectedValue.ToString(), cmbEstado.SelectedValue.ToString(), cmbTipo.SelectedValue.ToString(), cmbEmpresa.SelectedValue.ToString(), lbID.Text);
                        MessageBox.Show("Activo Actualizado", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }
        //--------------------------------------------------------------------------------------------------- -------------------------------------------------------------------------------//
        #endregion
        #region Botón que Guarda un nuevo activo
        //-------------------------------------------------------------- Guarda un nuevo Activo -------------------------------------------------------------------------------//
        private void btnSet_Click(object sender, EventArgs e)
        {
            if(txtDescripcion.Text != "" & cmbEstado.SelectedIndex != -1 & cmbTipo.SelectedIndex != -1 
                & cmbEmpresa.SelectedIndex != -1 & dtFecha.Value != null & cmbUsuario.SelectedIndex != -1 
                & cmbSubGrupo.SelectedIndex != -1 & nuValor.Value != 0 & txtFPC.Text != "" & dtDepreciacion.Value != null 
                & nuPorcentaje.Value != 0 & nuDepreciacionAcumulada.Value != 0 & nuValorResidual.Value != 0
                & nuValorLibros.Value != 0)
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
            lbNombreUsuario.Text = consultasMySQL.nombreUsuario;
            lbDepartamentoUsuario.Text = consultasMySQL.nombreDepartamentoUsuario;
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
        #endregion
        #region Método Mostrar
        private void metodoMostrar()
        {
            gbDetalleActivo.Enabled = false;
            gbSubGrupo.Enabled = false;
            gbUsuario.Enabled = false;
            gbValor.Enabled = false;
            MessageBox.Show(ID);
        }
        #endregion
    }
}
