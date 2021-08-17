using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using SimpleVectorGraphicViewer.Models.Math;
using SimpleVectorGraphicViewer.Utils.Extensions;

namespace SimpleVectorGraphicViewer.Models.Primitives
{
    public sealed class Rectangle : Primitive
    {
        internal Rectangle() { }

        private PointF A { get; set; }
        private PointF B { get; set; }
        private PointF C { get; set; }
        private PointF D { get; set; }

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
        /// Rectangle constructor taking 4 points
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="color"></param>
        /// <param name="filled"></param>
        internal Rectangle(PointF a, PointF b, PointF c, PointF d, Color? color = null, bool filled = false) : this(a, b, color, filled)
        {
            C = c;
            D = d;
        }
        
        /// <summary>
        /// Returns primitive properties
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            var res = $"Type: {GetType().Name}\nA: {A}\nB: {B}\n";
            if (!C.IsEmpty && !D.IsEmpty) res += $"C: {C}\nD: {D}\n";
            res += $"Color: {Color.A}; {Color.R}; {Color.G}; {Color.B} {(Color.IsNamedColor ? $"({Color.Name})" : "")}\nFilled: {Filled}";
            return res;
        }

        /// <summary>
        /// Checks if point is within the primitive
        /// </summary>
        /// <param name="point">Point</param>
        /// <returns>bool</returns>
        internal override bool IsPointWithin(PointF point)
        {
            if (C.IsEmpty && D.IsEmpty)
                return GetRectangle().Contains(point);

            // If Rhombus
            var a = A.Scale();
            var b = B.Scale();
            var AB = Vector.New(a, b);
            var AM = Vector.New(a, point);
            var BC = Vector.New(b, C.Scale());
            var BM = Vector.New(b, point);
            var dotABAM = Vector.Dot(AB, AM);
            var dotBCBM = Vector.Dot(BC, BM);
            return 0 <= dotABAM && dotABAM <= Vector.Dot(AB, AB) && 0 <= dotBCBM && dotBCBM <= Vector.Dot(BC, BC);
        }

        /// <summary>
        /// Renders primitive on a Graphic handle
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        /// <param name="brush"></param>
        internal override void Render(Graphics graphics, Pen pen, Brush brush = null)
        {
            if (C.IsEmpty && D.IsEmpty)
            {
                var rect = GetRectangle();
                graphics.DrawRectangles(pen, new RectangleF[] { rect });
                if (Filled) graphics.FillRectangle(brush, rect);
            }
            else // If Rhombus
            {
                using var path = new GraphicsPath();
                path.StartFigure();
                path.AddPolygon(new [] {A.Scale(), B.Scale(), C.Scale(), D.Scale() });
                path.CloseFigure();
                graphics.DrawPath(pen, path);
                if (Filled) graphics.FillPath(brush, path);
            }
        }

        /// <summary>
        /// Creates a rectangle based on two points.
        /// </summary>
        /// <param name="p1">Point 1</param>
        /// <param name="p2">Point 2</param>
        /// <returns>RectangleF</returns>
        private RectangleF GetRectangle()
        {
            var a = A.Scale();
            var b = B.Scale();
            var top = System.Math.Min(a.Y, b.Y);
            var bottom = System.Math.Max(a.Y, b.Y);
            var left = System.Math.Min(a.X, b.X);
            var right = System.Math.Max(a.X, b.X);

            return RectangleF.FromLTRB(left, top, right, bottom);
        }
    }
}
