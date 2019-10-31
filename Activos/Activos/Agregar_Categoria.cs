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
        public Agregar_Categoria()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseas agregar esta categoria?", "Agregar Categoria", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                MessageBox.Show("Categoria agregado correctamente", "Categoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
    }
}
