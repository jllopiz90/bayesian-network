using System;
using System.Collections.Generic;
using System.Text;

namespace FlowChartDesigner
{
    /// <summary>
    /// Representa una coleccion fija de pines.
    /// </summary>
  [Serializable]
    public class PinCollection : IEnumerable<Pin>
    {
        /// <summary>
        /// Array unidimensional con los pines de la coleccion.
        /// </summary>
        Pin[] pins;

        /// <summary>
        /// Inicializa una coleccion de pines de cierto tipo, para determinado elemento.
        /// </summary>
        /// <param name="chart">Elemento poseedor de los pines.</param>
        /// <param name="count">Cantidad de pines de la coleccion.</param>
        /// <param name="type">Tipo de pin de la coleccion.</param>
        public PinCollection(ChartElement chart, int count, PinType type)
        {
            this.pins = new Pin[count];
            for (int i = 0; i < this.pins.Length; i++)
                this.pins[i] = new Pin(chart, i, type);
        }

        /// <summary>
        /// Devuelve la cantidad de pines de esta coleccion.
        /// </summary>
        public int Count { get { return pins.Length; } }

        /// <summary>
        /// Devuelve el index-esimo elemento de la coleccion.
        /// </summary>
        public Pin this[int index]
        {
            get
            {
                if (index >= pins.Length) throw new IndexOutOfRangeException();
                return pins[index];
            }
            set
            {
                if (index >= pins.Length) throw new IndexOutOfRangeException();
                if(value!=null)
                pins[index] = value;
            }
        }

        /// <summary>
        /// Devuelve un iterador de los pines de esta coleccion.
        /// </summary>
        public IEnumerator<Pin> GetEnumerator()
        {
            return ((IEnumerable<Pin>)pins).GetEnumerator();
        }

        /// <summary>
        /// Devuelve un iterador de los pines de esta coleccion.
        /// </summary>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
