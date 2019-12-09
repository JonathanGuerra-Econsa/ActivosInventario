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
        //-------------Variables Publicas-----------//
        public string nombre;
        //--------------------------------------------//
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Agregar_Departamento().Show();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            new Agregar_Usuario().Show();
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            new Agregar_Tipo().Show();
        }

        private void btnActivo_Click(object sender, EventArgs e)
        {
            new Activos().Show();
        }

        private void btnArticulo_Click(object sender, EventArgs e)
        {
            new Articulos().ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new Activos().ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Departamento de Informática 2020", "Creditos", MessageBoxButtons.OK);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new DashboardTodos().Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelName.Text = ("Bienvenido " + nombre);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            Aperturar_Inventario aperturarInventario = new Aperturar_Inventario();
            aperturarInventario.Show();
        }
    }
}
