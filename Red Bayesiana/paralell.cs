using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Red_Bayesiana
{
    public partial class paralell : Form
    {
        public paralell()
        {
            InitializeComponent();
        }

        private void aceptbton_Click(object sender, EventArgs e)
        {
            PararellNumber = (int) (numericUpDown1.Value);
        }

        public int PararellNumber { get; set; }
    }
}
