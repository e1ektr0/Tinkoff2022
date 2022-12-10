using Common;

namespace Task6;

public class Node
{
    public Node? Right { get; set; }
    public Node? Left { get; set; }
    public bool Value { get; set; }

    public IEnumerable<Node> Get()
    {
        if (Right != null)
            yield return Right;
        if (Left != null)
            yield return Left;
    }
}

public class Tree
{
    private readonly Node _root = new();

    public void Add(long k)
    {
        var count = 32;
        bool[] bitsArray = new bool[count];
        for (int i = 0; i < (int)Math.Log(k, 2) + 1; i++)
            bitsArray[bitsArray.Length - i - 1] = ((k >> i) & 1) == 1;
        var currentNode = _root;
        for (var index = 0; index < count; index++)
        {
            var bit = bitsArray[index];
            if (!bit)
            {
                currentNode.Left ??= new Node();
                currentNode = currentNode.Left;
            }
            else
            {
                currentNode.Right ??= new Node { Value = true };
                currentNode = currentNode.Right;
            }
        }
    }

    public long Max()
    {
        bool[] bitsArray = new bool[32]; //rewrite to bit shift

        SingleBranch(_root, 0, bitsArray);

        return BoolArrayToInt(bitsArray);
    }

    private void SingleBranch(Node node, int deep, bool[] bitsArray) //одна ветка
    {
        if(deep == 33)
            return;
        if (node.Left != null && node.Right != null)
        {
            TwoBranch(new[] { node.Left }, new[] { node.Right }, deep, bitsArray);
        }

        if (node.Left != null)
            SingleBranch(node.Left, deep + 1, bitsArray);
        else
            SingleBranch(node.Right!, deep + 1, bitsArray);
    }

    private static void TwoBranch(Node[] rootLeft, Node[] rootRight, int deep, bool[] bitsArray)
    {
        if(deep == 32)
            return;
        if (rootLeft.Any(n => rootRight.Any(x => x.Value != n.Value)))
        {
            bitsArray[deep] = true;
            var left = rootLeft.Where(n => rootRight.Any(x => x.Value != n.Value)).SelectMany(n=>n.Get()).ToArray();
            var right = rootRight.Where(n => rootLeft.Any(x => x.Value != n.Value)).SelectMany(n=>n.Get()).ToArray();
            TwoBranch(left, right, deep + 1, bitsArray);
        }
        else
        {
            TwoBranch(rootLeft.SelectMany(n => n.Get()).ToArray(), rootRight.SelectMany(n => n.Get()).ToArray(),
                deep + 1, bitsArray);
        }
    }

    static long BoolArrayToInt(bool[] arr)
    {
        long val = 0;
        for (int i = 0; i < arr.Length; ++i)
            if (arr[i])
                val |= (long)1 << (31 - i);
        return val;
    }

    static long ByteArrayToInt(byte[] arr)
    {
        long val = 0;
        for (int i = 0; i < arr.Length; ++i)
            if (arr[i] == 2)
                val |= (long)1 << (31 - i);
        return val;
    }
}

public class Task6Solution : IConsoleTest
{
    public void Process(TextReader textReader, TextWriter textWriter)
    {
        var tree = new Tree();
        var q = long.Parse(textReader.ReadLine()!);
        for (int i = 0; i < q; i++)
        {
            long k = long.Parse(textReader.ReadLine()!);
            tree.Add(k);
            textWriter.WriteLine(tree.Max());
        }
    }
}