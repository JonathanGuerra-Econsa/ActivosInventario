﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Activos
{
    public partial class Lectura : Form
    {
        #region Variables
        //----------------------------------------------- * Variables * -------------------------------------------------//
        ConsultasMySQL_JG consultasMySQL = new ConsultasMySQL_JG();
        int idActivo;
        int idArticulo;
        public int invIdAc;
        public int invIdArt;
        string activo_articulo;
        //---------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Load()
        public Lectura()
        {
            InitializeComponent();
        }
        #endregion
        #region Botón Soporte
        //---------------------------------------------- * Cuando le da click al botón de soporte * --------------------------------------------------------//
        private void btnSoporte_Click(object sender, EventArgs e)
        {
            if (idArticulo != 0 || idActivo != 0)
            {
                cmbEstados.Visible = true;
                lbEstado.Visible = false;
                btnActualizar.Visible = true;
                btnSoporte.Visible = false;
                txtEscaner.Enabled = false;
                btnCancelar.Visible = true;
                cmbEstados.Text = lbEstado.Text;
            }
        }
        //---------------------------------------------- ---------------------------------------------- --------------------------------------------------------//
        #endregion
        #region Text Cahnged
        //------------------------------------------------------- * Cada vez que el texto cambia * --------------------------------------------------------------------//
        private void txtEscaner_TextChanged(object sender, EventArgs e)
        {
            idActivo = 0;
            idArticulo = 0;
            ocultar_ver(false);
            if (txtEscaner.Text.Length >= 7)
            {
                Regex rx = new Regex(@"^[aA-zZ]+(\-|\')?[0-9]+$");
                if (rx.IsMatch(txtEscaner.Text))
                {
                    int inicio = txtEscaner.Text.LastIndexOf('-');
                    if (inicio == -1)
                    {
                        inicio = txtEscaner.Text.LastIndexOf('\'');
                        string nuevo = Regex.Replace(txtEscaner.Text, "'", "-");
                        txtEscaner.Text = nuevo;
                    }
                    activo_articulo = txtEscaner.Text.Substring(0, inicio);
                    int id = Convert.ToInt32(txtEscaner.Text.Substring(inicio + 1, txtEscaner.Text.Length - (inicio + 1)));
                    if (activo_articulo == "a" || activo_articulo == "A")
                    {
                        llenarDatosActivo(id.ToString());
                        idActivo = id;
                    }
                    else if (activo_articulo == "ar" || activo_articulo == "AR" || activo_articulo == "Ar" || activo_articulo == "aR")
                    {
                        llenarDatosArticulo(id.ToString());
                        idArticulo = id;
                    }
                    else
                    {
                        MessageBox.Show("El texto que acaba de ingresar no es un identificador propio del programa", "Error de Sintaxis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("El texto que acaba de ingresar no es un identificador propio del programa", "Error de Sintaxis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region llenarDatosActivo()
        //--------------------------- * Llena los datos del detalle * ------------------------------//
        private void llenarDatosActivo(string idActivo)
        {
            ocultar_ver(true);
            consultasMySQL.traerActivo(idActivo, Convert.ToString(invIdAc));
            lbDescripcion.Text = consultasMySQL.descripcion;
            lbUsuario.Text = consultasMySQL.usuario;
            lbEstado.Text = consultasMySQL.estado;
            lbStatus.Text = consultasMySQL.fisico;
            lbInventario.Text = consultasMySQL.inv_activo;
            lbFecha.Text = consultasMySQL.fecha_activo;
            if(lbDescripcion.Text != "")
            {
                btnSoporte.Visible = true;
            }
            else
            {
                btnSoporte.Visible = false;
            }
        }
        //------------------------------------------- ------------------------------------------------//
        #endregion
        #region llenarDatosArticulo()
        //--------------------------- * Llena los datos del detalle * ------------------------------//
        private void llenarDatosArticulo(string idArticulo)
        {
            ocultar_ver(true);
            consultasMySQL.traerArticulo(idArticulo, Convert.ToString(invIdArt));
            lbDescripcion.Text = consultasMySQL.descripcion_articulo;
            lbUsuario.Text = consultasMySQL.usuario_articulo;
            lbEstado.Text = consultasMySQL.estado_articulo;
            lbStatus.Text = consultasMySQL.fisico_articulo;
            lbInventario.Text = consultasMySQL.inv_articulo;
            lbFecha.Text = consultasMySQL.fecha_articulo;
            if (lbDescripcion.Text != "")
            {
                btnSoporte.Visible = true;
            }
            else
            {
                btnSoporte.Visible = false;
            }
        }
        //------------------------------------------- ------------------------------------------------//
        #endregion
        #region Carga Inicial
        private void Lectura_Load(object sender, EventArgs e)
        {
            cmbEstados.DataSource = consultasMySQL.verEstados();
            cmbEstados.DisplayMember = "Estado";
            cmbEstados.ValueMember = "ID";
        }
        #endregion
        #region Botón Actualizar
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (cmbEstados.SelectedItem != null)
            {
                if (MessageBox.Show("Desea cambiar este artículo a un esado físico " + cmbEstados.Text + "?", "Revisar Artículo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string estado = cmbEstados.SelectedValue.ToString();
                    string idStatus = "1";
                    string idInventarioArticulo = invIdArt.ToString();
                    string idInventarioActivo = invIdAc.ToString();
                    string idDetalle = consultasMySQL.idDetalleActivo;
                    string idDetalleArt = consultasMySQL.idDetalleArticulo;
                    try
                    {
                        if(activo_articulo == "a" || activo_articulo == "A")
                        {
                            //MessageBox.Show("Es una activo");
                            consultasMySQL.updateDetalleActivo(estado, idStatus, fecha, idDetalle);
                            consultasMySQL.cambioEstadoActivo(estado, idActivo.ToString());
                            llenarDatosActivo(idActivo.ToString());
                            cmbEstados.Visible = false;
                            btnCancelar.Visible = false;
                            btnActualizar.Visible = false;
                            txtEscaner.Enabled = true;
                            txtEscaner.Text = "";
                            btnSoporte.Visible = true;
                            lbEstado.Visible = true;
                            ocultar_ver(false);
                        }
                        else if (activo_articulo == "ar" || activo_articulo == "AR")
                        {
                            consultasMySQL.updateDetalleArticulo(estado, idStatus, fecha, idDetalleArt);
                            consultasMySQL.cambioEstadoArticulo(estado, idArticulo.ToString());
                            llenarDatosArticulo(idArticulo.ToString());
                            cmbEstados.Visible = false;
                            btnCancelar.Visible = false;
                            btnActualizar.Visible = false;
                            txtEscaner.Enabled = true;
                            txtEscaner.Text = "";
                            btnSoporte.Visible = true;
                            lbEstado.Visible = true;
                            ocultar_ver(false);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }
        #endregion
        #region Botón Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnCancelar.Visible = false;
            txtEscaner.Enabled = true;
            btnActualizar.Visible = false;
            cmbEstados.Visible = false;
            btnSoporte.Visible = true;
            lbEstado.Visible = true;
        }
        #endregion
        #region ocultar_ver()
        private void ocultar_ver(bool ver)
        {
            lbDescripcion.Visible = ver;
            lbUsuario.Visible = ver;
            lbInventario.Visible = ver;
            lbEstado.Visible = ver;
            lbStatus.Visible = ver;
            lbFecha.Visible = ver;
            btnSoporte.Visible = ver;
        }
        #endregion
    }
}
