namespace Activos
{
    partial class Aperturar_Inventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Aperturar_Inventario));
            this.label1 = new System.Windows.Forms.Label();
            this.btnActivo = new System.Windows.Forms.Button();
            this.btnArticulo = new System.Windows.Forms.Button();
            this.btnAmbos = new System.Windows.Forms.Button();
            this.lbInventario = new System.Windows.Forms.Label();
            this.txtInventario = new System.Windows.Forms.TextBox();
            this.btnAperturar = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnAperturarInv = new System.Windows.Forms.Button();
            this.btnBuscarInv = new System.Windows.Forms.Button();
            this.lbBusqueda = new System.Windows.Forms.Label();
            this.cmbInventario = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(247, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inventario";
            // 
            // btnActivo
            // 
            this.btnActivo.BackColor = System.Drawing.Color.Transparent;
            this.btnActivo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnActivo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivo.Image = global::Activos.Properties.Resources.article1;
            this.btnActivo.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnActivo.Location = new System.Drawing.Point(41, 112);
            this.btnActivo.Name = "btnActivo";
            this.btnActivo.Size = new System.Drawing.Size(150, 190);
            this.btnActivo.TabIndex = 3;
            this.btnActivo.TabStop = false;
            this.btnActivo.Text = "Activo";
            this.btnActivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnActivo.UseVisualStyleBackColor = false;
            this.btnActivo.Visible = false;
            this.btnActivo.Click += new System.EventHandler(this.btnActivo_Click);
            // 
            // btnArticulo
            // 
            this.btnArticulo.BackColor = System.Drawing.Color.Transparent;
            this.btnArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnArticulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArticulo.Image = global::Activos.Properties.Resources.stapler__1_;
            this.btnArticulo.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnArticulo.Location = new System.Drawing.Point(238, 112);
            this.btnArticulo.Name = "btnArticulo";
            this.btnArticulo.Size = new System.Drawing.Size(150, 190);
            this.btnArticulo.TabIndex = 4;
            this.btnArticulo.TabStop = false;
            this.btnArticulo.Text = "Artículo";
            this.btnArticulo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnArticulo.UseVisualStyleBackColor = false;
            this.btnArticulo.Visible = false;
            this.btnArticulo.Click += new System.EventHandler(this.btnArticulo_Click);
            // 
            // btnAmbos
            // 
            this.btnAmbos.BackColor = System.Drawing.Color.Transparent;
            this.btnAmbos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAmbos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAmbos.Image = global::Activos.Properties.Resources.backend;
            this.btnAmbos.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAmbos.Location = new System.Drawing.Point(439, 112);
            this.btnAmbos.Name = "btnAmbos";
            this.btnAmbos.Size = new System.Drawing.Size(150, 190);
            this.btnAmbos.TabIndex = 5;
            this.btnAmbos.TabStop = false;
            this.btnAmbos.Text = "Ambos";
            this.btnAmbos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAmbos.UseVisualStyleBackColor = false;
            this.btnAmbos.Visible = false;
            this.btnAmbos.Click += new System.EventHandler(this.btnAmbos_Click);
            // 
            // lbInventario
            // 
            this.lbInventario.AutoSize = true;
            this.lbInventario.BackColor = System.Drawing.Color.Transparent;
            this.lbInventario.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInventario.Location = new System.Drawing.Point(205, 305);
            this.lbInventario.Name = "lbInventario";
            this.lbInventario.Size = new System.Drawing.Size(206, 25);
            this.lbInventario.TabIndex = 6;
            this.lbInventario.Text = "Nombre del inventario";
            this.lbInventario.Visible = false;
            // 
            // txtInventario
            // 
            this.txtInventario.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInventario.Location = new System.Drawing.Point(209, 333);
            this.txtInventario.Name = "txtInventario";
            this.txtInventario.Size = new System.Drawing.Size(202, 29);
            this.txtInventario.TabIndex = 7;
            this.txtInventario.Visible = false;
            this.txtInventario.TextChanged += new System.EventHandler(this.txtInventario_TextChanged);
            // 
            // btnAperturar
            // 
            this.btnAperturar.BackColor = System.Drawing.Color.Transparent;
            this.btnAperturar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAperturar.Enabled = false;
            this.btnAperturar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAperturar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAperturar.Location = new System.Drawing.Point(238, 368);
            this.btnAperturar.Name = "btnAperturar";
            this.btnAperturar.Size = new System.Drawing.Size(142, 49);
            this.btnAperturar.TabIndex = 8;
            this.btnAperturar.Text = "Aperturar";
            this.btnAperturar.UseVisualStyleBackColor = false;
            this.btnAperturar.Visible = false;
            this.btnAperturar.Click += new System.EventHandler(this.btnAperturar_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Image = global::Activos.Properties.Resources.left_arrow_in_circular_button_black_symbol;
            this.btnBack.Location = new System.Drawing.Point(12, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(33, 33);
            this.btnBack.TabIndex = 9;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnAperturarInv
            // 
            this.btnAperturarInv.BackColor = System.Drawing.Color.Transparent;
            this.btnAperturarInv.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAperturarInv.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAperturarInv.Image = global::Activos.Properties.Resources.box__1_;
            this.btnAperturarInv.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAperturarInv.Location = new System.Drawing.Point(151, 112);
            this.btnAperturarInv.Name = "btnAperturarInv";
            this.btnAperturarInv.Size = new System.Drawing.Size(150, 190);
            this.btnAperturarInv.TabIndex = 10;
            this.btnAperturarInv.TabStop = false;
            this.btnAperturarInv.Text = "Aperturar Inventario";
            this.btnAperturarInv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAperturarInv.UseVisualStyleBackColor = false;
            this.btnAperturarInv.Click += new System.EventHandler(this.btnAperturarInv_Click);
            // 
            // btnBuscarInv
            // 
            this.btnBuscarInv.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscarInv.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscarInv.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarInv.Image = global::Activos.Properties.Resources.loupe__2_;
            this.btnBuscarInv.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscarInv.Location = new System.Drawing.Point(321, 112);
            this.btnBuscarInv.Name = "btnBuscarInv";
            this.btnBuscarInv.Size = new System.Drawing.Size(150, 190);
            this.btnBuscarInv.TabIndex = 11;
            this.btnBuscarInv.TabStop = false;
            this.btnBuscarInv.Text = "Buscar Inventario";
            this.btnBuscarInv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBuscarInv.UseVisualStyleBackColor = false;
            this.btnBuscarInv.Click += new System.EventHandler(this.btnBuscarInv_Click);
            // 
            // lbBusqueda
            // 
            this.lbBusqueda.AutoSize = true;
            this.lbBusqueda.BackColor = System.Drawing.Color.Transparent;
            this.lbBusqueda.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBusqueda.Location = new System.Drawing.Point(204, 305);
            this.lbBusqueda.Name = "lbBusqueda";
            this.lbBusqueda.Size = new System.Drawing.Size(222, 25);
            this.lbBusqueda.TabIndex = 12;
            this.lbBusqueda.Text = "Seleccione un Inventario";
            this.lbBusqueda.Visible = false;
            // 
            // cmbInventario
            // 
            this.cmbInventario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbInventario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbInventario.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.cmbInventario.FormattingEnabled = true;
            this.cmbInventario.Location = new System.Drawing.Point(209, 333);
            this.cmbInventario.Name = "cmbInventario";
            this.cmbInventario.Size = new System.Drawing.Size(202, 29);
            this.cmbInventario.TabIndex = 13;
            this.cmbInventario.Visible = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(269, 368);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(142, 49);
            this.btnBuscar.TabIndex = 14;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Visible = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // Aperturar_Inventario
            // 
            this.AcceptButton = this.btnAperturar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Activos.Properties.Resources.fondo2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(628, 470);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cmbInventario);
            this.Controls.Add(this.lbBusqueda);
            this.Controls.Add(this.btnBuscarInv);
            this.Controls.Add(this.btnAperturarInv);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAperturar);
            this.Controls.Add(this.txtInventario);
            this.Controls.Add(this.lbInventario);
            this.Controls.Add(this.btnAmbos);
            this.Controls.Add(this.btnArticulo);
            this.Controls.Add(this.btnActivo);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Aperturar_Inventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aperturar Inventario";
            this.Load += new System.EventHandler(this.Aperturar_Inventario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnActivo;
        private System.Windows.Forms.Button btnArticulo;
        private System.Windows.Forms.Button btnAmbos;
        private System.Windows.Forms.Label lbInventario;
        private System.Windows.Forms.TextBox txtInventario;
        private System.Windows.Forms.Button btnAperturar;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnAperturarInv;
        private System.Windows.Forms.Button btnBuscarInv;
        private System.Windows.Forms.Label lbBusqueda;
        private System.Windows.Forms.ComboBox cmbInventario;
        private System.Windows.Forms.Button btnBuscar;
    }
}