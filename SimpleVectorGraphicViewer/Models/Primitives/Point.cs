using System.Drawing;
using System.Drawing.Drawing2D;
using SimpleVectorGraphicViewer.Utils.Extensions;

namespace SimpleVectorGraphicViewer.Models.Primitives
{
    public sealed class Point : Primitive
    {
        private PointF Coord { get; set; }
        internal bool Enabled { get; private set; }

        internal Point() { }

        /// <summary>
        /// Point constructor accepting multiple float params
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        internal Point(float x, float y, Color? color = null) 
        {
            Coord = new PointF(x, y);
            Color = color ?? Color.Black;
        }

        /// <summary>
        /// Point constructor accepting PointF param
        /// </summary>
        /// <param name="point"></param>
        /// <param name="color"></param>
        internal Point(PointF point, Color? color = null)
        {
            Coord = point;
            Color = color ?? Color.Black;
        }

        /// <summary>
        /// Returns Point coordinates
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            var pt = Coord.Relative().Scale();
            return $"({pt.X:0.#}, {pt.Y:0.#})";
        }

        /// <summary>
        /// Renders primitive on Graphics handle
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        /// <param name="brush"></param>
        internal override void Render(Graphics graphics, Pen pen, Brush brush = null)
        {
            using var minorFont = new Font(FontFamily.GenericSansSerif, Plan.UNIT_BLOCK_SIZE / 3);
            var scaledPoint = Coord.Scale();

            //pen.Width = 1.5f;
            pen.DashStyle = DashStyle.Dash;


            var str = ToString();
            var resMes = graphics.MeasureString(str, minorFont);

            graphics.DrawString(str, minorFont, brush, new PointF(scaledPoint.X - resMes.Width / 2, 
                scaledPoint.Y + (scaledPoint.Y < 0 
                ? Plan.UNIT_BLOCK_SIZE / -1.4f 
                : Plan.UNIT_BLOCK_SIZE / 5)));

            graphics.DrawLine(pen, 0, scaledPoint.Y, scaledPoint.X, scaledPoint.Y); // Draw X-Axis
            graphics.DrawLine(pen, scaledPoint.X, 0, scaledPoint.X, scaledPoint.Y); // Draw Y-Axis
            graphics.FillEllipse(brush, scaledPoint.ToPlan());
        }

        /// <summary>
        /// Toggles Enabled property
        /// </summary>
        internal void Toggle()
        {
            Enabled = !Enabled;
        }

        internal PointF Scale() => Coord.Scale();

        /// <summary>
        /// Calculates distance from point to point
        /// </summary>
        /// <param name="point"></param>
        /// <returns>double</returns>
        internal double DistanceTo(PointF point)
        {
            return Coord.DistanceTo(point);
        }
    }
}
