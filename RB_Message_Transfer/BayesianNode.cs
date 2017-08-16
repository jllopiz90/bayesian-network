using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RB_Message_Transfer
{
   
    
    public class BayesianNode
    {
        #region Instance Variables
        public string Name { get; set; }

        /// <summary>
        /// Los mensajes enviados por los padres del nodo.
        /// En la posicion [i][j] se guarda el mensaje enviado por el padre i en el estado j.
        /// Es un array multiple porque no es necesario que todos los nodos tengan la misma cant de estados.
        /// </summary>
        public double[][] ParentMessages { get; private set; }

        /// <summary>
        /// Los mensajes enviados por los hijos del nodo.
        /// En la posicion [i][j] se guarda el mensaje enviado por el hijo i al estado j de este nodo.
        /// Es un array multiple porque no es necesario que todos los nodos tengan la misma cant de estados.
        /// </summary>
        public double[][] ChildrenMessages { get; private set; }

        /// <summary>
        /// La expresion ro en la formula de probabilidad condicional dada la evidencia.
        /// Si no ha sido calculada su valor es -1 para cada estado.
        /// </summary>
        public double[] Ro { get; private set; }

        /// <summary>
        /// La expresion Lambda en la formula de probabilidad condicional dada la evidencia.
        /// Si no ha sido calculada su valor es -1 para cada estado..
        /// </summary>
        public double[] Lambda { get; private set; }

        /// <summary>
        /// La  probabilidad condicional del nodo dado los padres
        /// </summary>
        public ICondictionalProbability Probabilities { get; set; }


        /// <summary>
        ///La  probabilidad condicional dada la evidencia.Si no ha sido calculada su valor es -1 en cada estado.
        /// </summary>
        public double[] ConditionalProbability { get; private set; } 
        #endregion


        #region MessageTransferMethods


        public bool CanComputeLambda
        {
            get { return ChildrenMessages.All((x) => x.All((y) => y >= 0)); }
        }

        public bool CanComputeRo
        {
            get { return ParentMessages.All((x) => x.All((y) => y >= 0)); }
        }

        public bool CanComputeConditionalProbabilities
        {
            get { return Lambda.All(x => x >= 0) && Ro.All(x => x >= 0); }
        }
    
        public bool CanSendParentMessages(int parentIndex)
        {
            return Lambda.All(x => x >= 0) && ParentMessages.AllExcept(parentIndex).All(y => y.All(z => z >= 0));
        }

        public bool CanSendChildMessages(int childIndex)
        {
            return Ro.All(x => x >= 0) && ChildrenMessages.AllExcept(childIndex).All(y => y.All(z => z >= 0));
        }

        public bool[] ParentMessagesSended { get; private set; }
        public bool[] ChildrenMessagesSended { get; private set; }
        bool finished;
        public bool Finished
        {
            get
            {
                if (finished) return true;
                if (ConditionalProbability.All(x => x >= 0) && ParentMessagesSended.All(x => x) && ChildrenMessagesSended.All(x => x))
                    finished = true;
                return finished;
            }
        }

        #endregion

       
        /// <summary>
        /// Si este nodo pertenece a la evidencia
        /// se actuaiza su probabilidad condicional mediante este metodo.
        /// La probabilidad condicional de cada estado es 0 excepto en el de la evidencia que es 1
        /// </summary>
        /// <param name="state">estado en que se encuentra este nodo daod la evidencia</param>
        public void SetEvidence(int state)
        {
            if(state<0) return;
            if (state >= ConditionalProbability.Length) throw new ArgumentOutOfRangeException();

            for (int i = 0; i < ConditionalProbability.Length; i++)
                ConditionalProbability[i] = (i == state) ? 1.0 : 0.0;

            for (int i = 0; i < Ro.Length; i++)
            {
                Ro[i] = (i == state) ? 1.0 : 0;
                Lambda[i] = (i == state) ? 1.0 : 0;
            }
        }
    

       

        public void ComputeConditionalProbabilities()
        {
            for (int i = 0; i < ConditionalProbability.Length; i++)
            {
                ConditionalProbability[i] = Ro[i] * Lambda[i];
            }
            var normalization = 1.0 / (ConditionalProbability.Sum());

            for (int i = 0; i < ConditionalProbability.Length; i++)
            {
                ConditionalProbability[i] *= normalization;
            }

            for (int i = 0; i < ConditionalProbability.Length; i++)
            {
                ConditionalProbability[i] = Math.Round(ConditionalProbability[i], 3);
            }
        }
        
        /// <summary>
        /// Crea un nodo bayesiano.
        /// </summary>
        /// <param name="cantParents">La cant de padres del nodo</param>
        /// <param name="cantChildren">La cant de hijos del nodo</param>
        public BayesianNode(int cantParents, int cantChildren)
        {
          
            Inicialize(cantParents, cantChildren, 2);
        }

        public int States { get { return Lambda.Length; } }

        /// <summary>
        /// Este metodo inicializa las variables del nodo para el calculo con un nueva evidencia
        /// </summary>
        public void Inicialize()
        {
            for (int i = 0; i < States; i++)
            {
                Ro[i] = -1;
                Lambda[i] = -1;
                ConditionalProbability[i] = -1;
            }
            for (int l = 0; l < ParentMessages.Length; l++)
            {
                for (int i = 0; i < ParentMessages[l].Length; i++)
                {
                    ParentMessages[l][i] = -1;
                }
                
            }
            finished = false;
            for (var child = 0; child < ChildrenMessages.Length; child++)
            {
                for (int k = 0; k < States; k++)
                {
                    ChildrenMessages[child][k] = -1;
                }
            }
			ParentMessagesSended=new bool[ParentMessages.Length];
            ChildrenMessagesSended=new bool[ChildrenMessages.Length];

        }

        /// <summary>
        /// Inicializa un nodo bayesiano.
        /// Actualiza a -1 los mensajes de los hijos y padres y las probabilidades condicionales;
        /// el ro y el lambda. de forma que se pueda iniciar otra vez el proceso de traspaso de mensajes
        /// </summary>
        /// <param name="cantParents">La cant de padres del nodo</param>
        /// <param name="cantChildren">La cant de hijos del nodo</param>
        /// <param name="states">La cant de estados del nodo</param>
        /// <param name="parentStates">La cant de estados de los padres del nodo</param>
        public void Inicialize(int cantParents, int cantChildren, int states,
                                int[] parentStates = null)
        {
            if (parentStates == null)
            {
                parentStates = new int[cantParents];

                for (int parent = 0; parent < cantParents; parent++)
                {
                    parentStates[parent] = 2; //si no se especifica nada asumo que son binarias.
                }
            }

            if (parentStates.Length != cantParents)
                throw new ArgumentException(String.Format("{0} no coincide con {1}", parentStates, cantParents));
            Ro = new double[states];
            Lambda = new double[states];

            ParentMessages = new double[cantParents][];
            ChildrenMessages = new double[cantChildren][];
            ConditionalProbability=new double[states];
            ParentMessagesSended=new bool[ParentMessages.Length];
            ChildrenMessagesSended=new bool[ChildrenMessages.Length];

            for (int i = 0; i < cantChildren; i++)
            {
                ChildrenMessages[i] = new double[states];
            }
            for (int j = 0; j < cantParents; j++)
            {
                  ParentMessages[j]=new double[parentStates[j]];
            }
            Inicialize();



        }
        /// <summary>
        ///  Crea un nodo bayesiano.
        /// </summary>
        /// <param name="cantParents">La cant de padres del nodo</param>
        /// <param name="cantChildren">La cant de hijos del nodo</param>
        /// <param name="states">La cant de estados del nodo</param>
        /// <param name="parentStates">La cant de estados del los padres del nodo</param>
        public BayesianNode(int cantParents, int cantChildren, int states, int[] parentStates = null)
        {
            
            Inicialize(cantParents, cantChildren, states, parentStates);
        }
    }

}
