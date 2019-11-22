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
        }
        #endregion
        #region llenarComboBox()
        private void llenarComboBox()
        {
            Dictionary<string, string> admin = new Dictionary<string, string>();
            admin.Add("1", "Tipo");
            admin.Add("2", "Grupo");
            admin.Add("3", "Sub Grupo");
            cmbAdministrar.DataSource = new BindingSource(admin, null);
            cmbAdministrar.DisplayMember = "Value";
            cmbAdministrar.ValueMember = "Key";
        }
        #endregion

        private void cmbAdministrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAdministrar.SelectedIndex != -1)
            {
                if (cmbAdministrar.SelectedIndex == 0)
                {
                    gbTipos.Visible = true;
                    gbGrupos.Visible = false;
                    dgvTipos.DataSource = consultasMySQL.verTiposActivo();
                    dgvTipos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvTipos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    btnCancelTipo.Visible = false;
                }
                if (cmbAdministrar.SelectedIndex == 1)
                {
                    gbGrupos.Visible = true;
                    gbTipos.Visible = false;
                    dgvGrupo.DataSource = consultasMySQL.verGrupo();
                    dgvGrupo.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvGrupo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    btnCancelarGrupo.Visible = false;
                }
            }
        }

        private void dgvTipos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
