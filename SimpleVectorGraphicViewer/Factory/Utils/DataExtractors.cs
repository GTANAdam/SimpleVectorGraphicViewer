using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVectorGraphicViewer.Factories
{
    internal static class DataExtractors
    {
        /// <summary>
        /// Gets PointF structure from string
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        internal static PointF GetPoint(string data)
        {
            var currentCulture = System.Globalization.CultureInfo.InstalledUICulture;
            var numberFormat = (System.Globalization.NumberFormatInfo)currentCulture.NumberFormat.Clone();
            numberFormat.NumberDecimalSeparator = ",";

            var point = data.Split(';');
            var x = float.Parse(point[0].Trim(), System.Globalization.NumberStyles.Float, numberFormat);
            var y = float.Parse(point[1].Trim(), System.Globalization.NumberStyles.Float, numberFormat);

            return new PointF(x, y);
        }

        /// <summary>
        /// Gets Color structure from string
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        internal static Color GetColor(string data)
        {
            var cA = data.Split(';');

            var alpha = int.Parse(cA[0].Trim());
            var r = int.Parse(cA[1].Trim());
            var g = int.Parse(cA[2].Trim());
            var b = int.Parse(cA[3].Trim());

            return Color.FromArgb(alpha, r, g, b);
        }
    }
}
