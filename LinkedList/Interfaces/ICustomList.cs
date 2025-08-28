using System;

namespace LinkedList.Interfaces;

/// <summary>
/// Интерфейс связанного списка
/// </summary>
/// <typeparam name="T">Шаблон для гибкости типов входных параметров</typeparam>
public interface ICustomList<T>
{
    public void Add(T data);
    public bool Remove(T data);
    public bool Contains(T data);
    public int GetCount();
    public IEnumerator<T> GetEnumerator();
}
