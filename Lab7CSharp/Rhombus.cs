using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7CSharp
{
    public class Rhombus : Shape
    {
        public Rhombus(int x, int y, int s, Color c, string t) : base(x, y, s, c, t) { }

        public override void Draw(Graphics g)
        {
            Point[] points = {
            new Point(X, Y - Size),     // Верх
            new Point(X + Size, Y),     // Право
            new Point(X, Y + Size),     // Низ
            new Point(X - Size, Y)      // Ліво
        };
            using (SolidBrush brush = new SolidBrush(ShapeColor))
                g.FillPolygon(brush, points);

            g.DrawPolygon(Pens.Black, points); 
            DrawCenteredText(g);
        }
    }
}
