using System;
using System.Collections.Generic;

namespace Algorithms.Algorithms.DataStructures
{
    public class Graph<T>
    {
        public Dictionary<T, List<T>> _adjacencyList { get; set; }

        public Graph()
        {
            _adjacencyList = new Dictionary<T, List<T>>();
        }

        public void AddEdge(T fromKey, T toKey)
        {
            if (_adjacencyList.ContainsKey(fromKey))
                _adjacencyList[fromKey].Add(toKey);
            else
                _adjacencyList[fromKey] = new List<T>() { toKey };

            if (_adjacencyList.ContainsKey(toKey))
                _adjacencyList[toKey].Add(fromKey);
            else
                _adjacencyList[toKey] = new List<T>() { fromKey };
        }

        public void PrintAllRoutes(T source, T destination)
        {
            var isVisited = new Dictionary<T, bool>();
            foreach (var pair in _adjacencyList)
            {
                isVisited[pair.Key] = new bool();
            }
            var pathList = new List<T> {source};

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
