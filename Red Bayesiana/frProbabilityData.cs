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
    public partial class frProbabilityData : Form
    {
        public frProbabilityData(int[] parent_states,int mystates)
        {
            if (parent_states == null || parent_states.Length == 0) throw new ArgumentException();
            ParentStates = parent_states;
            Mystates = mystates;
            datagridProbabilities = new DataGridView();
          
           
            InitializeComponent();
        }
     
        public RB_Message_Transfer.ICondictionalProbability Probabilities { get;private set; }

      

        private void frProbabilityData_Load(object sender, EventArgs e)
        {

        }

        public int[] ParentStates { get; set; }

        public int Mystates { get; set; }
    }
}
