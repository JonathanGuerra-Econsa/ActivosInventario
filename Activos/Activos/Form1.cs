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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            
        }

        private void btnActivo_Click(object sender, EventArgs e)
        {
            
        }

        private void btnArticulo_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new Activos().Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Departamento de Informática 2020", "Creditos", MessageBoxButtons.OK);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Articulos().Show();
        }
    }
}
