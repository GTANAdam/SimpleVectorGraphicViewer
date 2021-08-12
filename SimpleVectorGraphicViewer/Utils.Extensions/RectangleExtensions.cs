using System.Drawing;

namespace SimpleVectorGraphicViewer.Utils.Extensions
{
    internal static class RectangleExtensions
    {
        /// <summary>
        /// Returns a Rectangle from a Point and size
        /// </summary>
        /// <param name="point"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        internal static RectangleF ToRect(this PointF point, int size)
        {
            return new RectangleF(point.X - (size / 2), point.Y - (size / 2), size, size);
        }

        /// <summary>
        /// Returns Rectangle points relative to plan
        /// </summary>
        /// <param name="dp"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        internal static RectangleF ToPlan(this PointF dp, float size = 0f)
        {
            return new RectangleF(dp.X - 3 - (size / 2), dp.Y - 3 - (size / 2), 6 + size, 6 + size);
        }
    }
}
