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
        #region Variables
        //----------------------------------Variables-----------------------------------//
        ConsultasMySQL_JG consultasMySQL = new ConsultasMySQL_JG();
        bool detalle = true;
        //-------------------------------------------------------------------------------//
        #endregion
        #region Load()
        //------------------------------------------------------Primeros Procesos (Load) --------------------------------------------------//
        public Agregar_Usuario()
        {
            InitializeComponent();
        }
        private void Agregar_Usuario_Load(object sender, EventArgs e)
        {
            verUsuarios();
            activarDGV();
            llenarComboBox();
        }
        //----------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region LlenarComboBox()
        //--------------------- Llena los combobox que se necesitan para agregar y editar usuarios ------------------------------------------//
        private void llenarComboBox()
        {
            cmbDepartamento.DataSource = consultasMySQL.verDepartamentos();
            cmbDepartamento.DisplayMember = "Departamento";
            cmbDepartamento.ValueMember = "ID";
        }
        //--------------------------------------------------------- ------------------------------------------------------------//
        #endregion
        #region Click en DataGridView
        //------------- Cuando dan click en una celda del DGV actualiza la data en los textbox --------------------------//
        private void dgvUsuarios_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                transladarusuarios();
            }
        }
        //--------------------------------------------------------- ------------------------------------------------------------//
        #endregion
        #region Botón Cancelar
        //---------------------------------------------- llama al método de actualizarDGV() ------------------------------------------------------------//
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            activarDGV();
        }
        //--------------------------------------------------------- ------------------------------------------------------------//
        #endregion
        #region Set
        //------------------------------------------------ Guarda un nuevo usuario en la base de datos ------------------------------------------------------------//
        private void btnSet_Click(object sender, EventArgs e)
        {
            if (txtNombre.Enabled == false)
            {
                activarDetalle();
                txtNombre.Enabled = true;
                txtUsuario.Enabled = true;
                cmbDepartamento.Enabled = true;
                txtNombre.Text = "";
                txtUsuario.Text = "";
                cmbDepartamento.Text = "";
                lbNombreID.Visible = false;
                lbID.Text = "";
                btnEditar.Visible = false;
            }
            else
            {
                if (MessageBox.Show("Desea agregar este usuario?", "Agregar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (txtNombre.Text != "" && txtUsuario.Text != "" && cmbDepartamento.SelectedItem != null)
                    {
                        try
                        {
                            const string contraseña_por_defecto = "null";
                            consultasMySQL.agregarUsuario(txtNombre.Text, txtUsuario.Text, contraseña_por_defecto, cmbDepartamento.SelectedValue.ToString());
                            MessageBox.Show("Usuario guardado con éxito!", "Usuario Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            activarDGV();
                            verUsuarios();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor llene todos los campos correctamente", "Guardado Fallido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        //--------------------------------------------------------- ------------------------------------------------------------//
        #endregion
        #region Botón Editar
        //-------------------------------------- Botón que edita o actualiza un usuario ------------------------------------------------------------//
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Enabled == false)
            {
                activarDetalle();
                btnCancelar.Location = new Point(103, 226);
            }
            else
            {
                if (MessageBox.Show("Desea editar este usuario?", "Actualizar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (txtNombre.Text != "" && txtUsuario.Text != "" && cmbDepartamento.SelectedItem != null)
                    {
                        try
                        {
                            consultasMySQL.updateUsuario(txtNombre.Text, txtUsuario.Text, cmbDepartamento.SelectedValue.ToString(), lbID.Text);
                            MessageBox.Show("Usuario actualizado con éxito!", "Usuario Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            verUsuarios();
                            activarDGV();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor llene todos los campos correctamente", "Guardado Fallido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        //--------------------------------------------------------- ------------------------------------------------------------//
        #endregion
        #region verUsuarios()
        private void verUsuarios()
        {
            dgvUsuarios.DataSource = consultasMySQL.verUsuarios();
            dgvUsuarios.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvUsuarios.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        #endregion
        #region transladarUsuarios();
        private void transladarusuarios()
        {
            string idUsuario = dgvUsuarios.CurrentRow.Cells[0].Value.ToString();
            string nombre = dgvUsuarios.CurrentRow.Cells[1].Value.ToString();
            string usuario = dgvUsuarios.CurrentRow.Cells[2].Value.ToString();
            string departamento = dgvUsuarios.CurrentRow.Cells[3].Value.ToString();

            lbID.Text = idUsuario;
            txtNombre.Text = nombre;
            txtUsuario.Text = usuario;
            cmbDepartamento.Text = departamento;
        }
        #endregion
        #region activarDGV()
        private void activarDGV()
        {
            dgvUsuarios.Enabled = true;
            dgvUsuarios.BackgroundColor = Color.White;
            dgvUsuarios.DefaultCellStyle.BackColor = Color.White;
            txtNombre.Enabled = false;
            txtUsuario.Enabled = false;
            cmbDepartamento.Enabled = false;
            btnEditar.Visible = true;
            btnCancelar.Visible = false;
            btnCancelar.Location = new Point(226, 226);
            lbNombreID.Visible = true;
            transladarusuarios();
        }
        #endregion
        #region activarDetalle()
        private void activarDetalle()
        {
            dgvUsuarios.Enabled = false;
            dgvUsuarios.BackgroundColor = Color.Silver;
            dgvUsuarios.DefaultCellStyle.BackColor = Color.Silver;
            txtNombre.Enabled = true;
            txtUsuario.Enabled = true;
            cmbDepartamento.Enabled = true;
            btnCancelar.Visible = true;
        }
        #endregion
    }
}