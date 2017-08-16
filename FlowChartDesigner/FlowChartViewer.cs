using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Drawing.Drawing2D;


namespace FlowChartDesigner
{
    public delegate void NodeAgregated();
    /// <summary>
    /// Este control visualiza un diagrama cuyos elementos se agregan en la coleccion Charts.
    /// </summary>
    [Serializable]
    public partial class FlowChartViewer : ScrollableControl
    {
        #region Instances

        /// <summary>
        /// Ultima posicion del mouse. Se utiliza para determinar cuanto 
        /// hay que desplazar un objeto que se esta haciendo drag and drop.
        /// </summary>
        Point lastMousePlace;

        /// <summary>
        /// Determina si se esta estableciendo una conexion o no.
        /// </summary>
        bool isConnecting = false;

        /// <summary>
        /// Determina la conexion que esta siendo cambiada.
        /// </summary>
        Connection modifyingConnection = null;

        /// <summary>
        /// Determina los builders disponibles para agregar nuevos elementos en el diagrama.
        /// </summary>
        List<ChartElementBuilder> builders = new List<ChartElementBuilder>();

        /// <summary>
        /// Determina el elemento actualmente seleccionado.
        /// </summary>
        ChartElement _SelectedItem = null;

        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa el control.
        /// </summary>
        public FlowChartViewer()
        {
            InitializeComponent();

            // El metodo SetStyle permite configurar aspectos 
            //de la ejecucion de un control en los momentos de visualizacion e interaccion.
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true); // determina que se debe utilizar 
            //doble buffer para evitar el parpadeo durante las animaciones.
            SetStyle(ControlStyles.UserPaint, true); // determina que se debe disparar
            //el evento Paint.
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // determina que todo el pintado 
            //sera establecido en el metodo OnPaint por lo que no se borra el fondo y evita parpadeo.

            // se crea una coleccion para almacenar los elementos del diagrama.
            Charts = new ChartElementCollection();
            // se suscribe al evento que notifica el cambio en la coleccion y 
            //esto permite refrescar visualmente el control a cualquiera de estos cambios.
            Charts.CollectionChanged += new EventHandler(Charts_CollectionChanged);

            AutoScroll = true;
        }

        #endregion

        #region Privates

        /// <summary>
        /// Ocurre cuando cambian el conjunto de elementos del diagrama y refresca el control.
        /// </summary>
        void Charts_CollectionChanged(object sender, EventArgs e)
        {
            Invalidate(); // El control se invalida para cualquier cambio 
            //sobre la coleccion de elementos del diagrama.
        }

        /// <summary>
        /// Determina la distancia euclideana entre dos puntos.
        /// </summary>
        private double Distance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        /// <summary>
        /// Crea un menu contextual global.
        /// </summary>
        private ContextMenu GetGlobalContextMenu(Point center)
        {
            ContextMenu cm = new ContextMenu();

            // Opcion Create... esta opcion permitira agregar nuevos elementos al diagrama.
            //MenuItem create = new MenuItem("Create");
            foreach (ChartElementBuilder builder in Builders) // Para cada objeto "Builder" se crea
                //una opcion dentro del menu item.
            {
                MenuItem builderMenuItem = new MenuItem();
                builder.Center = center; // se especifica al builder donde quedaria el elemento.
                builderMenuItem.Text = builder.BuilderName; // se nombra la opcion con el nombre del Builder.
                builderMenuItem.Tag = builder; // se asocia el builder al menu item para su futuro uso.
                builderMenuItem.Click += new EventHandler(builderMenuItem_Click); // se suscribe al metodo Click
                //para realizar la accion para esta opcion.

                cm.MenuItems.Add(builderMenuItem); // se adiciona el menu item como submenu 
                //dentro del menu Create.
            }

            //cm.MenuItems.Add(create); // se agrega Create como unica opcion del menu contextual global.

            // Utilice este menu contextual para agregar nuevas opciones a nivel global que Ud. decida.

            return cm;
        }

        void builderMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem item = sender as MenuItem;
            ChartElementBuilder builder = item.Tag as ChartElementBuilder; // se recupera el Builder a partir
            //del menu item.

            ChartElement element = builder.Build(); // se crea un nuevo elemento utilizando ese builder.

