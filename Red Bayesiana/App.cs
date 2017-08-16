using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.IO;
using System.Windows.Forms;
using RB_Message_Transfer;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using FlowChartDesigner;
using Red_Bayesiana.Properties;

namespace Red_Bayesiana
{
    public partial class App : Form
    {
        public App()
        {
 
            InitializeComponent();
        }

        /// <summary>
        /// la extension de los archivos que maneja este programa si el achivo guarda la informacion grafica.
        /// </summary>
        private const string save_garafic_ext = ".gri";

        private void UpdatePropertyGrid(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = ((FlowChartViewer)sender).SelectedItem;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            flowChartViewer1.Builders.Add(new BayesianNodeBuilder());
            flowChartViewer1.SelectedItemChanged += UpdatePropertyGrid;

            Evidence = new List<Evidence>();
            EvidenceIndex = -1;
            //Si cambia el grafo se pierde la evidencia que se almaceno 
            //porque la cantidad de nodos o si sus estados varia
            flowChartViewer1.GraphChanged += new NodeAgregated(() =>
                {
                    EvidenceIndex = -1;
                    Evidence = new List<Evidence>();
                    datagridnewevidence.Columns.Clear();
                    lbevidenceName.Text = "No evidence";
                });
            Tests = new List<BayesianTest>();
            TestsIndex = -1;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void informacionGraficaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
            Stream file = null;
            try
            {
                var openfile = new SaveFileDialog { DefaultExt = save_garafic_ext, AddExtension = true };
                if (openfile.ShowDialog() == DialogResult.OK)
                {
                    file = new FileStream(openfile.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    var bin = new BinaryFormatter();
                    var c = new List<ChartElement>(flowChartViewer1.Charts.Count);
                    //guardo una lista porque el control no puedo hacerlo serializable
                    c.AddRange(flowChartViewer1.Charts);

                    Evidence = null;
                    Tests = null;
                  
                    var save = new Tuple<List<ChartElement>, List<Evidence>, List<BayesianTest>>(c,Evidence, Tests);
                    bin.Serialize(file, save);
MessageBox.Show(Resources.App_SaveBayesianNetwork_La_red_bayesiana_ha_sido_guardada_correctamente_);
        
                }
                    }
            catch (Exception ex)
            {
                MessageBox.Show("Lo siento. Ha ocurrido un error guardando la red bayesiana. " + ex.Message);
            }
            finally
            {
                if (file != null)
                    file.Close();

            }
        }




        private void opentoolstrip_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
            Stream file = null;

            try
            {
                var open = new OpenFileDialog();
                if (open.ShowDialog() == DialogResult.OK)
                {
                    if (open.FileName.Contains(save_garafic_ext))
                    {
                        var bin = new BinaryFormatter();
                        file = open.OpenFile();
                        var l = (Tuple<List<ChartElement>, List<Evidence>, List<BayesianTest>>)bin.Deserialize(file);


                        flowChartViewer1.Charts = new ChartElementCollection(l.Item1);
                        Evidence = l.Item2 ?? new List<Evidence>();

                        EvidenceIndex = -1;
                        if (Evidence.Count > 0)
                            EvidenceIndex = 0;
                        Tests = l.Item3 ?? new List<BayesianTest>();
                        TestsIndex = 0;
                        if (Tests.Count > 0)
                            ShowConditionalProbabilities();

                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hubo un error abriendo el archivo " + ex.Message);
            }
            finally
            {
                if (file != null)
                    file.Close();
            }
        }





        private void computarProbabilidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
            try
            {
                if (CheckConsistency())
                {
                    //obtener la evidencia
                    if (flowChartViewer1.Charts.Count > 0 && Evidence.Count > 0)
                        GetEvidence();
                    //transformar el grafo del visor a un grafo de nodos bayesianos

                    var graph = new BayesianGraph();
                    //
                     var dict = new Dictionary<BayesianNode, BayesianNodeChartElement>(flowChartViewer1.Charts.Count);
                    BayesianNode node;
                    var dict2 = new Dictionary<BayesianNodeChartElement, BayesianNode>(flowChartViewer1.Charts.Count);
                    
                    graph.Clear();
                   
                    foreach (var item in flowChartViewer1.Charts.Cast<BayesianNodeChartElement>())
                    {

                        node = new BayesianNode(item.Parents.Count, item.Childs.Count(), item.States.Count,
                                                item.Parents.Select(x => x.States.Count).ToArray()) { Probabilities = item.Condicional_Probabilities, Name = item.Name };

                        dict.Add(node, item);
                        dict2.Add(item,node);
                        item.CreateConditionalProbabilities();


                        graph.AddVertex(node);
                    }
                    foreach (var bnodechart in flowChartViewer1.Charts.Cast<BayesianNodeChartElement>())
                    {
                        foreach (var child in bnodechart.Childs)
                        {
                            graph.AddEdge(dict2[bnodechart], dict2[child]);
                        }
                    }
                    //ejecutar el traspaso de mensajes en un poliarbol o en una red multiplemente conexa
                    if (graph.Arbol())
                    {
                        if (Evidence.Count > 0)
                            MessageTransfer.Message_Tranfer_Poliarbol(graph, Evidence[EvidenceIndex]);
                        else
                            MessageTransfer.Message_Tranfer_Poliarbol(graph);
                        foreach (var nodebayesian in graph)
                        {
                            dict[nodebayesian].SetConditionalProbabilities(nodebayesian.ConditionalProbability);

                        }
                    }
                    else
                    {
                        var markovnet = new MarkovNet(graph);
                        if (Evidence.Count > 0)
                            MessageTransfer.Message_Tranfer_Arbol_Union(markovnet, Evidence[EvidenceIndex]);
                        else
                            MessageTransfer.Message_Tranfer_Arbol_Union(markovnet);
                        foreach (var nodebayesian in markovnet.BayesianNet)
                        {
                            dict[nodebayesian].SetConditionalProbabilities(nodebayesian.ConditionalProbability);

                        }
                    }

                    tabControl1.SelectTab(0);



                    Tests.Add(new BayesianTest()
                        {
                            Evidence = Evidence[EvidenceIndex].Clone(),
                            Probabilities =
                                graph.Select(x => x.ConditionalProbability.Clone() as double[]).ToArray()
                        });
                    TestsIndex = Tests.Count - 1;
                    ShowConditionalProbabilities();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo algun problema al calcular las probabilidades condicionales. " + ex.Message);
            }
        }




        private void ShowConditionalProbabilities()
        {
            tabControl1.SelectTab(0);
            dataGridconditionalprob.Columns.Clear();
            int maxstates = 0;

            foreach (var item in flowChartViewer1.Charts.Select(x => x as BayesianNodeChartElement))
            {
                var index = dataGridconditionalprob.Columns.Add(item.Name, item.Name);
                dataGridconditionalprob.Columns[index].ToolTipText =
                    "Seleccione el estado del nodo si este pertenece\n a la evidencia.";
                dataGridconditionalprob.Columns[index].Tag = item;
                maxstates = Math.Max(maxstates, item.States.Count);

            }

            dataGridconditionalprob.Rows.Add(2 * maxstates);
            for (int j = 0; j < dataGridconditionalprob.Columns.Count; j++)
            {
                for (int i = 0; i < dataGridconditionalprob.Rows.Count; i += 2)
                {
                    try
                    {
                        dataGridconditionalprob[j, i].Value = ((BayesianNodeChartElement)(flowChartViewer1.Charts[j])).States[i / 2] + ":";
                        dataGridconditionalprob[j, i + 1].Value = Tests[TestsIndex].Probabilities[j][i / 2];
                    }
                    catch
                    {
                       
                    }
                }
            }
            dataGridconditionalevidence.Columns.Clear();
            for (int i = 0; i < Tests[TestsIndex].Evidence.EvidenceValues.Length; i++)
            {
                dataGridconditionalevidence.Columns.Add(Tests[TestsIndex].Evidence.NodeNames[i], Tests[TestsIndex].Evidence.NodeNames[i]);
            }
            dataGridconditionalevidence.Rows.Add(maxstates*2);

            for (int j = 0; j < dataGridconditionalevidence.Columns.Count; j++)
                for (int i = 0; i < dataGridconditionalevidence.Rows.Count; i+=2)
                {
                    try
                    {
                        dataGridconditionalevidence[j, i].Value = ((BayesianNodeChartElement)(flowChartViewer1.Charts[j])).States[i / 2] + ":";
                        dataGridconditionalevidence[j, i + 1].Value = Tests[TestsIndex].Evidence.EvidenceValues[j][i / 2];
                    }
                    catch
                    {
                        
                    }
                } 

            UpdateLabelEvidence();
        }

        public List<Evidence> Evidence { get; private set; }

        public List<BayesianTest> Tests { get; private set; }
        public int TestsIndex { get; set; }

        private bool CheckConsistency()
        {
            return flowChartViewer1.Charts.Count > 0 && flowChartViewer1.Charts.Cast<BayesianNodeChartElement>().All(x => x.Condicional_Probabilities != null);
        }



        public int EvidenceIndex { get; set; }



        private void LoadEvidence()
        {
            datagridnewevidence.Columns.Clear();
            
            foreach (var item in flowChartViewer1.Charts.Select(x => x as BayesianNodeChartElement))
            {
                var index = datagridnewevidence.Columns.Add(item.Name, item.Name);
                datagridnewevidence.Columns[index].ToolTipText =
                    "Seleccione la probabilidad de cada estado del nodo si este pertenece\n a la evidencia.";
                datagridnewevidence.Columns[index].Tag = item;
            }
            var max = flowChartViewer1.Charts.Cast<BayesianNodeChartElement>().Select(x => x.States).ToArray();
                   
                    
            datagridnewevidence.Rows.Add(max.Select(x=>x.Count).Max()*2);
            //pongo los valores de la evidencia
            if (Evidence.Count > 0)
                for (int j = 0; j < datagridnewevidence.Columns.Count; j++)
                {
                    for (int i = 0; i < datagridnewevidence.Rows.Count-1; i += 2)
                    {
                        if (Evidence[EvidenceIndex].EvidenceValues.Length > j &&
                            Evidence[EvidenceIndex].EvidenceValues[j].Length > i/2)
                        {
                            datagridnewevidence[j, i].Value = max[j][i/2];
                            datagridnewevidence[j, i + 1].Value = Evidence[EvidenceIndex].EvidenceValues[j][i/2];

                        }
                        else
                        {
                            datagridnewevidence[j, i].Value = "-";
                            datagridnewevidence[j, i+1].Value = "-";
                        }
                    }
                }
        
                

        }

        private void GetEvidence()
        {
            try
            {
                double val = 0.0;
                for (int i = 1; i < datagridnewevidence.Rows.Count; i+=2)
                {
                     for (int j = 0; j < datagridnewevidence.Columns.Count; j++)
                    if (double.TryParse(datagridnewevidence[j, i].Value.ToString(),out val))
                        Evidence[EvidenceIndex].EvidenceValues[j][i/2] = val;
                }
               
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudo obtener la evidencia.Verifique que todos los elementos son correctos. "+e.Message);
            }
        }

        private void bttonevidencedown_Click(object sender, EventArgs e)
        {
            EvidenceIndex = (EvidenceIndex > 0)
                                 ? EvidenceIndex - 1
                                 : 0;
            if (Evidence.Count > 0)
            {
                LoadEvidence();
                UpdateLabelEvidence();
                tabPage3.Refresh();
            }
            else
                EvidenceIndex = -1;
        }
        void UpdateLabelEvidence()
        {
            lbevidenceName.Text =(Evidence.Count>0)? "Evidence " + (EvidenceIndex + 1):"No Evidence";
            lbtest.Text =(Tests.Count>0)?  "Test " + (TestsIndex + 1):"No Test";
        }

        private void bttonevidenceup_Click(object sender, EventArgs e)
        {

            if (flowChartViewer1.Charts.Count > 0 && Evidence.Count > 0 && (EvidenceIndex < Evidence.Count - 1))
            {
                EvidenceIndex++;
                LoadEvidence();
                UpdateLabelEvidence();
                tabPage3.Refresh();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (flowChartViewer1.Charts.Count > 0)
            {
                if (Evidence.Count > 0)
                {
                    Evidence.RemoveAt(EvidenceIndex);
                    if (EvidenceIndex == Evidence.Count) EvidenceIndex = Evidence.Count - 1;
                    if (Evidence.Count == 0)
                    {
                        datagridnewevidence.Columns.Clear();
                        lbevidenceName.Text = "No evidence";
                        EvidenceIndex = -1;
                    }
                    else
                        UpdateLabelEvidence();



                    Refresh();
                }
            }
        }

        private void bttonagregarevidence_Click(object sender, EventArgs e)
        {
            if (flowChartViewer1.Charts.Count > 0)
            {
                Evidence.Add(new Evidence(flowChartViewer1.Charts.Cast<BayesianNodeChartElement>().Select(x=>x.States.Count).ToArray(),flowChartViewer1.Charts.Cast<BayesianNodeChartElement>().Select(x=>x.Name).ToArray()));
                EvidenceIndex = Evidence.Count - 1;
                
                UpdateLabelEvidence();
                LoadEvidence();
                Refresh();
            }
        }

       

        private void bttontestdown_Click(object sender, EventArgs e)
        {
            if (Tests.Count > 0 && TestsIndex > 0)
            {
                TestsIndex--;
                ShowConditionalProbabilities();
                tabPage1.Refresh();
            }
        }

        private void bttontestup_Click(object sender, EventArgs e)
        {
            if (Tests.Count > 0 && TestsIndex < Tests.Count - 1)
            {
                TestsIndex++;
                ShowConditionalProbabilities();
                tabPage1.Refresh();
            }
        }

        private void bttontestremove_Click(object sender, EventArgs e)
        {
            if (Tests.Count > 0 && TestsIndex < Tests.Count)
            {
                Tests.RemoveAt(TestsIndex);
                TestsIndex = (TestsIndex == 0) ? 0 : TestsIndex - 1;
                if (Tests.Count == 0)
                {
                    dataGridconditionalprob.Columns.Clear();
                    dataGridconditionalevidence.Columns.Clear();
                    lbtest.Text = "No Test";
                    TestsIndex = -1;
                }
                else
                {
                    ShowConditionalProbabilities();
                }
                tabPage1.Refresh();
            }
        }

        private void flowChartViewer1_KeyPress(object sender, KeyPressEventArgs e)
        {

           
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void numeroDeParalelismoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new paralell();
            if(form.ShowDialog()== DialogResult.OK)
            {
                MessageTransfer.ParalellStartNumber = form.PararellNumber;
               
            }

        }

      
    }
}
