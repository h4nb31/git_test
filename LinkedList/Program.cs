using System;
using LinkedList.Classes;
using LinkedList.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LinkedList;

class Program
{
    private readonly ICustomList<int> _intList;

    public Program(ICustomList<int> intList)
    {
        _intList = intList;
    }

    public static void Main()
    {
        var services = new ServiceCollection();
        services.AddScoped(typeof(ICustomList<>), typeof(CustomList<>));
        services.AddScoped<Program>();

        var serviceProvider = services.BuildServiceProvider();
        var program = serviceProvider.GetRequiredService<Program>();

        program._intList.Add(1);
        program._intList.Add(2);
        program._intList.Add(3);
        program._intList.Add(4);
        program._intList.Add(5);

        System.Console.WriteLine($"\nList count before deleting: {program._intList.GetCount()}\n");

        program._intList.Remove(1);
        program._intList.Remove(5);

        foreach (var item in program._intList)
        {
            System.Console.WriteLine(item);
        }
        System.Console.WriteLine();
        System.Console.WriteLine($"Is {4} in List: {program._intList.Contains(4)}");
        System.Console.WriteLine($"Is {3} in List: {program._intList.Contains(3)}\n");

        System.Console.WriteLine($"List count after deleting: {program._intList.GetCount()}\n");



    }
}