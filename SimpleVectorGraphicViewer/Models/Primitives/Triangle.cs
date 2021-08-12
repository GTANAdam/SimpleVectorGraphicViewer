using System.Drawing;
using SimpleVectorGraphicViewer.Utils.Extensions;

namespace SimpleVectorGraphicViewer.Models.Primitives
{
    public class Triangle : Line
    {
        public PointF C { get; set; }
        internal Triangle() { }

        /// <summary>
        /// Triangle constructor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="color"></param>
        /// <param name="filled"></param>
        internal Triangle(PointF a, PointF b, PointF c, Color? color = null, bool filled = false) : base(a, b, color)
        {
            C = c;
            Filled = filled;
        }

        /// <summary>
        /// Returns primitives properties
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return $"Type: {GetType().Name}\n" +
                    $"A: {A}\n" +
                    $"B: {B}\n" +
                    $"C: {C}\n" +
                    $"Color: {Color.A}; {Color.R}; {Color.G}; {Color.B} {(Color.IsNamedColor ? $"({Color.Name})" : "")}\n" +
                    $"Filled: {Filled}";
        }

        /// <summary>
        /// Checks if point is within the primitive
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        internal override bool IsPointWithin(PointF point) => IsPointWithin(point, this);

        /// <summary>
        /// Checks if point is within the primitive
        /// </summary>
        /// <param name="pts"></param>
        /// <param name="triangle"></param>
        /// <returns></returns>
        internal static bool IsPointWithin(PointF pts, Triangle triangle)
        {
            static float sign(PointF p1, PointF p2, PointF p3) => (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);

            var pt = pts.Relative();

            float d1, d2, d3;
            bool has_neg, has_pos;

            d1 = sign(pt, triangle.A, triangle.B);
            d2 = sign(pt, triangle.B, triangle.C);
            d3 = sign(pt, triangle.C, triangle.A);

            has_neg = (d1 < 0) || (d2 < 0) || (d3 < 0);
            has_pos = (d1 > 0) || (d2 > 0) || (d3 > 0);

            return !(has_neg && has_pos);
        }

        /// <summary>
        /// Renders primitive on Graphic handle
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        /// <param name="brush"></param>
        internal override void Render(Graphics graphics, Pen pen, Brush brush = null)
        {
            var poly = new PointF[] { A.Scale(), B.Scale(), C.Scale() };
            graphics.DrawPolygon(pen, poly);
            if (Filled) graphics.FillPolygon(brush, poly);
        }
    }
}
