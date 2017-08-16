using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FlowChartDesigner
{
    public partial class FrProbabilityData : Form
    {
        public FrProbabilityData(IEnumerable<KeyValuePair<BayesianNodeChartElement,List<StringWraper>>> parent_states,
            List<StringWraper> mystates,BayesianNodeChartElement element)
        {
           
            InitializeComponent();

            if(element==null)throw new ArgumentNullException("element can not be null");
           

            datagridProbabilities.Columns.Clear();
            datagridProbabilities.Rows.Clear(); 
            int parents=0;
            //relleno las casillas de los estados de los padres
            foreach (var item in parent_states)
            {
                datagridProbabilities.Columns.Add(item.Key.Name, item.Key.Name);
                parents++;
            }
            int index = 0;
            FirstIndex = -1;
            foreach (var item in mystates)
            {
               index= datagridProbabilities.Columns.Add(item,element.Name+" :" + item);
               if (FirstIndex == -1) FirstIndex = index;
              
            } 
            ParentStates = parent_states.Select(x => x.Value.Count()).ToArray();
            Mystates = mystates.Count;
            datagridProbabilities.Rows.Add(ParentStates.Aggregate(1,(x, y) => x*y));
            int row = 0;
            CreateParentInstances(parent_states.Select(x=>x.Value).ToArray(),0,new StringWraper[parents],ref row);
            
            if(element.Condicional_Probabilities!=null)
            {
                //si ya tiene probabilidades entonces las pongo el el data grid para su edicion o visualizacion
                for (int j = FirstIndex; j < datagridProbabilities.Columns.Count; j++)
                {
                    for (int i = 0; i < datagridProbabilities.Rows.Count; i++)
                    {
                        datagridProbabilities[j, i].Value =
                            element.Condicional_Probabilities[(j-FirstIndex)*datagridProbabilities.Rows.Count + i];
                    }
                }
            }

            Probabilities = element.Condicional_Probabilities;


        }
        int FirstIndex { get; set; }
        
        void CreateParentInstances(IEnumerable<StringWraper>[] parents, int index,StringWraper[] instance,ref int row)
        {
            if (index == instance.Length)
            {
                for (int i = 0; i < index; i++)
                {
                    datagridProbabilities.Rows[row].Cells[i].Value = instance[i].String;
                }
                row++;
                return; 
            }
            foreach (var item in parents[index])
            {
                instance[index] = item;
                CreateParentInstances(parents, index + 1,instance,ref row);
            }
        }
        
        public RB_Message_Transfer.Probability Probabilities { get;private set; }

        

        int[] ParentStates { get; set; }
        private int Mystates;

        private void frProbabilityData_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var prob = new List<double>(datagridProbabilities.Rows.Count * (datagridProbabilities.Columns.Count - FirstIndex));
            double p = 0.0;
            double sum = 0;
            try
            {
                for (int j = FirstIndex; j < datagridProbabilities.Columns.Count; j++)
                    {
                        for (int i = 0; i < datagridProbabilities.Rows.Count; i++)
                        {
                            if (double.TryParse(((datagridProbabilities[j, i].Value).ToString()), out p) && p >= 0 && p <= 1)
                            { prob.Add(p);
                            
                            }
                            else
                            {
                                throw new Exception("Algun valor no es correcto. Verifique que sean numeros entre 0 y 1");
                            }

                        }
                        
                    }
                    for (int k = 0; k < datagridProbabilities.Rows.Count; k++)
                    {
                        for (int l = FirstIndex; l < datagridProbabilities.Columns.Count; l++)
                            sum += double.Parse(datagridProbabilities[l, k].Value.ToString());
                        if (Math.Abs(1 - sum) > double.Epsilon)
                            throw new Exception("La suma de las probabilidades de cada estado del nodo " + "" + "deben ser 1");
                        sum = 0;
                    }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hubo un error obteniendo las probabilidades condicionales. \n" +ex.Message);
                return;
            }
            var arr=new List<int>(ParentStates);
            arr.Insert(0,Mystates);
            Probabilities = new RB_Message_Transfer.Probability(prob.ToArray(), arr.ToArray());
            
        }

        private void datagridProbabilities_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
    }
}
