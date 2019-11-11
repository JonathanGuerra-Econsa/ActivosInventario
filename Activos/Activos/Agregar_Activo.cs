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
    public partial class Agregar_Activo : Form
    {
        //----------------------------------------------------------*Variables*---------------------------------------------------//
        ConsultasMySQL_JG consultasMySQL =new  ConsultasMySQL_JG();
        bool detalle = true;

        string ID;
        string Descripcion;
        string Usuario;
        string Estado;
        string Categoria;
        string Empresa;
        string Fecha_Ingreso;
        //--------------------------------------------------------------------------------------------------------------------------//
        public Agregar_Activo()
        {
            InitializeComponent();
        }
        private void Agregar_Activo_Load(object sender, EventArgs e)
        {
            llenarComboBox();
            actualizarDGV();
            lbID.Text = "";
        }

        private void actualizarDGV()
        {
            //Consulta inicial
            dgvActivo.DataSource = consultasMySQL.verActivos();

            //Cambio de visibilidad para botones
            btnAgregar.Visible = true;
            btnCancelar.Visible = false;
            btnSet.Visible = false;
            btnActualizar.Visible = true;

            //dgvAparece
            dgvActivo.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvActivo.Enabled = true;
            dgvActivo.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvActivo.BackgroundColor = Color.White;
            dgvActivo.DefaultCellStyle.BackColor = Color.White;

            //txtCambian
            txtDescripcion.BorderStyle = BorderStyle.None;
            txtDescripcion.ReadOnly = true;
            txtUsuario.BorderStyle = BorderStyle.None;
            txtUsuario.ReadOnly = true;
            txtUsuario.Visible = true;
            txtEstado.BorderStyle = BorderStyle.None;
            txtEstado.ReadOnly = true;
            txtEstado.Visible = true;
            txtCategoria.BorderStyle = BorderStyle.None;
            txtCategoria.ReadOnly = true;
            txtCategoria.Visible = true;
            txtEmpresa.BorderStyle = BorderStyle.None;
            txtEmpresa.ReadOnly = true;
            txtEmpresa.Visible = true;
            txtFecha.BorderStyle = BorderStyle.None;
            txtFecha.ReadOnly = true;
            txtFecha.Visible = true;

            //cmb Desaparecen
            cmbUsuario.Visible = false;
            cmbEstado.Visible = false;
            cmbCategoria.Visible = false;
            cmbEmpresa.Visible = false;
            dtFecha.Visible = false;

            //ahora está en detalle
            detalle = true;
        }

        private void deshabilitarDGV()
        {
            //Cambio de visibilidad para botones
            btnAgregar.Visible = false;
            btnCancelar.Visible = true;
            

            //dgvAparece
            dgvActivo.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvActivo.Enabled = false;
            dgvActivo.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver;
            dgvActivo.BackgroundColor = Color.Silver;
            dgvActivo.DefaultCellStyle.BackColor = Color.Silver;

            //txtCambian
            txtDescripcion.BorderStyle = BorderStyle.Fixed3D;
            txtDescripcion.ReadOnly = false;
            txtUsuario.BorderStyle = BorderStyle.Fixed3D;
            txtUsuario.ReadOnly = false;
            txtUsuario.Visible = false;
            txtEstado.BorderStyle = BorderStyle.Fixed3D;
            txtEstado.ReadOnly = false;
            txtEstado.Visible = false;
            txtCategoria.BorderStyle = BorderStyle.Fixed3D;
            txtCategoria.ReadOnly = false;
            txtCategoria.Visible = false;
            txtEmpresa.BorderStyle = BorderStyle.Fixed3D;
            txtEmpresa.ReadOnly = false;
            txtEmpresa.Visible = false;
            txtFecha.BorderStyle = BorderStyle.Fixed3D;
            txtFecha.ReadOnly = false;
            txtFecha.Visible = false;

            //cmb Aparecen
            cmbUsuario.Visible = true;
            cmbUsuario.Text = Usuario;
            cmbEstado.Visible = true;
            cmbEstado.Text = Estado;
            cmbCategoria.Visible = true;
            cmbCategoria.Text = Categoria;
            cmbEmpresa.Visible = true;
            cmbEmpresa.Text = Empresa;
            dtFecha.Visible = true;
            dtFecha.Text = Fecha_Ingreso;

            //ahora no está en detalle
            detalle = false;
        }

        private void llenarComboBox()
        {
            cmbUsuario.DataSource = consultasMySQL.verUsuarios();
            cmbUsuario.DisplayMember = "Usuario";
            cmbUsuario.ValueMember = "ID";

            cmbEstado.DataSource = consultasMySQL.verEstados();
            cmbEstado.DisplayMember = "Estado";
            cmbEstado.ValueMember = "ID";

            cmbCategoria.DataSource = consultasMySQL.verCategorias();
            cmbCategoria.DisplayMember = "Categoria";
            cmbCategoria.ValueMember = "ID";

            cmbEmpresa.DataSource = consultasMySQL.verEmpresa();
            cmbEmpresa.DisplayMember = "Empresa";
            cmbEmpresa.ValueMember = "ID";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            btnSet.Visible = true;
            btnActualizar.Visible = false;
            deshabilitarDGV();
            lbID.Text = "";
            txtDescripcion.Text = "";
            cmbUsuario.Text = "";
            cmbEstado.Text = "";
            cmbCategoria.Text = "";
            cmbEmpresa.Text = "";
            dtFecha.Text = DateTime.Now.ToString();
        }

        private void dgvActivo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                ID = dgvActivo.CurrentRow.Cells[0].Value.ToString();
                Descripcion = dgvActivo.CurrentRow.Cells[1].Value.ToString();
                Usuario = dgvActivo.CurrentRow.Cells[2].Value.ToString();
                Estado = dgvActivo.CurrentRow.Cells[3].Value.ToString();
                Categoria = dgvActivo.CurrentRow.Cells[4].Value.ToString();
                Empresa = dgvActivo.CurrentRow.Cells[5].Value.ToString();
                Fecha_Ingreso = dgvActivo.CurrentRow.Cells[6].Value.ToString();

                lbID.Text = ID;
                txtDescripcion.Text = Descripcion;
                txtUsuario.Text = Usuario;
                txtEstado.Text = Estado;
                txtCategoria.Text = Categoria;
                txtEmpresa.Text = Empresa;
                txtFecha.Text = Fecha_Ingreso;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            actualizarDGV();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if(detalle == true)
            {
                deshabilitarDGV();
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            actualizarDGV();
        }
    }
}
