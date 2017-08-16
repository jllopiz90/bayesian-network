namespace Red_Bayesiana
{
    partial class App
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridconditionalprob = new System.Windows.Forms.DataGridView();
            this.dataGridconditionalevidence = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbtest = new System.Windows.Forms.Label();
            this.bttontestup = new System.Windows.Forms.Button();
            this.bttontestremove = new System.Windows.Forms.Button();
            this.bttontestdown = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.flowChartViewer1 = new FlowChartDesigner.FlowChartViewer();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.datagridnewevidence = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bttonevidencedown = new System.Windows.Forms.Button();
            this.lbevidenceName = new System.Windows.Forms.Label();
            this.bttonevidenceup = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.bttonagregarevidence = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.statesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.edittoolstrip = new System.Windows.Forms.ToolStripMenuItem();
            this.opentoolstrip = new System.Windows.Forms.ToolStripMenuItem();
            this.guardartoolstrip = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inferenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.computarProbabilidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bayesianNodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.numeroDeParalelismoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridconditionalprob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridconditionalevidence)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridnewevidence)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statesBindingSource1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bayesianNodeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertyGrid1);
            this.splitContainer1.Size = new System.Drawing.Size(693, 332);
            this.splitContainer1.SplitterDistance = 523;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(519, 328);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer2);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(511, 302);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Modo Inferencia";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridconditionalevidence);
            this.splitContainer2.Size = new System.Drawing.Size(505, 220);
            this.splitContainer2.SplitterDistance = 138;
            this.splitContainer2.TabIndex = 11;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridconditionalprob);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(505, 138);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            // 
            // dataGridconditionalprob
            // 
            this.dataGridconditionalprob.AllowUserToAddRows = false;
            this.dataGridconditionalprob.AllowUserToDeleteRows = false;
            this.dataGridconditionalprob.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridconditionalprob.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridconditionalprob.Location = new System.Drawing.Point(3, 16);
            this.dataGridconditionalprob.Name = "dataGridconditionalprob";
            this.dataGridconditionalprob.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridconditionalprob.Size = new System.Drawing.Size(499, 119);
            this.dataGridconditionalprob.TabIndex = 0;
            // 
            // dataGridconditionalevidence
            // 
            this.dataGridconditionalevidence.AllowUserToAddRows = false;
            this.dataGridconditionalevidence.AllowUserToOrderColumns = true;
            this.dataGridconditionalevidence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridconditionalevidence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridconditionalevidence.Location = new System.Drawing.Point(0, 0);
            this.dataGridconditionalevidence.Name = "dataGridconditionalevidence";
            this.dataGridconditionalevidence.ReadOnly = true;
            this.dataGridconditionalevidence.Size = new System.Drawing.Size(505, 78);
            this.dataGridconditionalevidence.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbtest);
            this.groupBox2.Controls.Add(this.bttontestup);
            this.groupBox2.Controls.Add(this.bttontestremove);
            this.groupBox2.Controls.Add(this.bttontestdown);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(3, 223);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(505, 76);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // lbtest
            // 
            this.lbtest.AutoSize = true;
            this.lbtest.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtest.Location = new System.Drawing.Point(234, 26);
            this.lbtest.Name = "lbtest";
            this.lbtest.Size = new System.Drawing.Size(87, 25);
            this.lbtest.TabIndex = 9;
            this.lbtest.Text = "No Test";
            // 
            // bttontestup
            // 
            this.bttontestup.BackgroundImage = global::Red_Bayesiana.Properties.Resources.steering_arrow_right_01;
            this.bttontestup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bttontestup.Location = new System.Drawing.Point(75, 26);
            this.bttontestup.Name = "bttontestup";
            this.bttontestup.Size = new System.Drawing.Size(55, 35);
            this.bttontestup.TabIndex = 6;
            this.bttontestup.UseVisualStyleBackColor = true;
            this.bttontestup.Click += new System.EventHandler(this.bttontestup_Click);
            // 
            // bttontestremove
            // 
            this.bttontestremove.Location = new System.Drawing.Point(136, 28);
            this.bttontestremove.Name = "bttontestremove";
            this.bttontestremove.Size = new System.Drawing.Size(54, 31);
            this.bttontestremove.TabIndex = 8;
            this.bttontestremove.Text = "Eliminar";
            this.bttontestremove.UseVisualStyleBackColor = true;
            this.bttontestremove.Click += new System.EventHandler(this.bttontestremove_Click);
            // 
            // bttontestdown
            // 
            this.bttontestdown.BackgroundImage = global::Red_Bayesiana.Properties.Resources.steering_arrow_left_01;
            this.bttontestdown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bttontestdown.Location = new System.Drawing.Point(14, 26);
            this.bttontestdown.Name = "bttontestdown";
            this.bttontestdown.Size = new System.Drawing.Size(55, 35);
            this.bttontestdown.TabIndex = 5;
            this.bttontestdown.UseVisualStyleBackColor = true;
            this.bttontestdown.Click += new System.EventHandler(this.bttontestdown_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.flowChartViewer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(511, 302);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Modo Edición";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // flowChartViewer1
            // 
            this.flowChartViewer1.AutoScroll = true;
            this.flowChartViewer1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.flowChartViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowChartViewer1.Location = new System.Drawing.Point(3, 3);
            this.flowChartViewer1.Name = "flowChartViewer1";
            this.flowChartViewer1.SelectedItem = null;
            this.flowChartViewer1.Size = new System.Drawing.Size(505, 296);
            this.flowChartViewer1.TabIndex = 1;
            this.flowChartViewer1.Text = "flowChartViewer1";
            this.flowChartViewer1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.flowChartViewer1_KeyPress);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Transparent;
            this.tabPage3.Controls.Add(this.datagridnewevidence);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(511, 302);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Insertar Evidencia";
            // 
            // datagridnewevidence
            // 
            this.datagridnewevidence.AllowUserToAddRows = false;
            this.datagridnewevidence.AllowUserToDeleteRows = false;
            this.datagridnewevidence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridnewevidence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagridnewevidence.Location = new System.Drawing.Point(3, 3);
            this.datagridnewevidence.Name = "datagridnewevidence";
            this.datagridnewevidence.Size = new System.Drawing.Size(505, 190);
            this.datagridnewevidence.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.bttonevidencedown);
            this.groupBox1.Controls.Add(this.lbevidenceName);
            this.groupBox1.Controls.Add(this.bttonevidenceup);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.bttonagregarevidence);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(3, 193);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(505, 106);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(210, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 32);
            this.label1.TabIndex = 7;
            this.label1.Text = "Seleccione el estado de \r\ncada variable.\r\n";
            // 
            // bttonevidencedown
            // 
            this.bttonevidencedown.BackgroundImage = global::Red_Bayesiana.Properties.Resources.steering_arrow_left_01;
            this.bttonevidencedown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bttonevidencedown.Location = new System.Drawing.Point(17, 7);
            this.bttonevidencedown.Name = "bttonevidencedown";
            this.bttonevidencedown.Size = new System.Drawing.Size(80, 40);
            this.bttonevidencedown.TabIndex = 1;
            this.bttonevidencedown.UseVisualStyleBackColor = true;
            this.bttonevidencedown.Click += new System.EventHandler(this.bttonevidencedown_Click);
            // 
            // lbevidenceName
            // 
            this.lbevidenceName.AutoSize = true;
            this.lbevidenceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbevidenceName.Location = new System.Drawing.Point(208, 65);
            this.lbevidenceName.Name = "lbevidenceName";
            this.lbevidenceName.Size = new System.Drawing.Size(132, 25);
            this.lbevidenceName.TabIndex = 5;
            this.lbevidenceName.Text = "No evidence";
            // 
            // bttonevidenceup
            // 
            this.bttonevidenceup.BackgroundImage = global::Red_Bayesiana.Properties.Resources.steering_arrow_right_01;
            this.bttonevidenceup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bttonevidenceup.Location = new System.Drawing.Point(113, 7);
            this.bttonevidenceup.Name = "bttonevidenceup";
            this.bttonevidenceup.Size = new System.Drawing.Size(80, 40);
            this.bttonevidenceup.TabIndex = 2;
            this.bttonevidenceup.UseVisualStyleBackColor = true;
            this.bttonevidenceup.Click += new System.EventHandler(this.bttonevidenceup_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(17, 60);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 40);
            this.button3.TabIndex = 4;
            this.button3.Text = "Eliminar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // bttonagregarevidence
            // 
            this.bttonagregarevidence.Location = new System.Drawing.Point(113, 60);
            this.bttonagregarevidence.Name = "bttonagregarevidence";
            this.bttonagregarevidence.Size = new System.Drawing.Size(80, 40);
            this.bttonagregarevidence.TabIndex = 3;
            this.bttonagregarevidence.Text = "Agregar";
            this.bttonagregarevidence.UseVisualStyleBackColor = true;
            this.bttonagregarevidence.Click += new System.EventHandler(this.bttonagregarevidence_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(519, 328);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(162, 328);
            this.propertyGrid1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.edittoolstrip,
            this.inferenciaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(693, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // edittoolstrip
            // 
            this.edittoolstrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opentoolstrip,
            this.guardartoolstrip,
            this.toolStripMenuItem1,
            this.salirToolStripMenuItem});
            this.edittoolstrip.Name = "edittoolstrip";
            this.edittoolstrip.Size = new System.Drawing.Size(58, 20);
            this.edittoolstrip.Text = "Edicion";
            this.edittoolstrip.ToolTipText = "Opciones para editar una red bayesiana.\r\nPermite crear, abrir y utilizar una red " +
                "bayesiana.\r\n";
            // 
            // opentoolstrip
            // 
            this.opentoolstrip.Name = "opentoolstrip";
            this.opentoolstrip.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.opentoolstrip.Size = new System.Drawing.Size(180, 22);
            this.opentoolstrip.Text = "Abrir";
            this.opentoolstrip.ToolTipText = "Abre un archivo de una red bayesiana";
            this.opentoolstrip.Click += new System.EventHandler(this.opentoolstrip_Click);
            // 
            // guardartoolstrip
            // 
            this.guardartoolstrip.Name = "guardartoolstrip";
            this.guardartoolstrip.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.guardartoolstrip.Size = new System.Drawing.Size(180, 22);
            this.guardartoolstrip.Text = "Guardar";
            this.guardartoolstrip.ToolTipText = "Guarda a disco los datos de la red bayesiana.";
            this.guardartoolstrip.Click += new System.EventHandler(this.informacionGraficaToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // inferenciaToolStripMenuItem
            // 
            this.inferenciaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.computarProbabilidadesToolStripMenuItem});
            this.inferenciaToolStripMenuItem.Name = "inferenciaToolStripMenuItem";
            this.inferenciaToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.inferenciaToolStripMenuItem.Text = "Inferencia";
            this.inferenciaToolStripMenuItem.ToolTipText = "Realiza las acciones de inferencia en la red creada .";
            // 
            // computarProbabilidadesToolStripMenuItem
            // 
            this.computarProbabilidadesToolStripMenuItem.Name = "computarProbabilidadesToolStripMenuItem";
            this.computarProbabilidadesToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.computarProbabilidadesToolStripMenuItem.Text = "Computar Probabilidades";
            this.computarProbabilidadesToolStripMenuItem.Click += new System.EventHandler(this.computarProbabilidadesToolStripMenuItem_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // bayesianNodeBindingSource
            // 
            this.bayesianNodeBindingSource.DataSource = typeof(RB_Message_Transfer.BayesianNode);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.numeroDeParalelismoToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(204, 22);
            this.toolStripMenuItem1.Text = "Opciones de paralelismo";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // numeroDeParalelismoToolStripMenuItem
            // 
            this.numeroDeParalelismoToolStripMenuItem.Name = "numeroDeParalelismoToolStripMenuItem";
            this.numeroDeParalelismoToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.numeroDeParalelismoToolStripMenuItem.Text = "Numero de paralelismo";
            this.numeroDeParalelismoToolStripMenuItem.Click += new System.EventHandler(this.numeroDeParalelismoToolStripMenuItem_Click);
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 356);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "App";
            this.Text = "Red Bayesiana";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridconditionalprob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridconditionalevidence)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridnewevidence)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statesBindingSource1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bayesianNodeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem edittoolstrip;
        private System.Windows.Forms.ToolStripMenuItem opentoolstrip;
        private System.Windows.Forms.ToolStripMenuItem guardartoolstrip;
        private System.Windows.Forms.ToolStripMenuItem inferenciaToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem computarProbabilidadesToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.BindingSource bayesianNodeBindingSource;
        private System.Windows.Forms.BindingSource statesBindingSource1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bttontestup;
        private System.Windows.Forms.Button bttontestremove;
        private System.Windows.Forms.Button bttontestdown;
        private System.Windows.Forms.TabPage tabPage1;
        private FlowChartDesigner.FlowChartViewer flowChartViewer1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bttonevidencedown;
        private System.Windows.Forms.Label lbevidenceName;
        private System.Windows.Forms.Button bttonevidenceup;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button bttonagregarevidence;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridconditionalprob;
        private System.Windows.Forms.DataGridView dataGridconditionalevidence;
        private System.Windows.Forms.Label lbtest;
        private System.Windows.Forms.DataGridView datagridnewevidence;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem numeroDeParalelismoToolStripMenuItem;
    }
}

