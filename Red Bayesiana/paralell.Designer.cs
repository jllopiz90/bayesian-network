namespace Red_Bayesiana
{
    partial class paralell
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
            this.aceptbton = new System.Windows.Forms.Button();
            this.cancelbton = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // aceptbton
            // 
            this.aceptbton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.aceptbton.Location = new System.Drawing.Point(12, 135);
            this.aceptbton.Name = "aceptbton";
            this.aceptbton.Size = new System.Drawing.Size(117, 34);
            this.aceptbton.TabIndex = 0;
            this.aceptbton.Text = "Aceptar";
            this.aceptbton.UseVisualStyleBackColor = true;
            this.aceptbton.Click += new System.EventHandler(this.aceptbton_Click);
            // 
            // cancelbton
            // 
            this.cancelbton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelbton.Location = new System.Drawing.Point(181, 135);
            this.cancelbton.Name = "cancelbton";
            this.cancelbton.Size = new System.Drawing.Size(117, 34);
            this.cancelbton.TabIndex = 1;
            this.cancelbton.Text = "Cancelar";
            this.cancelbton.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(17, 91);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(286, 20);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 72);
            this.label1.TabIndex = 3;
            this.label1.Text = "    Ingrese el numero de nodos del grafo,\r\na partir del cual, se realizará el tra" +
                "spaso \r\nde mensajes en paralelo.\r\n ";
            // 
            // paralell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 181);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.cancelbton);
            this.Controls.Add(this.aceptbton);
            this.Name = "paralell";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button aceptbton;
        private System.Windows.Forms.Button cancelbton;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
    }
}