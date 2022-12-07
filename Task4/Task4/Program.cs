using System.Diagnostics.CodeAnalysis;
using Common;
using System.Drawing;

new Task4Solution().Process(Console.In, Console.Out);

public interface IDrawing
{
    void PrintPoints(int i, Task4Solution task4Solution);
    void Save();
    void DrawLine(int i0, int i1);
}

public class DrawingStub : IDrawing
{
    public void PrintPoints(int i, Task4Solution task4Solution)
    {
        
    }

    public void Save()
    {
    }

    public void DrawLine(int i0, int i1)
    {
    }
}
[SuppressMessage("Interoperability", "CA1416:Проверка совместимости платформы")]
public class Drawing : IDrawing
{
    static Bitmap bmp = new(2000, 2000);
    Graphics gfx = Graphics.FromImage(bmp);
    Pen pen = new(Color.White);

    int offsetX = bmp.Width/2;
    int offsetY = 10;
    double coof = 100;
    private Task4Solution task;
    private bool _print = false;

    public void PrintPoints(int i, Task4Solution task4Solution)
    {
        n = i;
        gfx.Clear(Color.Blue);
        PrintPointsI(i);
        task = task4Solution;
    }

    private int n { get; set; }

    public void Save()
    {
        bmp.Save("demo.png");
    }
    
    private void PrintPointsI(int n)
    {
        for (int i = 1; i < n; i++)
            DrawLine(i - 1, i);
        DrawLine(0, n - 1);
    }

    public void DrawLine(int i0, int i1)
    {
        if (i0 == n)
            i0 = 0;
        if (i1 == n)
            i1 = 0;
        var x0 = task._x[i0];
        var y0 = task._y[i0];
        var x1 = task._x[i1];
        var y1 = task._y[i1];

        Point pt1 = new((int)(x0 * coof + offsetX), (int)(y0 * coof + offsetY));
        Point pt2 = new((int)(x1 * coof + offsetX), (int)(y1 * coof + offsetY));
        gfx.DrawLine(pen, pt1, pt2);
    }
}


public class Task4Solution : IConsoleTest
{
    public double[] _x = null!;
    public  double[] _y = null!;
    private int n;

    private IDrawing _drawing = new DrawingStub();
    public void Process(TextReader textReader, TextWriter textWriter)
    {
        n = int.Parse(textReader.ReadLine()!);

        PreparePoints(n);

        var p0 = 0;
        var p1 = n / 3;
        var p2 = n * 2 / 3;

        
        var s = S(p0, p1, p2);

        _drawing.PrintPoints(n, this);
        
        if (n != 3)
        {
            s += Range(p0, p1);
            s += Range(p1, p2);
            s += Range(p2, p0);
        }
        
        _drawing.DrawLine(p0, p1);
        _drawing. DrawLine(p1, p2);
        _drawing.DrawLine(p2, p0);

        _drawing.Save();

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

        _drawing.DrawLine(a, b);
        _drawing. DrawLine(b, c);
        _drawing.DrawLine(c, a);

        var s = S(a, b, c);
        s += Range(a, c);
        s += Range(c, b);
        return s;
    }

    private void PreparePoints(int n)
    {
        _x = new double[n];
        _y = new double[n];
        var alfa = 180d * (n - 2d) / n;
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