using System.Collections.Generic;

namespace DataStructures
{
    class Tree<T>
    {
        public T Value;
        public Tree<T> Parent;
        public List<Tree<T>> Children;

        public Tree(T value)
        {
            Value = value;
            Children = new List<Tree<T>>();
        }

        // TODO: Implement all require methods like Add, Remove, Traverse
    }
}
