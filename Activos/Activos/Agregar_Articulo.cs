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
        }
        //---------------------------------------------------------------------------  -------------------------------------------------------------------------------//
        #endregion
        #region llenarComboBox()
        //--------------------------------------------------------------------------- Llena los ComboBox que necesita Artículos -------------------------------------------------------------------------------//
        private void llenarComboBox()
        {
            cmbUsuario.DataSource = consultasMySQL.verUsuarios();
            cmbUsuario.DisplayMember = "Usuario";
            cmbUsuario.ValueMember = "ID";

            cmbEstado.DataSource = consultasMySQL.verEstados();
            cmbEstado.DisplayMember = "Estado";
            cmbEstado.ValueMember = "ID";

            cmbCategoria.DataSource = consultasMySQL.verTipos();
            cmbCategoria.DisplayMember = "Categoria";
            cmbCategoria.ValueMember = "ID";

            cmbEmpresa.DataSource = consultasMySQL.verEmpresa();
            cmbEmpresa.DisplayMember = "Empresa";
            cmbEmpresa.ValueMember = "ID";
        }
        //---------------------------------------------------------------------------  -------------------------------------------------------------------------------//
        #endregion
        #region Agregar()
        //--------------------------------------------------------------------------- Botón que agrega un nuevo artículo -------------------------------------------------------------------------------//
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseas agregar este artículo?", "Agregar Artículo", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                try
                {
                    consultasMySQL.agregarArticulo(txtDescripcion.Text, cmbUsuario.SelectedValue.ToString(), cmbEstado.SelectedValue.ToString(), cmbCategoria.SelectedValue.ToString(), cmbEmpresa.SelectedValue.ToString(), dtFecha.Value.ToString("yyyy-MM-dd"));
                    MessageBox.Show("Artículo agregado correctamente", "Artículo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    try
                    {
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrió una Excepción: " + ex);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió una Excepción: " + ex);
                }
            }
        }
        //---------------------------------------------------------------------------  -------------------------------------------------------------------------------//
        #endregion
    }
}
