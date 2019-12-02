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
            if(opcion == 1)
            {
                vistaAgregar();
            }
            else
            {
                vistaDetalle();
            }
            llenarComboBox();
        }
        //---------------------------------------------------------------------------  -------------------------------------------------------------------------------//
        #endregion
        #region llenarComboBox()
        //--------------------------------------------------------------------------- Llena los ComboBox que necesita Artículos -------------------------------------------------------------------------------//
        private void llenarComboBox()
        {
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
                    MessageBox.Show("Artículo Guardado", "Guardar Artículo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Hide();
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
        #region vistaAgregar()
        private void vistaAgregar()
        {
            habilitar(true);
            btnSet.Visible = true;
        }
        #endregion
    }
}
