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
            if(consultasMySQL.Login(txtUser.Text, txtPassword.Text) != "")
            {
                new Form1().Show();
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña invalido");
            }
        }
    }
}
