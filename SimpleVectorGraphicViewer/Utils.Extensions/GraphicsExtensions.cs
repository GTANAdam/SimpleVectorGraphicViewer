using System.Drawing;

namespace SimpleVectorGraphicViewer.Utils.Extensions
{
    internal static class GraphicsExtensions
    {
        /// <summary>
        /// Draws circle on Graphics handle
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        /// <param name="centerX"></param>
        /// <param name="centerY"></param>
        /// <param name="radius"></param>
        internal static void DrawCircle(this Graphics g, Pen pen, float centerX, float centerY, float radius)
        {
            g.DrawEllipse(pen, centerX - radius, centerY - radius, radius + radius, radius + radius);
        }

        /// <summary>
        /// Fills circle on Graphics handle
        /// </summary>
        /// <param name="g"></param>
        /// <param name="brush"></param>
        /// <param name="centerX"></param>
        /// <param name="centerY"></param>
        /// <param name="radius"></param>
        internal static void FillCircle(this Graphics g, Brush brush, float centerX, float centerY, float radius)
        {
            g.FillEllipse(brush, centerX - radius, centerY - radius, radius + radius, radius + radius);
        }
    }
}
