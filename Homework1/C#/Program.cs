using System;
using System.Drawing;
using System.Windows.Forms;
 
public class ShapeForm : Form
{
    public ShapeForm()
    {
        this.Size = new Size(800, 800); // Increase the width to accommodate all shapes
    }
 
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;
 
        // Draw a point
        int centerX = this.ClientSize.Width / 2;
        int centerY = 50;
        int r = 2;
        Pen pen = new Pen(Color.Blue, 2);
        g.DrawEllipse(pen, centerX - r, centerY - r, 2 * r, 2 * r);
        pen.Dispose();
 
        // Draw a line
        Point point0 = new Point(100, 100);
        Point point1 = new Point(700, 100);
        pen = new Pen(Color.Red, 2);
        g.DrawLine(pen, point0, point1);
        pen.Dispose();
 
        // Draw a circle
        int x0 = this.ClientSize.Width / 2;
        int y0 = 250;
        int radius = 100;
        pen = new Pen(Color.Yellow, 2);
        g.DrawEllipse(pen, x0 - radius, y0 - radius, 2 * radius, 2 * radius);
        SolidBrush brush = new SolidBrush(Color.Yellow);
        pen.Dispose();
        
        // Draw a rectangle
        int x = 100;
        int y = 400;
        int width = 200;
        int height = 100;
        pen = new Pen(Color.Brown, 2);
        g.DrawRectangle(pen, x, y, width, height);
            brush.Color = Color.Brown;
            g.FillRectangle(brush, 100,400,200,100);
        pen.Dispose();
 
    }
}
 
public class Program
{
    public static void Main()
    {
        Application.Run(new ShapeForm());
    }
}