using System.Collections.Generic;
using System.Text;

namespace Algorithms.DataStructures.Graph
{

    public class Vertex<T>
    {
        public int Weight { get; set; }
        public T Value { get; set; }
        public List<Edge<T>> Edges { get; set; }

        public Vertex(T value, int weight)
        {
            Value = value;
            Weight = weight;
        }

        public Vertex(Vertex<T> vertex) : this(vertex.Value, vertex.Weight)
        {
            Edges.AddRange(vertex.Edges);
        }

        public void AddEdge(Edge<T> edge)
        {
            Edges.Add(edge);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"Value: ${Value}, wight: {Weight}\n");
            foreach (Edge<T> edge in Edges)
            {
                builder.Append($"{edge}\n");
            }

            return builder.ToString();
        }
    }

}