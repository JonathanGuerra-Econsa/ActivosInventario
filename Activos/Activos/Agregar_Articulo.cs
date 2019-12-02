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
                habilitar(true);
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
    }
}
