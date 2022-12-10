using Common;

namespace Task6;

public class Node
{
    public Node? Right { get; set; }
    public Node? Left { get; set; }
}

public class Tree
{
    public Node Root { get; set; } = new Node();

    public void Add(long k)
    {
        bool[] bitsArray = new bool[32];
        for (int i = 0; i < (int)Math.Log(k, 2) + 1; i++)
            bitsArray[bitsArray.Length - i - 1] = ((k >> i) & 1) == 1;
        var currentNode = Root;
        for (var index = 0; index < 32; index++)
        {
            var bit = bitsArray[index];
            if (bit)
            {
                currentNode.Left ??= new Node();
                currentNode = currentNode.Left;
            }
            else
            {
                currentNode.Right ??= new Node();
                currentNode = currentNode.Right;
            }
        }
    }

    public long Max()
    {
        bool[] bitsArray = new bool[32]; //rewrite to bit shift
        Queue<Node> leftNodes = new Queue<Node>();
        Queue<Node> rightNodes = new Queue<Node>();
        if (Root.Left != null)
            leftNodes.Enqueue(Root.Left);
        if (Root.Right != null)
            rightNodes.Enqueue(Root.Right);

        for (int i = 0; i < bitsArray.Length; i++)
        {
            var rightNodesCount = rightNodes.Count;
            var leftNodesCount = leftNodes.Count;
            if (rightNodesCount > 0 && leftNodesCount > 0)
                bitsArray[i] = true;

            for (int j = 0; j < rightNodesCount; j++)
            {
                var node = rightNodes.Dequeue();
                if (node.Left != null)
                    leftNodes.Enqueue(node.Left);
                if (node.Right != null)
                    rightNodes.Enqueue(node.Right);
            }

            for (int j = 0; j < leftNodesCount; j++)
            {
                var node = leftNodes.Dequeue();
                if (node.Left != null)
                    leftNodes.Enqueue(node.Left);
                if (node.Right != null)
                    rightNodes.Enqueue(node.Right);
            }
        }

        return BoolArrayToInt(bitsArray);
    }

    static long BoolArrayToInt(bool[] arr)
    {
        long val = 0;
        for (int i = 0; i < arr.Length; ++i)
            if (arr[i])
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