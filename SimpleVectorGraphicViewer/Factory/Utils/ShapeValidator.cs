using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVectorGraphicViewer.Factory.Utils
{
    internal static class ShapeValidator
    {
        internal static bool IsRectangleAnyOrder(PointF a, PointF b, PointF c, PointF d)
        {
            bool IsOrthogonal(PointF a, PointF b, PointF c)
            {
                return (b.X - a.X) * (b.X - c.X) + (b.Y - a.Y) * (b.Y - c.Y) == 0;
            }

            bool IsRectangle(PointF a, PointF b, PointF c, PointF d)
            {
                return IsOrthogonal(a, b, c) &&
                       IsOrthogonal(b, c, d) &&
                       IsOrthogonal(c, d, a);
            }

            return IsRectangle(a, b, c, d) ||
                   IsRectangle(b, c, a, d) ||
                   IsRectangle(c, a, b, d);
        }
    }
}
