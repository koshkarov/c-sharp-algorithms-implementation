using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Algorithms.Algorithms.Graph.Alternatives
{
    public class GraphAdjacencyList<T>
    {
        //private int V;
        private Dictionary<T, HashSet<T>> _adjacencyList = new Dictionary<T, HashSet<T>>();
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
                _adjacencyList[source] = new HashSet<T>() {destination};

            if (_graphType == GraphType.Undirected)
                if (_adjacencyList.ContainsKey(destination))
                    _adjacencyList[destination].Add(source);
                else
                    _adjacencyList[destination] = new HashSet<T>() { source };
        }

        public void AddEdges(T source, HashSet<T> destinations)
        {
            if (_adjacencyList.ContainsKey(source))
                foreach (var destination in destinations)
                    _adjacencyList[source].Add(destination);
            else
                _adjacencyList[source] = destinations;

            if (_graphType == GraphType.Undirected)
                foreach (var destination in destinations)
                    if (_adjacencyList.ContainsKey(destination))
                        _adjacencyList[destination].Add(source);
                    else
                        _adjacencyList[destination] = new HashSet<T>() { source };
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

        public void PrintAllRoutes(T source, T destination)
        {
            var isVisited = new Dictionary<T, bool>();
            foreach (var pair in _adjacencyList)
            {
                isVisited[pair.Key] = new bool();
            }

            var pathList = new List<T> { source };

            PrintAllPaths(source, destination, isVisited, pathList);

        }

        private void PrintAllPaths(T source, T destination, Dictionary<T, bool> isVisited, List<T> pathList)
        {
            isVisited[source] = true;

            if (source.Equals(destination))
            {
                foreach (var item in pathList)
                {
                    Console.Write($"{item} ");

                }
                Console.WriteLine();
            }

            foreach (T vertex in _adjacencyList[source])
            {
                if (!isVisited[vertex])
                {
                    pathList.Add(vertex);
                    PrintAllPaths(vertex, destination, isVisited, pathList);

                    pathList.Remove(vertex);
                }
            }

            isVisited[source] = false;
        }
    }
}
