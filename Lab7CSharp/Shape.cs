using System;
using System.Drawing;
using System.Collections.Generic;

namespace Lab7CSharp
{
    public abstract class Shape
    {
        public int X { get; set; } // Координата центру X
        public int Y { get; set; } // Координата центру Y
        public int Size { get; set; } // Радіус або характерний розмір
        public Color ShapeColor { get; set; }
        public string Text { get; set; } = "ID";

        public Shape(int x, int y, int size, Color color, string text)
        {
            X = x; Y = y; Size = size; ShapeColor = color; Text = text;
        }

        // Віртуальна функція малювання
        public abstract void Draw(Graphics g);

        // Віртуальна функція переміщення
        public virtual void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }

        // Допоміжний метод для малювання тексту по центру
        protected void DrawCenteredText(Graphics g)
        {
            using (Font font = new Font("Arial", Size / 3, FontStyle.Bold))
            {
                SizeF textSize = g.MeasureString(Text, font);
                g.DrawString(Text, font, Brushes.Black, X - textSize.Width / 2, Y - textSize.Height / 2);
            }
        }
    }
}