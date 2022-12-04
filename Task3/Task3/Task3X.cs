namespace Task3;

//todo: rename
public class Task3X //: IConsoleTest
{
    //todo: return tests
    public void Process(TextReader textReader, TextWriter textWriter,string gaps)
    {
        var n = int.Parse(textReader.ReadLine()!);

        if (n % 2 == 0)
        {
            textWriter.WriteLine(n / 2 + " " + n / 2);
            return;
        }

        int[] primeNumbers = new int[gaps.Length];
        primeNumbers[0] = 2;
        int gapIndex = 0;
        int primeNumberIndex;
        for (primeNumberIndex = 1; primeNumberIndex < primeNumbers.Length && primeNumbers[primeNumberIndex] < n; primeNumberIndex++, gapIndex++)
        {
            var primeGap = gaps[gapIndex];
            var tempPrimeNumber = primeNumbers[primeNumberIndex - 1] + primeGap;
            if (primeGap == 255)
            {
                gapIndex++;
                primeNumbers[primeNumberIndex] = tempPrimeNumber + gaps[gapIndex];
            }
            else
            {
                primeNumbers[primeNumberIndex] = tempPrimeNumber;
            }
        }

        var temp = n;
        var possibleSolution2 = 1;

        var binarySearch = Array.BinarySearch(primeNumbers, 0, primeNumberIndex, n);
        if (binarySearch > 0) //prime number
        {
            textWriter.WriteLine(1 + " " + (n - 1));
            return;
        }

        var startPoint = Math.Min(primeNumberIndex - 1, Math.Abs(binarySearch));
        //todo: possible can be divide to /2
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