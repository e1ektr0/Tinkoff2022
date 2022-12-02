using Common;

namespace Task3;

public class Task3 : IConsoleTest
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

public class PrimeNumbers   
{
    public static byte[] PrimeGaps { get; set; }
}