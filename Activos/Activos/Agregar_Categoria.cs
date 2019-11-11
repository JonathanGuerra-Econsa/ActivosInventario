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
    public partial class Agregar_Categoria : Form
    {
        //----------------------------------------------*Variables*------------------------------------------------//
        ConsultasMySQL_JG consultasMySQL = new ConsultasMySQL_JG();
        bool detalle = true;
        //-----------------------------------------------------------------------------------------------------------//
        public Agregar_Categoria()
        {
            InitializeComponent();
        }

        private void Agregar_Categoria_Load(object sender, EventArgs e)
        {
            actualizarDGV();
            lbID.Text = "";
        }

        private void actualizarDGV()
        {
            dgvCategoria.DataSource = consultasMySQL.verCategorias();
            //Detalle cambia como al origen
            dgvCategoria.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            txtNombre.BorderStyle = BorderStyle.None;
            txtNombre.ReadOnly = true;
            //el DataGridView se vuelve activo
            dgvCategoria.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvCategoria.BackgroundColor = Color.White;
            dgvCategoria.DefaultCellStyle.BackColor = Color.White;
            dgvCategoria.Enabled = true;
            //Se reordenar el factor de los botones
            btnAgregar.Visible = true;
            btnActualizar.Visible = true;
            btnSet.Visible = false;
            btnCancelar.Visible = false;
            //Ahora está en modo detalle
            detalle = true;
        }

        private void deshabilitarDGV()
        {
            //el DataGridView se vuelve activo
            dgvCategoria.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver;
            dgvCategoria.BackgroundColor = Color.Silver;
            dgvCategoria.DefaultCellStyle.BackColor = Color.Silver;
            dgvCategoria.Enabled = false;
            //Ahora está en modo detalle
            detalle = false;
            //textos limpios
            txtNombre.BorderStyle = BorderStyle.Fixed3D;
            txtNombre.ReadOnly = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            btnSet.Visible = true;
            btnActualizar.Visible = false;
            btnCancelar.Visible = true;
            btnAgregar.Visible = false;
            txtNombre.BorderStyle = BorderStyle.Fixed3D;
            txtNombre.Text = "";
            lbID.Text = "";
            deshabilitarDGV();
        }

        private void dgvCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                string ID = dgvCategoria.CurrentRow.Cells[0].Value.ToString();
                string Categoria = dgvCategoria.CurrentRow.Cells[1].Value.ToString();

                lbID.Text = ID;
                txtNombre.Text = Categoria;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            actualizarDGV();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                if (MessageBox.Show("Deseas agregar esta categoria?", "Agregar Categoria", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    try
                    {
                        consultasMySQL.agregarCategoria(txtNombre.Text);
                        MessageBox.Show("Categoria agregado correctamente", "Categoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Excepción Encontrada: " + ex);
                    }
                }
            }
            else
            {
                MessageBox.Show("Escriba el nombre de la categoria antes de enviarla", "Campo Vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            actualizarDGV();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if(detalle == true)
            {
                deshabilitarDGV();
                btnAgregar.Visible = false;
                btnCancelar.Visible = true;
                btnSet.Visible = false;
            }
            else
            {
                if (MessageBox.Show("Quieres cambiar la Categoría a :" + txtNombre.Text + ", ?", "Actualizar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    try
                    {
                        consultasMySQL.updateCategoria(lbID.Text, txtNombre.Text);
                        MessageBox.Show("Categoría Actualizada", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    actualizarDGV();
                    btnAgregar.Visible = true;
                    btnCancelar.Visible = false;
                    btnSet.Visible = false;
                }
            }
        }
    }
}
