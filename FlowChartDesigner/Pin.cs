using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FlowChartDesigner
{
    /// <summary>
    /// Un pin representa un posible lugar por el que un objeto puede ser conectado, ya sea de salida o de entrada.
    /// </summary>
    [Serializable]
    public class Pin
    {
        /// <summary>
        /// Determina la orientación del Pin con respecto al centro del elemento en que este se encuentra.
        /// </summary>
        public PinOrientation Orientation
        {
            get
            {
                Point pos = Position; // Posicion actual del Pin

                Rectangle display = ChartElement.Display; // rectangulo del elemento en que se encuentra.

                int r = pos.Y * 3 / display.Height; // fila en el espacio dividido en 9 cuadrantes.
                int c = pos.X * 3 / display.Width; // columna del espacio dividido en 9 cuadrantes.
                r = Math.Max(0, Math.Min(2, r)); // obligando a quedar entre 0 y 2
                c = Math.Max(0, Math.Min(2, c)); // obligando a quedar entre 0 y 2

                PinOrientation[,] directions = new PinOrientation[,] { 
                    { PinOrientation.UpLeft, PinOrientation.Up, PinOrientation.UpRight},
                    { PinOrientation.Left, PinOrientation.Up, PinOrientation.Right },
                    { PinOrientation.DownLeft, PinOrientation.Down, PinOrientation.DownRight }
                }; // Conjunto de orientaciones para cada cuadrante.

                return directions[r, c];
            }
        }

        ChartElement _ChartElement;
        /// <summary>
        /// Devuelve el elemento del que forma parte este pin.
        /// </summary>
        public ChartElement ChartElement { get { return _ChartElement; } internal set { _ChartElement = value; } }

        int _Index;
        /// <summary>
        /// Devuelve el indice de este pin.
        /// </summary>
        public int Index { get { return _Index; } private set { _Index = value; } }

        PinType _PinType;
        /// <summary>
        /// Devuelve el tipo de pin, si es de entrada o de salida.
        /// </summary>
        public PinType PinType { get { return _PinType; } private set { _PinType = value; } }

        /// <summary>
        /// Permite inicializar un pin. Observe que el uso de internal 
        /// esta dado porque el elemento del diagrama es el que sabe que pines debe tener.
        /// </summary>
        internal Pin(ChartElement chart, int index, PinType type)
        {
            this.ChartElement = chart;
            this.Index = index;
            this.PinType = type;
        }

        /// <summary>
        /// Determina la posicion actual del pin. Esta posicion se define 
        /// para cada pin a traves de los metodos GetPositionForInputPin y 
        /// GetPositionForOutputPin del tipo abstracto ChartElement.
        /// </summary>
        public Point Position
        {
            get
            {
                switch (PinType)
                {
                    case FlowChartDesigner.PinType.Input:
                        return ChartElement.GetPositionForInputPin(Index);
                    case FlowChartDesigner.PinType.Output:
                        return ChartElement.GetPositionForOutputPin(Index);
                }

                throw new NotSupportedException();
            }
        }
    }
}
