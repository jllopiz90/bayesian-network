using System.Collections.Generic;
using System.Linq;

namespace RB_Message_Transfer
{
    public class BayesianClique
    {
        public List<BayesianNode> Nodes { get; set; }
        public List<BayesianNode> Representativos { get; set; }
        public Dictionary<BayesianClique, Dictionary<string, double>> NeighborMsg { get; private set; }
        public string Name { get; set; }
        int cantneighbors;
        
        public void Inicialize(int cantNeighbors)
        {
            ConditionalProbability = new Dictionary<string, double>();
            NeighborMsg = new Dictionary<BayesianClique, Dictionary<string, double>>(cantNeighbors);
            cantneighbors = cantNeighbors;
        }
               

        public bool CanSendMesg(BayesianClique neighbor)
        {
            return (NeighborMsg.Count==cantneighbors || (NeighborMsg.Count==cantneighbors-1 && !NeighborMsg.ContainsKey(neighbor)));
        }

        public bool MsgSended(BayesianClique neighbor)
        {
            return neighbor.NeighborMsg.ContainsKey(this);
        }
                

        public bool ProbabilityDone
        {
            get { return ConditionalProbability.Count > 0; }
        }


        public bool CanComputeProbability
        {
            get { return NeighborMsg.Count==cantneighbors; }
        }

        public Dictionary<string, double> ConditionalProbability { get; private set; }

    }
}