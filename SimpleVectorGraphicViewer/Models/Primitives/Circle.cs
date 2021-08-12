using System.Drawing;
using SimpleVectorGraphicViewer.Utils.Extensions;

namespace SimpleVectorGraphicViewer.Models.Primitives
{
    public class Circle : Primitive
    {
        public PointF Center { get; set; }
        public float Radius { get; set; }

        internal Circle() { }

        /// <summary>
        /// Circle constructor
        /// </summary>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        /// <param name="color"></param>
        /// <param name="filled"></param>
        internal Circle(PointF center, float radius, Color? color = null, bool filled = false)
        {
            Center = center;
            Radius = radius;
            Filled = filled;
            Color = color ?? Color.Black;
        }

        /// <summary>
        /// Returns primitive properties
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return $"Type: {GetType().Name}\n" +
                    $"Center: {Center}\n" +
                    $"Radius: {Radius} units\n" +
                    $"Color: {Color.A}; {Color.R}; {Color.G}; {Color.B} {(Color.IsNamedColor ? $"({Color.Name})" : "" )}\n" +
                    $"Filled: {Filled}";
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
        /// <param name="circle">Rectangle</param>
        /// <returns>bool</returns>
        internal static bool IsPointWithin(PointF point, Circle circle)
        {
            var pt = point.Relative();

            float dx = pt.X - circle.Center.X;
            float dy = pt.Y - circle.Center.Y;
            return (dx * dx + dy * dy <= circle.Radius * circle.Radius);
        }

        /// <summary>
        /// Renders primitive on Graphics handle
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        /// <param name="brush"></param>
        internal override void Render(Graphics graphics, Pen pen, Brush brush = null)
        {
            var scaledCenter = Center.Scale();
            graphics.DrawCircle(pen, scaledCenter.X, scaledCenter.Y, Radius * Plan.UNIT_BLOCK_SIZE);
            if (Filled) graphics.FillCircle(brush, scaledCenter.X, scaledCenter.Y, Radius * Plan.UNIT_BLOCK_SIZE);
        }
    }
}
