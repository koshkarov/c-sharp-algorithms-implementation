namespace Algorithms.DataStructures
{
    /// <summary>
    /// Creates a new doubly linked list node of arbitrary type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The element type of the doubly linked list.</typeparam>
    public class DoublyLinkedListNode<T>
    {
        public T Value;
        public DoublyLinkedListNode<T> Next;
        public DoublyLinkedListNode<T> Prev;

        public DoublyLinkedListNode(T value) { Value = value; }
    }
}
