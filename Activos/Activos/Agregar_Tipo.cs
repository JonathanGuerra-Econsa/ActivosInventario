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
    public partial class Agregar_Tipo : Form
    {
        #region Variables
        //----------------------------------------------*Variables*------------------------------------------------//
        ConsultasMySQL_JG consultasMySQL = new ConsultasMySQL_JG();
        bool detalle = true;
        //-----------------------------------------------------------------------------------------------------------//
        #endregion
        #region Primeros procesos del Form "Load()"
        //---------------------------------------------------------------- Load() -------------------------------------------------------------------------------//
        public Agregar_Tipo()
        {
            InitializeComponent();
        }

        private void Agregar_Categoria_Load(object sender, EventArgs e)
        {

        }
        //---------------------------------------------------------------------------  -------------------------------------------------------------------------------//
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            Administrador_Activo administrar = new Administrador_Activo();
            administrar.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Administrador_Articulo().ShowDialog();
            this.Show();
        }
    }
}