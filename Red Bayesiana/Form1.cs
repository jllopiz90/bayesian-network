using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RB_Message_Transfer;
using FlowChartDesigner;

namespace Red_Bayesiana
{
    public partial class Form1 : Form
    {
        public Form1()
        {
           
            
              InitializeComponent();
        }
        
        
        private void UpdatePropertyGrid(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = ((FlowChartViewer)sender).SelectedItem;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            flowChartViewer1.Builders.Add(new BayesianNodeBuilder("Bayesian Node"));
            flowChartViewer1.SelectedItemChanged+=UpdatePropertyGrid;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void agregarNodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flowChartViewer1.Charts.Add(new BayesianNodeChartElement() { Display = new Rectangle(flowChartViewer1.ClientRectangle.Width / 2, flowChartViewer1.ClientRectangle.Height / 2,130,30) ,Name="Bayesian Node",BackColor=Color.LightBlue,MaxParents=5,ShowInputPins=true,ShowOutputPins=true});
        }
    }
}
