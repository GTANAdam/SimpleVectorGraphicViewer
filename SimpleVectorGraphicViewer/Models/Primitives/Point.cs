using System.Drawing;
using System.Drawing.Drawing2D;
using SimpleVectorGraphicViewer.Utils.Extensions;

namespace SimpleVectorGraphicViewer.Models.Primitives
{
    public sealed class Point : Primitive
    {
        public PointF Coord { get; set; }
        public float Size { get; set; }
        public bool Enabled { get; set; }

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
        /// Returns relative position of the point to the graph
        /// </summary>
        /// <returns>PointF</returns>
        internal PointF Relative()
        {
            return new PointF(Coord.X / Plan.UNIT_BLOCK_SIZE, Coord.Y / -Plan.UNIT_BLOCK_SIZE);
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
        /// Calculates distance from point to point
        /// </summary>
        /// <param name="point"></param>
        /// <returns>double</returns>
        internal double DistanceTo(PointF point)
        {
            return Coord.DistanceTo(point);
        }

        /// <summary>
        /// Renders primitive on Graphics handle
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        /// <param name="brush"></param>
        internal override void Render(Graphics graphics, Pen pen, Brush brush = null)
        {
            var scaledPoint = Coord.Scale();

            //pen.Width = 1.5f;
            pen.DashStyle = DashStyle.Dash;

            var str = ToString();
            var resMes = graphics.MeasureString(str, Plan.MinorFont);

            graphics.DrawString(str, Plan.MinorFont, brush, new PointF(scaledPoint.X - resMes.Width / 2, 
                scaledPoint.Y + (scaledPoint.Y < 0 
                ? Plan.UNIT_BLOCK_SIZE / -1.4f 
                : Plan.UNIT_BLOCK_SIZE / 5)));

            graphics.DrawLine(pen, 0, scaledPoint.Y, scaledPoint.X, scaledPoint.Y); // Draw X-Axis
            graphics.DrawLine(pen, scaledPoint.X, 0, scaledPoint.X, scaledPoint.Y); // Draw Y-Axis
            graphics.FillEllipse(brush, scaledPoint.ToPlan());
        }
    }
}
