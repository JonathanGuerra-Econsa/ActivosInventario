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
    public partial class Agregar_Departamento : Form
    {
        //--------------------------------------------------*Variables*-----------------------------------------------//
        ConsultasMySQL_JG consultasMySQL = new ConsultasMySQL_JG();
        bool detalle = true;
        //------------------------------------------------------------------------------------------------------------//
        public Agregar_Departamento()
        {
            InitializeComponent();
        }

        private void Agregar_Departamento_Load(object sender, EventArgs e)
        {
            actualizarDGV();
            lbID.Text = "";
        }
        public void actualizarDGV()
        {
            dgvDepartamento.DataSource = consultasMySQL.verCategorias();
            //Detalle cambia como al origen
            dgvDepartamento.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            txtDepartamento.BorderStyle = BorderStyle.None;
            txtDepartamento.ReadOnly = true;
            //el DataGridView se vuelve activo
            dgvDepartamento.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvDepartamento.BackgroundColor = Color.White;
            dgvDepartamento.DefaultCellStyle.BackColor = Color.White;
            dgvDepartamento.Enabled = true;
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
            dgvDepartamento.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver;
            dgvDepartamento.BackgroundColor = Color.Silver;
            dgvDepartamento.DefaultCellStyle.BackColor = Color.Silver;
            dgvDepartamento.Enabled = false;
            //Ahora está en modo detalle
            detalle = false;
            //textos limpios
            txtDepartamento.BorderStyle = BorderStyle.Fixed3D;
            txtDepartamento.ReadOnly = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (detalle == true)
            {
                btnAgregar.Visible = false;
                btnCancelar.Visible = true;
                btnActualizar.Visible = false;
                btnSet.Visible = true;
                txtDepartamento.Text = "";
                lbID.Text = "";
                deshabilitarDGV();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if(detalle == false)
            {
                if(MessageBox.Show("Este Departamento sera cambiado a: " + txtDepartamento.Text + ", está de acuerdo?", "Cambio de Departamento", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    try
                    {
                        consultasMySQL.updateDepartamento(lbID.Text, txtDepartamento.Text);
                        MessageBox.Show("Departamento Actualizado","Actualizado");
                        actualizarDGV();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                actualizarDGV();
            }
            else
            {
                deshabilitarDGV();
            }
        }

        private void dgvDepartamento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                string ID = dgvDepartamento.CurrentRow.Cells[0].Value.ToString();
                string Departamento = dgvDepartamento.CurrentRow.Cells[1].Value.ToString();

                lbID.Text = ID;
                txtDepartamento.Text = Departamento;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            actualizarDGV();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if(detalle == false)
            {
                if (txtDepartamento.Text != "")
                {
                    if (MessageBox.Show("Deseas agregar este departamento?", "Agregar Departamento", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        try
                        {
                            consultasMySQL.agregarDepartamento(txtDepartamento.Text);
                            MessageBox.Show("Departamento agregado correctamente", "Departamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Exepción encontrada: " + ex);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Escriba el nombre del Departamento", "Valor Vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                actualizarDGV();
            }
        }
    }
}
