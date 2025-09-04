var fruitCounts = new Dictionary<string, int>
{
    {"apple", 5},
    {"cherry", 10},
};


if (fruitCounts.TryGetValue("apple", out int count))
{
    System.Console.WriteLine($"Кол-во яблок: {count}");
}
