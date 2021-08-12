using System;
using System.Drawing;

namespace SimpleVectorGraphicViewer.Utils.Extensions
{
    internal static class PointExtensions
    {
        /// <summary>
        /// Returns relative positional coordinates
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        internal static PointF Relative(this PointF point)
        {
            return new PointF(point.X / Plan.UNIT_BLOCK_SIZE, point.Y / -Plan.UNIT_BLOCK_SIZE);
        }

        /// <summary>
        /// Returns distance from point1 to point2
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        internal static double DistanceTo(this PointF point1, PointF point2)
        {
            return Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
        }

        /// <summary>
        /// Returns coordinate properties
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        internal static string String(this PointF point)
        {
            return $"({point.X:0.#}, {point.Y:0.#})";
        }

        /// <summary>
        /// Returns scaled coordinates
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        internal static PointF Scale(this PointF point)
        {
            return new PointF(point.X * Plan.UNIT_BLOCK_SIZE, point.Y * -Plan.UNIT_BLOCK_SIZE);
        }
    }
}
