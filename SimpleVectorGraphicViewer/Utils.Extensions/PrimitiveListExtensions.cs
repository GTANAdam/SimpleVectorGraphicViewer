using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using SimpleVectorGraphicViewer.Models;

namespace SimpleVectorGraphicViewer.Utils.Extensions
{
    internal static class PrimitiveListExtensions
    {
        /// <summary>
        /// Adds Primitive to list, accept floats instead of a Point structure
        /// </summary>
        /// <param name="list"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        internal static void Add(this List<Primitive> list, float x, float y, Color color)
        {
            list.Add(new Models.Primitives.Point(x, y, color));
        }

        /// <summary>
        /// Gets the closest Point of given coordinates
        /// </summary>
        /// <param name="points"></param>
        /// <param name="point"></param>
        /// <param name="constraint"></param>
        /// <returns></returns>
        internal static Models.Primitives.Point GetClosestTo(this List<Primitive> points, PointF point, float constraint = 5f)
        {
            var target = point.Relative();
            var closestPoint = points.Where(x => x is Models.Primitives.Point).Cast<Models.Primitives.Point>()
                .OrderBy(p => p.DistanceTo(target))
                .FirstOrDefault();

            if (constraint > 0f && closestPoint?.DistanceTo(target) > 0.3f) return null;

            return closestPoint;
        }
    }
}
