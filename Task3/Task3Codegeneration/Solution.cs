using System;using System.IO;using System.Text; namespace Task3{public class PrimeNumbers{public static byte[] PrimeGaps = new byte[]{1,2,2,4,2,4,2,4,6,2,6,4,2,4,6,6,2,6,4,2,6,4,6,8,4,2,4,2,4,14,4,6,2,10,2,6,6,4,6,6,2,10,2,4,2,12,12,4,2,4,6,2,10,6,6,6,2,6,4,2,10,14,4,2,4,14,6,10,2,4,6,8,6,6,4,6,8,4,8,10,2,10,2,6,4,6,8,4,2,4,12,8,4,8,4,6,12,2,18,6,10,6,6,2,6,10,6,6,2,6,6,4,2,12,10,2,4,6,6,2,12,4,6,8,10,8,10,8,6,6,4,8,6,4,8,4,14,10,12,2,10,2,4,2,10,14,4,2,4,14,4,2,4,20,4,8,10,8,4,6,6,14,4,6,6,8,6,};}
    public class Task3X
{
    private int[] primeNumbers = Array.Empty<int>();

    public void PreparePrimeNumbers(int num)
    {
        int[] numbers = new int[PrimeNumbers.PrimeGaps.Length];
        numbers[0] = 2;
        int gapIndex = 0;
        for (int i = 1; i < numbers.Length && numbers[i] < num; i++, gapIndex++)
        {
            var primeGap = PrimeNumbers.PrimeGaps[gapIndex];
            numbers[i] = numbers[i - 1] + primeGap;
            if (primeGap == 255)
            {
                gapIndex++;
                numbers[i] += PrimeNumbers.PrimeGaps[gapIndex];
            }
        }

        primeNumbers = numbers;
    }

    public void Process(TextReader textReader, TextWriter textWriter)
    {
        var n = int.Parse(textReader.ReadLine()!);
        if (n % 2 == 0)
        {
            textWriter.WriteLine(n / 2 + " " + n / 2);
            return;
        }

        var temp = n;
        var possibleSolution2 = 1;

        PreparePrimeNumbers(n);
        //rewrite, to binary search point of start
        var binarySearch = Array.BinarySearch(primeNumbers, 0, primeNumbers.Length, n);
        if (binarySearch > 0) //prime number
        {
            textWriter.WriteLine(1 + " " + (n - 1));
            return;
        }

        var startPoint = Math.Min(primeNumbers.Length - 1, Math.Abs(binarySearch));
        for (int i = startPoint; i > 0; i--)
        {
            var primeNumber = primeNumbers[i];
            if (temp % primeNumber == 0)
            {
                if (possibleSolution2 * primeNumber < n)
                {
                    temp /= primeNumber;
                    possibleSolution2 *= primeNumber;
                    i++;
                }
            }

            if (possibleSolution2 > n / 2)
                break;
        }


        textWriter.WriteLine(possibleSolution2 + " " + (n - possibleSolution2));
    }
}

public static class Program{
public static void Main(){
new Task3X().Process(Console.In, Console.Out);
}
}}