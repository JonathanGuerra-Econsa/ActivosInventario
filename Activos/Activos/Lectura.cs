using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Activos
{
    public partial class Lectura : Form
    {
        #region Variables
        //----------------------------------------------- * Variables * -------------------------------------------------//
        ConsultasMySQL_JG consultasMySQL = new ConsultasMySQL_JG();
        int idActivo = 0;
        int idArticulo = 0;
        public int invIdAc = 28;
        public int invIdArt = 25;
        string activo_articulo;
        //---------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Load()
        public Lectura()
        {
            InitializeComponent();
        }
        #endregion
        #region Botón Soporte
        //---------------------------------------------- * Cuando le da click al botón de soporte * --------------------------------------------------------//
        private void btnSoporte_Click(object sender, EventArgs e)
        {
            if (idArticulo != 0 || idActivo != 0)
            {
                cmbEstados.Visible = true;
                lbEstado.Visible = false;
                btnActualizar.Visible = true;
                btnSoporte.Visible = false;
                txtEscaner.Enabled = false;
                btnCancelar.Visible = true;
            }
        }
        //---------------------------------------------- ---------------------------------------------- --------------------------------------------------------//
        #endregion
        #region Text Cahnged
        //------------------------------------------------------- * Cada vez que el texto cambia * --------------------------------------------------------------------//
        private void txtEscaner_TextChanged(object sender, EventArgs e)
        {
            if (txtEscaner.Text.Length >= 7)
            {
                Regex rx = new Regex(@"^[aA-zZ]+\-[0-9]+$");
                if (rx.IsMatch(txtEscaner.Text))
                {
                    int inicio = txtEscaner.Text.LastIndexOf('-');
                    activo_articulo = txtEscaner.Text.Substring(0, inicio);
                    int id = Convert.ToInt32(txtEscaner.Text.Substring(inicio + 1, txtEscaner.Text.Length - (inicio + 1)));
                    if (activo_articulo == "a" || activo_articulo == "A")
                    {
                        //MessageBox.Show("Es un activo con id: " + id);
                        llenarDatosActivo(id.ToString());
                        idActivo = id;
                    }
                    else if (activo_articulo == "ar" || activo_articulo == "AR")
                    {
                        //MessageBox.Show("Es un artículo con id: " + id);
                        llenarDatosArticulo(id.ToString());
                        idArticulo = id;
                    }
                    else
                    {
                        MessageBox.Show("El texto que acaba de ingresar no es un identificador propio del programa", "Error de Sintaxis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("El texto que acaba de ingresar no es un identificador propio del programa", "Error de Sintaxis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region llenarDatosActivo()
        //--------------------------- * Llena los datos del detalle * ------------------------------//
        private void llenarDatosActivo(string idActivo)
        {
            lbUsuario.Visible = true;
            lbDescripcion.Visible = true;
            lbEstado.Visible = true;
            lbStatus.Visible = true;
            lbInventario.Visible = true;
            lbFecha.Visible = true;
            consultasMySQL.traerActivo(idActivo, Convert.ToString(invIdAc));
            lbDescripcion.Text = consultasMySQL.descripcion;
            lbUsuario.Text = consultasMySQL.usuario;
            lbEstado.Text = consultasMySQL.estado;
            lbStatus.Text = consultasMySQL.fisico;
            lbInventario.Text = consultasMySQL.inv_activo;
            lbFecha.Text = consultasMySQL.fecha_activo;
            if (lbStatus.Text == "Revisado")
            {
                btnSoporte.Text = "Revisado";
                btnSoporte.Enabled = false;
            }
            else
            {
                btnSoporte.Text = "Revisar";
                btnSoporte.Enabled = true;
            }
        }
        //------------------------------------------- ------------------------------------------------//
        #endregion
        #region llenarDatosArticulo()
        //--------------------------- * Llena los datos del detalle * ------------------------------//
        private void llenarDatosArticulo(string idArticulo)
        {
            lbUsuario.Visible = true;
            lbDescripcion.Visible = true;
            lbEstado.Visible = true;
            lbStatus.Visible = true;
            lbInventario.Visible = true;
            lbFecha.Visible = true;
            consultasMySQL.traerArticulo(idArticulo, Convert.ToString(invIdArt));
            lbDescripcion.Text = consultasMySQL.descripcion_articulo;
            lbUsuario.Text = consultasMySQL.usuario_articulo;
            lbEstado.Text = consultasMySQL.estado_articulo;
            lbStatus.Text = consultasMySQL.fisico_articulo;
            lbInventario.Text = consultasMySQL.inv_articulo;
            lbFecha.Text = consultasMySQL.fecha_articulo;
            if(lbStatus.Text == "Revisado")
            {
                btnSoporte.Text = "Revisado";
                btnSoporte.Enabled = false;
            }
            else
            {
                btnSoporte.Text = "Revisar";
                btnSoporte.Enabled = true;
            }
        }
        //------------------------------------------- ------------------------------------------------//
        #endregion
        #region Carga Inicial
        private void Lectura_Load(object sender, EventArgs e)
        {
            cmbEstados.DataSource = consultasMySQL.verEstados();
            cmbEstados.DisplayMember = "Estado";
            cmbEstados.ValueMember = "ID";
        }
        #endregion

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (cmbEstados.SelectedItem != null)
            {
                if (MessageBox.Show("Desea cambiar este artículo a un esado físico " + cmbEstados.Text + "?", "Revisar Artículo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string estado = cmbEstados.SelectedValue.ToString();
                    string idStatus = "1";
                    string idInventarioArticulo = invIdArt.ToString();
                    string idInventarioActivo = invIdAc.ToString();
                    string idDetalle = consultasMySQL.idDetalleActivo;
                    try
                    {
                        if(activo_articulo == "a" || activo_articulo == "A")
                        {
                            //MessageBox.Show("Es una activo");
                            consultasMySQL.updateDetalleActivo(estado, idStatus, fecha, idDetalle);
                            consultasMySQL.cambioEstadoActivo(estado, idActivo.ToString());
                        }
                        else if (activo_articulo == "ar" || activo_articulo == "AR")
                        {
                            MessageBox.Show("Es una artículo");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnCancelar.Visible = false;
            txtEscaner.Enabled = true;
            btnActualizar.Visible = false;
            cmbEstados.Visible = false;
            btnSoporte.Visible = true;
            lbEstado.Visible = true;
        }
    }
}
