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
    public partial class Activos : Form
    {
        ConsultasMysql mysql = new ConsultasMysql();
        DateTime fechaI = new DateTime(2000,1,1), fechaF = DateTime.Today, fechaAntI, fechaAntF;

        public Activos()
        {
            InitializeComponent();
        }

        private void Activos_Load(object sender, EventArgs e)
        {
            //datos
            dataGridView1.DataSource = mysql.consulta("activo");
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[7].Visible = false;

            //datatime
            dateInicio.Value = fechaI;
            dateFinal.Value = fechaF;
            fechaAntF = fechaF;
            fechaAntI = fechaI;
            
            //Combo box de USUARIOS
            DataTable usuarios = new DataTable();
            usuarios = mysql.usuarios();

            DataRow nulo1 = usuarios.NewRow();
            nulo1["nombre"] = "Escoger Usuario...";
            nulo1["idU"] = 0;
            usuarios.Rows.InsertAt(nulo1, 0);
                        
            cmbUsuario.DisplayMember = "nombre";
            cmbUsuario.ValueMember = "idU";
            cmbUsuario.DataSource = usuarios;

            //Combo box de Categoria
            DataTable categorias = new DataTable();
            categorias = mysql.categorias();

            DataRow nulo2 = categorias.NewRow();
            nulo2["nombre"] = "Escoger Categoria...";
            nulo2["idC"] = 0;
            categorias.Rows.InsertAt(nulo2, 0);

            cmbCat.DisplayMember = "nombre";
            cmbCat.ValueMember = "idC";
            cmbCat.DataSource = categorias;

            //Combo box de Estado
            DataTable estados = new DataTable();
            estados = mysql.estados();

            DataRow nulo3 = estados.NewRow();
            nulo3["nombre"] = "Escoger Estado...";
            nulo3["idE"] = 0;
            estados.Rows.InsertAt(nulo3, 0);

            cmbEstado.DisplayMember = "nombre";
            cmbEstado.ValueMember = "idE";
            cmbEstado.DataSource = estados;
        }

        private void ArmarConsulta(object sender, EventArgs e)
        {
            if (dateInicio.Value < dateFinal.Value) { fechaAntI = dateInicio.Value; fechaAntF = dateFinal.Value; }
            else
            {
                dateFinal.Value = fechaAntF;
                dateInicio.Value = fechaAntI;
                MessageBox.Show("La fecha Inicial no puede ser superior a la fecha Final", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (cmbEstado.SelectedValue == null) return;
            StringBuilder consulta = new StringBuilder();
            consulta.Append("WHERE ");
            if (!(string.IsNullOrEmpty(textBox7.Text))) consulta.Append("a.descripcion like '%" + textBox7.Text + "%' AND ");
            if (cmbUsuario.SelectedValue.ToString() != 0.ToString()) consulta.Append("u.idUsuario like '%" + cmbUsuario.SelectedValue + "%' AND ");
            if (cmbCat.SelectedValue.ToString() != 0.ToString()) consulta.Append("c.idCategoria like '%" + cmbCat.SelectedValue + "%' AND ");
            if (cmbEstado.SelectedValue.ToString() != 0.ToString()) consulta.Append("e.idEstado like '%" + cmbEstado.SelectedValue + "%' AND ");
            consulta.Append("a.fecha_ingreso BETWEEN '"+ dateInicio.Value.Date.ToString("yyyy-MM-dd") + "' AND '" + dateFinal.Value.Date.ToString("yyyy-MM-dd") + "' ORDER BY idActivo");
            //if (consulta.ToString() == "WHERE ") consulta = new StringBuilder();
            //DataRowView dv = (DataRowView)cmbUsuario.SelectedItem;
            //int id = (int)dv.Row["idU"];;
            Console.WriteLine(consulta);
            dataGridView1.DataSource = mysql.consulta("activo",consulta.ToString());
        }

        private void limpiarDatos(object sender, EventArgs e)
        {
            cmbEstado.SelectedValue = 0;
            cmbCat.SelectedValue = 0;
            cmbUsuario.SelectedValue = 0;
            textBox7.Text = "";
            dateInicio.Value = fechaI;
            dateFinal.Value = fechaF;
        }
    }
}
