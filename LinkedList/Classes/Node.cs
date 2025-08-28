using System;

namespace LinkedList.Classes;

/// <summary>
/// Основной класс данных.
/// Нода данных которая включает в себя поле данных,
/// и поле ссылки на следующую ноду в списке
/// </summary>
public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get; set; }

    public Node(T data, Node<T> node = null)
    {
        this.Data = data;
        this.Next = node;
    }
}   
