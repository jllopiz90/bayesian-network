using System.Collections.Generic;
using System.Linq;
using System;

namespace RB_Message_Transfer
{
    public class MarkovNet : IEnumerable<BayesianClique>
    {
        public BayesianGraph BayesianNet { get; private set; }
        public TreeCluster TreeCluster { get; private set; }

        public MarkovNet(BayesianGraph bayesianNet)
        {
            this.BayesianNet = bayesianNet;
            TreeCluster = new TreeCluster();
            FirstTreeCluster();
            TransformTreeCluster();
            CheckSubConj();
            foreach (var clique in TreeCluster)
            {
                clique.Inicialize(TreeCluster.AdjCount(clique));
            }

        }

        public BayesianClique this[int index]
        {
            get { return TreeCluster[index]; }

        }


        private void ComputeProbability(BayesianClique Ci)
        {
            List<int> Ci_realizacion = new List<int>();
            ComputeProbability(Ci, ref Ci_realizacion);

            var normalization = 1 / Ci.ConditionalProbability.Values.Sum();

            for (int i = 0; i < Ci.ConditionalProbability.Count; i++)
            {
                var key = Ci.ConditionalProbability.Keys.ToList()[i];
                var value = Ci.ConditionalProbability.Values.ToList()[i];
                Ci.ConditionalProbability.Remove(key);
                var valueround = Math.Round(value * normalization, 3);
                Ci.ConditionalProbability.Add(key, valueround);
            }
        }

        private void ComputeProbability(BayesianClique Ci, ref List<int> Ci_realizacion)
        {
            if (Ci_realizacion.Count == Ci.Nodes.Count)
            {
                double msgs = 1.0;
                foreach (var neighbor in TreeCluster.Adjacent(Ci))
                {
                    List<int> Sji = Intersectionij(Ci, neighbor);
                    List<int> realizacion_Sji = new List<int>();
                    foreach (var item in Sji)
                        realizacion_Sji.Add(Ci_realizacion[item]);
                    msgs *= Ci.NeighborMsg[neighbor][ListToString(realizacion_Sji)];
                }


                Ci.ConditionalProbability.Add(ListToString(Ci_realizacion), msgs * Fi(Ci, Ci_realizacion));
            }
            else
            {
                for (int i = 0; i < Ci.Nodes[Ci_realizacion.Count].States; i++)
                {
                    Ci_realizacion.Add(i);
                    ComputeProbability(Ci, ref Ci_realizacion);
                    Ci_realizacion.RemoveAt(Ci_realizacion.Count - 1);
                }
            }
        }

        /// <summary>
        /// Manda un msg de un nodo a un vecino
        /// </summary>
        /// <param name="from">Nodo que manda el msg</param>
        /// <param name="to">Vecino que recibe el msg</param>
        private void SendMsgToNeighbor(BayesianClique from, BayesianClique to)
        {
            int Sijcount = Intersectionij(from, to).Count;
            List<int> Sij_realizacion = new List<int>();
            SendMsgToNeighbor(from, to, ref Sij_realizacion, Sijcount);
        }

        /// <summary>
        /// Manda un msg de un nodo a un vecino
        /// </summary>
        /// <param name="from">Nodo que manda el msg</param>
        /// <param name="to">Vecino que recibe el msg</param>
        /// <param name="Sij">Realizacion de la interseccion entre los nodos </param>
        private void SendMsgToNeighbor(BayesianClique from, BayesianClique to, ref List<int> Sij_realizacion, int Sijcount)
        {
            if (Sij_realizacion.Count == Sijcount)
            {
                List<int> Ci_realizacion = new List<int>();
                List<int> aux = new List<int>(Sijcount);
                foreach (var i in Sij_realizacion)
                    aux.Add(i);

                SendMsg(from, to, aux, ref Ci_realizacion);
            }
            else
            {
                List<int> Sij = Intersectionij(from, to);
                for (int i = 0; i < from.Nodes[Sij[Sij_realizacion.Count]].States; i++)
                {
                    Sij_realizacion.Add(i);
                    SendMsgToNeighbor(from, to, ref Sij_realizacion, Sijcount);
                    Sij_realizacion.RemoveAt(Sij_realizacion.Count - 1);
                }
            }
        }


