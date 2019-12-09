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
        ConsultasMySQL_JG consultasMySQL = new ConsultasMySQL_JG();
        public Aperturar_Inventario()
        {
            InitializeComponent();
        }

        private void txtInventario_TextChanged(object sender, EventArgs e)
        {
            if (txtInventario.Text != "") btnAperturar.Enabled = true;
            else btnAperturar.Enabled = false;
        }

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
                            //----------------------------------------------------------------------------------------//
                            MessageBox.Show("Inventario de artículo creado éxitosamente", "Inventario Creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //-------------------------------* Redirigir *------------------------------------//
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

                            //----------------------------------------------------------------------------------------------------//
                            MessageBox.Show("Inventarios creados éxitosamente", "Aperurar Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //----------------------------* Redirigir *-----------------------------------//
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
        #region Botones principales
        private void btnActivo_Click(object sender, EventArgs e)
        {
            btnArticulo.Enabled = false;
            btnAmbos.Enabled = false;
            btnAperturar.Visible = true;
            txtInventario.Visible = true;
            lbInventario.Visible = true;
        }

        private void btnArticulo_Click(object sender, EventArgs e)
        {
            btnActivo.Enabled = false;
            btnAmbos.Enabled = false;
            btnAperturar.Visible = true;
            txtInventario.Visible = true;
            lbInventario.Visible = true;
        }

        private void btnAmbos_Click(object sender, EventArgs e)
        {
            btnArticulo.Enabled = false;
            btnActivo.Enabled = false;
            btnAperturar.Visible = true;
            txtInventario.Visible = true;
            lbInventario.Visible = true;
        }
        #endregion
        #region Botón Atras
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (txtInventario.Visible == true)
            {
                btnActivo.Enabled = true;
                btnArticulo.Enabled = true;
                btnAmbos.Enabled = true;
                txtInventario.Text = "";
                txtInventario.Visible = false;
                btnAperturar.Visible = false;
            }
            else if(btnActivo.Enabled == true || btnArticulo.Enabled == true || btnAmbos.Enabled == true)
            {
                Close();
            }
        }
        #endregion
    }
}
