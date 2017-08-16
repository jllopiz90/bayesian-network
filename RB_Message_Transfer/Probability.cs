using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RB_Message_Transfer
{
    /// <summary>
    /// Este objeto guarda las probabilidades condicionales. 
    /// La forma de guardar es la sigte:
    /// Si el nodo tiene N padres con N1,N2 ... Nm 
    /// estados respectivamente las probabilidades
    /// de este nodo dado que los padres tienen la configuracion (N1=n1,N2=n2...Nm=nm)
    /// esta se obtiene mediante el metodo GetElem pasando los valores de los estados de los padres en el array  y como ultimo valor del array el estado  del nodo del que se desea conocer la probabilidad
    /// </summary>
    [Serializable]
    public class Probability : IEnumerable<double>,ICondictionalProbability
    {
        private readonly double[] _probabilities;

        private readonly int[] _parentsNumberOfStates;//el numero de estados de cada padre el ultimo valor es el de los estados del nodo actual

        private int[] productos;

        /// <summary>
        /// Implementa una interfaz para el manejo de las probabilidades condicionales
        /// </summary>
        /// <param name="arr">las probabilidades</param>
        /// <param name="parentsNumberOfStates">La cantidad de estados de cada padre.La primera posicion es la cant de estados del nodo actual</param>
        public Probability(double[] arr, int[] parentsNumberOfStates)
        {
            _probabilities = arr;
            _parentsNumberOfStates = parentsNumberOfStates;
            productos = new int[parentsNumberOfStates.Length];
            if (arr.Length != parentsNumberOfStates.Aggregate(1, (x, y) => x * y)) throw new ArgumentException("No coincide los numeros de estados de los padres con el tamano del array ");
            int prod = 1;
            for (int i = parentsNumberOfStates.Length -2; i >= 0; i--)
            {
                prod *= parentsNumberOfStates[i];
                productos[i] = prod;
            }
            productos[productos.Length - 1] = 1;
        }
        /// <summary>
        /// Devuelve el valor de la probabilidad condicional de este nodo dado una onfiguracion de los padres.
        /// </summary>
        /// <param name="parentStates">La configuracion de los padres.El primer valor de este array es el estado del nodo actual</param>
        /// <returns></returns>
        public double GetElem(int[] parentStates)
        {
            if (parentStates.Length != _parentsNumberOfStates.Length) throw new ArgumentException("La cant de padres no coincide");

            int index = 0;
            for (int i = 0; i < parentStates.Length; i++)
                index += parentStates[i] * productos[i];

            return _probabilities[index];
        }

        public double this[int index]
        {
            get { return _probabilities[index]; }

       }

        public IEnumerator<double> GetEnumerator()
        {
            return (IEnumerator<double>) _probabilities.GetEnumerator();
        }

        /// <summary>
        /// Devuelve todos los elementos de la tabla tales que el padre parent siempre esta en el estado state
        /// </summary>
       
        /// <param name="nodestates">La configuracion de los estados de los nodos a calcular la probabilidad marginal.
        /// La i-esima posicion se pone el estado en que se va a fijar el nodo i-esimo (si se fija en alguno)
        /// Si no tiene un valor fijo entonces tendra -1 </param>
        /// <returns></returns>
        public IEnumerable<double> MarginalProbability(params int[] nodestates)
        {
            if (nodestates.Length < _parentsNumberOfStates.Length)
                nodestates =
                    nodestates.Concat(Enumerable.Repeat(-1, _parentsNumberOfStates.Length - nodestates.Length)).ToArray();

            return Marginals(new int[_parentsNumberOfStates.Length], nodestates, 0);

        }
        IEnumerable<double> Marginals(int[] states,int[] nodeStates,int pos)
        {
            if (pos == nodeStates.Length)
            {
                yield return GetElem(states);
                yield break;
            }

            if (nodeStates[pos]<0)
            {
                for (int i = 0; i < _parentsNumberOfStates[pos]; i++)
                {
                    states[pos] = i;
                    foreach (var variable in Marginals(states, nodeStates, pos + 1))
                    {
                        yield return variable;
                    }
                }
            }
            else
            {
                states[pos] = nodeStates[pos];
                foreach (var variable in Marginals(states, nodeStates, pos + 1))
                {
                    yield return variable;
                }
            }
           
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #region ICondictionalProbability Members


        public int[] ParentStates()
        {
            return _parentsNumberOfStates;
        }

        #endregion

      

      
    }
}