        private void SendMsg(BayesianClique from, BayesianClique to, List<int> Sij_realizacion, ref List<int> Ci_realizacion)
        {
            if (Ci_realizacion.Count == from.Nodes.Count) //si tengo una real de Ci
            {
                double othersmsg = 1.0;
                foreach (var neigh in TreeCluster.Adjacent(from))
                {
                    if (neigh == to) //si el vecino es al q le estoy mandando el msg
                        continue;
                    List<int> Ski = Intersectionij(from, neigh);
                    List<int> realizacion_Ski = new List<int>();
                    foreach (var item in Ski)
                        realizacion_Ski.Add(Ci_realizacion[item]); //obtengo Ski
                    othersmsg *= from.NeighborMsg[neigh][ListToString(realizacion_Ski)];
                }

                double msg = Fi(from, Ci_realizacion) * othersmsg;
                if (!to.NeighborMsg.ContainsKey(from))// si es el primer msg quemanda node a neighbor
                {
                    to.NeighborMsg.Add(from, new Dictionary<string, double>());
                    to.NeighborMsg[from].Add(ListToString(Sij_realizacion), msg);
                }
                else
                {
                    if (!to.NeighborMsg[from].ContainsKey(ListToString(Sij_realizacion))) // si es el primer msg que manda node a neighbor 
                        to.NeighborMsg[from].Add(ListToString(Sij_realizacion), msg);   // con esta realizacion de Sij
                    else
                        to.NeighborMsg[from][ListToString(Sij_realizacion)] += msg;
                }
            }
            else
            {
                List<int> Sij = Intersectionij(from, to);
                if (Sij.Contains(Ci_realizacion.Count)) // si el nodo que toca en la realizacion de Ci pertenece a Sij no lo vario
                {
                    Ci_realizacion.Add(Sij_realizacion[Sij.IndexOf(Ci_realizacion.Count)]);
                    SendMsg(from, to, Sij_realizacion, ref Ci_realizacion);
                    Ci_realizacion.RemoveAt(Ci_realizacion.Count - 1);
                }
                else
                {
                    for (int i = 0; i < from.Nodes[Ci_realizacion.Count].States; i++)
                    {
                        Ci_realizacion.Add(i);
                        SendMsg(from, to, Sij_realizacion, ref Ci_realizacion);
                        Ci_realizacion.RemoveAt(Ci_realizacion.Count - 1);
                    }
                }
            }
        }

        private string ListToString(IEnumerable<int> list)
        {
            string result = "";
            foreach (var i in list)
                result += i.ToString() + ".";

            return result;
        }
        private List<int> StringToList(string str)
        {

            string[] aux = str.Split(new char[] { '.' });
            List<int> result = new List<int>();
            for (int i = 0; i < aux.Length - 1; i++)
                result.Add(int.Parse(aux[i]));

            return result;

        }

        public void ParalellWork(BayesianClique clique)
        {
            while (!clique.CanComputeProbability)
                do
                {
                    Work(clique);
                } while (!clique.CanComputeProbability);

        }  

        public void Work(object clique1)
        {
            var clique = (BayesianClique)clique1;
            foreach (var adj in TreeCluster.Adjacent(clique).Where(x => !clique.MsgSended(x) && clique.CanSendMesg(x)))
                SendMsgToNeighbor(clique, adj);


            if (clique.CanComputeProbability)
                ComputeProbability(clique);

        }

        private bool AllMsgSended(BayesianClique clique)
        {
            foreach (var adj in TreeCluster.Adjacent(clique))
                if (!adj.MsgSended(adj))
                    return false;

            return true;

        }
        /// <summary>
        /// Devuelve si ya todos los nodos pueden calcular sus probabilidades condicionales
        /// </summary>
        /// <returns></returns>
        public bool AllConditionalProbabilitiesComputed()
        {
            return TreeCluster != null && TreeCluster.All(x => x.ProbabilityDone);
        }

        public void Marginalize_X(BayesianNode Xj)
        {
            BayesianClique Ci = null;
            int min = int.MaxValue;

            foreach (var c in TreeCluster)
                if (c.Nodes.Contains(Xj) && c.Nodes.Count < min)
                    Ci = c;
            if (Ci != null)
                Marginalize_Xj(Xj, Ci);
        }