            this.Charts.Add(element); // se agrega a la coleccion de elementos del diagrama.
            if (GraphChanged != null) GraphChanged();
        }

        public event NodeAgregated GraphChanged;
        /// <summary>
        /// Crea un menu contextual para cierto elemento del diagrama.
        /// Permite eliminar el elemento, conectar a otro, etc.
        /// </summary>
        /// <param name="chart">Elemento al que se le aplican las opciones.</param>
        /// <returns>Un objeto ContextMenu con las opciones.</returns>
        private ContextMenu GetContextMenuFor(ChartElement chart)
        {
            ContextMenu cm = new ContextMenu();

            MenuItem node = new MenuItem();
            node.Text = "Insert conditional probabilities";
            node.Tag = chart;
            node.Click += new EventHandler(Probability_Click);
            cm.MenuItems.Add(node); 
  
            MenuItem removeMenuItem = new MenuItem();
            removeMenuItem.Text = "Remove";
            removeMenuItem.Tag = chart;
            removeMenuItem.Click += new EventHandler(removeMenuItem_Click);

            cm.MenuItems.Add(removeMenuItem);

           
            foreach (Connection c in chart.Connections) // para cada conexion del elemento
            {
                MenuItem item = new MenuItem(); // se crea un nuevo MenuItem.
                item.Text ="Connect "+ c.Label; // el texto del menu es la etiqueta de la conexion.
                item.Tag = c; // se almacena la conexion como un objeto asociado al MenuItem.
                item.Click += item_Click; // se determina que accion se ejecuta para el click del MenuItem.
                cm.MenuItems.Add(item); // se agrega el menu item a los menuItems del menu contextual.
            }

            MenuItem sep = new MenuItem ();
            sep.Text = "-";

            cm.MenuItems.Add(sep);

              return cm;
        }

        /// <summary>
        /// Accion que se produce cuando se elimina un elemento.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void removeMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem item = sender as MenuItem;


            BayesianNodeChartElement element = ((BayesianNodeChartElement) item.Tag);

            this.Charts.Remove(element);
            
        }

        /// <summary>
        /// Accion que se produce cuando se selecciona una conexion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item_Click(object sender, EventArgs e)
        {
            MenuItem item = sender as MenuItem;
            // recuperar la conexion de la propiedad Tag.
            Connection connection = item.Tag as Connection;
            modifyingConnection = connection;
            isConnecting = true;
        }
        /// <summary>
        /// Accion que se produce cuando se quiere insertar las
        /// probabilidades condicionales de un
        /// nodo dado los padres
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Probability_Click(object sender, EventArgs e)
        {
            MenuItem item = sender as MenuItem;
            var chart=item.Tag as BayesianNodeChartElement;// recuperar la conexion de la propiedad Tag.
            if (chart!=null&&chart.Parents != null)
            {
                var fomr_prob = new FrProbabilityData(chart.Parents.Select(x => new KeyValuePair<BayesianNodeChartElement,List<StringWraper>>(x,x.States)), chart.States,chart);

                if (fomr_prob.ShowDialog() == DialogResult.OK)
                {
                    chart.Condicional_Probabilities = fomr_prob.Probabilities;
                }
            }
            else
                MessageBox.Show("El nodo no tiene padres.");
        }

        #endregion

        #region Public

      
        ChartElementCollection _Charts;
        /// <summary>
        /// Devuelve el conjunto de elementos del diagrama.
        /// </summary>
        public ChartElementCollection Charts
        {
            get { return _Charts; }
             set { _Charts = value; }
        }

        /// <summary>
        /// Evento que se dispara cuando un elemento del diagrama es seleccionado.
        /// </summary>
        public event EventHandler SelectedItemChanged;

        /// <summary>
        /// Devuelve o establece el elemento seleccionado dentro del diagrama.
        /// </summary>
        public ChartElement SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                _SelectedItem = value;

                if (SelectedItemChanged != null)
                    SelectedItemChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Devuelve una lista con los builders disponibles para agregar elementos en el diagrama.
        /// Utilice esta lista para agregar builders y aumentar asi los posibles elementos a estar presentes en el diagrama.
        /// </summary>
        public IList<ChartElementBuilder> Builders { get { return builders; } }

        #endregion

        #region Protected

        /// <summary>
        /// Metodo que se invoca cuando el mouse se mueve sobre el control.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            Point mousePositionInCanvas = FromClientToCanvas(e.Location);

            if (e.Button == System.Windows.Forms.MouseButtons.Left && SelectedItem != null)
            {
                Rectangle translate = SelectedItem.Display;
                translate.Offset(mousePositionInCanvas.X - lastMousePlace.X, mousePositionInCanvas.Y - lastMousePlace.Y);
                SelectedItem.Display = translate;
            }

            foreach (ChartElement c in Charts)
                if (c.Display.Contains(mousePositionInCanvas))
                {
                    c.HighLight = true;
                    
                }
                else
                    c.HighLight = false;

            lastMousePlace = mousePositionInCanvas;

            Invalidate();
        }

        /// <summary>
        /// Este metodo permite convertir una coordenada del area cliente en una coordenada en el lienzo real *considerando la posicion del scroll*.
        /// </summary>
        protected Point FromClientToCanvas(Point p)
        {
            p.Offset(-AutoScrollPosition.X, -AutoScrollPosition.Y);
            return p;
        }

        /// <summary>
        /// Metodo que se invoca cuando se presiona un boton del mouse.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            lastMousePlace = FromClientToCanvas (e.Location);

            ChartElement nextSelected = null;

            foreach (ChartElement c in Charts)
                if (c.Display.Contains(FromClientToCanvas(e.Location)))
                    nextSelected = c;

            if (SelectedItem != null) SelectedItem.Selected = false;
            SelectedItem = nextSelected;
            if (SelectedItem != null) SelectedItem.Selected = true;

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                isConnecting = false;
                modifyingConnection = null;

                if (SelectedItem != null)
                {
                    ContextMenu cm = GetContextMenuFor(SelectedItem);
                    this.ContextMenu = cm;
                }
                else
                {
                    ContextMenu cm = GetGlobalContextMenu(FromClientToCanvas(e.Location));
                    this.ContextMenu = cm;
                }
            }
            else
            {
                if (isConnecting)
                {
                    Pin nearestInput = null;
                    if (SelectedItem != null)
                        foreach (Pin input in SelectedItem.ValidInputs)
                            if (nearestInput == null || Distance(input.Position, FromClientToCanvas (e.Location)) < Distance(nearestInput.Position, FromClientToCanvas (e.Location)))
                                nearestInput = input;

                    var before = modifyingConnection.To;
                  
                    modifyingConnection.To = nearestInput;
                    if(nearestInput!=null) //le pongo el padre
                    {
                        ((BayesianNodeChartElement) nearestInput.ChartElement).Parents.Add((BayesianNodeChartElement)modifyingConnection.From.ChartElement);
                        ((BayesianNodeChartElement) nearestInput.ChartElement).Condicional_Probabilities = null;
                    }
                    if (before != null )//le quito el antiguo padre
                    {
                        ((BayesianNodeChartElement) before.ChartElement).Parents.Remove(
                            modifyingConnection.From.ChartElement as BayesianNodeChartElement);
                        ((BayesianNodeChartElement) before.ChartElement).Condicional_Probabilities = null;
                    }
                   

                    isConnecting = false;
                    modifyingConnection = null;
                }
            }

            Invalidate();

            base.OnMouseDown(e);
        }

        protected override void OnScroll(ScrollEventArgs se)
        {
            base.OnScroll(se);

            Invalidate();
        }

        /// <summary>
        /// Metodo que se invoca cuando se repinta el control.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Matrix transform = new Matrix();
            transform.Translate(AutoScrollPosition.X, AutoScrollPosition.Y);
            e.Graphics.Transform = transform;

            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            int maxX = 0, maxY = 0;

            foreach (ChartElement chart in Charts)
            {
                chart.OnPaintBackground(e);
                chart.OnPaint(e);

                maxX = Math.Max(maxX, chart.Display.Right);
                maxY = Math.Max(maxY, chart.Display.Bottom);
            }

            if (isConnecting)
                modifyingConnection.From.ChartElement.DrawFreeConnection(e.Graphics, modifyingConnection, FromClientToCanvas (PointToClient(Control.MousePosition)), PinOrientation.Up);

            this.AutoScrollMinSize = new Size(maxX, maxY);
        }

        #endregion
    }

    
}
