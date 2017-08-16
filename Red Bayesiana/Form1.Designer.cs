namespace Red_Bayesiana
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowChartViewer1 = new FlowChartDesigner.FlowChartViewer();
            this.toolstripfooter = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.edittoolstrip = new System.Windows.Forms.ToolStripMenuItem();
            this.newtoolstrip = new System.Windows.Forms.ToolStripMenuItem();
            this.opentoolstrip = new System.Windows.Forms.ToolStripMenuItem();
            this.guardartoolstrip = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarNodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inferenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowChartViewer1.SuspendLayout();
            this.toolstripfooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.flowChartViewer1);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertyGrid1);
            this.splitContainer1.Size = new System.Drawing.Size(693, 332);
            this.splitContainer1.SplitterDistance = 534;
            this.splitContainer1.TabIndex = 0;
            // 
            // flowChartViewer1
            // 
            this.flowChartViewer1.AutoScroll = true;
            this.flowChartViewer1.Controls.Add(this.toolstripfooter);
            this.flowChartViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowChartViewer1.Location = new System.Drawing.Point(0, 0);
            this.flowChartViewer1.Name = "flowChartViewer1";
            this.flowChartViewer1.SelectedItem = null;
            this.flowChartViewer1.Size = new System.Drawing.Size(530, 328);
            this.flowChartViewer1.TabIndex = 1;
            this.flowChartViewer1.Text = "flowChartViewer1";
            // 
            // toolstripfooter
            // 
            this.toolstripfooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolstripfooter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.toolStripSeparator1,
            this.toolStripButton1});
            this.toolstripfooter.Location = new System.Drawing.Point(0, 303);
            this.toolstripfooter.Name = "toolstripfooter";
            this.toolstripfooter.Size = new System.Drawing.Size(530, 25);
            this.toolstripfooter.TabIndex = 0;
            this.toolstripfooter.Text = "toolStrip1";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(530, 328);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(151, 328);
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
            this.newtoolstrip,
            this.opentoolstrip,
            this.guardartoolstrip,
            this.agregarNodoToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.edittoolstrip.Name = "edittoolstrip";
            this.edittoolstrip.Size = new System.Drawing.Size(58, 20);
            this.edittoolstrip.Text = "Edicion";
            this.edittoolstrip.ToolTipText = "Opciones para editar una red bayesiana.\r\nPermite crear, abrir y utilizar una red " +
                "bayesiana.\r\n";
            // 
            // newtoolstrip
            // 
            this.newtoolstrip.Name = "newtoolstrip";
            this.newtoolstrip.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newtoolstrip.Size = new System.Drawing.Size(164, 22);
            this.newtoolstrip.Text = "Nuevo";
            this.newtoolstrip.ToolTipText = "Crea una nueva red bayesiana";
            // 
            // opentoolstrip
            // 
            this.opentoolstrip.Name = "opentoolstrip";
            this.opentoolstrip.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.opentoolstrip.Size = new System.Drawing.Size(164, 22);
            this.opentoolstrip.Text = "Abrir";
            this.opentoolstrip.ToolTipText = "Abre un archivo de una red bayesiana";
            // 
            // guardartoolstrip
            // 
            this.guardartoolstrip.Name = "guardartoolstrip";
            this.guardartoolstrip.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.guardartoolstrip.Size = new System.Drawing.Size(164, 22);
            this.guardartoolstrip.Text = "Guardar";
            this.guardartoolstrip.ToolTipText = "Guarda a disco los datos de la red bayesiana.";
            // 
            // agregarNodoToolStripMenuItem
            // 
            this.agregarNodoToolStripMenuItem.Name = "agregarNodoToolStripMenuItem";
            this.agregarNodoToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.agregarNodoToolStripMenuItem.Text = "Agregar Nodo";
            this.agregarNodoToolStripMenuItem.Click += new System.EventHandler(this.agregarNodoToolStripMenuItem_Click);
            // 
            // inferenciaToolStripMenuItem
            // 
            this.inferenciaToolStripMenuItem.Name = "inferenciaToolStripMenuItem";
            this.inferenciaToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.inferenciaToolStripMenuItem.Text = "Inferencia";
            this.inferenciaToolStripMenuItem.ToolTipText = "Realiza las acciones de inferencia en la red creada .";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 356);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Red Bayesiana";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowChartViewer1.ResumeLayout(false);
            this.flowChartViewer1.PerformLayout();
            this.toolstripfooter.ResumeLayout(false);
            this.toolstripfooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem edittoolstrip;
        private System.Windows.Forms.ToolStripMenuItem newtoolstrip;
        private System.Windows.Forms.ToolStripMenuItem opentoolstrip;
        private System.Windows.Forms.ToolStripMenuItem guardartoolstrip;
        private System.Windows.Forms.ToolStripMenuItem agregarNodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inferenciaToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FlowChartDesigner.FlowChartViewer flowChartViewer1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.ToolStrip toolstripfooter;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
    }
}

