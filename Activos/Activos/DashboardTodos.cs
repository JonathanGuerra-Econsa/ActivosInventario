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
    public partial class DashboardTodos : Form
    {

        int heightMax, widthMax;
        ConsultasMysql mysql = new ConsultasMysql();

        public DashboardTodos()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            this.heightMax = Height;
            this.widthMax = Width;
            MinimizeBox = false;
            this.CenterToScreen();
            Responsive();
        }

        private void DashboardTodos_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = mysql.consulta();
            dataGridView2.DataSource = mysql.consultaArticulo();
        }

        private void Responsive()
        {
            int actheig = heightMax - Height;
            dataGridView1.Height = Height - 245 - actheig;
            dataGridView2.Height = dataGridView2.Height - actheig;

        }
    }
}
