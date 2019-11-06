﻿using System;
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
    public partial class Agregar_Categoria : Form
    {
        ConsultasMySQL_JG consultasMySQL = new ConsultasMySQL_JG();
        public Agregar_Categoria()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                if (MessageBox.Show("Deseas agregar esta categoria?", "Agregar Categoria", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    try
                    {
                        consultasMySQL.agregarCategoria(txtNombre.Text);
                        MessageBox.Show("Categoria agregado correctamente", "Categoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Excepción Encontrada: " + ex);
                    }
                }
            }
            else
            {
                MessageBox.Show("Escriba el nombre de la categoria antes de enviarla", "Campo Vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
