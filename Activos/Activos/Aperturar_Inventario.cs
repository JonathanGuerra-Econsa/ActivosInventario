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
        bool allDeptos;
        bool allUsers;
        string posicion;
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
            llenarComboBoxDepto();
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
                            if (posicion == "Departamento activo")
                            {
                                consultasMySQL.insertarDetalleActivo(idInventario);
                            }
                            else if (posicion == "Todas las personas activo")
                            {
                                string idDepartamento = cmbDepartamento.SelectedValue.ToString();
                                consultasMySQL.insertarDetalleActivoUnDepto(idInventario, idDepartamento);
                            }
                            else if (posicion == "Persona activo")
                            {
                                string idUsuario = cmbUsuarios.SelectedValue.ToString();
                                consultasMySQL.insertarDetalleActivoUnUsuario(idInventario, idUsuario);
                            }
                            //---------------------------------------------------------------------------------//
                            MessageBox.Show("Inventario activo creado éxitosamente", "Inventario Creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //-----------------------------* Redirigir a DashBoard *----------------------------//
                            DahsboardActivos dahsboard = new DahsboardActivos();
                            dahsboard.idA = Convert.ToInt32(idInventario);
                            dahsboard.ShowDialog();
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
                            if (posicion == "Departamento articulo")
                            {
                                consultasMySQL.insertarDetalleArticulo(idInventario);
                            }
                            else if (posicion == "Todas las personas articulo") 
                            {
                                string idDepartamento = cmbDepartamento.SelectedValue.ToString();
                                consultasMySQL.insertarDetalleArticuloUnDepartamento(idInventario, idDepartamento);
                            }
                            else if (posicion == "Persona articulo")
                            {
                                string idUsuario = cmbUsuarios.SelectedValue.ToString();
                                consultasMySQL.insertarDetalleArticuloUnUsuario(idInventario, idUsuario);
                            }
                            //----------------------------------------------------------------------------------------//
                            MessageBox.Show("Inventario de artículo creado éxitosamente", "Inventario Creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //-------------------------------* Redirigir *------------------------------------//
                            DashboardArticulo dashboard = new DashboardArticulo();
                            dashboard.idAr = Convert.ToInt32(idInventario);
                            dashboard.ShowDialog();
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
                            if (posicion == "Departamento ambos")
                            {
                                consultasMySQL.insertarDetalleArticulo(idInventarioArticulo);
                                consultasMySQL.insertarDetalleActivo(idInventarioActivo);
                            }
                            else if (posicion == "Todas las personas ambos")
                            {
                                string idDepartamento = cmbDepartamento.SelectedValue.ToString();
                                consultasMySQL.insertarDetalleArticuloUnDepartamento(idInventarioArticulo, idDepartamento);
                                consultasMySQL.insertarDetalleActivoUnDepto(idInventarioActivo, idDepartamento);
                            }
                            else if (posicion == "Persona ambos")
                            {
                                string idUsuario = cmbUsuarios.SelectedValue.ToString();
                                consultasMySQL.insertarDetalleArticuloUnUsuario(idInventarioArticulo, idUsuario);
                                consultasMySQL.insertarDetalleActivoUnUsuario(idInventarioActivo, idUsuario);
                            }
                            //----------------------------------------------------------------------------------------------------//
                            MessageBox.Show("Inventarios creados éxitosamente", "Aperurar Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //----------------------------* Redirigir *-----------------------------------//
                            DashboardTodos dashBoard = new DashboardTodos();
                            dashBoard.idA = Convert.ToInt32(idInventarioActivo);
                            dashBoard.idAr = Convert.ToInt32(idInventarioArticulo);
                            dashBoard.ShowDialog();
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
                if (posicion == "Todos los departamentos")
                {
                    posicion = "Departamento activo";
                }else if (posicion == "Todas las personas")
                {
                    posicion = "Todas las personas activo";
                }else if (posicion == "Una persona")
                {
                    posicion = "Persona activo";
                }
            }
            else if (btnAperturarInv.Enabled == false)
            {
                llenarCmbActivo();
                btnBuscar.Visible = true;
                lbInventario.Visible = true;
                cmbInventario.Visible = true;
                btnArticulo.Enabled = false;
                btnAmbos.Enabled = false;
                posicion = "Buscar activo";
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
                if (posicion == "Todos los departamentos")
                {
                    posicion = "Departamento articulo";
                }
                else if (posicion == "Todas las personas")
                {
                    posicion = "Todas las personas articulo";
                }
                else if (posicion == "Una persona")
                {
                    posicion = "Persona articulo";
                }
            }
            else if (btnAperturarInv.Enabled == false)
            {
                llenarCmbArticulo();
                btnBuscar.Visible = true;
                lbInventario.Visible = true;
                cmbInventario.Visible = true;
                btnActivo.Enabled = false;
                btnAmbos.Enabled = false;
                posicion = "Buscar articulo";
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
                if (posicion == "Todos los departamentos")
                {
                    posicion = "Departamento ambos";
                }
                else if (posicion == "Todas las personas")
                {
                    posicion = "Todas las personas ambos";
                }
                else if (posicion == "Una persona")
                {
                    posicion = "Persona ambos";
                }
            }
            else if(btnAperturarInv.Enabled == false)
            {
                llenarComboBox();
                btnBuscar.Visible = true;
                lbInventario.Visible = true;
                cmbInventario.Visible = true;
                btnArticulo.Enabled = false;
                btnActivo.Enabled = false;
                posicion = "Buscar ambos";
            }
        }
        #endregion
        #region Botón Atras
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (posicion == "Buscar activo" || posicion == "Buscar articulo" || posicion == "Buscar ambos")
            {
                retornarMenu();
                posicion = "Buscar inventario";
            }
            else if (posicion == "Todas las personas activo" || posicion == "Todas las personas articulo" || posicion == "Todas las personas ambos")
            {
                retornarMenu();
                posicion = "Todas las personas";
            }
            else if (posicion == "Departamento activo" || posicion == "Departamento articulo" || posicion == "Departamento ambos")
            {
                retornarMenu();
                posicion = "Todos los departamentos";
            }
            else if (posicion == "Persona activo" || posicion == "Persona articulo" || posicion == "Persona ambos")
            {
                retornarMenu();
                posicion = "Una persona";
            }
            else if (posicion == "Buscar inventario")
            {
                ocultarMenu();
                btnAperturarInv.Visible = true;
                btnBuscarInv.Visible = true;
                btnAperturarInv.Enabled = true;
                btnBuscarInv.Enabled = true;
                label1.Text = "Inventario";
                label1.Location = new Point(247, 44);
                posicion = "";
            }
            else if (posicion == "Todos los departamentos")
            {
                ocultarMenu();
                btnTodosDepto.Visible = true;
                btnUnDepto.Visible = true;
                posicion = "Aperturar inventario";
            }
            else if (posicion == "Todas las personas")
            {
                ocultarMenu();
                btnTodasPersonas.Visible = true;
                btnUnaPersona.Visible = true;
                posicion = "Departamento seleccionado";
            }
            else if (posicion == "Una persona")
            {
                ocultarMenu();
                btnUnaPersona.Visible = true;
                btnTodasPersonas.Visible = true;
                btnTodasPersonas.Enabled = false;
                lbUsuario.Visible = true;
                cmbUsuarios.Visible = true;
                btnUsuario.Visible = true;
                posicion = "Persona seleccionada";
            }
            else if (posicion == "Persona seleccionada")
            {
                btnTodasPersonas.Enabled = true;
                btnDepartamento.Visible = false;
                cmbUsuarios.Visible = false;
                lbUsuario.Visible = false;
                btnUsuario.Visible = false;
                posicion = "Departamento seleccionado";
            }
            else if (posicion == "Departamento seleccionado")
            {
                btnUnaPersona.Visible = false;
                btnTodasPersonas.Visible = false;
                btnTodosDepto.Visible = true;
                btnTodosDepto.Enabled = false;
                btnDepartamento.Visible = true;
                btnUnDepto.Visible = true;
                cmbDepartamento.Visible = true;
                lbDepartamento.Visible = true;
                posicion = "Un departamento";
            }
            else if (posicion == "Un departamento")
            {
                btnTodosDepto.Enabled = true;
                lbDepartamento.Visible = false;
                cmbDepartamento.Visible = false;
                btnDepartamento.Visible = false;
                posicion = "Aperturar inventario";
            }else if (posicion == "Aperturar inventario")
            {
                btnUnDepto.Visible = false;
                btnTodosDepto.Visible = false;
                btnAperturarInv.Visible = true;
                btnBuscarInv.Visible = true;
                btnBuscarInv.Enabled = true;
                posicion = "";
                label1.Text = "Inventario";
                label1.Location = new Point(247, 44);
            }
            else if (posicion == "")
            {
                Close();
            }
        }

        private void retornarMenu()
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

        private void ocultarMenu()
        {
            btnActivo.Visible = false;
            btnArticulo.Visible = false;
            btnAmbos.Visible = false;
        }
        #endregion
        #region Botón Opción Aperturar 
        //------------------------------------------------------------ *Botón que muestra las opciónes para aperturar un inventario * ----------------------------------------------------------------------------//
        private void btnAperturarInv_Click(object sender, EventArgs e)
        {
            btnUnDepto.Visible = true;
            btnTodosDepto.Visible = true;
            btnAperturarInv.Visible = false;
            btnBuscarInv.Visible = false;
            btnBuscarInv.Enabled = false;
            label1.Text = "Aperturar Inventario";
            label1.Location = new Point(189, 43);
            posicion = "Aperturar inventario";
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
            posicion = "Buscar inventario";
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
        private void llenarComboBoxDepto()
        {
            cmbDepartamento.DataSource = consultasMySQL.verDepartamentos();
            cmbDepartamento.DisplayMember = "Departamento";
            cmbDepartamento.ValueMember = "ID";
        }
        private void llenarComboBoxUsuario()
        {
            cmbUsuarios.DataSource = consultasMySQL.verUsuariosDep(cmbDepartamento.SelectedValue.ToString());
            cmbUsuarios.DisplayMember = "Nombre";
            cmbUsuarios.ValueMember = "ID";
        }
        //----------------------------------------------------------------------- ---------------------------------------------------------------------//
        #endregion
        #region Botón Buscar Inventario
        //----------------------- * abre los forms según las opciones que se escojen * -----------------------//
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string idActivo = consultasMySQL.idActivo(cmbInventario.Text);
            string idArticulo = consultasMySQL.idArticulo(cmbInventario.Text); ;
            //----------------------------* Redirigir *-----------------------------------//
            if (btnAmbos.Enabled == true)
            {
                DashboardTodos dashBoard = new DashboardTodos();
                dashBoard.idA = Convert.ToInt32(idActivo);
                dashBoard.idAr = Convert.ToInt32(idArticulo);
                dashBoard.ShowDialog();
            }
            else if (btnActivo.Enabled == true)
            {
                DahsboardActivos dahsboard = new DahsboardActivos();
                dahsboard.idA = Convert.ToInt32(idActivo);
                dahsboard.ShowDialog();
            }
            else if (btnArticulo.Enabled == true)
            {
                DashboardArticulo dashboard = new DashboardArticulo();
                dashboard.idAr = Convert.ToInt32(idArticulo);
                dashboard.ShowDialog();
            }
            //------------------------------------------------------------------------------//
        }
        //----------------------------------------------------------------------------------------------------------//
        #endregion
        #region Botón Departamento
        private void btnDepartamento_Click(object sender, EventArgs e)
        {
            lbDepartamento.Visible = false;
            cmbDepartamento.Visible = false;
            btnDepartamento.Visible = false;
            btnUnaPersona.Visible = true;
            btnTodasPersonas.Visible = true;
            btnUnDepto.Visible = false;
            btnTodosDepto.Visible = false;
            posicion = "Departamento seleccionado";
        }
        #endregion
        #region Botón Todos los departamentos
        private void btnTodosDepto_Click(object sender, EventArgs e)
        {
            btnUnDepto.Visible = false;
            btnTodosDepto.Visible = false;
            btnActivo.Visible = true;
            btnArticulo.Visible = true;
            btnAmbos.Visible = true;
            btnBuscarInv.Enabled = false;
            allDeptos = true;
            posicion = "Todos los departamentos";
        }
        #endregion
        #region Botón de un departamento
        private void btnUnDepto_Click(object sender, EventArgs e)
        {
            btnTodosDepto.Enabled = false;
            cmbDepartamento.Visible = true;
            lbDepartamento.Visible = true;
            btnDepartamento.Visible = true;
            btnBuscarInv.Enabled = false;
            posicion = "Un departamento";
        }
        #endregion
        #region Botón de una persona
        private void btnUnaPersona_Click(object sender, EventArgs e)
        {
            llenarComboBoxUsuario();
            btnTodasPersonas.Enabled = false;
            lbUsuario.Visible = true;
            cmbUsuarios.Visible = true;
            btnUsuario.Visible = true;
            posicion = "Persona seleccionada";
        }
        #endregion
        #region Botón de Usuario
        private void btnUsuario_Click(object sender, EventArgs e)
        {
            btnActivo.Visible = true;
            btnArticulo.Visible = true;
            btnAmbos.Visible = true;
            btnUnaPersona.Visible = false;
            btnTodasPersonas.Visible = false;
            btnUsuario.Visible = false;
            cmbUsuarios.Visible = false;
            lbUsuario.Visible = false;
            posicion = "Una persona";
        }
        #endregion
        #region Botón de todos los usuarios
        private void btnTodasPersonas_Click(object sender, EventArgs e)
        {
            btnUnaPersona.Visible = false;
            btnTodasPersonas.Visible = false;
            btnActivo.Visible = true;
            btnArticulo.Visible = true;
            btnAmbos.Visible = true;
            allUsers = true;
            posicion = "Todas las personas";
        }
        #endregion
    }
}
