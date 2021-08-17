using System;
using System.Drawing;
using SimpleVectorGraphicViewer.Utils.Extensions;

namespace SimpleVectorGraphicViewer.Models.Primitives
{
    public sealed class Rectangle : Primitive
    {
        internal Rectangle() { }

        private PointF A { get; set; }
        private PointF B { get; set; }

        /// <summary>
        /// Rectangle constructor taking 2 points
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="color"></param>
        /// <param name="filled"></param>
        internal Rectangle(PointF a, PointF b, Color? color = null, bool filled = false)
        {
            A = a;
            B = b;
            Filled = filled;
            Color = color ?? Color.Black;
        }

        /// <summary>
        /// Creates a rectangle based on two points.
        /// </summary>
        /// <param name="p1">Point 1</param>
        /// <param name="p2">Point 2</param>
        /// <returns>RectangleF</returns>
        internal static RectangleF GetRectangle(PointF p1, PointF p2)
        {
            var top = Math.Min(p1.Y, p2.Y);
            var bottom = Math.Max(p1.Y, p2.Y);
            var left = Math.Min(p1.X, p2.X);
            var right = Math.Max(p1.X, p2.X);

            return RectangleF.FromLTRB(left, top, right, bottom);
        }

        /// <summary>
        /// Checks if point is within the primitive
        /// </summary>
        /// <param name="point">Point</param>
        /// <returns>bool</returns>
        internal override bool IsPointWithin(PointF point) => IsPointWithin(point, this);

        /// <summary>
        /// Checks if point is within the primitive
        /// </summary>
        /// <param name="point">Point</param>
        /// <param name="rect">Rectangle</param>
        /// <returns>bool</returns>
        internal static bool IsPointWithin(PointF point, Rectangle rect)
        {
            return GetRectangle(rect.A, rect.B).Contains(point.Relative());
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
                    $"Color: {Color.A}; {Color.R}; {Color.G}; {Color.B} {(Color.IsNamedColor ? $"({Color.Name})" : "")}\n" +
                    $"Filled: {Filled}";
        }

        /// <summary>
        /// Renders primitive on a Graphic handle
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        /// <param name="brush"></param>
        internal override void Render(Graphics graphics, Pen pen, Brush brush = null)
        {
            var rect = GetRectangle(A.Scale(), B.Scale());
            graphics.DrawRectangles(pen, new RectangleF[] { rect });
            if (Filled) graphics.FillRectangle(brush, rect);
        }
    }
}
