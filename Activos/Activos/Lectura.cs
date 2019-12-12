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
        public int invIdAc, invIdArt;
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
                Agregar_Activo agregar = new Agregar_Activo();
                agregar.ID = idActivo.ToString();
                agregar.opcion = 2;
                agregar.Show();
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
                    string activo_articulo = txtEscaner.Text.Substring(0, inicio);
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
            consultasMySQL.detalleActivo(idActivo);
            lbDescripcion.Text = consultasMySQL.descripcion;
            lbUsuario.Text = consultasMySQL.usuario;
            lbEstado.Text = consultasMySQL.estado;
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
            consultasMySQL.detalleArticulo(idArticulo);
            lbDescripcion.Text = consultasMySQL.descripcion_articulo;
            lbUsuario.Text = consultasMySQL.usuario_articulo;
            lbEstado.Text = consultasMySQL.estado_articulo;
        }
        //------------------------------------------- ------------------------------------------------//
        #endregion
        #region Carga Inicial
        private void Lectura_Load(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
