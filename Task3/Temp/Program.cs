namespace Temp;

public class Program
{
    public static void Main()
    {
        var readAllText = File.ReadAllText("info.json");
        var indexOf = readAllText.IndexOf("compiler_output", StringComparison.Ordinal);
        Console.WriteLine(indexOf);
        Console.WriteLine(readAllText.Substring(indexOf, 100));
        ;
    }
}