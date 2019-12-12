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
    public partial class Aperturar_Inventario : Form
    {
        #region Variables
        //--------------------- * Variables * -----------------------------//
        ConsultasMySQL_JG consultasMySQL = new ConsultasMySQL_JG();
        //---------------------------- --------------------------------------//
        #endregion
        #region Load()
        //------------------------------------ * Load inicio de la app * ---------------------------------------------//
        public Aperturar_Inventario()
        {
            InitializeComponent();
        }
        private void Aperturar_Inventario_Load(object sender, EventArgs e)
        {

        }
        //------------------------------------------------ ------------------------------------------------------------//
        #endregion
        #region txtChanged
        //------------------------------------ * Cada vez que el texto en el txt cambie * -----------------------------------------//
        private void txtInventario_TextChanged(object sender, EventArgs e)
        {
            if (txtInventario.Text != "") btnAperturar.Enabled = true;
            else btnAperturar.Enabled = false;
        }
        //-------------------------------------------------------------- --------------------------------------------------------------//
        #endregion
        #region Botón Aperturar Inventario
        //----------------------------------------------- * Botón que apertura el inventario con el nombre del txt * ----------------------------------------------//
        private void btnAperturar_Click(object sender, EventArgs e)
        {
            if(btnActivo.Enabled == true)
            {
                if (consultasMySQL.verificarInventarioActivo(txtInventario.Text).Rows.Count >= 1)
                {
                    MessageBox.Show("Este nombre ya lo ocupa un inventario de activo", "Nombre Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        if (MessageBox.Show("Desea aperturar este inventario bajo el nombre de: "+ txtInventario.Text, "Aperturar Inventario?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //----------* Variables para enviar *-------------------//
                            string nombre = txtInventario.Text;
                            string fechaApertura = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            //---------------------------------------------------------//
                            //--------------------* Crear Inventario *--------------------//
                            consultasMySQL.insertInvActivo(nombre, fechaApertura);
                            //------------------------------------------------------------//
                            //-------------------* Crear Detalle de Inventario Activo  *------------------//
                            string idInventario = consultasMySQL.buscarInventario(fechaApertura);
                            consultasMySQL.insertarDetalleActivo(idInventario);
                            //---------------------------------------------------------------------------------//
                            MessageBox.Show("Inventario activo creado éxitosamente", "Inventario Creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //-----------------------------* Redirigir a DashBoard *----------------------------//
                            //DashboardTodos dashBoard = new DashboardTodos();
                            //dashBoard.idA = Convert.ToInt32(idInventario);
                            //dashBoard.opcion = 2;
                            //dashBoard.Show();
                            //--------------------------------------------------------------------------------------//
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else if (btnArticulo.Enabled == true)
            {
                if (consultasMySQL.verificarInventarioArticulo(txtInventario.Text).Rows.Count >= 1)
                {
                    MessageBox.Show("Este nombre ya lo ocupa un inventario de articulo", "Nombre Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        if (MessageBox.Show("Desea aperturar este inventario bajo el nombre: " + txtInventario.Text, "Aperturar Inventario?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            // --------------------* Variables para enviar *--------------------//
                            string nombre = txtInventario.Text;
                            string fechaApertura = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            //--------------------------------------------------------------------//
                            //--------------------* Crear Inventario en Articulos *--------------------//
                            consultasMySQL.insertInvArticulo(nombre, fechaApertura);
                            //-----------------------------------------------------------------------------//
                            //-------------------------------* Crear Detalle *--------------------------------------//
                            string idInventario = consultasMySQL.buscarInventarioArticulo(fechaApertura);
                            consultasMySQL.insertarDetalleArticulo(idInventario);
                            //----------------------------------------------------------------------------------------//
                            MessageBox.Show("Inventario de artículo creado éxitosamente", "Inventario Creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //-------------------------------* Redirigir *------------------------------------//
                            //DashboardTodos dashBoard = new DashboardTodos();
                            //dashBoard.idAr = Convert.ToInt32(idInventario);
                            //dashBoard.opcion = 2;
                            //dashBoard.Show();
                            //---------------------------------------------------------------------------------//
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else if (btnAmbos.Enabled == true)
            {
                if (consultasMySQL.verificarInventarioArticulo(txtInventario.Text).Rows.Count >= 1 || consultasMySQL.verificarInventarioActivo(txtInventario.Text).Rows.Count >= 1)
                {
                    MessageBox.Show("Este nombre ya lo ocupa un inventario en activo o articulo", "Nombre Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        if (MessageBox.Show("Desea aperturar estos inventarios tanto en activo como en artículo bajo los nombres de: "+ txtInventario.Text, "Aperturar Inventario?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //-------------------* Variables para enviar *--------------------------//
                            string nombre = txtInventario.Text;
                            string fechaApertura = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            //-------------------------------------------------------------------------//
                            //----------------------------* Crear Inventarios *----------------------------------//
                            consultasMySQL.insertInvActivo(nombre, fechaApertura);
                            consultasMySQL.insertInvArticulo(nombre, fechaApertura);
                            //-------------------------------------------------------------------------------------//
                            //-----------------------------------* Crear Detalles *----------------------------------------------//
                            string idInventarioArticulo = consultasMySQL.buscarInventarioArticulo(fechaApertura);
                            string idInventarioActivo = consultasMySQL.buscarInventario(fechaApertura);
                            consultasMySQL.insertarDetalleArticulo(idInventarioArticulo);
                            consultasMySQL.insertarDetalleActivo(idInventarioActivo);
                            //----------------------------------------------------------------------------------------------------//
                            MessageBox.Show("Inventarios creados éxitosamente", "Aperurar Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //----------------------------* Redirigir *-----------------------------------//
                            DashboardTodos dashBoard = new DashboardTodos();
                            dashBoard.idA = Convert.ToInt32(idInventarioActivo);
                            dashBoard.idAr = Convert.ToInt32(idInventarioArticulo);
                            dashBoard.opcion = 2;
                            dashBoard.Show();
                            //------------------------------------------------------------------------------//
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Botones principales
        private void btnActivo_Click(object sender, EventArgs e)
        {
            if(btnBuscarInv.Enabled == false)
            {
                btnArticulo.Enabled = false;
                btnAmbos.Enabled = false;
                btnAperturar.Visible = true;
                txtInventario.Visible = true;
                lbInventario.Visible = true;
            }
            else if (btnAperturarInv.Enabled == false)
            {
                llenarCmbActivo();
                btnBuscar.Visible = true;
                lbInventario.Visible = true;
                cmbInventario.Visible = true;
                btnArticulo.Enabled = false;
                btnAmbos.Enabled = false;
            }
        }

        private void btnArticulo_Click(object sender, EventArgs e)
        {
            if (btnBuscarInv.Enabled == false)
            {
                btnActivo.Enabled = false;
                btnAmbos.Enabled = false;
                btnAperturar.Visible = true;
                txtInventario.Visible = true;
                lbInventario.Visible = true;
            }
            else if (btnAperturarInv.Enabled == false)
            {
                llenarCmbArticulo();
                btnBuscar.Visible = true;
                lbInventario.Visible = true;
                cmbInventario.Visible = true;
                btnActivo.Enabled = false;
                btnAmbos.Enabled = false;
            }
        }

        private void btnAmbos_Click(object sender, EventArgs e)
        {
            if (btnBuscarInv.Enabled == false)
            {
                btnArticulo.Enabled = false;
                btnActivo.Enabled = false;
                btnAperturar.Visible = true;
                txtInventario.Visible = true;
                lbInventario.Visible = true;
            }
            else if(btnAperturarInv.Enabled == false)
            {
                llenarComboBox();
                btnBuscar.Visible = true;
                lbInventario.Visible = true;
                cmbInventario.Visible = true;
                btnArticulo.Enabled = false;
                btnActivo.Enabled = false;
            }
        }
        #endregion
        #region Botón Atras
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (btnActivo.Enabled == false || btnArticulo.Enabled == false || btnAmbos.Enabled == false)
            {
                btnActivo.Enabled = true;
                btnArticulo.Enabled = true;
                btnAmbos.Enabled = true;
                txtInventario.Text = "";
                txtInventario.Visible = false;
                btnAperturar.Visible = false;
                lbInventario.Visible = false;
                lbInventario.Visible = false;
                cmbInventario.Visible = false;
                btnBuscar.Visible = false;
                cmbInventario.Text = "";
            }
            else if (btnActivo.Visible == true || btnArticulo.Visible == true || btnAmbos.Visible == true)
            {
                btnActivo.Visible = false;
                btnArticulo.Visible = false;
                btnAmbos.Visible = false;
                btnAperturarInv.Visible = true;
                btnBuscarInv.Visible = true;
                btnAperturarInv.Enabled = true;
                btnBuscarInv.Enabled = true;
                label1.Text = "Inventario";
                label1.Location = new Point(247, 44);
            }
            else if (btnAperturarInv.Visible == true && btnBuscarInv.Visible == true)
            {
                Close();
            }
        }
        #endregion
        #region Botón Opción Aperturar 
        //------------------------------------------------------------ *Botón que muestra las opciónes para aperturar un inventario * ----------------------------------------------------------------------------//
        private void btnAperturarInv_Click(object sender, EventArgs e)
        {
            btnAperturarInv.Visible = false;
            btnBuscarInv.Visible = false;
            btnActivo.Visible = true;
            btnArticulo.Visible = true;
            btnAmbos.Visible = true;
            btnBuscarInv.Enabled = false;
            label1.Text = "Aperturar Inventario";
            label1.Location = new Point(189, 43);
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Botón de busqueda de Inventario
        //----------------------------------------------------- * Busca un inventario según el nombre elegido en el cmbInventario * ----------------------------------------------------------//
        private void btnBuscarInv_Click(object sender, EventArgs e)
        {
            btnAperturarInv.Visible = false;
            btnAperturarInv.Enabled = false;
            btnBuscarInv.Visible = false;
            btnActivo.Visible = true;
            btnArticulo.Visible = true;
            btnAmbos.Visible = true;
            label1.Text = "Buscar Inventario";
            label1.Location = new Point(210, 43);
        }
        //-------------------------------------------------------------------------------------------- -----------------------------------------------------------------------------------------------//
        #endregion
        #region LlenarComboBox()
        //----------------------------- * Dependiendo de a cual botón den click se escojera uno de estos 3 métodos * ---------------------------//
        //---------------- * ComboBox que trae los inventarios de activo * ------------------//
        private void llenarCmbActivo()
        {
            cmbInventario.DataSource = consultasMySQL.inventarioActivo();
            cmbInventario.DisplayMember = "Nombre";
            cmbInventario.ValueMember = "ID";
        }
        //----------------------------------------------- ----------------------------------------//
        //---------------- * ComboBox que trae los inventarios de artículo * -----------------//
        private void llenarCmbArticulo()
        {
            cmbInventario.DataSource = consultasMySQL.inventarioArticulo();
            cmbInventario.DisplayMember = "Nombre";
            cmbInventario.ValueMember = "ID";
        }
        //------------------------------------------- ----------------------------------------------//
        //------------- * ComboBox que trae los inventario de activo y articulo que tengan el mismo nombre y fecha de creación * -----------------//
        private void llenarComboBox()
        {
            cmbInventario.DataSource = consultasMySQL.inventarioActivoArticulo();
            cmbInventario.DisplayMember = "Nombre";
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------------//
        //----------------------------------------------------------------------- ---------------------------------------------------------------------//
        #endregion
        #region Botón Buscar Inventario
        //----------------------- * abre los forms según las opciones que se escojen * -----------------------//
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string idActivo = consultasMySQL.idActivo(cmbInventario.Text);
            string idArticulo = consultasMySQL.idArticulo(cmbInventario.Text); ;
            //----------------------------* Redirigir *-----------------------------------//
            DashboardTodos dashBoard = new DashboardTodos();
            dashBoard.idA = Convert.ToInt32(idActivo);
            dashBoard.idAr = Convert.ToInt32(idArticulo);
            dashBoard.opcion = 2;
            dashBoard.Show();
            //------------------------------------------------------------------------------//
        }
        //----------------------------------------------------------------------------------------------------------//
        #endregion
    }
}
