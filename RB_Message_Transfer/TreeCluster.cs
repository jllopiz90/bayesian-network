using System;
using System.Text;

namespace RB_Message_Transfer
{
   public class TreeCluster : Graph<BayesianClique>
    {
        public override void AddEdge(BayesianClique from, BayesianClique to)
        {
            base.AddEdge(from, to);
            base.AddEdge(to, from);
        }

        public bool RemoveVert(BayesianClique vert)
        {
            if (Dictionary.ContainsKey(vert))
            {
                foreach (var item in Vertexes[Dictionary[vert]])
                    Vertexes[Dictionary[item]].Remove(vert);

                Vertexes.RemoveAt(Dictionary[vert]);
                Vertexes.Insert(Dictionary[vert], null);
                Dictionary.Remove(vert);
                return true;
            }
            return false;
        }
       
        public int IndexNode(BayesianClique node)
        {
            return Dictionary[node];
        }

        public void RemoveEdge(BayesianClique node1, BayesianClique node2)
        {
            Vertexes[Dictionary[node1]].Remove(node2);
            Vertexes[Dictionary[node2]].Remove(node1);
        }

    }
}
