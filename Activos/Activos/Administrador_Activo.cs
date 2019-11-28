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
    public partial class Administrador_Activo : Form
    {
        #region Variables
        ConsultasMySQL_JG consultasMySQL = new ConsultasMySQL_JG();
        #endregion
        #region Load()
        public Administrador_Activo()
        {
            InitializeComponent();
        }

        private void Administrador_Activo_Load(object sender, EventArgs e)
        {
            llenarComboBox();
            bloquearDetalleTipo();
            bloquearDetalleGrupo();
            bloquearDetalleSubGrupo();
        }
        #endregion
        #region llenarComboBox()
        private void llenarComboBox()
        {
            //-------------------------------------------------------- ComboBox de Administrador -----------------------------------------------------//
            Dictionary<string, string> admin = new Dictionary<string, string>();
            admin.Add("1", "Tipo");
            admin.Add("2", "Grupo");
            admin.Add("3", "Sub Grupo");
            cmbAdministrar.DataSource = new BindingSource(admin, null);
            cmbAdministrar.DisplayMember = "Value";
            cmbAdministrar.ValueMember = "Key";
            //---------------------------------------------------------------------- -----------------------------------------------------------------------//
            //---------------------------------------------------------------- ComboBox de Grupo en gbSubGrupo ---------------------------------------//
            cmbGrupo.DataSource = consultasMySQL.verGrupo();
            cmbGrupo.DisplayMember = "Nombre";
            cmbGrupo.ValueMember = "ID";
            //----------------------------------------------------------------------------------------------------------------------------------------------------//
        }
        #endregion
        #region SelectedValueChanged de Administrador
        private void cmbAdministrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAdministrar.SelectedIndex != -1)
            {
                if (cmbAdministrar.SelectedIndex == 0)
                {
                    gbTipos.Visible = true;
                    gbGrupos.Visible = false;
                    gbSubGrupos.Visible = false;
                    dgvTipos.DataSource = consultasMySQL.verTiposActivo();
                    dgvTipos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvTipos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    transladarDatosTipo();
                    btnCancelTipo.Visible = false;
                }
                if (cmbAdministrar.SelectedIndex == 1)
                {
                    gbGrupos.Visible = true;
                    gbTipos.Visible = false;
                    gbSubGrupos.Visible = false;
                    dgvGrupo.DataSource = consultasMySQL.verGrupo();
                    dgvGrupo.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvGrupo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    transladarDatosGrupo();
                    btnCancelarGrupo.Visible = false;
                }
                if (cmbAdministrar.SelectedIndex == 2)
                {
                    gbSubGrupos.Visible = true;
                    gbGrupos.Visible = false;
                    gbTipos.Visible = false;
                    dgvSubGrupos.DataSource = consultasMySQL.verSubGrupo();
                    dgvSubGrupos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvSubGrupos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    transladarDatosSubGrupo();
                    btnCancelarSubGrupo.Visible = false;
                }
            }
        }
        #endregion
        #region DataGridView TIPO
        private void dgvTipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                transladarDatosTipo();
            }
        }

        private void transladarDatosTipo()
        {
            string idTipo = dgvTipos.CurrentRow.Cells[0].Value.ToString();
            string tipo = dgvTipos.CurrentRow.Cells[1].Value.ToString();

            lbIDTipo.Text = idTipo;
            txtTipo.Text = tipo;
        }
        #endregion
        #region DataGridView GRUPO
        private void dgvGrupo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                transladarDatosGrupo();
            }
        }

        public void transladarDatosGrupo()
        {
            string idGrupo = dgvGrupo.CurrentRow.Cells[0].Value.ToString();
            string nombreGrupo = dgvGrupo.CurrentRow.Cells[1].Value.ToString();

            lbIDGrupo.Text = idGrupo;
            txtGrupo.Text = nombreGrupo;
        }
        #endregion
        #region DataGrid SUBGRUPO
        private void dgvSubGrupos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                transladarDatosSubGrupo();
            }
        }

        public void transladarDatosSubGrupo()
        {
            string idSubGrupo = dgvSubGrupos.CurrentRow.Cells[0].Value.ToString();
            string subGrupo = dgvSubGrupos.CurrentRow.Cells[1].Value.ToString();
            string grupo = dgvSubGrupos.CurrentRow.Cells[2].Value.ToString();

            lbIDsubGrupo.Text = idSubGrupo;
            txtSubGrupo.Text = subGrupo;
            cmbGrupo.Text = grupo;
        }
        #endregion
        #region Selected Value Changed de Grupo Tipo
        //------------------------------------------------------------------ cmbGrupoTipo ---------------------------------------------------//
        private void cmbGrupoTipo_SelectedValueChanged(object sender, EventArgs e)
        {
            cmbAdministrar.SelectedIndex = 0;
        }
        //------------------------------------------------------------------------- / -------------------------------------------------------------//
        #endregion
        #region Bloquear Detalle Tipo
        private void bloquearDetalleTipo()
        {
            txtTipo.Enabled = false;
            dgvTipos.Enabled = true;
            dgvTipos.BackgroundColor = Color.White;
            dgvTipos.DefaultCellStyle.BackColor = Color.White;
            btnCancelTipo.Visible = false;
            btnEditTipo.Visible = true;
            cmbAdministrar.Enabled = true;
            btnCancelTipo.Location = new Point(193, 243);
        }
        #endregion
        #region Bloquear Detalle Grupo
        public void bloquearDetalleGrupo()
        {
            txtGrupo.Enabled = false;
            dgvGrupo.Enabled = true;
            dgvGrupo.BackgroundColor = Color.White; 
            dgvGrupo.DefaultCellStyle.BackColor = Color.White;
            btnCancelarGrupo.Visible = false;
            cmbAdministrar.Enabled = true;
            btnCancelarGrupo.Location = new Point(193, 243);
        }
        #endregion
        #region Bloquear Detalle SubGrupo
        private void bloquearDetalleSubGrupo()
        {
            dgvSubGrupos.Enabled = true;
            dgvSubGrupos.BackgroundColor = Color.White;
            dgvSubGrupos.DefaultCellStyle.BackColor = Color.White;
            txtSubGrupo.Enabled = false;
            cmbGrupo.Enabled = false;
            btnCancelarSubGrupo.Visible = false;
            cmbAdministrar.Enabled = true;
            btnCancelarSubGrupo.Location = new Point(193, 243);
        }
        #endregion
        #region Bloquear DataGridView Tipo
        private void bloquearDGVTipo()
        {
            txtTipo.Enabled = true;
            dgvTipos.Enabled = false;
            dgvTipos.BackgroundColor = Color.Silver;
            dgvTipos.DefaultCellStyle.BackColor = Color.Silver;
            btnCancelTipo.Visible = true;
            cmbAdministrar.Enabled = false;
        }
        #endregion
        #region Bloquear DataGridView Grupo
        private void bloquearDGVGrupo()
        {
            txtGrupo.Enabled = true;
            btnCancelarGrupo.Visible = true;
            dgvGrupo.Enabled = false;
            dgvGrupo.BackgroundColor = Color.Silver;
            dgvGrupo.DefaultCellStyle.BackColor = Color.Silver;
            cmbAdministrar.Enabled = false;
        }
        #endregion
        #region Bloquear DataGridView SubGrupo
        private void bloquearDGVSubGrupo()
        {
            txtSubGrupo.Enabled = true;
            cmbGrupo.Enabled = true;
            btnCancelarSubGrupo.Visible = true;
            dgvSubGrupos.Enabled = false;
            dgvSubGrupos.BackgroundColor = Color.Silver;
            dgvSubGrupos.DefaultCellStyle.BackColor = Color.Silver;
            cmbAdministrar.Enabled = false;
        }
        #endregion

        #region Botones TIPO
        //----------------------------------------------- Tipo ---------------------------------------------//
        private void btnAddTipo_Click(object sender, EventArgs e)
        {
            if (txtTipo.Enabled == false)
            {
                bloquearDGVTipo();
                btnEditTipo.Visible = false;
                lbIDTipo.Text = "";
                txtTipo.Text = "";
            }
            else
            {
                if(MessageBox.Show("Desea Guardar este Tipo?", "Guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (txtTipo.Text != "" )
                        {
                            consultasMySQL.addTipo(txtTipo.Text);
                            MessageBox.Show("Guardado Correctamente", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvTipos.DataSource = consultasMySQL.verTiposActivo();
                            bloquearDetalleTipo();
                            transladarDatosTipo();
                            cmbAdministrar.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Ingrese los campo correctamente", "No Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }
        private void btnCancelTipo_Click(object sender, EventArgs e)
        {
            bloquearDetalleTipo();
            transladarDatosTipo();
            cmbAdministrar.Enabled = true;
        }
        private void btnEditTipo_Click(object sender, EventArgs e)
        {
            if (txtTipo.Enabled == false)
            {
                bloquearDGVTipo();
                btnCancelTipo.Location = new Point(61, 243);
            }
            else
            {
                if (MessageBox.Show("Desea Editar este Tipo?", "Actualizar Tipo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (txtTipo.Text != "" )
                        {
                            consultasMySQL.editTipo(lbIDTipo.Text, txtTipo.Text);
                            MessageBox.Show("Guardado Correctamente", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvTipos.DataSource = consultasMySQL.verTiposActivo();
                            bloquearDetalleTipo();
                            transladarDatosTipo();
                            cmbAdministrar.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Ingrese los campos correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }
        //--------------------------------------------------------------------------------------------------//
        #endregion
        #region Botones GRUPO
        private void btnAgregarGrupo_Click(object sender, EventArgs e)
        {
            if (txtGrupo.Enabled == false)
            {
                bloquearDGVGrupo();
                txtGrupo.Text = "";
                lbIDGrupo.Text = "";
            }
            else
            {
                if (MessageBox.Show("Desea crear este nuevo grupo?", "Guardar Grupo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (txtGrupo.Text != "")
                        {
                            consultasMySQL.addGrupo(txtGrupo.Text);
                            MessageBox.Show("Grupo Guardado Exitosamente", "Grupo guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvGrupo.DataSource = consultasMySQL.verGrupo();
                            bloquearDetalleGrupo();
                            transladarDatosGrupo();
                        }
                        else
                        {
                            MessageBox.Show("Ingrese los campo correctamente", "No Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }
        private void btnCancelarGrupo_Click(object sender, EventArgs e)
        {
            bloquearDetalleGrupo();
            transladarDatosGrupo();
        }
        private void btnEditarGrupo_Click(object sender, EventArgs e)
        {
            if (txtGrupo.Enabled == false)
            {
                bloquearDGVGrupo();
                btnCancelarGrupo.Location = new Point(61, 243);
            }
            else
            {
                if (MessageBox.Show("Desea editar este grupo?", "Editar Grupo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (txtGrupo.Text != "")
                        {
                            consultasMySQL.editGrupo(lbIDGrupo.Text, txtGrupo.Text);
                            MessageBox.Show("Grupo Editado Exitosamente", "Grupo Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bloquearDetalleGrupo();
                            dgvGrupo.DataSource = consultasMySQL.verGrupo();
                            transladarDatosGrupo();
                        }
                        else
                        {
                            MessageBox.Show("Ingrese los campo correctamente", "No Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }
        #endregion
        #region Botones SubGrupo
        private void btnAgregarSubGrupo_Click(object sender, EventArgs e)
        {
            if (txtSubGrupo.Enabled == false)
            {
                bloquearDGVSubGrupo();
                lbIDsubGrupo.Text = "";
                txtSubGrupo.Text = "";
                cmbGrupo.Text = "";
            }
            else
            {
                if (MessageBox.Show("Desea agregar este subgrupo?", "Guardar SubGrupo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (txtSubGrupo.Text != "" && cmbGrupo.SelectedItem != null)
                        {
                            consultasMySQL.addSubGrupo(txtSubGrupo.Text, cmbGrupo.SelectedValue.ToString());
                            MessageBox.Show("SubGrupo guardado correctamente", "Guardar SubGrupo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bloquearDetalleSubGrupo();
                            transladarDatosSubGrupo();
                            dgvSubGrupos.DataSource = consultasMySQL.verSubGrupo();
                        }
                        else
                        {
                            MessageBox.Show("Ingrese los campo correctamente", "No Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }
        private void btnCancelarSubGrupo_Click(object sender, EventArgs e)
        {
            bloquearDetalleSubGrupo();
            transladarDatosSubGrupo();
        }

        private void btnEditarSubGrupo_Click(object sender, EventArgs e)
        {
            if (txtSubGrupo.Enabled == false)
            {
                bloquearDGVSubGrupo();
                btnCancelarSubGrupo.Location = new Point(61, 243);
            }
            else
            {
                if (MessageBox.Show("Desea editar este Sub Grupo?", "Editar Sub Grupo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (txtSubGrupo.Text != "" && cmbGrupo.SelectedItem != null)
                        {
                            consultasMySQL.editSubGrupo(lbIDsubGrupo.Text, txtSubGrupo.Text, cmbGrupo.SelectedValue.ToString());
                            MessageBox.Show("Sub Grupo editado correctamente", "Editar Sub Grupo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bloquearDetalleSubGrupo();
                            transladarDatosSubGrupo();
                            dgvSubGrupos.DataSource = consultasMySQL.verSubGrupo();
                        }
                        else
                        {
                            MessageBox.Show("Ingrese los campo correctamente", "No Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }
        #endregion

    }
}
