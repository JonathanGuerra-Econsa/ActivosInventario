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
    public partial class Agregar_Usuario : Form
    {
        //----------------------------------Variables-----------------------------------//
        bool detalle = true;
        ConsultasMySQL_JG consultasMySQL = new ConsultasMySQL_JG();
        //-------------------------------------------------------------------------------//
        public Agregar_Usuario()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
        }

        private void Agregar_Usuario_Load(object sender, EventArgs e)
        {
            ComboDash();
            Detalle();
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                string idUsuario = dgvUsuarios.CurrentRow.Cells[0].Value.ToString();
                string nombre = dgvUsuarios.CurrentRow.Cells[1].Value.ToString();
                string usuario = dgvUsuarios.CurrentRow.Cells[2].Value.ToString();
                string departamento = dgvUsuarios.CurrentRow.Cells[3].Value.ToString();

                lbID.Text = idUsuario;
                txtNombre.Text = nombre;
                txtUsuario.Text = usuario;
                txtDepartamento.Text = departamento;
            }
        }

        private void Detalle()
        {
            if(detalle == true)
            {
                txtNombre.BorderStyle = BorderStyle.None;
                txtNombre.ReadOnly = true;
                txtUsuario.BorderStyle = BorderStyle.None;
                txtUsuario.ReadOnly = true;
                txtDepartamento.BorderStyle = BorderStyle.None;
                txtDepartamento.ReadOnly = true;

                txtDepartamento.Visible = true;
                cmbDepartamento.Visible = false;
                btnCancelar.Visible = false;
                btnSet.Visible = false;
                btnEditar.Visible = true;
                btnAgregar.Visible = true;
            }
            else
            {
                txtNombre.BorderStyle = BorderStyle.Fixed3D;
                txtNombre.ReadOnly = false;
                txtUsuario.BorderStyle = BorderStyle.Fixed3D;
                txtUsuario.ReadOnly = false;
                txtDepartamento.Visible = false;
                cmbDepartamento.Visible = true;
                btnCancelar.Visible = true;
                btnSet.Visible = true;
                dgvUsuarios.Enabled = false;
                dgvUsuarios.DefaultCellStyle.BackColor = Color.Silver;
                dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver;
                dgvUsuarios.BackgroundColor = Color.Silver;
                limpiar();
            }
        }

        private void ComboDash()
        {
            cmbDepartamento.DataSource = consultasMySQL.verDepartamentos();
            cmbDepartamento.DisplayMember = "Departamento";
            cmbDepartamento.ValueMember = "ID";

            dgvUsuarios.DataSource = consultasMySQL.verUsuarios();
            dgvUsuarios.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvUsuarios.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            btnAgregar.Visible = false;
            btnEditar.Visible = false;
            detalle = false;
            Detalle();
        }

        private void limpiar()
        {
            txtNombre.Text = "";
            txtUsuario.Text = "";
            txtDepartamento.Text = "";
            lbID.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Reordenar();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" || txtUsuario.Text != "")
            {
                if (MessageBox.Show("Deseas agregar a este usuario?", "Agregar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    try
                    {
                        consultasMySQL.agregarUsuario(txtNombre.Text, txtUsuario.Text, "null", cmbDepartamento.SelectedValue.ToString());
                        MessageBox.Show("Usuario agregado correctamente", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Reordenar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Excepción Encontrada: " + ex);
                    }
                }
            }
            else
            {
                MessageBox.Show("Porfavor llene correctamente todos los campos debidamente", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Reordenar()
        {
            btnAgregar.Visible = true;
            btnEditar.Visible = true;
            dgvUsuarios.Enabled = true;
            dgvUsuarios.DefaultCellStyle.BackColor = Color.White;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvUsuarios.BackgroundColor = Color.White;
            limpiar();
            ComboDash();
            detalle = true;
            Detalle();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(detalle == false)
            {
                try
                {
                    consultasMySQL.updateUsuario(txtNombre.Text, txtUsuario.Text, cmbDepartamento.SelectedValue.ToString(), lbID.Text);
                    MessageBox.Show("Usuario Actualizado");
                    Reordenar();
                    detalle = true;
                    Detalle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio una Excepción: " + ex);
                }
            }
            else if(detalle == true)
            {
                detalle = false;
                Detalle();
                string idUsuario = dgvUsuarios.CurrentRow.Cells[0].Value.ToString();
                string nombre = dgvUsuarios.CurrentRow.Cells[1].Value.ToString();
                string usuario = dgvUsuarios.CurrentRow.Cells[2].Value.ToString();
                string departamento = dgvUsuarios.CurrentRow.Cells[3].Value.ToString();

                lbID.Text = idUsuario;
                txtNombre.Text = nombre;
                txtUsuario.Text = usuario;
                cmbDepartamento.Text = departamento;
            }
        }
    }
}
