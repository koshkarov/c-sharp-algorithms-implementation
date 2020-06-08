namespace Algorithms.DataStructures
{
    /// <summary>
    /// Creates a new doubly linked list node of arbitrary type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The element type of the doubly linked list.</typeparam>
    public class DoublyLinkedListNode<T>
    {
        public T Value { get; set; }
        public DoublyLinkedListNode<T> Next { get; set; }
        public DoublyLinkedListNode<T> Prev { get; set; }

        public DoublyLinkedListNode(T value) { Value = value; }
    }
}
