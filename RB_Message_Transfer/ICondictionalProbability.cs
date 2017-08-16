using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace RB_Message_Transfer
{
    
   public interface ICondictionalProbability:IEnumerable
    {
       double GetElem(int[] parentStates);
       /// <summary>
       ///Contiene la cant de estados de cada padre. La ultima posicion es la cant de estados del
       ///nodo actual
       /// </summary>
       /// <returns></returns>
        int[] ParentStates();
       /// <summary>
       /// Devuelve la probabilidad marginal.
       ///  </summary>
       /// <param name="nodestates">Si el nodo iesimo se quiere fijar en la formula de la marginal se pone su estado en 
       /// la posicion iesima si no se pone -1.El orden en que se ponen los nodos importa.</param>
       /// <returns></returns>
       IEnumerable<double> MarginalProbability(params int[] nodestates);
    }
}
