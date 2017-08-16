using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace RB_Message_Transfer
{
    /// <summary>
    /// Representa un grafo generico en el tipo que guarda. asi se puede reusar para cuaquier implementacion de grafo.
    /// Tiene una implementacion para grafo dirigido.
    /// </summary>
    /// <typeparam name="T">Cada vertice es del tipo T.Se puede usar para agregar valores.</typeparam>
   public class Graph<T>:IEnumerable<T>
    {
       /// <summary>
       /// La lista de adyacencia del grafo
       /// </summary>
       protected List<List<T>> Vertexes;
       /// <summary>
       /// Cada vertice se mapea a entero para saber cuales son sus adyacentes en la lista de adyacencia.
       /// </summary>
       protected Dictionary<T, int> Dictionary;
       //el indice de cada nodo en el grafo
       protected Dictionary<int, T> IndexOF = new Dictionary<int, T>();

       public Graph()
       {
           Vertexes = new List<List<T>>();
           Dictionary=new Dictionary<T, int>();
       }
       /// <summary>
       /// La cantidad de nodos del grafo
       /// </summary>
        public int Count {get { return Vertexes.Count; }
        }

      
        public int AdjCount(T vert)
        {
            if (!Dictionary.ContainsKey(vert))
                throw new ArgumentException();
            return Vertexes[Dictionary[vert]].Count;
        }

       public IEnumerable<T> Adjacent(T vert )
       {
           if (!Dictionary.ContainsKey(vert))
               throw new ArgumentException();
           return Vertexes[Dictionary[vert]];
       }
       public virtual void AddVertex(T newvertex )
       {
           if (newvertex == null || Dictionary.ContainsKey(newvertex))
               throw new ArgumentException("El parametro es null o ya esta en el grafo");
           Dictionary.Add(newvertex,Vertexes.Count);
           Vertexes.Add(new List<T>());
           IndexOF.Add(Dictionary[newvertex], newvertex);
       }
       public void Remove(T x) 
       {
           if (Dictionary.ContainsKey(x)) 
           {
               Vertexes[Dictionary[x]] = new List<T>();
               Dictionary.Remove(x);
               
           }
       }
       public virtual void AddEdge(T from,T to )
       {
           if(!Dictionary.ContainsKey(from)||!Dictionary.ContainsKey(to))
               throw new ArgumentException("Argumentos nulos o alguno de ellos no pertenece al grafo");
           Vertexes[Dictionary[from]].Add(to);
           
          
           
       }
       public T this[int index]
       {
           get
           {
               if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
               return IndexOF[index];
           }
       }
       public IEnumerator<T> GetEnumerator()
       {
          
          
           return Dictionary.Select(vertexce => vertexce.Key).GetEnumerator();
       }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
       {
           return GetEnumerator();
       }

       /// <summary>
       /// Asumo que es conexo el grafo.
       /// Porque lo usare en una red bayesiana
       /// </summary>
       /// <returns></returns>
        public virtual bool Arbol()
        {
            if(Vertexes.Count==0) return true;
           
            return Vertexes.Select(x=>x.Count).Aggregate((z,y)=>z+y)==Vertexes.Count-1;
        }
    }
}