        private void Marginalize_Xj(BayesianNode Xj, BayesianClique Ci)
        {
            if (TreeCluster == null) ;
            //var clique = TreeCluster.Aggregate(default(BayesianClique), (x, y) => (x == null || y.Nodes.Contains(Xj) && y.Nodes.Count < x.Nodes.Count) ? y : x);

            //if (clique == default(BayesianClique)) throw new Exception("El nodo no pertenece al arbol de union");
            //var index = clique.Nodes.IndexOf(Xj);
            var index = Ci.Nodes.IndexOf(Xj);
            for (int i = 0; i < Xj.ConditionalProbability.Length; i++)
            {
                Xj.ConditionalProbability[i] = Math.Round(Ci.ConditionalProbability.Where(x => StringToList(x.Key)[index] == i).Select(y => y.Value).Sum(), 3);
            }
        }

        /// <summary>
        /// Retorna los indices en el clique i en los que estan los nodos de la interseccion con j 
        /// </summary>
        /// <param name="i">Clique i</param>
        /// <param name="j">Clique j</param>
        /// <returns></returns>
        private List<int> Intersectionij(BayesianClique i, BayesianClique j)
        {
            List<int> result = new List<int>();
            IEnumerable<BayesianNode> inters = i.Nodes.Intersect(j.Nodes);
            foreach (var item in inters)
            {
                result.Add(i.Nodes.IndexOf(item));
            }
            return result;
        }

        /// <summary>
        /// Funcion exponencial de el clique Ci
        /// </summary>
        /// <param name="Ci">Clique sobre el que esta definido la funcion </param>
        /// <param name="states">Realizacion de los nodos del clique </param>
        /// <returns>Retorna el resultado de la funcion exponencial de Ci dado una realizacion </returns>
        public double Fi(BayesianClique Ci, List<int> states) //pongo este met aqui pq me hace falta saber el indice de cada nodo para buscar en la evidencia
        {
            double result = 1;

            //revisando evidencia
            if (BayesianNet.Evidence != null)
            {
                for (int i = 0; i < Ci.Nodes.Count; i++) //tener en cuenta que en un clique solo va estar un nodo y su padres, ver la forma de construir el arbol de U si se tiene dudas
                {
                    if (states[i] != BayesianNet.Evidence[BayesianNet.GetIndex(Ci.Nodes[i])] &&
                        BayesianNet.Evidence[BayesianNet.GetIndex(Ci.Nodes[i])] >= 0)
                        return 0;
                }
            }

            List<int> aux = new List<int>();
            aux.Add(states[0]);
            foreach (var parent in Ci.Nodes)
                if (BayesianNet.Parent(Ci.Nodes[0]).Contains(parent))
                    aux.Add(states[BayesianNet.GetParentIndex(Ci.Nodes[0], parent) + 1]);

            result *= Ci.Nodes[0].Probabilities.GetElem(aux.ToArray());

            for (int i = 1; i < Ci.Representativos.Count; i++)
            {
                int parentindex = BayesianNet.GetParentIndex(Ci.Nodes[0], Ci.Representativos[i]);
                int[] stats = new int[Ci.Representativos[i].ParentMessages.Length + 1];
                stats[0] = states[parentindex + 1];
                for (int k = 1; k < stats.Length; k++)
                {
                    parentindex = BayesianNet.GetParentIndex(Ci.Nodes[0], BayesianNet.ParentInIndex(Ci.Representativos[i], k - 1));
                    stats[k] = states[parentindex + 1];
                }
                result *= Ci.Representativos[i].Probabilities.GetElem(stats);
            }

            return result;
        }

        /// <summary>
        /// Crea el primer grafo de racimos
        /// </summary>
        void FirstTreeCluster()
        {
            BayesianClique temp;
            var listnode = new List<BayesianNode>();
            foreach (var node in BayesianNet)
            {
                listnode.Clear();
                listnode.Add(node);
                listnode.AddRange(BayesianNet.Parent(node));
                temp = new BayesianClique();
                temp.Name = node.Name;
                temp.Nodes = new List<BayesianNode>();
                temp.Nodes.AddRange(listnode);
                temp.Representativos = new List<BayesianNode>();
                temp.Representativos.Add(node);
                TreeCluster.AddVertex(temp);

                //poniendo las aristas, recordar que la red markov es no dirigido
                foreach (var adj in BayesianNet.Adjacent(node))
                {
                    BayesianClique adjcliq = Clique(adj.Name, TreeCluster);
                    if (adjcliq != null)
                        TreeCluster.AddEdge(temp, adjcliq);

                }
                foreach (var parent in BayesianNet.Parent(node))
                {
                    BayesianClique parentcliq = Clique(parent.Name, TreeCluster);
                    if (parentcliq != null)
                        TreeCluster.AddEdge(temp, parentcliq);
                }
            }
            CheckSubConj();
        }

