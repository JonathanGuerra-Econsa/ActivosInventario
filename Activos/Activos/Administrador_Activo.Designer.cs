﻿namespace Activos
{
    partial class Administrador_Activo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Administrador_Activo));
            this.cmbAdministrar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbTipos = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddTipo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSubGrupoTipo = new System.Windows.Forms.ComboBox();
            this.dgvTipos = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbGrupoTipo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbIDTipo = new System.Windows.Forms.Label();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.btnEditTipo = new System.Windows.Forms.Button();
            this.btnCancelTipo = new System.Windows.Forms.Button();
            this.gbGrupos = new System.Windows.Forms.GroupBox();
            this.gbDetalleGrupo = new System.Windows.Forms.GroupBox();
            this.btnCancelarGrupo = new System.Windows.Forms.Button();
            this.btnEditarGrupo = new System.Windows.Forms.Button();
            this.txtGrupo = new System.Windows.Forms.TextBox();
            this.lbIDGrupo = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAgregarGrupo = new System.Windows.Forms.Button();
            this.dgvGrupo = new System.Windows.Forms.DataGridView();
            this.gbSubGrupos = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.dgvSubGrupos = new System.Windows.Forms.DataGridView();
            this.gbTipos.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipos)).BeginInit();
            this.gbGrupos.SuspendLayout();
            this.gbDetalleGrupo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupo)).BeginInit();
            this.gbSubGrupos.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubGrupos)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbAdministrar
            // 
            this.cmbAdministrar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAdministrar.FormattingEnabled = true;
            this.cmbAdministrar.Location = new System.Drawing.Point(22, 41);
            this.cmbAdministrar.Name = "cmbAdministrar";
            this.cmbAdministrar.Size = new System.Drawing.Size(178, 25);
            this.cmbAdministrar.TabIndex = 1;
            this.cmbAdministrar.SelectedIndexChanged += new System.EventHandler(this.cmbAdministrar_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "¿Qué desea administrar?";
            // 
            // gbTipos
            // 
            this.gbTipos.BackColor = System.Drawing.Color.Transparent;
            this.gbTipos.Controls.Add(this.groupBox1);
            this.gbTipos.Controls.Add(this.dgvTipos);
            this.gbTipos.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTipos.Location = new System.Drawing.Point(12, 93);
            this.gbTipos.Name = "gbTipos";
            this.gbTipos.Size = new System.Drawing.Size(744, 381);
            this.gbTipos.TabIndex = 2;
            this.gbTipos.TabStop = false;
            this.gbTipos.Text = "Tipos";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.btnCancelTipo);
            this.groupBox1.Controls.Add(this.btnEditTipo);
            this.groupBox1.Controls.Add(this.txtTipo);
            this.groupBox1.Controls.Add(this.lbIDTipo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbGrupoTipo);
            this.groupBox1.Controls.Add(this.btnAddTipo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbSubGrupoTipo);
            this.groupBox1.Location = new System.Drawing.Point(376, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 337);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle Tipo";
            // 
            // btnAddTipo
            // 
            this.btnAddTipo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddTipo.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTipo.Image = global::Activos.Properties.Resources.plus__1_;
            this.btnAddTipo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddTipo.Location = new System.Drawing.Point(61, 243);
            this.btnAddTipo.Name = "btnAddTipo";
            this.btnAddTipo.Size = new System.Drawing.Size(126, 65);
            this.btnAddTipo.TabIndex = 6;
            this.btnAddTipo.Text = "Agregar";
            this.btnAddTipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddTipo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddTipo.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sub Grupo:";
            // 
            // cmbSubGrupoTipo
            // 
            this.cmbSubGrupoTipo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSubGrupoTipo.FormattingEnabled = true;
            this.cmbSubGrupoTipo.Location = new System.Drawing.Point(105, 173);
            this.cmbSubGrupoTipo.Name = "cmbSubGrupoTipo";
            this.cmbSubGrupoTipo.Size = new System.Drawing.Size(214, 25);
            this.cmbSubGrupoTipo.TabIndex = 5;
            // 
            // dgvTipos
            // 
            this.dgvTipos.AllowUserToAddRows = false;
            this.dgvTipos.AllowUserToResizeRows = false;
            this.dgvTipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTipos.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTipos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTipos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTipos.EnableHeadersVisualStyles = false;
            this.dgvTipos.Location = new System.Drawing.Point(10, 26);
            this.dgvTipos.MultiSelect = false;
            this.dgvTipos.Name = "dgvTipos";
            this.dgvTipos.ReadOnly = true;
            this.dgvTipos.RowHeadersVisible = false;
            this.dgvTipos.Size = new System.Drawing.Size(360, 337);
            this.dgvTipos.TabIndex = 0;
            this.dgvTipos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTipos_CellContentDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(280, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "Administrar Activos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "Grupo:";
            // 
            // cmbGrupoTipo
            // 
            this.cmbGrupoTipo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGrupoTipo.FormattingEnabled = true;
            this.cmbGrupoTipo.Location = new System.Drawing.Point(105, 130);
            this.cmbGrupoTipo.Name = "cmbGrupoTipo";
            this.cmbGrupoTipo.Size = new System.Drawing.Size(214, 25);
            this.cmbGrupoTipo.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "ID:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 21);
            this.label6.TabIndex = 10;
            this.label6.Text = "Tipo:";
            // 
            // lbIDTipo
            // 
            this.lbIDTipo.AutoSize = true;
            this.lbIDTipo.BackColor = System.Drawing.Color.Transparent;
            this.lbIDTipo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIDTipo.Location = new System.Drawing.Point(101, 54);
            this.lbIDTipo.Name = "lbIDTipo";
            this.lbIDTipo.Size = new System.Drawing.Size(26, 21);
            this.lbIDTipo.TabIndex = 11;
            this.lbIDTipo.Text = "ID";
            // 
            // txtTipo
            // 
            this.txtTipo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipo.Location = new System.Drawing.Point(105, 90);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(214, 27);
            this.txtTipo.TabIndex = 12;
            // 
            // btnEditTipo
            // 
            this.btnEditTipo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditTipo.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditTipo.Image = global::Activos.Properties.Resources.writing;
            this.btnEditTipo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditTipo.Location = new System.Drawing.Point(193, 243);
            this.btnEditTipo.Name = "btnEditTipo";
            this.btnEditTipo.Size = new System.Drawing.Size(126, 65);
            this.btnEditTipo.TabIndex = 13;
            this.btnEditTipo.Text = "Editar";
            this.btnEditTipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditTipo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditTipo.UseVisualStyleBackColor = true;
            // 
            // btnCancelTipo
            // 
            this.btnCancelTipo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelTipo.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelTipo.Image = global::Activos.Properties.Resources.close;
            this.btnCancelTipo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelTipo.Location = new System.Drawing.Point(193, 243);
            this.btnCancelTipo.Name = "btnCancelTipo";
            this.btnCancelTipo.Size = new System.Drawing.Size(126, 65);
            this.btnCancelTipo.TabIndex = 14;
            this.btnCancelTipo.Text = "Cancelar";
            this.btnCancelTipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelTipo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelTipo.UseVisualStyleBackColor = true;
            // 
            // gbGrupos
            // 
            this.gbGrupos.BackColor = System.Drawing.Color.Transparent;
            this.gbGrupos.Controls.Add(this.gbDetalleGrupo);
            this.gbGrupos.Controls.Add(this.dgvGrupo);
            this.gbGrupos.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbGrupos.Location = new System.Drawing.Point(12, 93);
            this.gbGrupos.Name = "gbGrupos";
            this.gbGrupos.Size = new System.Drawing.Size(744, 381);
            this.gbGrupos.TabIndex = 3;
            this.gbGrupos.TabStop = false;
            this.gbGrupos.Text = "Grupos";
            // 
            // gbDetalleGrupo
            // 
            this.gbDetalleGrupo.BackColor = System.Drawing.Color.White;
            this.gbDetalleGrupo.Controls.Add(this.btnCancelarGrupo);
            this.gbDetalleGrupo.Controls.Add(this.btnEditarGrupo);
            this.gbDetalleGrupo.Controls.Add(this.txtGrupo);
            this.gbDetalleGrupo.Controls.Add(this.lbIDGrupo);
            this.gbDetalleGrupo.Controls.Add(this.label9);
            this.gbDetalleGrupo.Controls.Add(this.label10);
            this.gbDetalleGrupo.Controls.Add(this.btnAgregarGrupo);
            this.gbDetalleGrupo.Location = new System.Drawing.Point(376, 26);
            this.gbDetalleGrupo.Name = "gbDetalleGrupo";
            this.gbDetalleGrupo.Size = new System.Drawing.Size(351, 337);
            this.gbDetalleGrupo.TabIndex = 1;
            this.gbDetalleGrupo.TabStop = false;
            this.gbDetalleGrupo.Text = "Detalle Grupo";
            // 
            // btnCancelarGrupo
            // 
            this.btnCancelarGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelarGrupo.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarGrupo.Image = global::Activos.Properties.Resources.close;
            this.btnCancelarGrupo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarGrupo.Location = new System.Drawing.Point(193, 243);
            this.btnCancelarGrupo.Name = "btnCancelarGrupo";
            this.btnCancelarGrupo.Size = new System.Drawing.Size(126, 65);
            this.btnCancelarGrupo.TabIndex = 14;
            this.btnCancelarGrupo.Text = "Cancelar";
            this.btnCancelarGrupo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarGrupo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelarGrupo.UseVisualStyleBackColor = true;
            // 
            // btnEditarGrupo
            // 
            this.btnEditarGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditarGrupo.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarGrupo.Image = global::Activos.Properties.Resources.writing;
            this.btnEditarGrupo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditarGrupo.Location = new System.Drawing.Point(193, 243);
            this.btnEditarGrupo.Name = "btnEditarGrupo";
            this.btnEditarGrupo.Size = new System.Drawing.Size(126, 65);
            this.btnEditarGrupo.TabIndex = 13;
            this.btnEditarGrupo.Text = "Editar";
            this.btnEditarGrupo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarGrupo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditarGrupo.UseVisualStyleBackColor = true;
            // 
            // txtGrupo
            // 
            this.txtGrupo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrupo.Location = new System.Drawing.Point(105, 140);
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.Size = new System.Drawing.Size(214, 27);
            this.txtGrupo.TabIndex = 12;
            // 
            // lbIDGrupo
            // 
            this.lbIDGrupo.AutoSize = true;
            this.lbIDGrupo.BackColor = System.Drawing.Color.Transparent;
            this.lbIDGrupo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIDGrupo.Location = new System.Drawing.Point(101, 100);
            this.lbIDGrupo.Name = "lbIDGrupo";
            this.lbIDGrupo.Size = new System.Drawing.Size(26, 21);
            this.lbIDGrupo.TabIndex = 11;
            this.lbIDGrupo.Text = "ID";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(39, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 21);
            this.label9.TabIndex = 9;
            this.label9.Text = "ID:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(39, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 21);
            this.label10.TabIndex = 7;
            this.label10.Text = "Grupo:";
            // 
            // btnAgregarGrupo
            // 
            this.btnAgregarGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgregarGrupo.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarGrupo.Image = global::Activos.Properties.Resources.plus__1_;
            this.btnAgregarGrupo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarGrupo.Location = new System.Drawing.Point(61, 243);
            this.btnAgregarGrupo.Name = "btnAgregarGrupo";
            this.btnAgregarGrupo.Size = new System.Drawing.Size(126, 65);
            this.btnAgregarGrupo.TabIndex = 6;
            this.btnAgregarGrupo.Text = "Agregar";
            this.btnAgregarGrupo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarGrupo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarGrupo.UseVisualStyleBackColor = true;
            // 
            // dgvGrupo
            // 
            this.dgvGrupo.AllowUserToAddRows = false;
            this.dgvGrupo.AllowUserToResizeRows = false;
            this.dgvGrupo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGrupo.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGrupo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrupo.EnableHeadersVisualStyles = false;
            this.dgvGrupo.Location = new System.Drawing.Point(10, 26);
            this.dgvGrupo.MultiSelect = false;
            this.dgvGrupo.Name = "dgvGrupo";
            this.dgvGrupo.ReadOnly = true;
            this.dgvGrupo.RowHeadersVisible = false;
            this.dgvGrupo.Size = new System.Drawing.Size(360, 337);
            this.dgvGrupo.TabIndex = 0;
            // 
            // gbSubGrupos
            // 
            this.gbSubGrupos.BackColor = System.Drawing.Color.Transparent;
            this.gbSubGrupos.Controls.Add(this.groupBox3);
            this.gbSubGrupos.Controls.Add(this.dgvSubGrupos);
            this.gbSubGrupos.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSubGrupos.Location = new System.Drawing.Point(12, 87);
            this.gbSubGrupos.Name = "gbSubGrupos";
            this.gbSubGrupos.Size = new System.Drawing.Size(744, 381);
            this.gbSubGrupos.TabIndex = 4;
            this.gbSubGrupos.TabStop = false;
            this.gbSubGrupos.Text = "Sub Grupos";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Location = new System.Drawing.Point(376, 26);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(351, 337);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Detalle Grupo";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Activos.Properties.Resources.close;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(193, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 65);
            this.button1.TabIndex = 14;
            this.button1.Text = "Cancelar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::Activos.Properties.Resources.writing;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(193, 243);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 65);
            this.button2.TabIndex = 13;
            this.button2.Text = "Editar";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(105, 140);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(214, 27);
            this.textBox1.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(101, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 21);
            this.label7.TabIndex = 11;
            this.label7.Text = "ID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(39, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 21);
            this.label8.TabIndex = 9;
            this.label8.Text = "ID:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(39, 142);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 21);
            this.label11.TabIndex = 7;
            this.label11.Text = "Grupo:";
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = global::Activos.Properties.Resources.plus__1_;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.Location = new System.Drawing.Point(61, 243);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(126, 65);
            this.button3.TabIndex = 6;
            this.button3.Text = "Agregar";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // dgvSubGrupos
            // 
            this.dgvSubGrupos.AllowUserToAddRows = false;
            this.dgvSubGrupos.AllowUserToResizeRows = false;
            this.dgvSubGrupos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubGrupos.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSubGrupos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSubGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubGrupos.EnableHeadersVisualStyles = false;
            this.dgvSubGrupos.Location = new System.Drawing.Point(10, 26);
            this.dgvSubGrupos.MultiSelect = false;
            this.dgvSubGrupos.Name = "dgvSubGrupos";
            this.dgvSubGrupos.ReadOnly = true;
            this.dgvSubGrupos.RowHeadersVisible = false;
            this.dgvSubGrupos.Size = new System.Drawing.Size(360, 337);
            this.dgvSubGrupos.TabIndex = 0;
            // 
            // Administrador_Activo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Activos.Properties.Resources.fondo2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(776, 528);
            this.Controls.Add(this.gbSubGrupos);
            this.Controls.Add(this.gbGrupos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbTipos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbAdministrar);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Administrador_Activo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrador Activo";
            this.Load += new System.EventHandler(this.Administrador_Activo_Load);
            this.gbTipos.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipos)).EndInit();
            this.gbGrupos.ResumeLayout(false);
            this.gbDetalleGrupo.ResumeLayout(false);
            this.gbDetalleGrupo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupo)).EndInit();
            this.gbSubGrupos.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubGrupos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbAdministrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbTipos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddTipo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSubGrupoTipo;
        private System.Windows.Forms.DataGridView dgvTipos;
        private System.Windows.Forms.Button btnCancelTipo;
        private System.Windows.Forms.Button btnEditTipo;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.Label lbIDTipo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbGrupoTipo;
        private System.Windows.Forms.GroupBox gbGrupos;
        private System.Windows.Forms.GroupBox gbDetalleGrupo;
        private System.Windows.Forms.Button btnCancelarGrupo;
        private System.Windows.Forms.Button btnEditarGrupo;
        private System.Windows.Forms.TextBox txtGrupo;
        private System.Windows.Forms.Label lbIDGrupo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAgregarGrupo;
        private System.Windows.Forms.DataGridView dgvGrupo;
        private System.Windows.Forms.GroupBox gbSubGrupos;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dgvSubGrupos;
    }
}