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
                gbDetalleActivo.Enabled = false;
                gbSubGrupo.Enabled = false;
                gbUsuario.Enabled = false;
                gbValor.Enabled = false;
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
            if(txtDescripcion.Text != "")
            {

            }
        }
        //--------------------------------------------------------------------------------------------------- -------------------------------------------------------------------------------//
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
        #endregion

        private void cmbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idGrupo = cmbGrupo.SelectedValue.ToString();
            cmbSubGrupo.DataSource = consultasMySQL.verSubGrupo(idGrupo);
            cmbSubGrupo.DisplayMember = "Nombre";
            cmbSubGrupo.ValueMember = "ID";
        }

        private void cmbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
