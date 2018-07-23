namespace DataStructures
{
    public class TrieNode<T>
    {
        
        private TrieNode<T>[] paths = new TrieNode<T>[10];

        public TrieNode(T value)
        {
            Value = value;
        }

        public TrieNode<T> ParentNode { get; set; }
        public T Value { get; set; }
    }
}
