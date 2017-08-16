using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using RB_Message_Transfer;


namespace FlowChartDesigner
{
    [System.Serializable]
    public class BayesianTest
    {
        //el nombre de la columna de ese nodo y su estado
        public Evidence Evidence { get; set; }
        public double[][] Probabilities { get; set; }
      
    }
}