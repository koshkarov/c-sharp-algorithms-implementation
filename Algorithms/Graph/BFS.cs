using Algorithms.DataStructures;

namespace Algorithms.Graph
{
    public class BFS
    {
        public static BfsVertexInfo<int?>[] DoBfs(int[][] graph, int source)
        {
            BfsVertexInfo<int?>[] bfsInfo = new BfsVertexInfo<int?>[graph.Length];

            // Initialize bfsInfo array
            for (int i = 0; i < graph.Length; i++)
            {
                bfsInfo[i] = new BfsVertexInfo<int?>
                {
                    Distance = null,
                    Predecessor = null
                };
            }

            bfsInfo[source].Distance = 0;

            var queue = new QueueLinkedList<int>();
            queue.Enqueue(source);

            while (!queue.IsEmpty())
            {
                var u = queue.Dequeue();
                for (int i = 0; i < graph[u].Length; i++)
                {
                    var v = graph[u][i];
                    if (bfsInfo[v].Distance == null)
                    {
                        bfsInfo[v].Distance = bfsInfo[u].Distance + 1;
                        bfsInfo[v].Predecessor = u;
                        queue.Enqueue(v);
                    }
                }
            }

            return bfsInfo;
        }
    }

    public class BfsVertexInfo<T>
    {
        public int? Distance { get; set; }
        public T Predecessor { get; set; }
    }
}
