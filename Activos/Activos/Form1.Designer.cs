namespace Activos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnDepartamento = new System.Windows.Forms.Button();
            this.btnUsuario = new System.Windows.Forms.Button();
            this.btnCategoria = new System.Windows.Forms.Button();
            this.btnActivo = new System.Windows.Forms.Button();
            this.btnArticulo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.btnInventario = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDepartamento
            // 
            this.btnDepartamento.BackColor = System.Drawing.Color.Transparent;
            this.btnDepartamento.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDepartamento.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDepartamento.Image = global::Activos.Properties.Resources.cashier;
            this.btnDepartamento.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDepartamento.Location = new System.Drawing.Point(23, 107);
            this.btnDepartamento.Name = "btnDepartamento";
            this.btnDepartamento.Size = new System.Drawing.Size(150, 190);
            this.btnDepartamento.TabIndex = 0;
            this.btnDepartamento.TabStop = false;
            this.btnDepartamento.Text = "Departamento";
            this.btnDepartamento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDepartamento.UseVisualStyleBackColor = false;
            this.btnDepartamento.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUsuario
            // 
            this.btnUsuario.BackColor = System.Drawing.Color.Transparent;
            this.btnUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUsuario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuario.Image = global::Activos.Properties.Resources.man__1_;
            this.btnUsuario.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUsuario.Location = new System.Drawing.Point(179, 107);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(150, 190);
            this.btnUsuario.TabIndex = 1;
            this.btnUsuario.TabStop = false;
            this.btnUsuario.Text = "Usuario";
            this.btnUsuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUsuario.UseVisualStyleBackColor = false;
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            // 
            // btnCategoria
            // 
            this.btnCategoria.BackColor = System.Drawing.Color.Transparent;
            this.btnCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCategoria.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategoria.Image = global::Activos.Properties.Resources.backend;
            this.btnCategoria.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCategoria.Location = new System.Drawing.Point(335, 107);
            this.btnCategoria.Name = "btnCategoria";
            this.btnCategoria.Size = new System.Drawing.Size(150, 190);
            this.btnCategoria.TabIndex = 2;
            this.btnCategoria.TabStop = false;
            this.btnCategoria.Text = "Tipo";
            this.btnCategoria.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCategoria.UseVisualStyleBackColor = false;
            this.btnCategoria.Click += new System.EventHandler(this.btnCategoria_Click);
            // 
            // btnActivo
            // 
            this.btnActivo.BackColor = System.Drawing.Color.Transparent;
            this.btnActivo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnActivo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivo.Image = global::Activos.Properties.Resources.article;
            this.btnActivo.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnActivo.Location = new System.Drawing.Point(491, 107);
            this.btnActivo.Name = "btnActivo";
            this.btnActivo.Size = new System.Drawing.Size(150, 190);
            this.btnActivo.TabIndex = 3;
            this.btnActivo.TabStop = false;
            this.btnActivo.Text = "Activo";
            this.btnActivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnActivo.UseVisualStyleBackColor = false;
            this.btnActivo.Click += new System.EventHandler(this.btnActivo_Click);
            // 
            // btnArticulo
            // 
            this.btnArticulo.BackColor = System.Drawing.Color.Transparent;
            this.btnArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnArticulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArticulo.Image = global::Activos.Properties.Resources.attachment;
            this.btnArticulo.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnArticulo.Location = new System.Drawing.Point(647, 107);
            this.btnArticulo.Name = "btnArticulo";
            this.btnArticulo.Size = new System.Drawing.Size(150, 190);
            this.btnArticulo.TabIndex = 4;
            this.btnArticulo.TabStop = false;
            this.btnArticulo.Text = "Articulo";
            this.btnArticulo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnArticulo.UseVisualStyleBackColor = false;
            this.btnArticulo.Click += new System.EventHandler(this.btnArticulo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(395, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 45);
            this.label1.TabIndex = 5;
            this.label1.Text = "Menú Principal";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::Activos.Properties.Resources.Econsa;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(819, 328);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(158, 124);
            this.panel1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Help;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1, 431);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(269, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "Departamento de Informática 2020";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(647, 303);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 44);
            this.button2.TabIndex = 9;
            this.button2.Text = "Articulo Busqueda";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            this.labelName.Cursor = System.Windows.Forms.Cursors.Help;
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.Color.Black;
            this.labelName.Location = new System.Drawing.Point(1, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(93, 21);
            this.labelName.TabIndex = 10;
            this.labelName.Text = "Bienvenido";
            // 
            // btnInventario
            // 
            this.btnInventario.BackColor = System.Drawing.Color.Transparent;
            this.btnInventario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInventario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventario.Image = global::Activos.Properties.Resources.archive;
            this.btnInventario.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnInventario.Location = new System.Drawing.Point(803, 107);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(150, 190);
            this.btnInventario.TabIndex = 11;
            this.btnInventario.TabStop = false;
            this.btnInventario.Text = "Inventario";
            this.btnInventario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnInventario.UseVisualStyleBackColor = false;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Activos.Properties.Resources.fondo2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(980, 457);
            this.Controls.Add(this.btnInventario);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnArticulo);
            this.Controls.Add(this.btnActivo);
            this.Controls.Add(this.btnCategoria);
            this.Controls.Add(this.btnUsuario);
            this.Controls.Add(this.btnDepartamento);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(996, 496);
            this.MinimumSize = new System.Drawing.Size(996, 496);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú Principal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDepartamento;
        private System.Windows.Forms.Button btnUsuario;
        private System.Windows.Forms.Button btnCategoria;
        private System.Windows.Forms.Button btnActivo;
        private System.Windows.Forms.Button btnArticulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button btnInventario;
    }
}

