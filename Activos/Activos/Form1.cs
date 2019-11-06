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
            Agregar_Departamento agregarDepartamento = new Agregar_Departamento();
            agregarDepartamento.Show();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            Agregar_Usuario agregarusuario = new Agregar_Usuario();
            agregarusuario.Show();
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            Agregar_Categoria agregarCategoria = new Agregar_Categoria();
            agregarCategoria.Show();
        }

        private void btnActivo_Click(object sender, EventArgs e)
        {
            Agregar_Activo agregarActivo = new Agregar_Activo();
            agregarActivo.Show();
        }

        private void btnArticulo_Click(object sender, EventArgs e)
        {
            Agregar_Articulo agregarArticulo = new Agregar_Articulo();
            agregarArticulo.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new Activos().Show();
        }
    }
}
