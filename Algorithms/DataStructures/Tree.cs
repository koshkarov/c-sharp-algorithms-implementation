using System.Collections.Generic;

namespace Algorithms.DataStructures
{
    class Tree<T>
    {
        public T Value { get; set; }
        public Tree<T> Parent { get; set; }
        public List<Tree<T>> Children { get; set; }

        public Tree(T value)
        {
            Value = value;
            Children = new List<Tree<T>>();
        }

        // TODO: Implement all require methods like Add, Remove, Traverse
    }
}
