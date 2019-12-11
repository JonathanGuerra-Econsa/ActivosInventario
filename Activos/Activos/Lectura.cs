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
        //---------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Load()
        public Lectura()
        {
            InitializeComponent();
        }
        #endregion
        #region Botón Soporte
        //---------------------------------------------- * Cuando de da click al botón de soporte * --------------------------------------------------------//
        private void btnSoporte_Click(object sender, EventArgs e)
        {
            
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
                        MessageBox.Show("Es un activo con id: " + id);
                    }
                    else if (activo_articulo == "ar" || activo_articulo == "AR")
                    {
                        MessageBox.Show("Es un artículo con id: " + id);
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
    }
}
