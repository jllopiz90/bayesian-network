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
    [Serializable]
    public class BayesianNodeChartElement:ChartElement
   {
        
        public BayesianNodeChartElement()
        { 
            Parents=new List<BayesianNodeChartElement>(_maxparents);
            States = new List<StringWraper>() {"State1","State2" };//variable binaria por defecto
            
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
        ///La  probabilidad condicional dada la evidencia.Si no ha sido calculada su valor es -1 en cada estado.
        /// </summary>
        public double[] ConditionalProbability { get; private set; } 

        /// <summary>
        /// Se utiliza para darle un nombre por defecto a cada nodo
        /// y que sea unico
        /// </summary>
        public static int Num_Node { get { numnode++; return numnode; } }
        static int numnode = -1;

        /// <summary>
        /// El nombre de este nodo en la red.
        /// </summary>
       
        public string Name{get;set;}
       
        public List<StringWraper> States{get;set;}

        public List<BayesianNodeChartElement> Parents { get;private set; }

        public IEnumerable<BayesianNodeChartElement> Childs
       {
           get
           {
               return _Connections.Where(x => x!=null&& x.To != null && x.To.ChartElement != null).Select(x => x.To.ChartElement as BayesianNodeChartElement);
           }
       }

        public Probability Condicional_Probabilities
        {
            get; set; }
        

        #region Base methods

        protected override void AddConnection(int outputPinIndex, string label)
        {
            base.AddConnection(outputPinIndex, label);
        }
       /// <summary>
       /// Se redefine la propiedad geometry para visualizar una elipse en lugar de un rectangulo.
       /// </summary>
       public override GraphicsPath Geometry
       {
           get
           {
               GraphicsPath path = new GraphicsPath();
               Point[] points=new Point[]{Display.Location,new Point(Display.Left,Display.Bottom),new Point(Display.Right,Display.Bottom),
               new Point(Display.Right,Display.Top)};
               path.AddClosedCurve(points);

               return path;
           }
       }

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
        static  readonly Brush b = new SolidBrush(Color.Black);
       public Font Font { get { return f; } set { f = value; } }
       public Color BackGround { get { return BackColor; } set { BackColor = value; } }
       protected internal override void OnPaint(System.Windows.Forms.PaintEventArgs e)
       {
           base.OnPaint(e);
           
           e.Graphics.DrawString(Name, f, b, Display);
       }
       #endregion



       public void CreateConditionalProbabilities()
       {
           ConditionalProbability=new double[States.Count];
           for (int i = 0; i < States.Count; i++)
           {
               ConditionalProbability[i] = -1;
           }
       }

       public void SetConditionalProbabilities(double[] p)
       {
           if(p==null)throw new ArgumentNullException();
           if(p.Length!=States.Count)throw new Exception("No coinciden la cant de estados");
           ConditionalProbability = (double[])p.Clone();
       }
       public static implicit operator BayesianNode(BayesianNodeChartElement s)
       {
           return new BayesianNode(s.Parents.Count, s.Childs.Count(), s.States.Count,
                                            s.Parents.Select(x => x.States.Count).ToArray()) { Probabilities = s.Condicional_Probabilities, Name = s.Name };
       }
       
   }
    [Serializable]
    public class StringWraper
    {
        public override string ToString()
        {
            return String.ToString();
        }

        public StringWraper()
        {
            if (String == null) String = string.Empty;
        }
        public string String { get; set; }
        public static implicit operator StringWraper(string s)
        {
            return new StringWraper() {String=s };
        }
        public static implicit operator String(StringWraper s)
        {
            return s.String;
        }
    }
    public class BayesianNodeBuilder : ChartElementBuilder
    {
        public string Name { get; set; }
        

        public BayesianNodeBuilder()
        {
            Name = "BayesianNode";
            
        }
        public override string BuilderName
        {
            get { return Name; }
        }

        public override ChartElement Build()
        {
            BayesianNodeChartElement node = new BayesianNodeChartElement();

            node.Name = "BayesianNode" + BayesianNodeChartElement.Num_Node;
            node.PinSize = new Size(5, 5);
            node.BackColor = Color.Snow;
            
           
            node.Display = new Rectangle(Center.X - 100, Center.Y - 20, 110, 25);
            node.ShowOutputPins = false;
            node.ShowInputPins = false;
            return node;
        }
    }

}
