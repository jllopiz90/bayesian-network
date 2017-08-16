using System;
using System.Collections.Generic;
using System.Text;

namespace FlowChartDesigner
{
    /// <summary>
    /// Representa una coneccion entre dos elementos de un diagrama.
    /// </summary>
   [Serializable]
    public class Connection
    {
        Pin _From;
        /// <summary>
        /// Devuelve el pin de salida que identifica de que elemento se sale.
        /// </summary>
        public Pin From
        {
            get { return _From; }
            internal set { _From = value; }
        }

        Pin _To;
        /// <summary>
        /// Devuelve o establece el pin de llegada que identifica a que elemento se llega.
        /// </summary>
        public Pin To { get { return _To; } set { _To = value; } }

        string _Label;
        /// <summary>
        /// Devuelve la etiqueta con que se identifica esta coneccion con respecto a otras.
        /// Ejemplo: una condicional tendria dos conecciones, una "Cuando Verdadero" y una "Cuando Falso".
        /// </summary>
        public string Label { get { return _Label; } internal set { _Label = value; } }

        /// <summary>
        /// Permite crear una coneccion. Las conecciones solo pueden 
        /// ser creadas por el tipo ChartElement en el metodo AddConnection. 
        /// Utilice el constructor de su tipo ChartElement para adicionar 
        /// las conecciones de salida de su elemento.
        /// </summary>
        /// <param name="from">Pin de salida de la coneccion.</param>
        /// <param name="to">Pin de llegada de la coneccion, puede ser null.</param>
        internal Connection(Pin from, Pin to)
        {
            this.From = from;
            this.To = to;
           

        }
    }
}
