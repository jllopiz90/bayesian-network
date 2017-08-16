using System;
using System.Collections.Generic;
using System.Collections;
using System.Globalization;
using System.Linq;

namespace RB_Message_Transfer
{
    public class BayesianGraph : Graph<BayesianNode>
    {
        #region Graph methods


        protected List<List<BayesianNode>> Parents;
        public override void AddEdge(BayesianNode from, BayesianNode to)
        {
            if (!Dictionary.ContainsKey(from) || !Dictionary.ContainsKey(to))
                throw new ArgumentException("Argumentos nulos o alguno de ellos no pertenece al grafo");
            Vertexes[Dictionary[from]].Add(to);
            Parents[Dictionary[to]].Add(from);

        }

        public IEnumerable<BayesianNode> Parent(BayesianNode vertex)
        {

            return Parents[Dictionary[vertex]];
        }

        public BayesianNode ParentInIndex(BayesianNode vertex, int index)
        {
            return Parents[Dictionary[vertex]][index];
        }

        public override void AddVertex(BayesianNode newvertex)
        {
            base.AddVertex(newvertex);
            Parents.Add(new List<BayesianNode>());
          
        }

        public BayesianGraph()
        {
            Parents = new List<List<BayesianNode>>();
        }

        #endregion

        public int[] Evidence { get; set; }

        #region Bayesian Network Methods

