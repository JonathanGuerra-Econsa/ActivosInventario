namespace Activos
{
    partial class Agregar_Activo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Agregar_Activo));
            this.label1 = new System.Windows.Forms.Label();
            this.gbDetalleActivo = new System.Windows.Forms.GroupBox();
            this.lbID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbEmpresa = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.gbUsuario = new System.Windows.Forms.GroupBox();
            this.btnActualiza = new System.Windows.Forms.Button();
            this.lbPuesto = new System.Windows.Forms.Label();
            this.lbDepartamentoUsuario = new System.Windows.Forms.Label();
            this.lbNombreUsuario = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbSubGrupo = new System.Windows.Forms.GroupBox();
            this.cmbSubGrupo = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbGrupo = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.gbValor = new System.Windows.Forms.GroupBox();
            this.nuValorLibros = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.nuValorResidual = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.nuDepreciacionAcumulada = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.nuPorcentaje = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.dtDepreciacion = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.txtFPC = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.nuValor = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.gbDetalleActivo.SuspendLayout();
            this.gbUsuario.SuspendLayout();
            this.gbSubGrupo.SuspendLayout();
            this.gbValor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuValorLibros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuValorResidual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuDepreciacionAcumulada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuPorcentaje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuValor)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(480, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 37);
            this.label1.TabIndex = 14;
            this.label1.Text = "Activo";
            // 
            // gbDetalleActivo
            // 
            this.gbDetalleActivo.BackColor = System.Drawing.Color.White;
            this.gbDetalleActivo.Controls.Add(this.lbID);
            this.gbDetalleActivo.Controls.Add(this.label8);
            this.gbDetalleActivo.Controls.Add(this.dtFecha);
            this.gbDetalleActivo.Controls.Add(this.label7);
            this.gbDetalleActivo.Controls.Add(this.cmbEmpresa);
            this.gbDetalleActivo.Controls.Add(this.label6);
            this.gbDetalleActivo.Controls.Add(this.cmbTipo);
            this.gbDetalleActivo.Controls.Add(this.label5);
            this.gbDetalleActivo.Controls.Add(this.cmbEstado);
            this.gbDetalleActivo.Controls.Add(this.label4);
            this.gbDetalleActivo.Controls.Add(this.txtDescripcion);
            this.gbDetalleActivo.Controls.Add(this.label2);
            this.gbDetalleActivo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDetalleActivo.Location = new System.Drawing.Point(12, 78);
            this.gbDetalleActivo.Name = "gbDetalleActivo";
            this.gbDetalleActivo.Size = new System.Drawing.Size(505, 292);
            this.gbDetalleActivo.TabIndex = 0;
            this.gbDetalleActivo.TabStop = false;
            this.gbDetalleActivo.Text = "Detalle Activo";
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.BackColor = System.Drawing.Color.Transparent;
            this.lbID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbID.Location = new System.Drawing.Point(126, 33);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(27, 21);
            this.lbID.TabIndex = 50;
            this.lbID.Text = "ID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 25);
            this.label8.TabIndex = 49;
            this.label8.Text = "ID:";
            // 
            // dtFecha
            // 
            this.dtFecha.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFecha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFecha.Location = new System.Drawing.Point(130, 222);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(337, 23);
            this.dtFecha.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 51);
            this.label7.TabIndex = 40;
            this.label7.Text = "Fecha Compra:";
            // 
            // cmbEmpresa
            // 
            this.cmbEmpresa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEmpresa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEmpresa.BackColor = System.Drawing.Color.White;
            this.cmbEmpresa.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmpresa.FormattingEnabled = true;
            this.cmbEmpresa.Location = new System.Drawing.Point(130, 178);
            this.cmbEmpresa.Name = "cmbEmpresa";
            this.cmbEmpresa.Size = new System.Drawing.Size(337, 25);
            this.cmbEmpresa.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 25);
            this.label6.TabIndex = 38;
            this.label6.Text = "Empresa:";
            // 
            // cmbTipo
            // 
            this.cmbTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTipo.BackColor = System.Drawing.Color.White;
            this.cmbTipo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(130, 137);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(337, 25);
            this.cmbTipo.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 25);
            this.label5.TabIndex = 36;
            this.label5.Text = "Tipo:";
            // 
            // cmbEstado
            // 
            this.cmbEstado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEstado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEstado.BackColor = System.Drawing.Color.White;
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(130, 99);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(337, 25);
            this.cmbEstado.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 25);
            this.label4.TabIndex = 34;
            this.label4.Text = "Estado:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.Color.White;
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(130, 60);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(337, 25);
            this.txtDescripcion.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 25);
            this.label2.TabIndex = 29;
            this.label2.Text = "Descripción: ";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.Image = global::Activos.Properties.Resources.cancel;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(683, 502);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(169, 76);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.Transparent;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnEditar.Image = global::Activos.Properties.Resources.file__1_;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.Location = new System.Drawing.Point(858, 502);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(170, 76);
            this.btnEditar.TabIndex = 5;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Visible = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnSet
            // 
            this.btnSet.BackColor = System.Drawing.Color.Transparent;
            this.btnSet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSet.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSet.Image = global::Activos.Properties.Resources.file;
            this.btnSet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSet.Location = new System.Drawing.Point(876, 502);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(152, 76);
            this.btnSet.TabIndex = 4;
            this.btnSet.Text = "Agregar";
            this.btnSet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSet.UseVisualStyleBackColor = false;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // gbUsuario
            // 
            this.gbUsuario.BackColor = System.Drawing.Color.Transparent;
            this.gbUsuario.Controls.Add(this.lbPuesto);
            this.gbUsuario.Controls.Add(this.lbDepartamentoUsuario);
            this.gbUsuario.Controls.Add(this.lbNombreUsuario);
            this.gbUsuario.Controls.Add(this.label11);
            this.gbUsuario.Controls.Add(this.label10);
            this.gbUsuario.Controls.Add(this.label9);
            this.gbUsuario.Controls.Add(this.cmbUsuario);
            this.gbUsuario.Controls.Add(this.label3);
            this.gbUsuario.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbUsuario.Location = new System.Drawing.Point(12, 376);
            this.gbUsuario.Name = "gbUsuario";
            this.gbUsuario.Size = new System.Drawing.Size(505, 173);
            this.gbUsuario.TabIndex = 2;
            this.gbUsuario.TabStop = false;
            this.gbUsuario.Text = "Usuario";
            // 
            // btnActualiza
            // 
            this.btnActualiza.BackColor = System.Drawing.Color.Transparent;
            this.btnActualiza.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnActualiza.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnActualiza.Image = global::Activos.Properties.Resources.file1;
            this.btnActualiza.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualiza.Location = new System.Drawing.Point(858, 502);
            this.btnActualiza.Name = "btnActualiza";
            this.btnActualiza.Size = new System.Drawing.Size(170, 76);
            this.btnActualiza.TabIndex = 15;
            this.btnActualiza.Text = "Actualizar";
            this.btnActualiza.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualiza.UseVisualStyleBackColor = false;
            this.btnActualiza.Visible = false;
            this.btnActualiza.Click += new System.EventHandler(this.btnActualiza_Click);
            // 
            // lbPuesto
            // 
            this.lbPuesto.AutoSize = true;
            this.lbPuesto.BackColor = System.Drawing.Color.Transparent;
            this.lbPuesto.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPuesto.Location = new System.Drawing.Point(222, 114);
            this.lbPuesto.Name = "lbPuesto";
            this.lbPuesto.Size = new System.Drawing.Size(69, 25);
            this.lbPuesto.TabIndex = 40;
            this.lbPuesto.Text = "Puesto";
            // 
            // lbDepartamentoUsuario
            // 
            this.lbDepartamentoUsuario.AutoSize = true;
            this.lbDepartamentoUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lbDepartamentoUsuario.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDepartamentoUsuario.Location = new System.Drawing.Point(222, 87);
            this.lbDepartamentoUsuario.Name = "lbDepartamentoUsuario";
            this.lbDepartamentoUsuario.Size = new System.Drawing.Size(133, 25);
            this.lbDepartamentoUsuario.TabIndex = 39;
            this.lbDepartamentoUsuario.Text = "Departamento";
            // 
            // lbNombreUsuario
            // 
            this.lbNombreUsuario.AutoSize = true;
            this.lbNombreUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lbNombreUsuario.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNombreUsuario.Location = new System.Drawing.Point(222, 61);
            this.lbNombreUsuario.Name = "lbNombreUsuario";
            this.lbNombreUsuario.Size = new System.Drawing.Size(81, 25);
            this.lbNombreUsuario.TabIndex = 38;
            this.lbNombreUsuario.Text = "Nombre";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(73, 114);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 25);
            this.label11.TabIndex = 37;
            this.label11.Text = "Puesto:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(73, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(143, 25);
            this.label10.TabIndex = 36;
            this.label10.Text = "Departamento:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(73, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 25);
            this.label9.TabIndex = 35;
            this.label9.Text = "Nombre:";
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbUsuario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUsuario.BackColor = System.Drawing.Color.White;
            this.cmbUsuario.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUsuario.FormattingEnabled = true;
            this.cmbUsuario.Location = new System.Drawing.Point(225, 32);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(193, 25);
            this.cmbUsuario.TabIndex = 0;
            this.cmbUsuario.SelectedIndexChanged += new System.EventHandler(this.cmbUsuario_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(73, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 25);
            this.label3.TabIndex = 34;
            this.label3.Text = "Usuario:";
            // 
            // gbSubGrupo
            // 
            this.gbSubGrupo.BackColor = System.Drawing.Color.Transparent;
            this.gbSubGrupo.Controls.Add(this.cmbSubGrupo);
            this.gbSubGrupo.Controls.Add(this.label17);
            this.gbSubGrupo.Controls.Add(this.cmbGrupo);
            this.gbSubGrupo.Controls.Add(this.label18);
            this.gbSubGrupo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSubGrupo.Location = new System.Drawing.Point(525, 78);
            this.gbSubGrupo.Name = "gbSubGrupo";
            this.gbSubGrupo.Size = new System.Drawing.Size(505, 88);
            this.gbSubGrupo.TabIndex = 1;
            this.gbSubGrupo.TabStop = false;
            this.gbSubGrupo.Text = "Sub Grupo";
            // 
            // cmbSubGrupo
            // 
            this.cmbSubGrupo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSubGrupo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSubGrupo.BackColor = System.Drawing.Color.White;
            this.cmbSubGrupo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSubGrupo.FormattingEnabled = true;
            this.cmbSubGrupo.Location = new System.Drawing.Point(249, 56);
            this.cmbSubGrupo.Name = "cmbSubGrupo";
            this.cmbSubGrupo.Size = new System.Drawing.Size(193, 25);
            this.cmbSubGrupo.TabIndex = 36;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(121, 52);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(102, 25);
            this.label17.TabIndex = 35;
            this.label17.Text = "SubGrupo:";
            // 
            // cmbGrupo
            // 
            this.cmbGrupo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGrupo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGrupo.BackColor = System.Drawing.Color.White;
            this.cmbGrupo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGrupo.FormattingEnabled = true;
            this.cmbGrupo.Location = new System.Drawing.Point(249, 17);
            this.cmbGrupo.Name = "cmbGrupo";
            this.cmbGrupo.Size = new System.Drawing.Size(193, 25);
            this.cmbGrupo.TabIndex = 0;
            this.cmbGrupo.SelectedIndexChanged += new System.EventHandler(this.cmbGrupo_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(121, 19);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(70, 25);
            this.label18.TabIndex = 34;
            this.label18.Text = "Grupo:";
            // 
            // gbValor
            // 
            this.gbValor.BackColor = System.Drawing.Color.White;
            this.gbValor.Controls.Add(this.nuValorLibros);
            this.gbValor.Controls.Add(this.label22);
            this.gbValor.Controls.Add(this.nuValorResidual);
            this.gbValor.Controls.Add(this.label21);
            this.gbValor.Controls.Add(this.nuDepreciacionAcumulada);
            this.gbValor.Controls.Add(this.label20);
            this.gbValor.Controls.Add(this.label19);
            this.gbValor.Controls.Add(this.nuPorcentaje);
            this.gbValor.Controls.Add(this.label16);
            this.gbValor.Controls.Add(this.dtDepreciacion);
            this.gbValor.Controls.Add(this.label15);
            this.gbValor.Controls.Add(this.txtFPC);
            this.gbValor.Controls.Add(this.label13);
            this.gbValor.Controls.Add(this.nuValor);
            this.gbValor.Controls.Add(this.label12);
            this.gbValor.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbValor.Location = new System.Drawing.Point(523, 172);
            this.gbValor.Name = "gbValor";
            this.gbValor.Size = new System.Drawing.Size(505, 324);
            this.gbValor.TabIndex = 3;
            this.gbValor.TabStop = false;
            this.gbValor.Text = "Valor";
            // 
            // nuValorLibros
            // 
            this.nuValorLibros.DecimalPlaces = 2;
            this.nuValorLibros.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuValorLibros.Location = new System.Drawing.Point(145, 287);
            this.nuValorLibros.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.nuValorLibros.Name = "nuValorLibros";
            this.nuValorLibros.Size = new System.Drawing.Size(299, 25);
            this.nuValorLibros.TabIndex = 6;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(7, 291);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(113, 25);
            this.label22.TabIndex = 60;
            this.label22.Text = "Valor libros:";
            // 
            // nuValorResidual
            // 
            this.nuValorResidual.DecimalPlaces = 2;
            this.nuValorResidual.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuValorResidual.Location = new System.Drawing.Point(146, 256);
            this.nuValorResidual.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.nuValorResidual.Name = "nuValorResidual";
            this.nuValorResidual.Size = new System.Drawing.Size(298, 25);
            this.nuValorResidual.TabIndex = 5;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(7, 260);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(133, 25);
            this.label21.TabIndex = 58;
            this.label21.Text = "Valor residual:";
            // 
            // nuDepreciacionAcumulada
            // 
            this.nuDepreciacionAcumulada.DecimalPlaces = 2;
            this.nuDepreciacionAcumulada.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuDepreciacionAcumulada.Location = new System.Drawing.Point(145, 208);
            this.nuDepreciacionAcumulada.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.nuDepreciacionAcumulada.Name = "nuDepreciacionAcumulada";
            this.nuDepreciacionAcumulada.Size = new System.Drawing.Size(299, 25);
            this.nuDepreciacionAcumulada.TabIndex = 4;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(6, 204);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(133, 55);
            this.label20.TabIndex = 56;
            this.label20.Text = "Depreciación acumulada:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(420, 156);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(24, 21);
            this.label19.TabIndex = 55;
            this.label19.Text = "%";
            // 
            // nuPorcentaje
            // 
            this.nuPorcentaje.DecimalPlaces = 2;
            this.nuPorcentaje.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuPorcentaje.Location = new System.Drawing.Point(145, 156);
            this.nuPorcentaje.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.nuPorcentaje.Name = "nuPorcentaje";
            this.nuPorcentaje.Size = new System.Drawing.Size(274, 25);
            this.nuPorcentaje.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(6, 145);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(166, 56);
            this.label16.TabIndex = 53;
            this.label16.Text = "Porcentaje de Depreciación:";
            // 
            // dtDepreciacion
            // 
            this.dtDepreciacion.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDepreciacion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDepreciacion.Location = new System.Drawing.Point(145, 103);
            this.dtDepreciacion.Name = "dtDepreciacion";
            this.dtDepreciacion.Size = new System.Drawing.Size(299, 25);
            this.dtDepreciacion.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(6, 91);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(133, 51);
            this.label15.TabIndex = 52;
            this.label15.Text = "Fecha de Depreciación:";
            // 
            // txtFPC
            // 
            this.txtFPC.BackColor = System.Drawing.Color.White;
            this.txtFPC.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFPC.Location = new System.Drawing.Point(145, 54);
            this.txtFPC.Name = "txtFPC";
            this.txtFPC.Size = new System.Drawing.Size(299, 25);
            this.txtFPC.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 54);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 25);
            this.label13.TabIndex = 52;
            this.label13.Text = "FPC: ";
            // 
            // nuValor
            // 
            this.nuValor.DecimalPlaces = 2;
            this.nuValor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuValor.Location = new System.Drawing.Point(145, 22);
            this.nuValor.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.nuValor.Name = "nuValor";
            this.nuValor.Size = new System.Drawing.Size(299, 25);
            this.nuValor.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 25);
            this.label12.TabIndex = 51;
            this.label12.Text = "Valor:";
            // 
            // Agregar_Activo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Activos.Properties.Resources.FONDO_4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1040, 632);
            this.Controls.Add(this.btnActualiza);
            this.Controls.Add(this.gbValor);
            this.Controls.Add(this.gbSubGrupo);
            this.Controls.Add(this.gbUsuario);
            this.Controls.Add(this.gbDetalleActivo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnSet);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Agregar_Activo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Activo";
            this.Load += new System.EventHandler(this.Agregar_Activo_Load);
            this.gbDetalleActivo.ResumeLayout(false);
            this.gbDetalleActivo.PerformLayout();
            this.gbUsuario.ResumeLayout(false);
            this.gbUsuario.PerformLayout();
            this.gbSubGrupo.ResumeLayout(false);
            this.gbSubGrupo.PerformLayout();
            this.gbValor.ResumeLayout(false);
            this.gbValor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuValorLibros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuValorResidual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuDepreciacionAcumulada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuPorcentaje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuValor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbDetalleActivo;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbEmpresa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.GroupBox gbUsuario;
        private System.Windows.Forms.Label lbPuesto;
        private System.Windows.Forms.Label lbDepartamentoUsuario;
        private System.Windows.Forms.Label lbNombreUsuario;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbSubGrupo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cmbGrupo;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox gbValor;
        private System.Windows.Forms.NumericUpDown nuValorLibros;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown nuValorResidual;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown nuDepreciacionAcumulada;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown nuPorcentaje;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtDepreciacion;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtFPC;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown nuValor;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbSubGrupo;
        private System.Windows.Forms.Button btnActualiza;
    }
}