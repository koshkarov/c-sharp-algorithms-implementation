using System.Collections.Generic;
using System.Collections.ObjectModel;
using Algorithms.Algorithms.Graph;

namespace Algorithms.Algorithms
{
    /// <summary>
    /// Graph. Could be directed or undirected depending on the TYPE enum. A graph is
    /// an abstract representation of a set of objects where some pairs of the
    /// objects are connected by links.
    /// </summary>
    public class Graph<T>
    {
        private List<Vertex<T>> allVertices = new List<Vertex<T>>();
        private List<Edge<T>> allEdges = new List<Edge<T>>();

        public enum GraphType
        {
            Directed,
            Undirected
        }

        /** Defaulted to undirected */
        private GraphType _graphType;

        public Graph(GraphType type)
        {
            _graphType = type;
        }

        public Graph(Collection<Vertex<T>> vertices, Collection<Edge<T>> edges) : this(GraphType.Undirected, vertices, edges)
        {
            
        }

        public Graph(GraphType type, Collection<Vertex<T>> vertices, Collection<Edge<T>> edges) : this(type)
        {
            allVertices.AddRange(vertices);
            allEdges.AddRange(edges);

            foreach (Edge<T> edge in edges)
            {
                Vertex<T> from = edge.From;
                Vertex<T> to = edge.To;

                if (!allVertices.Contains(from) || !allVertices.Contains(to))
                    continue;

                from.AddEdge(edge);
                if (_graphType == GraphType.Undirected)
                {
                    Edge<T> reciprical = new Edge<T>(from, to, edge.Cost);
                    to.AddEdge(reciprical);
                    allEdges.Add(reciprical);
                }
            }
        }

    }
}
}
