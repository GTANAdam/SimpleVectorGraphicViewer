using System;
using System.Drawing;
using SimpleVectorGraphicViewer.Utils.Extensions;

namespace SimpleVectorGraphicViewer.Models
{
    public class Line : Primitive
    {
        public PointF A { get; set; }
        public PointF B { get; set; }
        internal Line() { }

        /// <summary>
        /// Line constructor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="color"></param>
        internal Line(PointF a, PointF b, Color? color = null)
        {
            A = a;
            B = b;
            Color = color ?? Color.Black;
        }

        /// <summary>
        /// Returns primitive properties
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return $"Type: {GetType().Name}\n" +
                    $"A: {A}\n" +
                    $"B: {B}\n" +
                    $"Color: {Color.A}; {Color.R}; {Color.G}; {Color.B} {(Color.IsNamedColor ? $"({Color.Name})" : "")}\n";
        }

        /// <summary>
        /// Checks if point within primitive
        /// </summary>
        /// <param name="point"></param>
        /// <returns>bool</returns>
        internal override bool IsPointWithin(PointF point) => IsPointWithin(point, this);

        /// <summary>
        /// Checks if point within primitive
        /// </summary>
        /// <param name="pts"></param>
        /// <param name="line"></param>
        /// <param name="t"></param>
        /// <returns>bool</returns>
        internal static bool IsPointWithin(PointF pts, Line line, float t = 1E-03f)
        {
            var a = line.A;
            var b = line.B;
            var pt = pts.Relative();
            var p = new PointF((float)Math.Round(pt.X), (float)Math.Round(pt.Y));

            // ensure points are collinear
            var zero = (b.X - a.X) * (p.Y - a.Y) - (p.X - a.X) * (b.Y - a.Y);
            if (zero > t || zero < -t) return false;

            // check if x-coordinates are not equal
            if (a.X - b.X > t || b.X - a.X > t) // ensure x is between a.X & b.X (use tolerance)
                return a.X > b.X
                    ? p.X + t > b.X && p.X - t < a.X
                    : p.X + t > a.X && p.X - t < b.X;

            // ensure y is between a.Y & b.Y (use tolerance)
            return a.Y > b.Y
                ? p.Y + t > b.Y && p.Y - t < a.Y
                : p.Y + t > a.Y && p.Y - t < b.Y;
        }

        /// <summary>
        /// Renders primitive on Graphics handle
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        /// <param name="brush"></param>
        internal override void Render(Graphics graphics, Pen pen, Brush brush = null)
        {
            graphics.DrawLine(pen, A.Scale(), B.Scale());
        }
    }
}
