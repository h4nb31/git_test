namespace ActionMethodTest;



public class Program
{
    public record struct First(string StringPar);
    public record struct Second(double DoublePar);
    public record struct Third(int IntegerPar);

    static Action<string, double, int> SomeActionMethod = (first, second, third) =>
    {
        System.Console.WriteLine("\n\nThis method was invoked from an Action delegate!\n\n");
        System.Console.WriteLine($"First parameter: {first}");
        System.Console.WriteLine($"Second parameter: {second}");
        System.Console.WriteLine($"Third parameter: {third}\n\n");
    };

    public static void Main()
    {
        var first = new First("Hello from Action delegate!");
        var second = new Second(3.14159);
        var third = new Third(42);
        SimpleVoidFunc(first.StringPar, second.DoublePar, third.IntegerPar, SomeActionMethod);

    }

    public static void SimpleVoidFunc(string str, double dbl, int integer, Action<string, double, int> action)
    {
        action?.Invoke(str, dbl, integer);
    }


}