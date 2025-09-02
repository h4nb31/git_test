namespace ActionMethodTest;



public class Program
{
    public record struct SomeStruct(string Element, int Number);
    public record struct SecondStruct(double DoubleNum, char Sybmol);
    
    public record struct ThirdStruct(string Name, string Place);

    public static void Main()
    {
        var newStruct = new SomeStruct("First", 1);
        var secondStruct = new SecondStruct(22.2, 'a');

        Action<SomeStruct, SecondStruct, int> SomeActionMethod = (first, second, third) =>
        {
            System.Console.WriteLine($"\n\nThis is first struct: \nElement: {first.Element} Number: {first.Number}\n\nThis is second struct: \nDouble: {second.DoubleNum} Symbol: {second.Sybmol}\n\n");
            System.Console.WriteLine($"just a sum: {first.Number + second.DoubleNum}\n\n");
            System.Console.WriteLine($"third number: {third}\n\n");
        };

        SomeActionMethod(newStruct, secondStruct, 5);


    }
}