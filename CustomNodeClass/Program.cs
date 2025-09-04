

using System.Collections;
using System.Diagnostics.Tracing;
using System.Runtime.InteropServices;

/// TODO
/// Связанный список.
/// Добавление +
/// Удаление +
/// Вывод +
namespace CustomNodeClass
{

    class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node(T data, Node<T> next = null)
        {
            this.Data = data;
            this.Next = next;
        }
    }


    class LinkedList<T> : IEnumerable<T>
    {
        Node<T> Head;
        Node<T> Tail;
        int Count;

        public void Add(T data)
        {
            Node<T> node = new(data);

            if (Head is null)
            {
                Head = node;
            }
            else
                Tail!.Next = node;
            Tail = node;
        }

        public bool Remove(T data)
        {
            Node<T> current = Head;
            Node<T> previous = null;

            while (current is not null && current.Data is not null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous is not null)
                    {
                        if (current.Next is null)
                            Tail = previous;
                        previous.Next = current.Next;
                    }
                    else
                    {
                        Head = Head?.Next;
                        if (Head is null)
                        {
                            Tail = null;
                        }
                    }
                    Count--;
                    return true;
                }
                else
                {
                    previous = current;
                    current = current.Next;
                }
            }
            return false;
        }

        public bool Contains(T data)
        {
            return this.Any(item => item.Equals(data));
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = Head;
            while (current is not null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            LinkedList<string> List = new();

            List.Add("This");
            List.Add("Is");
            List.Add("Test");
            List.Add("List");
            List.Remove("This");

            foreach (var item in List)
            {
                System.Console.WriteLine(item);
            }

            System.Console.WriteLine(List.Contains("This")); 
        
        }
    }
}