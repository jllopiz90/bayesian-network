using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using FlowChartDesigner;


namespace RB_Message_Transfer
{
    [Serializable]
    public class BayesianNode:ChartElement
   {

        public BayesianNode()
        {

            for (int i = 0; i < _maxparents; i++)
            {
                AddConnection(i, "Child " + (i + 1));
            }
        }
        int _maxparents=5;
        public int MaxParents
        {
            get { return _maxparents; }
            set
            {
                if (value >= 1&&value>_maxparents)
                {
                    if (value > 10) { ShowInputPins = false; ShowOutputPins = false; }

                    _maxparents = value;
                    PinCollection p = new PinCollection(this, _maxparents, PinType.Input),
                                  pp = new PinCollection(this, _maxparents, PinType.Output);
                    int min = Math.Min(_maxparents, ValidInputs.Count);
                    List<Connection> newconnections = new List<Connection>(_maxparents);

                    for (int i = 0; i < min; i++)
                    {
                        p[i] = ValidInputs[i];
                        pp[i] = ValidOutputs[i];


                    }
                    ValidInputs = p;
                    ValidOutputs = pp;
                    min = Math.Min(_Connections.Count, _maxparents);

                    for (int j = 0; j < _maxparents; j++)
                    {
                        if (j < _Connections.Count)
                            newconnections.Add(_Connections[j]);
                        else
                            newconnections.Add(new Connection(ValidOutputs[j], null) { Label = "Child " + (j + 1) });
                    }
                    _Connections = newconnections;



                }
            }
        }
        
        /// <summary>
        /// El nombre de este nodo en la red.
        /// </summary>
       public string Name{get;set;}

       
       public IEnumerable<BayesianNode> Parents
       {
           get
           {
               foreach (var item in ValidInputs)
               {
                   yield return ((BayesianNode)item.ChartElement);
               }
           }
       }
       public IEnumerable<BayesianNode> Childs
       {
           get
           {
               foreach (var item in ValidOutputs)
               {
                   yield return ((BayesianNode)item.ChartElement);
               }
           }
       }
       public double[] Probabilities()
       {
           return new double[Parents.Count()];
       }
       /// <summary>
       ///las prob condicionales del nodo dados sus padres
       ///se considera las variables binarias y los estados en orden creciente 00 01 10 11 etc
      ///si tiene un solo padre el array tiene 4 elementos 
       /// </summary>
       public double[] GetProbabilities() { return null; }

        
        #region Base methods

       public override int NumberOfValidInputs
       {
           get { return MaxParents; }
       }

       public override int NumberOfValidOutputs
       {
           get { return MaxParents; }
       }

       protected internal override Point GetPositionForInputPin(int index)
       {
           if (index >= MaxParents)
               throw new IndexOutOfRangeException();

           return new Point(Display.X + index * Display.Width / (MaxParents - 1), Display.Y );

       }

       public int Width
       {
           get { return Display.Width; }
           set
           {
               Display = new Rectangle(Display.Location.X, Display.Location.Y, value, Display.Height);
           }
       }

       public int Heigth
       {
           get { return Display.Height; }
           set
           {
               Display = new Rectangle(Display.Location.X, Display.Location.Y,Display.Width, value);
           }
       }
       protected internal override Point GetPositionForOutputPin(int index)
       {
           if (index >= MaxParents)
               throw new IndexOutOfRangeException();

           return new Point(Display.X + index * Display.Width / (MaxParents - 1), Display.Y + Display.Height);

       }
        Font f = new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.Serif),12);
       Brush b = new SolidBrush(Color.Black);
       public Font Font { get { return f; } set { f = value; } }
       public Color BackGround { get { return BackColor; } set { BackColor = value; } }
       protected internal override void OnPaint(System.Windows.Forms.PaintEventArgs e)
       {
           base.OnPaint(e);
           e.Graphics.DrawString(Name,f,b,Display);
       }
       #endregion
   }
    public class BayesianNodeBuilder : ChartElementBuilder
    {
        public string Name { get; set; }
        public BayesianNodeBuilder(string name)
        {
            Name = name;
        }
        public override string BuilderName
        {
            get { return Name; }
        }

        public override ChartElement Build()
        {
            BayesianNode node = new BayesianNode();
            node.Name = Name;
            node.PinSize = new Size(5, 5);
            node.BackColor = Color.LightBlue;
            
            
            node.Display = new Rectangle(Center.X - 100, Center.Y - 25, 130, 30);
            node.ShowOutputPins = false;
            node.ShowInputPins = false;
            return node;
        }
    }

}
