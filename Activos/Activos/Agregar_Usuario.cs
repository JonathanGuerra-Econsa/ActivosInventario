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
        ConsultasMySQL_JG consultasMySQL = new ConsultasMySQL_JG();
        bool detalle = true;
        //-------------------------------------------------------------------------------//
        public Agregar_Usuario()
        {
            InitializeComponent();
        }
        private void Agregar_Usuario_Load(object sender, EventArgs e)
        {
            llenarComboBox();
            actualizarDGV();
        }

        private void actualizarDGV()
        {
            //Detalle cambia como al origen
            dgvUsuarios.DataSource = consultasMySQL.verUsuarios();
            dgvUsuarios.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            txtNombre.BorderStyle = BorderStyle.None;
            txtNombre.ReadOnly = true;
            txtUsuario.BorderStyle = BorderStyle.None;
            txtUsuario.ReadOnly = true;
            txtDepartamento.Visible = true;
            cmbDepartamento.Visible = false;
            txtDepartamento.BorderStyle = BorderStyle.None;
            txtDepartamento.ReadOnly = true;
            //el DataGridView se vuelve activo
            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvUsuarios.BackgroundColor = Color.White;
            dgvUsuarios.DefaultCellStyle.BackColor = Color.White;
            dgvUsuarios.Enabled = true;
            //Se reordenar el factor de los botones
            btnAgregar.Visible = true;
            btnEditar.Visible = true;
            btnSet.Visible = false;
            btnCancelar.Visible = false;
            //Ahora está en modo detalle
            detalle = true;
        }

        private void deshabilitarDGV()
        {
            //el DataGridView se vuelve activo
            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver;
            dgvUsuarios.BackgroundColor = Color.Silver;
            dgvUsuarios.DefaultCellStyle.BackColor = Color.Silver;
            dgvUsuarios.Enabled = false;
            //Ahora está en modo detalle
            detalle = false;
            //textos limpios
            txtNombre.BorderStyle = BorderStyle.Fixed3D;
            txtNombre.ReadOnly = false;
            txtUsuario.BorderStyle = BorderStyle.Fixed3D;
            txtUsuario.ReadOnly = false;
        }

        private void llenarComboBox()
        {
            cmbDepartamento.DataSource = consultasMySQL.verDepartamentos();
            cmbDepartamento.DisplayMember = "Departamento";
            cmbDepartamento.ValueMember = "ID";

            dgvUsuarios.DataSource = consultasMySQL.verUsuarios();
            dgvUsuarios.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvUsuarios.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtUsuario.Text = "";
            txtDepartamento.Text = "";
            lbID.Text = "";
            btnAgregar.Visible = false;
            btnEditar.Visible = false;
            btnCancelar.Visible = true;
            btnSet.Visible = true;
            cmbDepartamento.Visible = true;
            txtDepartamento.Visible = false;
            deshabilitarDGV();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            actualizarDGV();
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
                        actualizarDGV();
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(detalle == false)
            {
                try
                {
                    consultasMySQL.updateUsuario(txtNombre.Text, txtUsuario.Text, cmbDepartamento.SelectedValue.ToString(), lbID.Text);
                    MessageBox.Show("Usuario Actualizado");
                    actualizarDGV();
                    detalle = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio una Excepción: " + ex);
                }
            }
            else if(detalle == true)
            {
                deshabilitarDGV();
                string idUsuario = dgvUsuarios.CurrentRow.Cells[0].Value.ToString();
                string nombre = dgvUsuarios.CurrentRow.Cells[1].Value.ToString();
                string usuario = dgvUsuarios.CurrentRow.Cells[2].Value.ToString();
                string departamento = dgvUsuarios.CurrentRow.Cells[3].Value.ToString();

                lbID.Text = idUsuario;
                txtNombre.Text = nombre;
                txtUsuario.Text = usuario;
                cmbDepartamento.Text = departamento;

                btnAgregar.Visible = false;
                btnCancelar.Visible = true;
            }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}