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
    public partial class Agregar_Activo : Form
    {
        ConsultasMySQL_JG consultasMySQL =new  ConsultasMySQL_JG();
        public Agregar_Activo()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseas agregar este activo?", "Agregar Activo", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                try
                {
                    consultasMySQL.agregarActivo(txtDescripcion.Text, cmbUsuario.SelectedValue.ToString(), cmbEstado.SelectedValue.ToString(), cmbCategoria.SelectedValue.ToString(), cmbEmpresa.SelectedValue.ToString(), dtFecha.Value.ToString("yyyy-MM-dd"));
                    MessageBox.Show("Activo agregado correctamente", "Activo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    try
                    {
                        consultasMySQL.agregarActivo_Historial(txtDescripcion.Text, cmbUsuario.SelectedValue.ToString(), cmbEstado.SelectedValue.ToString(), cmbCategoria.SelectedValue.ToString(), cmbEmpresa.SelectedValue.ToString(), dtFecha.Value.ToString("yyyy-MM-dd"), consultasMySQL.verIdActivos());
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo guardar en historial debido a que ha ocurrido una excepción, las cual es: " + ex);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error: " + ex + ". :(");
                }
            }
        }
    }
}
