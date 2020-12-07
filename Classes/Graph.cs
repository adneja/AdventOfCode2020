using System;
using System.Collections.Generic;

namespace Aoc.Classes
{
    public class Graph<node,weight>
    {
        Dictionary<node, Dictionary<node, weight>> edges;

        public Graph()
        {
            Edges = new Dictionary<node, Dictionary<node, weight>>();
        }

        public Dictionary<node, Dictionary<node, weight>> Edges { get => edges; set => edges = value; }

        public void Add(node from, node to, weight weight)
        {
            if(!Edges.ContainsKey(from))
            {
                Edges.Add(from, new Dictionary<node, weight>());
                Edges[from].Add(to, weight);
            }
            else
            {
                if(Edges[from].ContainsKey(to))
                {
                    Edges[from][to] = weight;
                }
                else
                {
                    Edges[from].Add(to, weight);
                }
            }
        }

        public bool IsReachable(node from, node to)
        {
            Dictionary<node, weight> currEdges = new Dictionary<node, weight>();
            Dictionary<node, weight> nextEdges = new Dictionary<node, weight>();
            Dictionary<node, weight> visited = new Dictionary<node, weight>();

            if(Edges.ContainsKey(from)) currEdges = Edges[from];
            else return false;

            while(currEdges.Count > 0)
            {
                nextEdges.Clear();

                foreach(var edge in currEdges)
                {
                    if(edge.Key.Equals(to))
                    {
                        return true;
                    }
                    else{
                        if(!visited.ContainsKey(edge.Key))
                        {
                            if(Edges.ContainsKey(edge.Key))
                            {
                                foreach(var nextEdge in Edges[edge.Key])
                                {
                                    if(!visited.ContainsKey(nextEdge.Key) && !nextEdges.ContainsKey(nextEdge.Key))
                                    {
                                        nextEdges.Add(nextEdge.Key, nextEdge.Value);
                                    }
                                }
                            }
                        }
                    }
                    if(!visited.ContainsKey(edge.Key)) visited.Add(edge.Key, edge.Value);
                }

                currEdges.Clear();
                foreach(var nextEdge in nextEdges) currEdges.Add(nextEdge.Key, nextEdge.Value);
            }

            return false;
        }
    }
}