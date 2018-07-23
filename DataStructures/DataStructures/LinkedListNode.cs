namespace DataStructures
{
    /// <summary>
    /// Creates a new linked list node of arbitrary type <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The element type of the linked list</typeparam>
    public class LinkedListNode<T>
    {
        public T Value;
        public LinkedListNode<T> Next;

        public LinkedListNode(T value) { Value = value; }

    }
}
