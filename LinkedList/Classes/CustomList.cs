using System;
using System.Collections;
using LinkedList.Interfaces;

namespace LinkedList.Classes;

/// <summary>
/// Класс связанного списка.
/// Реализует методы интерфейса списка,
/// а так же реализует IEnumerable<T>
/// для возможности использования перечесления над объектом класса
/// </summary>
/// <typeparam name="T"></typeparam>
public class CustomList<T> : ICustomList<T>, IEnumerable<T>
{
    public Node<T> Head { get; set; }
    public Node<T> Tail { get; set; }
    int Count;

    /// <summary>
    /// Доабвление ноды в список.
    /// Создаём новую отдельную ноду из 
    /// входящих данны. И через условие проверки
    /// добавляем в конец списка
    /// </summary>
    /// <param name="data">Данные ноды</param>
    public void Add(T data)
    {
        Node<T> node = new(data);

        if (Head is null)
        {
            Head = node;
        }
        else
            Tail.Next = node;
        Tail = node;
        Count++;
    }

    /// <summary>
    /// Проверка наличия ноды с указаными данными в списке
    /// </summary>
    /// <param name="data">Данные для проверки</param>
    /// <returns></returns>
    public bool Contains(T data)
    {
        return this.Any(item => item.Equals(data));
    }

    /// <summary>
    /// Удаление ноды с указаными данными из списка
    /// и переназначение ссылок между смежными нодами
    /// </summary>
    /// <param name="data">Данные в ноде для удаления</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public bool Remove(T data)
    {
        Node<T> current = Head;
        Node<T> previous = null;

        while (current is not null && current.Data is not null)
        {
            if (current.Data.Equals(data))
            {
                if (previous is null)
                {
                    if (current.Next is null)
                    {
                        Head = null;
                        Tail = null;
                    }
                    Head = Head.Next;
                }
                else
                {
                    if (current.Next is null)
                    {
                        Tail = previous;
                    }
                    previous.Next = current.Next;
                }
                Count--;
                return true;
            }
            previous = current;
            current = current.Next;
        }
        return false;
    }

    public int GetCount()
    {
        return this.Count;
    }


    public IEnumerator<T> GetEnumerator()
    {
        Node<T> current = Head;
        while (current is not null && current.Data is not null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    /// <summary>
    /// Энумиратор с указанием шаблонного типа, чтобы при
    /// работе с перечислением возвращался тот тип с которым мы работаетм,
    /// а не просто object
    /// </summary>
    /// <returns></returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<T>)this).GetEnumerator();
    }
}
