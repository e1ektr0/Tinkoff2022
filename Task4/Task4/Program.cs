using Common;

new Task4Solution().Process(Console.In, Console.Out);

public class Task4Solution : IConsoleTest
{
    private double[] _x = null!;
    private double[] _y = null!;
    private int n = 0;

    public void Process(TextReader textReader, TextWriter textWriter)
    {
        n = int.Parse(textReader.ReadLine()!);

        PreparePoints(n);

        var p0 = 0;
        var p1 = n / 3;
        var p2 = n * 2 / 3;


        var s = S(p0, p1, p2);
        s += Range(p0, p1);
        s += Range(p1, p2);
        s += Range(p2, p0);

        textWriter.WriteLine(s);
    }

    private double Range(int p1, int p2)
    {
        var a = p1 - 1;
        if (a < 0)
            a = n - a;
        var b = p2 - 1;
        if (b < 0)
            b = n - b;
        if (a > n)
            a -= n;
        if (b > n)
            b -= n;
        
        if (Math.Abs(a - b) < 3)
            return 0;

        var c = a + b / 2;
        var s = S(a, b, c);
        s += Range(a, c);
        s += Range(b, c);
        return s;
    }

    private void PreparePoints(int n)
    {
        _x = new double[n];
        _y = new double[n];
        var alfa = 180 * (n - 2) / n;
        double angle = Math.PI * alfa / 180.0;
        double delta = 0;
        for (int i = 1; i < n; i++)
        {
            delta += angle;
            var cosA = Math.Cos(delta);
            var sinA = Math.Sin(delta);
            _x[i] = _x[i - 1] + cosA;
            _y[i] = _y[i - 1] + sinA;
        }
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
        return Math.Sqrt(Math.Pow(_x[p2] - _x[p1], 2) + Math.Pow(_y[p2] - _y[p1], 2));
    }
}