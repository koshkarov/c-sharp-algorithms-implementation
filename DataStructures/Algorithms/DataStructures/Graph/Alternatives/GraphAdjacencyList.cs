using System;
using System.Collections.Generic;

namespace Algorithms.Algorithms.Graph.Alternatives
{
    public class GraphAdjacencyList<T>
    {
        //private int V;
        private Dictionary<T, List<T>> _adjacencyList = new Dictionary<T, List<T>>();
        private GraphType _graphType;

        public GraphAdjacencyList() : this(GraphType.Undirected)
        {
        }

        public GraphAdjacencyList(GraphType type)
        {
            _graphType = type;
        }

        public void AddEdge(T source, T destination)
        {
            if (_adjacencyList.ContainsKey(source))
                _adjacencyList[source].Add(destination);
            else
                _adjacencyList[source] = new List<T>() {destination};

            //if (_graphType == GraphType.Undirected)
            //    if (_adjacencyList.ContainsKey(destination))
            //        _adjacencyList[destination].Add(source);
            //    else
            //        _adjacencyList[destination] = new List<T>() {source};
        }

        public void AddEdges(T source, List<T> edgesList)
        {
            if (_adjacencyList.ContainsKey(source))
                _adjacencyList[source].AddRange(edgesList);
            else
                _adjacencyList[source] = edgesList;

            //if (_graphType == GraphType.Undirected)
            //    foreach (var destination in edgesList)
            //        if (_adjacencyList.ContainsKey(destination))
            //            _adjacencyList[destination].Add(source);
            //        else
            //            _adjacencyList[destination] = new List<T>() {source};
        }

        public Dictionary<T, BfsVertexInfo<T>> BFS(T source)
        {
            var bfsInfo = new Dictionary<T, BfsVertexInfo<T>>();
            foreach (var i in _adjacencyList)
            {
                bfsInfo[i.Key] = new BfsVertexInfo<T>();
            }

            bfsInfo[source] = new BfsVertexInfo<T>() { Distance = 0 };

            QueueLinkedList<T> queue = new QueueLinkedList<T>();
            queue.Enqueue(source);

            while (!queue.IsEmpty())
            {
                var u = queue.Dequeue();
                Console.Write(u + " ");
                foreach (var v in _adjacencyList[u])
                {
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
}
