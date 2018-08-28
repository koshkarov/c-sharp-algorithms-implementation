namespace Algorithms.DataStructures.Graph
{
    public class Edge<T>
    {
        public Vertex<T> From { get; set; }
        public Vertex<T> To { get; set; }
        public int Cost { get; set; }

        public Edge(Vertex<T> from, Vertex<T> to, int cost)
        {
            From = from;
            To = to;
            Cost = cost;
        }

        public Edge(Edge<T> edge) : this(edge.From, edge.To, edge.Cost)
        {
        }

        public override string ToString()
        {
            return $"From [{From.Value}({From.Weight})] -> To [{To.Value}({To.Weight})]";
        }
    }
}
