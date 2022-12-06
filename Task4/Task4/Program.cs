using Common;

new Task4Solution().Process(Console.In, Console.Out);

public class Task4Solution : IConsoleTest
{
    double[] x;
    double[] y;

    public void Process(TextReader textReader, TextWriter textWriter)
    {
        var n = int.Parse(textReader.ReadLine()!);
        x = new double[n];
        y = new double[n];
        var alfa = 180 * (n - 2) / n;
        double angle    = Math.PI * alfa / 180.0;
        var cosA = Math.Cos(angle);
        var sinA = Math.Sin(angle);
        for (int i = 1; i < n; i++)
        {
            x[i] = x[i - 1] + cosA;
            y[i] = y[i - 1] + sinA;
        }
        //todo: multiple
        textWriter.WriteLine(S(0, 1, 2));
    }

    private double S(int p1, int p2, int p3)
    {
        var l1 = L(p1, p2);
        var l2 = L(p2, p3);
        var l3 = L(p3, p1);
        //S=sqrt{p*(p-a)*(p-b)*(p-c)}
        var p = (l1 + l2 + l3) / 2;
        var d1 = (p - l1);
        var l4 = (p - l2);
        var l5 = (p - l3);
        var d = p * d1 * l4 * l5;
        return Math.Sqrt(d);
    }

    private double L(int p1, int p2)
    {
        return Math.Sqrt(Math.Pow(x[p2] - x[p1], 2) + Math.Pow(y[p2] - y[p1], 2));
    }
}