using System;
using System.Collections.Generic;
using Algorithms.Graph;

namespace Algorithms.DataStructures.Graph
{
    /// <summary>
    /// In graph theory and computer science, 
    /// an adjacency list is a collection of unordered lists used to represent a finite graph. 
    /// Each list describes the set of neighbors of a vertex in the graph.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GraphAdjacencyList<T>
    {
        public Dictionary<T, HashSet<T>> AdjacencyList { get; } = new Dictionary<T, HashSet<T>>();
        private readonly GraphType _graphType;

        public GraphAdjacencyList() : this(GraphType.Undirected)
        {
        }

        public GraphAdjacencyList(GraphType type)
        {
            _graphType = type;
        }

        public void AddEdge(T source, T destination)
        {
            if (AdjacencyList.ContainsKey(source))
            {
                AdjacencyList[source].Add(destination);
            }
            else
            {
                AdjacencyList[source] = new HashSet<T>() { destination };
            }
            
            if (_graphType == GraphType.Undirected)
            {
                if (AdjacencyList.ContainsKey(destination))
                {
                    AdjacencyList[destination].Add(source);
                }
                else
                {
                    AdjacencyList[destination] = new HashSet<T>() { source };
                }
            }
        }

        public void AddEdges(T source, HashSet<T> destinations)
        {
            if (AdjacencyList.ContainsKey(source))
            {
                foreach (var destination in destinations)
                    AdjacencyList[source].Add(destination);
            }
            else
            {
                AdjacencyList[source] = destinations;
            }
                
            if (_graphType == GraphType.Undirected)
            {
                foreach (var destination in destinations)
                {
                    if (AdjacencyList.ContainsKey(destination))
                        AdjacencyList[destination].Add(source);
                    else
                        AdjacencyList[destination] = new HashSet<T>() { source };
                }
            }
        }

        public HashSet<T> Neighbors(T source)
        {
            if (AdjacencyList.ContainsKey(source))
            {
                return AdjacencyList[source];
            }
            return default(HashSet<T>);
        }

        /// <summary>
        /// Breadth-first search (BFS) is an algorithm for traversing or searching tree or graph data structures.
        /// Finds all vertices that can be reached by the starting vertex.
        /// </summary>
        /// <param name="rootVertex"></param>
        /// <returns></returns>
        public Dictionary<T, BfsVertexInfo<T>> BreadthFirstSearch(T rootVertex, Action<T> preVisit = null)
        {
            // Traversed graph information
            var visitedVerticesInfo = new Dictionary<T, BfsVertexInfo<T>>();

            if (!AdjacencyList.ContainsKey(rootVertex))
                return visitedVerticesInfo;

            // Initialize it
            foreach (var i in AdjacencyList)
            {
                visitedVerticesInfo[i.Key] = new BfsVertexInfo<T>();
            }

            // Set the distance for the root vertex
            visitedVerticesInfo[rootVertex] = new BfsVertexInfo<T>() { Distance = 0 };

            // Create a queue and add root vertex
            QueueLinkedList<T> queue = new QueueLinkedList<T>();
            queue.Enqueue(rootVertex);

            // As long as the queue is not empty:
            while (!queue.IsEmpty())
            {
                // Repeatedly dequeue a vertex u from the queue.
                var vertex = queue.Dequeue();
                Console.Write(vertex + " ");

                // Trace the path 
                preVisit?.Invoke(vertex);

                // For each neighbor v of u that has not been visited:
                foreach (var neighbor in AdjacencyList[vertex])
                {
                    if (visitedVerticesInfo[neighbor].Distance == null)
                    {
                        // Set distance to 1 greater than u's distance
                        visitedVerticesInfo[neighbor].Distance = visitedVerticesInfo[vertex].Distance + 1;
                        // Set predecessor to u
                        visitedVerticesInfo[neighbor].Predecessor = vertex;
                        // Enqueue v
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return visitedVerticesInfo;
        }


        /// <summary>
        /// Depth-first search (DFS) is an algorithm for traversing or searching tree or graph data structures.
        /// Finds all vertices that can be reached by the starting vertex.
        /// </summary>
        /// <param name="rootVertex"></param>
        /// <param name="previsit"></param>
        /// <returns></returns>
        public HashSet<T> DepthFirstSearch(T rootVertex, Action<T> preVisit = null)
        {
            // Traversed graph information
            var visitedVerticesInfo = new HashSet<T>();

            if (!AdjacencyList.ContainsKey(rootVertex))
                return visitedVerticesInfo;

            // Create a stack and add root vertex
            var stack = new StackLinkedList<T>(1000);
            stack.Push(rootVertex);

            // As long as the stack is not empty:
            while (!stack.IsEmpty())
            {
                // Repeatedly pop a vertex u from the queue.
                var vertex = stack.Pop();

                // Ignore if neigbor is already visited
                if (visitedVerticesInfo.Contains(vertex))
                    continue;

                // Trace the path 
                preVisit?.Invoke(vertex);

                // Add vertex info to the visited list
                visitedVerticesInfo.Add(vertex);

                // For each neighbor v of u that has not been visited:
                foreach (var neighbor in AdjacencyList[vertex])
                    if (!visitedVerticesInfo.Contains(neighbor))
                        // Push v
                        stack.Push(neighbor);
            }

            return visitedVerticesInfo;
        }

        /// <summary>
        /// Dijkstra's algorithm is an algorithm for finding the shortest paths between nodes in a graph.
        /// </summary>
        /// <param name="source"></param>
        public void Dijkstra(T source)
        {
            // TODO
        }

        /// <summary>
        /// A* ("A star") is an algorithm that is widely used in pathfinding and graph traversal.
        /// </summary>
        /// <param name="source"></param>
        public void AStar(T source)
        {
            // TODO
        }

        /// <summary>
        /// Print all paths between two nodes.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        public void PrintAllPaths(T source, T destination)
        {
            var visited = new Dictionary<T, bool>();
            foreach (var pair in AdjacencyList)
            {
                visited[pair.Key] = new bool();
            }
            var path = new List<T> { source };
            PrintAllPathsHelper(source, destination, visited, path);
        }


        private void PrintAllPathsHelper(T sourceVertex, T destVertex, Dictionary<T, bool> visited, List<T> path)
        {
            visited[sourceVertex] = true;
            if (sourceVertex.Equals(destVertex))
            {
                foreach (var item in path)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }

            foreach (T vertex in AdjacencyList[sourceVertex])
            {
                if (!visited[vertex])
                {
                    path.Add(vertex);
                    PrintAllPathsHelper(vertex, destVertex, visited, path);
                    path.Remove(vertex);
                }
            }

            visited[sourceVertex] = false;
        }
    }
}
