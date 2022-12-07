using System.Diagnostics.CodeAnalysis;
using Common;
using System.Drawing;

new Task4Solution().Process(Console.In, Console.Out);

[SuppressMessage("Interoperability", "CA1416:Проверка совместимости платформы")]
public class Task4Solution : IConsoleTest
{
    private double[] _x = null!;
    private double[] _y = null!;
    private int n;
    static Bitmap bmp = new(600, 400);
    Graphics gfx = Graphics.FromImage(bmp);
    Pen pen = new(Color.White);

    int offsetX = 250;
    int offsetY = 10;
    double coof = 100;


    public void Process(TextReader textReader, TextWriter textWriter)
    {
        n = int.Parse(textReader.ReadLine()!);

        PreparePoints(n);

        var p0 = 0;
        var p1 = n / 3;
        var p2 = n * 2 / 3;


        gfx.Clear(Color.Blue);
        var s = S(p0, p1, p2);
        s += Range(p0, p1);
        s += Range(p1, p2);
        s += Range(p2, p0);

        PrintPoints(n);

        DrawLine(p0, p1);
        DrawLine(p1, p2);
        DrawLine(p2, p0);

        bmp.Save("demo.png");

        textWriter.WriteLine(s);
    }

    private double Range(int p1, int p2)
    {
        var a = p1 + 1;
        if (a < 0)
            a = n + a;
        var b = p2 - 1;
        if (b < 0)
            b = n + b;
        if (a >= n)
            a -= n;
        if (b >= n)
            b -= n;

        if (Math.Abs(a - b) < 2)
            return 0;

        var c = (a + b) / 2;

        DrawLine(a, b);
        DrawLine(b, c);
        DrawLine(c, a);

        var s = S(a, b, c);
        s += Range(a, c);
        s += Range(c, b);
        return s;
    }

    private void PreparePoints(int n)
    {
        _x = new double[n];
        _y = new double[n];
        var alfa = 180 * (n - 2) / n;
        double delta = 0;
        for (int i = 1; i < n; i++)
        {
            delta += 180 - alfa;
            double angle = Math.PI * delta / 180.0;

            var cosA = Math.Cos(angle);
            var sinA = Math.Sin(angle);
            _x[i] = _x[i - 1] + cosA;
            _y[i] = _y[i - 1] + sinA;
        }
    }

    private void PrintPoints(int n)
    {
        for (int i = 1; i < n; i++)
            DrawLine(i - 1, i);
        DrawLine(0, n - 1);
    }

    private void DrawLine(int i0, int i1)
    {
        if (i0 == n)
            i0 = 0;
        if (i1 == n)
            i1 = 0;
        var x0 = _x[i0];
        var y0 = _y[i0];
        var x1 = _x[i1];
        var y1 = _y[i1];

        Point pt1 = new((int)(x0 * coof + offsetX), (int)(y0 * coof + offsetY));
        Point pt2 = new((int)(x1 * coof + offsetX), (int)(y1 * coof + offsetY));
        gfx.DrawLine(pen, pt1, pt2);
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