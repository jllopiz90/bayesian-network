using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RB_Message_Transfer
{
    [Serializable]
  public  class Evidence
    {
        /// <summary>
        /// cada elemento de la lista es un nodo del grafo 
        /// los elementos de la correspondiente lista interior
        /// son las probabilidades de estar en cada estado.
        /// Evidence[i][j] es la probabilidad de que el nodo i este en el estado j
        /// </summary>
        public double[][] EvidenceValues { get; set; }
        public string[] NodeNames { get; set; }
        public Evidence(List<List<double>> evidence,string[] names)
        {
            EvidenceValues = evidence.Select(x=>x.ToArray()).ToArray();
            NodeNames = names;
        }
        public Evidence(double[][] evidence, string[] names)
        {
            EvidenceValues = evidence;
            NodeNames = names;
        }
        /// <summary>
        /// Crea un objeto de evidencia para tantos 
        /// nodos como elementos tenga el array statespernode 
        /// y cada nodo con tantos estados como statespernode[i]
        /// </summary>
        /// <param name="statespernode"></param>
        public Evidence(int[] statespernode,string[] names)
        {
            EvidenceValues = new double[statespernode.Length][];
            for (int i = 0; i < statespernode.Length; i++)
            {
                EvidenceValues[i] = new double[statespernode[i]];
            }
            NodeNames=names;

        }

        public Evidence()
        {
            
        }
       

        public Evidence Clone()
        {
            var values = new double[EvidenceValues.Length][];
            for (int i = 0; i < values.Length; i++)
            {
                values[i]=new double[EvidenceValues[i].Length];
                for (int j = 0; j < EvidenceValues[i].Length; j++)
                {
                    values[i][j] = EvidenceValues[i][j];
                }
            }
            return new Evidence(values,(string[])NodeNames.Clone());
        }
    }

}
