using System;
using System.Collections.Generic;
using System.Text;

namespace FlowChartDesigner
{
    /// <summary>
    /// Orientaciones validas para un pin. (Estos valores identifican la posicion del pin con respecto al elemento en que se encuentra).
    /// </summary>
    [Serializable]
    public enum PinOrientation
    {
        /// <summary>
        /// El pin se encuentra hacia arriba.
        /// </summary>
        Up,
        UpRight,
        Right,
        DownRight,
        Down,
        DownLeft,
        Left,
        UpLeft
    }
}
