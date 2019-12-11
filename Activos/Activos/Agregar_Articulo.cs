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
    public partial class Agregar_Articulo : Form
    {
        #region Variables
        //--------------------------------------------------------------------------- Variables -------------------------------------------------------------------------------//
        ConsultasMySQL_JG consultasMySQL = new ConsultasMySQL_JG();
        public int opcion, ID;
        //---------------------------------------------------------------------------  -------------------------------------------------------------------------------//
        #endregion
        #region Load()
        //--------------------------------------------------------------------------- Primera Carga del Form (Load) -------------------------------------------------------------------------------//
        public Agregar_Articulo()
        {
            InitializeComponent();
        }
        private void Agregar_Articulo_Load(object sender, EventArgs e)
        {
            llenarComboBox();
            if(opcion == 1)
            {
                vistaAgregar();
                label8.Visible = false;
                lbID.Visible = false;
            }
            else
            {
                vistaDetalle();
            }
        }
        //---------------------------------------------------------------------------  -------------------------------------------------------------------------------//
        #endregion
        #region llenarComboBox()
        //--------------------------------------------------------------------------- Llena los ComboBox que necesita Artículos -------------------------------------------------------------------------------//
        private void llenarComboBox()
        {
            cmbEstado.DataSource = consultasMySQL.verEstados();
            cmbEstado.DisplayMember = "Estado";
            cmbEstado.ValueMember = "ID";

            cmbTipo.DataSource = consultasMySQL.verTipoArt();
            cmbTipo.DisplayMember = "Tipo";
            cmbTipo.ValueMember = "ID";

            cmbEmpresa.DataSource = consultasMySQL.verEmpresa();
            cmbEmpresa.DisplayMember = "Empresa";
            cmbEmpresa.ValueMember = "ID";

            cmbDepartamento.DataSource = consultasMySQL.verDepartamentos();
            cmbDepartamento.DisplayMember = "Departamento";
            cmbDepartamento.ValueMember = "ID";

            string idDepartamento = cmbDepartamento.SelectedValue.ToString();
            cmbUsuario.DataSource = consultasMySQL.verUsuariosDep(idDepartamento);
            cmbUsuario.DisplayMember = "Nombre";
            cmbUsuario.ValueMember = "ID";

            consultasMySQL.buscarUsuario(cmbUsuario.SelectedValue.ToString());
            lbPuesto.Text = consultasMySQL.puestoUsuario;
        }
        //---------------------------------------------------------------------------  -------------------------------------------------------------------------------//
        #endregion
        #region Agregar()
        //--------------------------------------------------------------------------- Botón que agrega un nuevo artículo -------------------------------------------------------------------------------//
        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }
        //---------------------------------------------------------------------------  -------------------------------------------------------------------------------//
        #endregion
        #region vistaDetalle()
        private void vistaDetalle()
        {
            habilitar(false);
            btnEditar.Visible = true;
            btnCancelar.Visible = false;
            try
            {
                consultasMySQL.detalleArticulo(ID.ToString());
                lbID.Text = ID.ToString();
                txtDescripcion.Text = consultasMySQL.descripcion_articulo;
                cmbEstado.Text = consultasMySQL.estado_articulo;
                cmbTipo.Text = consultasMySQL.tipo_articulo;
                cmbEmpresa.Text = consultasMySQL.empresa_articulo;
                cmbDepartamento.Text = consultasMySQL.departamento_articulo;
                cmbUsuario.Text = consultasMySQL.usuario_articulo;
                dtFecha.Text = consultasMySQL.fecha_articulo;
                nuValor.Value = Convert.ToDecimal(consultasMySQL.valor_articulo);
                txtFPC.Text = consultasMySQL.fpc_articulo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
        #region habilitar()
        private void habilitar(bool habilitar)
        {
            txtDescripcion.Enabled = habilitar;
            cmbEstado.Enabled = habilitar;
            cmbTipo.Enabled = habilitar;
            cmbEmpresa.Enabled = habilitar;
            cmbDepartamento.Enabled = habilitar;
            cmbUsuario.Enabled = habilitar;
            dtFecha.Enabled = habilitar;
            nuValor.Enabled = habilitar;
            txtFPC.Enabled = habilitar;
        }
        #endregion
        #region Botón Editar
        private void btnEditar_Click(object sender, EventArgs e)
        {
            habilitar(true);
            btnEditar.Visible = false;
            btnActualizar.Visible = true;
            btnCancelar.Visible = true;
        }
        #endregion
        #region Botón Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            vistaDetalle();
        }
        #endregion
        #region Botón Set
        private void btnSet_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Desea agregar este artículo", "Guardar Artículo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if(txtDescripcion.Text != "" && cmbUsuario.SelectedItem != null && cmbEstado.SelectedItem != null && cmbTipo.SelectedItem != null && cmbEmpresa.SelectedItem != null)
                    {
                        consultasMySQL.addArticulo(txtDescripcion.Text, cmbUsuario.SelectedValue.ToString(), cmbEstado.SelectedValue.ToString(), cmbTipo.SelectedValue.ToString(), cmbEmpresa.SelectedValue.ToString(), dtFecha.Value.ToString("yyyy-MM-dd HH:mm:ss"), nuValor.Value.ToString(), txtFPC.Text);
                        MessageBox.Show("Artículo Guardado", "Guardar Artículo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("Ingrese todos los datos correctamente", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        #endregion
        #region Botón Actualizar
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Desea actualizar este artículo?", "Actualizar Artículo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    consultasMySQL.editArticulo(txtDescripcion.Text, cmbUsuario.SelectedValue.ToString(), cmbEstado.SelectedValue.ToString(), cmbTipo.SelectedValue.ToString(), cmbEmpresa.SelectedValue.ToString(), dtFecha.Value.ToString("yyyy-MM-dd HH:mm:ss"), nuValor.Value.ToString(), txtFPC.Text, lbID.Text);
                    MessageBox.Show("Artículo actualizado correctamente!", "Artículo Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    habilitar(false);
                    vistaDetalle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        #endregion
        #region Value Changed
        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idDepartamento = cmbDepartamento.SelectedValue.ToString();
            cmbUsuario.DataSource = consultasMySQL.verUsuariosDep(idDepartamento);
            cmbUsuario.DisplayMember = "Nombre";
            cmbUsuario.ValueMember = "ID";
        }

        private void cmbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            consultasMySQL.buscarUsuario(cmbUsuario.SelectedValue.ToString());
            lbPuesto.Text = consultasMySQL.puestoUsuario;
        }
        #endregion
        #region vistaAgregar()
        private void vistaAgregar()
        {
            habilitar(true);
            btnSet.Visible = true;
        }
        #endregion
    }
}
