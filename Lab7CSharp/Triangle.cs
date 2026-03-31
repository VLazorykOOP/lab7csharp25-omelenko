using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7CSharp
{
    public class Triangle : Shape
    {
        public Triangle(int x, int y, int s, Color c, string t) : base(x, y, s, c, t) { }

        public override void Draw(Graphics g)
        {
            PointF[] points = new PointF[3];
            for (int i = 0; i < 3; i++)
            {
                double angle = (Math.PI / 180) * (i * 120 - 90);
                points[i] = new PointF(
                    (float)(X + Size * Math.Cos(angle)),
                    (float)(Y + Size * Math.Sin(angle))
                );
            }
            using (SolidBrush brush = new SolidBrush(ShapeColor) g.FillPolygon(brush, points);

            g.DrawPolygon(Pens.Black, points);
            DrawCenteredText(g);
        }
    }
}
