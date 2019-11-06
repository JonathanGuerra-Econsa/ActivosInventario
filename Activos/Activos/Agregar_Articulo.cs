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
    public partial class Agregar_Articulo : Form
    {
        ConsultasMySQL_JG consultasMySQL = new ConsultasMySQL_JG();
        public Agregar_Articulo()
        {
            InitializeComponent();
        }

        private void llenarComboBox()
        {
            cmbUsuario.DataSource = consultasMySQL.verUsuarios();
            cmbUsuario.DisplayMember = "Usuario";
            cmbUsuario.ValueMember = "ID";

            cmbEstado.DataSource = consultasMySQL.verEstados();
            cmbEstado.DisplayMember = "Estado";
            cmbEstado.ValueMember = "ID";

            cmbCategoria.DataSource = consultasMySQL.verCategorias();
            cmbCategoria.DisplayMember = "Categoria";
            cmbCategoria.ValueMember = "ID";

            cmbEmpresa.DataSource = consultasMySQL.verEmpresa();
            cmbEmpresa.DisplayMember = "Empresa";
            cmbEmpresa.ValueMember = "ID";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseas agregar este artículo?", "Agregar Artículo", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                try
                {
                    consultasMySQL.agregarArticulo(txtDescripcion.Text, cmbUsuario.SelectedValue.ToString(), cmbEstado.SelectedValue.ToString(), cmbCategoria.SelectedValue.ToString(), cmbEmpresa.SelectedValue.ToString(), dtFecha.Value.ToString("yyyy-MM-dd"));
                    MessageBox.Show("Artículo agregado correctamente", "Artículo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    try
                    {
                        consultasMySQL.agregarArticulo_Historial(txtDescripcion.Text, cmbUsuario.SelectedValue.ToString(), cmbEstado.SelectedValue.ToString(), cmbCategoria.SelectedValue.ToString(), cmbEmpresa.SelectedValue.ToString(), dtFecha.Value.ToString("yyyy-MM-dd"), consultasMySQL.verIdArticulos());
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrió una Excepción: " + ex);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió una Excepción: " + ex);
                }
            }
        }

        private void Agregar_Articulo_Load(object sender, EventArgs e)
        {
            llenarComboBox();
        }
    }
}
