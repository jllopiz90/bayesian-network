using System;

namespace RB_Message_Transfer
{
  public  class DirectedGraph<T> : Graph<T>
    {
        public override void AddEdge(T from, T to)
        {
            if (!Dictionary.ContainsKey(from) || !Dictionary.ContainsKey(to))
                throw new ArgumentException("Argumentos nulos o alguno de ellos no pertenece al grafo");
            Vertexes[Dictionary[from]].Add(to);
          
        }
    }
}