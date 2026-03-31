using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7CSharp
{
    public class Pentagon : Shape
    {
        public Pentagon(int x, int y, int s, Color c, string t) : base(x, y, s, c, t) { }

        public override void Draw(Graphics g)
        {
            PointF[] points = new PointF[5];
            for (int i = 0; i < 5; i++)
            {
                // Обчислення вершин через полярні координати (крок 72 градуси)
                double angle = (Math.PI / 180) * (i * 72 - 90);
                points[i] = new PointF(
                    (float)(X + Size * Math.Cos(angle)),
                    (float)(Y + Size * Math.Sin(angle))
                );
            }
            using (SolidBrush brush = new SolidBrush(ShapeColor))
                g.FillPolygon(brush, points);

            g.DrawPolygon(Pens.Black, points);
            DrawCenteredText(g);
        }
    }
}
