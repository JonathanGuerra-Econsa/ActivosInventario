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
        #region Variables
        //--------------------------------------------------*Variables*-----------------------------------------------//
        ConsultasMySQL_JG consultasMySQL = new ConsultasMySQL_JG();
        bool detalle = true;
        //------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Load
        //------------------------------------------------------------------------------- Load() -------------------------------------------------------------------------------------//
        public Agregar_Departamento()
        {
            InitializeComponent();
        }

        private void Agregar_Departamento_Load(object sender, EventArgs e)
        {
            verDepartamento();
            activarDGV();
        }
        //--------------------------------------------------------------------------------------- -------------------------------------------------------------------------------------//
        #endregion
        #region activarDGV()
        //------------------------------------------------------------------ Actualiza en DataGridView y lo Habilita -------------------------------------------------------------------------------------//
        public void activarDGV()
        {
            txtDepartamento.Enabled = false;
            btnCancelar.Visible = false;
            btnCancelar.Location = new Point(201, 199);
            btnSet.Visible = true;
            btnActualizar.Visible = true;
            lbNombreID.Visible = true;
            dgvDepartamento.Enabled = true;
            dgvDepartamento.BackgroundColor = Color.White;
            dgvDepartamento.DefaultCellStyle.BackColor = Color.White;
            transladarDepartamento();
        }
        //--------------------------------------------------------------------------------------- -------------------------------------------------------------------------------------//
        #endregion
        #region Botón Set()
        //------------------------------------------------------------------ Botón que guarda un nuevo departamento -------------------------------------------------------------------------------------//
        private void btnSet_Click(object sender, EventArgs e)
        {
            if (txtDepartamento.Enabled == false)
            {
                txtDepartamento.Enabled = true;
                activarDetalle();
                txtDepartamento.Text = "";
                lbID.Text = "";
                lbNombreID.Visible = false;
            }
            else
            {
                if (MessageBox.Show("Desea agregar este departamento?", "Guardar Departamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if(txtDepartamento.Text != "")
                        {
                            consultasMySQL.agregarDepartamento(txtDepartamento.Text);
                            MessageBox.Show("Departamento Agregado!", "Guardar Departamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            activarDGV();
                            verDepartamento();
                        }
                        else
                        {
                            MessageBox.Show("Por favor llene todos los campos correctamente", "Campos Inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }
        //--------------------------------------------------------------------------------------- -------------------------------------------------------------------------------------//
        #endregion
        #region Botón Actualizar()
        //------------------------------------------------------------------ Botón que actualiza un departamento -----------------------------------------------------------------//
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtDepartamento.Enabled == false)
            {
                activarDetalle();
                btnCancelar.Visible = true;
                btnCancelar.Location = new Point(78, 199);
                btnSet.Visible = false;
            }
            else
            {
                if(MessageBox.Show("Desea actualizar este departamento?", "Actualizar Departamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (txtDepartamento.Text != "")
                    {
                        try
                        {
                            consultasMySQL.updateDepartamento(lbID.Text, txtDepartamento.Text);
                            MessageBox.Show("Departamento actualizado con éxito", "Actualizar Departamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            verDepartamento();
                            activarDGV();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor llene todos los campos correctamente", "Campos Inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        //--------------------------------------------------------------------------------------- -------------------------------------------------------------------------------------//
        #endregion
        #region Click en el DataGridView
        //------------------------------------------------------------------ Click en el DataGridView de departamento ------------------------------------------------------------//
        private void dgvDepartamento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                transladarDepartamento();
            }
        }

        private void transladarDepartamento()
        {
            string ID = dgvDepartamento.CurrentRow.Cells[0].Value.ToString();
            string Departamento = dgvDepartamento.CurrentRow.Cells[1].Value.ToString();

            lbID.Text = ID;
            txtDepartamento.Text = Departamento;
        }
        //--------------------------------------------------------------------------------------- -------------------------------------------------------------------------------------//
        #endregion
        #region Cancelar()
        //------------------------------------------------------------------ Botón de cancelar que llama al método de actualizar-------------------------------------------------------------------------------------//
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            activarDGV();
        }
        //--------------------------------------------------------------------------------------- -------------------------------------------------------------------------------------//
        #endregion
        #region activarDetalle()
        private void activarDetalle()
        {
            dgvDepartamento.Enabled = false;
            dgvDepartamento.BackgroundColor = Color.Silver;
            dgvDepartamento.DefaultCellStyle.BackColor = Color.Silver;
            txtDepartamento.Enabled = true;
            btnCancelar.Visible = true;
        }
        #endregion
        #region verDepartamento()
        private void verDepartamento()
        {
            dgvDepartamento.DataSource = consultasMySQL.verDepartamentos();
            dgvDepartamento.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDepartamento.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        #endregion
    }
}
