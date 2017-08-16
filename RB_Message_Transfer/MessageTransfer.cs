using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Text;

namespace RB_Message_Transfer
{
    public static class MessageTransfer
    {
        static int paralell = 2;
       
        public static int ParalellStartNumber
        {
            get
            {
                return paralell;
            }
            set
            {
                if (value <= 0) throw new ArgumentException();
                paralell = value;
            }
        }
        /// <summary>
        /// Metodo que calcula, mediante el traspaso de mensajes en un poliarbol,
        /// las probabilidades condicionales de un nodo dada la evidencia.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="poliarbol"></param>
        /// <param name="evidence">Tiene tantos elementos como nodos el poliarbol.
        /// En la posicion i-esima guarda el valor del estado de la variable i si esta forma parte de la evidencia; 
        /// -1 en otro caso. 
        /// </param>

        
        public static void Message_Tranfer_Poliarbol(BayesianGraph poliarbol, Evidence evidence)
        {
            Generic(evidence, poliarbol, null);
        } 
        public static void Message_Tranfer_Arbol_Union(MarkovNet arboldeunion, Evidence evidence )
        {
           Generic(evidence,null,arboldeunion);



        }
        static void Generic(Evidence evidence, BayesianGraph poliarbol, MarkovNet arboldeunion)
        {
            //tamanno del grafo sea poliarbol o de racimos
            var count = poliarbol == null
                            ? arboldeunion.Count
                            : poliarbol.Count;
           double realization_probalility = 1.0;
           var nodesConditionalProbabilities = new double[count][];

           var bayesianGraph = poliarbol ?? arboldeunion.BayesianNet;
            bool traspasoEnPoliarbol = poliarbol != null;


           if (evidence == null) return;

           var deterministicEvidence = new KeyValuePair<BayesianNode, int>[evidence.EvidenceValues.Length];
           //absorber evidencia
           //no hay evidencia
           for (int i = 0; i < count; i++)
               deterministicEvidence[i] = new KeyValuePair<BayesianNode, int>(bayesianGraph[i], -1);

           for (int j = 0; j < count; j++)
               nodesConditionalProbabilities[j] = new double[bayesianGraph[j].ConditionalProbability.Length];
           bool stocasticrealizations = false;

           foreach (var item in EvidenceRealization(evidence, deterministicEvidence, 0))
           {
               
               stocasticrealizations = true;
               if (traspasoEnPoliarbol)
                   Message_Tranfer_Poliarbol(poliarbol, item.Item1);
               else
                   Message_Tranfer_Arbol_Union(arboldeunion, item.Item1);
              
               realization_probalility = item.Item2;
               
               for (int i = 0; i < nodesConditionalProbabilities.Length; i++)
                   for (int j = 0; j < nodesConditionalProbabilities[i].Length; j++)
                   {
                       nodesConditionalProbabilities[i][j] += bayesianGraph[i].ConditionalProbability[j] * realization_probalility;
                   }
              
           }
           //si no hubo evidencia estocastica es que se esta solicitando el traspaso de 
           //msges sin evidencia
           if (stocasticrealizations)
           {

               for (int i = 0; i < nodesConditionalProbabilities.Length; i++)
                   for (int j = 0; j < nodesConditionalProbabilities[i].Length; j++)
                       bayesianGraph[i].ConditionalProbability[j] = nodesConditionalProbabilities[i][j];
           }
           else
           {
               if (traspasoEnPoliarbol)
                   Message_Tranfer_Poliarbol(poliarbol, deterministicEvidence);
               else
                   Message_Tranfer_Arbol_Union(arboldeunion, deterministicEvidence);

           }
        }

       
       
        /// <summary>
        /// Realiza todas las realizaciones de una evidencia estocastica
        /// </summary>
        /// <param name="evidence"></param>
        /// <param name="realization"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        static IEnumerable<Tuple<KeyValuePair<BayesianNode, int>[],double>> EvidenceRealization(Evidence evidence, KeyValuePair<BayesianNode, int>[] realization, int pos,double probability=1.0)
        {
            if (pos == realization.Length)
            {
                if(realization.Any(x=>x.Value>=0))
                yield return new Tuple<KeyValuePair<BayesianNode, int>[], double>(realization,probability);
                
                yield break;
            }
            //en cada paso recursivo se escoge un nodo para su seleccion de estado
            //por cada probabilidad de estar en un estado de el nodo en la posicion pos
            bool outofevidence = true;
            for (int i = 0; i < evidence.EvidenceValues[pos].Length; i++)
            {
                
                if (evidence.EvidenceValues[pos][i] > 0)
                {
                    realization[pos] = new KeyValuePair<BayesianNode, int>(realization[pos].Key, i);
                    outofevidence = false;
                    var p = probability*evidence.EvidenceValues[pos][i];
                    foreach (var item in EvidenceRealization(evidence, realization, pos + 1,p))
                        yield return item;
                }
                
            }
            //si no esta en la evidencia entonces relization[pos]=bayesiannode,-1
            if(outofevidence)
                foreach (var item in EvidenceRealization(evidence, realization, pos + 1,probability))
                    yield return item;

        }

        public static void Message_Tranfer_Arbol_Union(MarkovNet arboldeunion, KeyValuePair<BayesianNode, int>[] evidence = null)
        {
            //absorber evidence
            if (evidence != null && evidence.Length > 0)
            {
                arboldeunion.BayesianNet.Evidence = evidence.Select(x => x.Value).ToArray();
            }
            if (arboldeunion.Count > ParalellStartNumber)
            {
                #region ParalellAlgorithm

                var actions = new TaskFactory();
                
                for (int i = 0; i < arboldeunion.Count; i++)
                {
                    new Thread(new ParameterizedThreadStart(arboldeunion.Work)).Start();
                }
                System.Threading.Thread.CurrentThread.Join();



                #endregion
            }
            else
                #region DeterministicAlgorithm
                while (!arboldeunion.All(x => x.CanComputeProbability))
                    for (int i = 0; i < arboldeunion.Count; i++)
                        arboldeunion.Work(arboldeunion[i]); 
                #endregion

        }
       

        public static void Message_Tranfer_Poliarbol(BayesianGraph poliarbol, KeyValuePair<BayesianNode, int>[] evidence = null)
        {
            
            foreach (var item in poliarbol)
            {
                item.Inicialize();
            
            }
            //fijar la evidencia

            evidence=evidence??new KeyValuePair<BayesianNode, int>[0];
            poliarbol.AbsorbeEvidence(evidence);

            if (poliarbol.Count > ParalellStartNumber)
            {
                #region PararellAlgorithm
               Task[] tareas=new Task[poliarbol.Count];
                for (int i = 0; i < poliarbol.Count; i++)
                {
                    tareas[i]=new Task(poliarbol.Work,poliarbol[i]);
                    tareas[i].Start();
                }
                Task.WaitAll(tareas);

                #endregion
            }
            else
                #region DeterministicAlgorithm
                while (!poliarbol.All(x => x.Finished))
                    for (int i = 0; i < poliarbol.Count; i++)
                        poliarbol.Work(poliarbol[i]); 
                #endregion



        }
    }
}
