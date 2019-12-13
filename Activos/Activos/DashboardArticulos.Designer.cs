namespace Activos
{
    partial class DashboardArticulos
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.excelArt = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.cmbArEmpresa = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbArDepto = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbArGrupo = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.cmbArTipo = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cmbArUser = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.cmbArEstado = new System.Windows.Forms.ComboBox();
            this.cmbArStatus = new System.Windows.Forms.ComboBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.button7 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(160, 25);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(601, 206);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button7);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.excelArt);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.chart1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(593, 173);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Articulos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(342, 40);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(121, 92);
            this.button5.TabIndex = 9;
            this.button5.Text = "Buscar";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // excelArt
            // 
            this.excelArt.BackgroundImage = global::Activos.Properties.Resources.Logo_excel;
            this.excelArt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.excelArt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.excelArt.Location = new System.Drawing.Point(466, 40);
            this.excelArt.Name = "excelArt";
            this.excelArt.Size = new System.Drawing.Size(121, 92);
            this.excelArt.TabIndex = 8;
            this.excelArt.UseVisualStyleBackColor = true;
            this.excelArt.Click += new System.EventHandler(this.excelArt_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(341, 7);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(246, 27);
            this.button3.TabIndex = 7;
            this.button3.Text = "Actualizar";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(252, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 20);
            this.label9.TabIndex = 6;
            this.label9.Text = "label9";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(158, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 20);
            this.label10.TabIndex = 5;
            this.label10.Text = "No revisados:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(239, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 40);
            this.label6.TabIndex = 4;
            this.label6.Text = "label6";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Revisados:";
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            this.chart1.Cursor = System.Windows.Forms.Cursors.Default;
            legend4.Name = "Legend1";
            this.chart1.Legends.Add(legend4);
            this.chart1.Location = new System.Drawing.Point(6, 6);
            this.chart1.Name = "chart1";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series4.LabelForeColor = System.Drawing.Color.Transparent;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(240, 161);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button6);
            this.tabPage2.Controls.Add(this.cmbArEmpresa);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.cmbArDepto);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.cmbArGrupo);
            this.tabPage2.Controls.Add(this.label22);
            this.tabPage2.Controls.Add(this.cmbArTipo);
            this.tabPage2.Controls.Add(this.label23);
            this.tabPage2.Controls.Add(this.cmbArUser);
            this.tabPage2.Controls.Add(this.label24);
            this.tabPage2.Controls.Add(this.label25);
            this.tabPage2.Controls.Add(this.label26);
            this.tabPage2.Controls.Add(this.cmbArEstado);
            this.tabPage2.Controls.Add(this.cmbArStatus);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPage2.Size = new System.Drawing.Size(593, 173);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Busqueda de Articulos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(8, 7);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(163, 52);
            this.button6.TabIndex = 28;
            this.button6.Text = "Limpiar Busqueda";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // cmbArEmpresa
            // 
            this.cmbArEmpresa.FormattingEnabled = true;
            this.cmbArEmpresa.Location = new System.Drawing.Point(203, 30);
            this.cmbArEmpresa.Name = "cmbArEmpresa";
            this.cmbArEmpresa.Size = new System.Drawing.Size(191, 28);
            this.cmbArEmpresa.TabIndex = 44;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(202, 63);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(106, 20);
            this.label19.TabIndex = 43;
            this.label19.Text = "Departamento";
            // 
            // cmbArDepto
            // 
            this.cmbArDepto.FormattingEnabled = true;
            this.cmbArDepto.Location = new System.Drawing.Point(203, 86);
            this.cmbArDepto.Name = "cmbArDepto";
            this.cmbArDepto.Size = new System.Drawing.Size(191, 28);
            this.cmbArDepto.TabIndex = 42;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(400, 6);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(50, 20);
            this.label20.TabIndex = 41;
            this.label20.Text = "Grupo";
            // 
            // cmbArGrupo
            // 
            this.cmbArGrupo.FormattingEnabled = true;
            this.cmbArGrupo.Location = new System.Drawing.Point(400, 29);
            this.cmbArGrupo.Name = "cmbArGrupo";
            this.cmbArGrupo.Size = new System.Drawing.Size(191, 28);
            this.cmbArGrupo.TabIndex = 40;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(400, 59);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(39, 20);
            this.label22.TabIndex = 37;
            this.label22.Text = "Tipo";
            // 
            // cmbArTipo
            // 
            this.cmbArTipo.FormattingEnabled = true;
            this.cmbArTipo.Location = new System.Drawing.Point(399, 86);
            this.cmbArTipo.Name = "cmbArTipo";
            this.cmbArTipo.Size = new System.Drawing.Size(191, 28);
            this.cmbArTipo.TabIndex = 36;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(202, 117);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(59, 20);
            this.label23.TabIndex = 35;
            this.label23.Text = "Usuario";
            // 
            // cmbArUser
            // 
            this.cmbArUser.FormattingEnabled = true;
            this.cmbArUser.Location = new System.Drawing.Point(203, 138);
            this.cmbArUser.Name = "cmbArUser";
            this.cmbArUser.Size = new System.Drawing.Size(191, 28);
            this.cmbArUser.TabIndex = 34;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(199, 6);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(66, 20);
            this.label24.TabIndex = 33;
            this.label24.Text = "Empresa";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(4, 64);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(54, 20);
            this.label25.TabIndex = 32;
            this.label25.Text = "Estado";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(4, 116);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(95, 20);
            this.label26.TabIndex = 31;
            this.label26.Text = "Estado Fisico";
            // 
            // cmbArEstado
            // 
            this.cmbArEstado.FormattingEnabled = true;
            this.cmbArEstado.Location = new System.Drawing.Point(8, 86);
            this.cmbArEstado.Name = "cmbArEstado";
            this.cmbArEstado.Size = new System.Drawing.Size(191, 28);
            this.cmbArEstado.TabIndex = 30;
            // 
            // cmbArStatus
            // 
            this.cmbArStatus.FormattingEnabled = true;
            this.cmbArStatus.Location = new System.Drawing.Point(8, 138);
            this.cmbArStatus.Name = "cmbArStatus";
            this.cmbArStatus.Size = new System.Drawing.Size(191, 28);
            this.cmbArStatus.TabIndex = 29;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 224);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(601, 355);
            this.dataGridView2.TabIndex = 5;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(340, 138);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(247, 29);
            this.button7.TabIndex = 14;
            this.button7.Text = "Escaner de código";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // DashboardArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 603);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dataGridView2);
            this.Name = "DashboardArticulos";
            this.Text = "DashboardArticulos";
            this.Load += new System.EventHandler(this.DashboardArticulos_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button excelArt;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ComboBox cmbArEmpresa;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbArDepto;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbArGrupo;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cmbArTipo;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cmbArUser;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox cmbArEstado;
        private System.Windows.Forms.ComboBox cmbArStatus;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button7;
    }
}