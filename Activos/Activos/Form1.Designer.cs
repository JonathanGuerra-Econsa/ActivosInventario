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
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDepartamento
            // 
            this.btnDepartamento.BackColor = System.Drawing.Color.Transparent;
            this.btnDepartamento.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDepartamento.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDepartamento.Image = global::Activos.Properties.Resources.cashier;
            this.btnDepartamento.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDepartamento.Location = new System.Drawing.Point(71, 127);
            this.btnDepartamento.Name = "btnDepartamento";
            this.btnDepartamento.Size = new System.Drawing.Size(133, 157);
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
            this.btnUsuario.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuario.Image = global::Activos.Properties.Resources.man__1_;
            this.btnUsuario.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUsuario.Location = new System.Drawing.Point(228, 127);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(133, 157);
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
            this.btnCategoria.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategoria.Image = global::Activos.Properties.Resources.backend;
            this.btnCategoria.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCategoria.Location = new System.Drawing.Point(387, 127);
            this.btnCategoria.Name = "btnCategoria";
            this.btnCategoria.Size = new System.Drawing.Size(133, 157);
            this.btnCategoria.TabIndex = 2;
            this.btnCategoria.TabStop = false;
            this.btnCategoria.Text = "Categoría";
            this.btnCategoria.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCategoria.UseVisualStyleBackColor = false;
            this.btnCategoria.Click += new System.EventHandler(this.btnCategoria_Click);
            // 
            // btnActivo
            // 
            this.btnActivo.BackColor = System.Drawing.Color.Transparent;
            this.btnActivo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnActivo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivo.Image = global::Activos.Properties.Resources.article;
            this.btnActivo.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnActivo.Location = new System.Drawing.Point(543, 127);
            this.btnActivo.Name = "btnActivo";
            this.btnActivo.Size = new System.Drawing.Size(133, 157);
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
            this.btnArticulo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArticulo.Image = global::Activos.Properties.Resources.attachment;
            this.btnArticulo.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnArticulo.Location = new System.Drawing.Point(702, 127);
            this.btnArticulo.Name = "btnArticulo";
            this.btnArticulo.Size = new System.Drawing.Size(133, 157);
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
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(382, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "Menú Principal";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(543, 279);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 42);
            this.button1.TabIndex = 6;
            this.button1.Text = "Activos Busqueda";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Activos.Properties.Resources.fondo2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(904, 447);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnArticulo);
            this.Controls.Add(this.btnActivo);
            this.Controls.Add(this.btnCategoria);
            this.Controls.Add(this.btnUsuario);
            this.Controls.Add(this.btnDepartamento);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú Principal";
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
        private System.Windows.Forms.Button button1;
    }
}