        /// <summary>
        /// Realiza transformaciones en el grafo de racimos hasta convertirlo en un arbol de union
        /// </summary>
        void TransformTreeCluster()
        {
            BayesianClique node1;
            BayesianClique node2;
            BayesianClique node3;
            while (FindCicle(out node1, out node2, out node3))
            {
                TreeCluster.RemoveEdge(node1, node2);
                node3.Nodes.AddRange(node1.Nodes.Intersect(node2.Nodes));
                if(!TreeCluster.Adjacent(node2).Contains(node3))
                    TreeCluster.AddEdge(node2, node3); 
            }
        }

        /// <summary>
        /// Verifica que un clique no sea subconjunto de otro
        /// </summary>
        void CheckSubConj()
        {
            IEnumerable<BayesianClique> treeaux = TreeCluster.ToList();

            foreach (var clique in treeaux)
            {
                IEnumerable<BayesianClique> adjsaux = TreeCluster.Adjacent(clique).ToList();
                foreach (var adjcliq in adjsaux)
                {
                    if (ContainConj(clique.Nodes, adjcliq.Nodes))
                    {
                        foreach (var ad in TreeCluster.Adjacent(adjcliq))
                            TreeCluster.AddEdge(clique, ad);

                        foreach (var c in adjcliq.Representativos)
                        {
                            if (!clique.Representativos.Contains(c))
                                clique.Representativos.Add(c);
                        }
                        TreeCluster.RemoveVert(adjcliq);
                    }
                    else if (ContainConj(adjcliq.Nodes, clique.Nodes))
                    {
                        foreach (var ad in TreeCluster.Adjacent(clique))
                            if (!ad.Equals(adjcliq))
                                TreeCluster.AddEdge(adjcliq, ad);
                        foreach (var c in clique.Representativos)
                        {
                            if (!adjcliq.Representativos.Contains(c))
                                adjcliq.Representativos.Add(c);
                        }
                        TreeCluster.RemoveVert(clique);
                        break;
                    }

                }

            }
        }

        /// <summary>
        /// Dado dos conjuntos de nodos verifica si una esta contenido dentro del otro
        /// </summary>
        /// <param name="container"> conjunto que podria ser el superconjunto</param>
        /// <param name="subc"> conjunto que podria ser el subconjunto</param>
        /// <returns></returns>
        bool ContainConj(IEnumerable<BayesianNode> container, IEnumerable<BayesianNode> subc)
        {
            foreach (var item in subc)
            {
                if (!container.Contains(item))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Busca si un clique pertenece a un grafo
        /// </summary>
        /// <param name="name">nombre del nodo a buscar</param>
        /// <param name="cliques"> grafo en el que buscar</param>
        /// <returns>el clique si lo encuentra y null en otro caso </returns>
        BayesianClique Clique(string name, Graph<BayesianClique> cliques)
        {
            foreach (var node in cliques)
            {
                if (node.Name == name)
                    return node;
            }
            return null;
        }

        bool FindCicle(out BayesianClique node1, out BayesianClique node2, out BayesianClique node3)
        {
            bool[] visit = new bool[TreeCluster.Count];

            return DFS_M(out node1, out node2, out node3, TreeCluster.First(), null, ref visit);
        }

        bool DFS_M(out BayesianClique node1, out BayesianClique node2, out BayesianClique node3, BayesianClique node, BayesianClique ant, ref bool[] Visit)
        {
            Visit[TreeCluster.IndexNode(node)] = true;
            foreach (var adj in TreeCluster.Adjacent(node))
            {
                if (adj.Equals(ant))
                    continue;

                if (Visit[TreeCluster.IndexNode(adj)] == false)
                {
                    if (DFS_M(out node1, out node2, out node3, adj, node, ref Visit))
                        return true;
                }
                else
                {
                    node1 = node;
                    node2 = adj;
                    node3 = ant;
                    return true;
                }
            }
            node1 = null;
            node2 = null;
            node3 = null;
            return false;
        }


        #region IEnumerable<BayesianClique> Members

        public IEnumerator<BayesianClique> GetEnumerator()
        {
            return TreeCluster.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return TreeCluster.GetEnumerator();
        }

        #endregion

        public int Count { get { return TreeCluster.Count; } }
    }
}