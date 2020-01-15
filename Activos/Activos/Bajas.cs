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
    public partial class Bajas : Form
    {
        #region varibales
        ConsultasMySQL_JG consultasMysql = new ConsultasMySQL_JG();
        DateTime dateNow = DateTime.Now;
        #endregion
        public Bajas()
        {
            InitializeComponent();
        }

        private void Bajas_Load(object sender, EventArgs e)
        {
            lbFecha.Text = dateNow.ToString("dd/MM/yyyy HH:mm");

            DataGridViewCheckBoxColumn CheckBoxColumn = new DataGridViewCheckBoxColumn();
            CheckBoxColumn.HeaderText = "✓";
            dgvActivos.Columns.Add(CheckBoxColumn);

            dgvActivos.DataSource = consultasMysql.verActivos();
            dgvActivos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvActivos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvActivos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvActivos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void chk_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvActivos.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = !(chk.Value == null ? false : (bool)chk.Value);
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (txtTitulo.Text != "")
            {

            }
        }

        private void capturarID()
        {
            string prueba = "";
            int contador = 0;
            foreach (DataGridViewRow row in dgvActivos.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    if (contador == 0)
                    {
                        prueba = row.Cells[1].Value.ToString();
                    }
                    else
                    {
                        prueba = prueba + "," + row.Cells[1].Value.ToString();
                    }
                    contador++;
                }
            }
        }
    }
}