        /// <summary>
        /// Envia un mensaje del hijo al padre.
        /// Los dos deben pertenecer al grafo
        /// </summary>
        /// <param name="child">Hijo</param>
        /// <param name="parentIndex">  El numero de padre que tiene parent en los padres de child </param>
        private void SendMessageFromChildToParent(BayesianNode child, int parentIndex)
        {

            if (!child.ParentMessagesSended[parentIndex])
            {
                try
                {

                    var parent = Parents[Dictionary[child]][parentIndex];



                    int childIndex = Vertexes[Dictionary[parent]].IndexOf(child);

                    for (int j = 0; j < parent.States; j++)
                    {
                        double sum = 0;

                        double otherParentsMessages = 1.0;
                        for (int childstate = 0; childstate < child.States; childstate++)
                        {
                            double parentRealization = 0;
                            foreach (var configuration in ParentRealizations(child, parentIndex, j))
                            {
                                otherParentsMessages =
                                    child.ParentMessages.AsParallel().Select(configuration).AllExcept(parentIndex).Aggregate(1.0,
                                                                                                                (x, y) =>
                                                                                                                x * y);
                                parentRealization +=
                                    (child.Probabilities.GetElem(new int[1] { childstate }.Concat(configuration).ToArray()) *
                                     otherParentsMessages);
                            }
                            sum += child.Lambda[childstate] * parentRealization;
                        }
                        parent.ChildrenMessages[childIndex][j] = sum;
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
                child.ParentMessagesSended[parentIndex] = true;
            }
           
        }

        private IEnumerable<int[]> ParentRealizations(BayesianNode child, int parentIndex = -1, int parentstate = -1)
        {
            if (parentIndex == -1)
                return ParentRealizations(child.ParentMessages.AsParallel().Select(x => x.Length).ToArray(), 0,
                                          new int[child.ParentMessages.Length]);
            var arr = Enumerable.Repeat(-1, Parents[Dictionary[child]].Count).ToArray();
            arr[parentIndex] = parentstate;
            return ParentRealizations(child.ParentMessages.AsParallel().Select(x => x.Length).ToArray(), 0,
                                      new int[child.ParentMessages.Length], arr);
        }

        private IEnumerable<int[]> ParentRealizations(int[] parentsSates, int pos, int[] realization,
                                                      params int[] setparentsstates)
        {
            if (pos == realization.Length)
            {
                yield return realization;
                yield break;
            }
            if (setparentsstates != null && setparentsstates.Length > pos && setparentsstates[pos] >= 0)
            {
                realization[pos] = setparentsstates[pos];
                foreach (var config in ParentRealizations(parentsSates, pos + 1, realization, setparentsstates))
                    yield return config;
                yield break;
            }
            for (int i = 0; i < parentsSates[pos]; i++)
            {
                realization[pos] = i;
                foreach (var config in ParentRealizations(parentsSates, pos + 1, realization, setparentsstates))
                    yield return config;
            }
        }


        /// <summary>
        /// Envia un mensaje del padre al hijo
        /// </summary>
        /// <param name="parent">Padre</param>
        /// <param name="child">Hijo</param>
        private void SendMessageFromParentToChild(BayesianNode parent, BayesianNode child)
        {
            int childrenIndex = 0;
            childrenIndex = Vertexes[Dictionary[parent]].IndexOf(child);
            if ( !parent.ChildrenMessagesSended[childrenIndex])
            {
                
                try
                {
                    int parentIndex = Parents[Dictionary[child]].IndexOf(parent);
                
                    for (int i = 0; i < parent.States; i++)
                    {
                        double otherChildsMessages =
                            parent.ChildrenMessages.AsParallel().AllExcept(childrenIndex).Select(x => x[i]).Aggregate(1.0, (x, y) => x * y);
                        child.ParentMessages[parentIndex][i] = parent.Ro[i] * otherChildsMessages;
                    }


                }
                catch (Exception e)
                {
                    throw;
                }
                parent.ChildrenMessagesSended[childrenIndex] = true;
            }
        }



        //Asumiendo q en la realizacion el primero sea el estado del nodo
        private void ComputeRo(BayesianNode node)
        {
            var states = new List<int>();
            for (int i = 0; i < node.States; i++)
            {
                states.Clear();
                states.Add(i);
                node.Ro[i] = ComputeRo(ref states, 0, node);
            }





        }

        /// <summary>
        /// Calcula el ro de un nodo
        /// </summary>
        /// <param name="states">la configuracion de los padres. En cada llamada recursiva se establece el estado de un padre</param>
        /// <param name="indexP">el indice del padre que se fa a fijar en un estado en esta llamada recursiva</param>
        /// <param name="node"></param>
        /// <returns></returns>
        private double ComputeRo(ref List<int> states, int indexP, BayesianNode node)
        {

            //cuando completo la realizacion de los padres
            if (indexP >= Parents[Dictionary[node]].Count)
            {
                double parentsmsg = 1.0;
                for (int i = 0; i < node.ParentMessages.Length; i++)
                    parentsmsg *= node.ParentMessages[i][states[i + 1]];

                return node.Probabilities.GetElem(states.ToArray())*parentsmsg;
            }

            BayesianNode parent = Parents[Dictionary[node]][indexP];
            int parentIndex = Dictionary[parent]; //indice en el grafo general del padre de indice indexP


            double sum = 0;
            for (int i = 0; i < parent.States; i++)
            {
                //mezclo la evidencia con la realizacion de los padres del nodo
                if (Evidence[parentIndex] != -1 && Evidence[parentIndex] != i) //si este nodo pertenece a la evidencia
                    continue;
                states.Add(i);
                sum += ComputeRo(ref states, indexP + 1, node);
                states.RemoveAt(states.Count - 1);
            }
            return sum;
        }

        /// <summary>
        /// Calcula el lambda de un nodo.
        /// El lambda es el producto de los mensajes de los hijos
        /// </summary>
        /// <param name="node">El nodo del grafo al que computar el lambda</param>
        private static void ComputeLambda(BayesianNode node)
        {

            for (int i = 0; i < node.Lambda.Length; i++)
            {
                node.Lambda[i] = node.ChildrenMessages.AsParallel().Select(x => x[i]).Aggregate(1.0, (x, y) => x * y);
            }

        }

        /// <summary>
        /// Absorbe la evidencia e inicializa el ro y el lambda 
        /// de los nodos sin padres o sin hijos respectivamente.
        /// </summary>
        /// <param name="evidence"></param>
        public void AbsorbeEvidence(KeyValuePair<BayesianNode, int>[] evidence)
        {

            int index = -1;

            Evidence = new int[Vertexes.Count];
            for (int i = 0; i < Evidence.Length; i++)
                Evidence[i] = -1;

            foreach (var node in this)
            {
                //si no tiene hijos
                if (Vertexes[Dictionary[node]].Count == 0)
                {
                    for (int i = 0; i < node.Lambda.Length; i++)
                    {
                        node.Lambda[i] = 1.0;
                    }
                }
                //si no tiene padres
                if (Parents[Dictionary[node]].Count == 0)
                {
                    for (int j = 0; j < node.Ro.Length; j++)
                    {
                        node.Ro[j] = node.Probabilities.MarginalProbability(j).Sum();
                    }
                }
            }

            foreach (var keyValuePair in evidence)
            {
                //si es un nodo del grafo
                var node = keyValuePair.Key;
                if (Dictionary.TryGetValue(node, out index))
                {
                    node.SetEvidence(keyValuePair.Value);
                    Evidence[Dictionary[keyValuePair.Key]] = keyValuePair.Value;
                }
            }




        }
        
        #endregion
        public void ParalellWork(object obj)
        {
            var node = obj as BayesianNode;
            if (node == null || !Dictionary.ContainsKey(node))
                throw new ArgumentException("El nodo no es de esta red bayesiana");
            do
            {
                Work(obj);
            }
            while (!node.Finished);
        }

        public void Work(object obj)
        {
            var node = obj as BayesianNode;
            if (node == null || !Dictionary.ContainsKey(node))
                throw new ArgumentException("El nodo no es de esta red bayesiana");
            if (!node.Finished)
            {
                if (Vertexes[Dictionary[node]].Count > 0 && Evidence[Dictionary[node]] == -1 
                    && node.CanComputeLambda&&node.Lambda.Any(x=>x<0))
                {
                     ComputeLambda(node);
                   
                }

                if (Parents[Dictionary[node]].Count > 0 && Evidence[Dictionary[node]] == -1 && node.CanComputeRo&&
                    node.Ro.Any(x => x < 0))
                {
                   
                    ComputeRo(node);
                }

                for (int i = 0; i < Parents[Dictionary[node]].Count; i++)
                {
                    //el nodo al que se le envia el mensaje no debe  estar en la evidencia
                    if (node.CanSendParentMessages(i))
                        SendMessageFromChildToParent(node, i);
                }
                for (int i = 0; i < Vertexes[Dictionary[node]].Count; i++)
                {
                    //el nodo al que se le envia el mensaje no puede  estar en la evidencia
                    if (node.CanSendChildMessages(i)) SendMessageFromParentToChild(node, Vertexes[Dictionary[node]][i]);
                }

                if (Evidence[Dictionary[node]] == -1 && node.CanComputeConditionalProbabilities)
                //si no forma parte de la evidencia
                {
                    node.ComputeConditionalProbabilities();
                }

            }
        }



        /// <summary>
        /// Limpia el grafo
        /// </summary>
        public void Clear()
        {
           Vertexes.Clear();
            Parents.Clear();
            Dictionary.Clear();
        }

        public int GetIndex(BayesianNode node)
        {
            if (Dictionary.ContainsKey(node))
                return Dictionary[node];

            return -1;
        }

        public int GetParentIndex(BayesianNode node, BayesianNode parent)
        {
            return Parents[Dictionary[node]].IndexOf(parent);
        }
    } 
    public  static class Extension
        {
            /// <summary>
            /// Devuelve todos los elemementos excepto el de la posicion elementIndex.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="source"></param>
            /// <param name="elementIndex"></param>
            /// <returns></returns>
            public static IEnumerable<T> AllExcept<T>(this IEnumerable<T> source, int elementIndex)
            {
                int count = 0;
                foreach (var item in source)
                {
                    if (count == elementIndex)
                    {
                        count++;
                        continue;
                    }
                    yield return item;
                    count++;
                }
            }

            /// <summary>
            /// Devuelve el iesimo elemento ienumerable de cada una de las colecciones que contiene source.
            /// La longitud de source y de indexes debe coincidir.
            /// </summary>
            /// <param name="source"></param>
            /// <param name="indexes"></param>
            /// <returns></returns>
            public static IEnumerable<T> Select<T>(this IEnumerable<IEnumerable<T>> source, int[] indexes)
            {
                var index = 0;
                foreach (var ienumerable in source)
                {
                    yield return ienumerable.ElementAt(indexes[index]);
                    index++;
                }
            }
        }
}
    
