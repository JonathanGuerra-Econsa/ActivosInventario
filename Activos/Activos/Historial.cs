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
    public partial class Historial : Form
    {

        public int id, inventario, opcion;
        public string activo;
        ConsultasMysql mysql = new ConsultasMysql();

        public Historial()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void Historial_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = mysql.historial(id, opcion);
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            if (opcion == 1) dataGridView1.Columns[18].Visible = false;
            if (opcion == 1) dataGridView1.Columns[20].Visible = false;
            label3.Text = activo;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}
