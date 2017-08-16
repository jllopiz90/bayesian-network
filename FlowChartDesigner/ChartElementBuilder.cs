using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FlowChartDesigner
{
    /// <summary>
    /// Representa un objeto capaz de crear nuevos elementos de un diagrama.
    /// </summary>
    public abstract class ChartElementBuilder
    {
        /// <summary>
        /// Devuelve el nombre del elemento que es capaz de crear.
        /// </summary>
        public abstract string BuilderName { get; }

        Point _Center;
        /// <summary>
        /// Devuelve o establece el punto que sera usado para posicionar el elemento creado.
        /// </summary>
        public Point Center { get { return _Center; } set { _Center = value; } }

        /// <summary>
        /// Construye una nueva instancia de un elemento y lo devuelve.
        /// </summary>
        /// <returns>Un objeto de tipo ChartElement.</returns>
        public abstract ChartElement Build();
    }
}
