using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace Activos
{
    public partial class Login : Form
    {
        ConsultasMySQL_JG consultasMySQL = new ConsultasMySQL_JG();
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Departamento de Informática 2020", "Creditos", MessageBoxButtons.OK);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user_name = consultasMySQL.Login(txtUser.Text, txtPassword.Text);
            if (user_name != "")
            {
                Form1 form1 = new Form1();
                form1.nombre = user_name;
                form1.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña invalido");
            }
        }
    }
}
