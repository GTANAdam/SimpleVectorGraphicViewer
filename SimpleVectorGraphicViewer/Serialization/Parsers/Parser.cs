using System.Collections.Generic;
using System.Drawing;
using System.IO;
using SimpleVectorGraphicViewer.Models;
using SimpleVectorGraphicViewer.Models.Primitives;

namespace SimpleVectorGraphicViewer.Serialization.Parsers
{
    internal static class Parser
    {
        /// <summary>
        /// Gets PointF structure from string
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static PointF ParsePoint(string data)
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
        private static Color ProcessColor(string data)
        {
            var cA = data.Split(';');

            var alpha = int.Parse(cA[0].Trim());
            var r = int.Parse(cA[1].Trim());
            var g = int.Parse(cA[2].Trim());
            var b = int.Parse(cA[3].Trim());

            return Color.FromArgb(alpha, r, g, b);
        }

        /// <summary>
        /// Returns a list of Primitives from a given path
        /// </summary>
        /// <param name="serializer"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        internal static IEnumerable<Primitive> ParseFile(ISerializer serializer, string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException();
            var fileData = File.ReadAllText(path);

            return ParseData(serializer, fileData);
        }

        /// <summary>
        /// Returns a list of primitives from given string dataa
        /// </summary>
        /// <param name="serializer"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        internal static List<Primitive> ParseData(ISerializer serializer, string data)
        {
            var list = new List<Primitive>();

            foreach (var entry in serializer.Deserialize<PrimitiveRaw[]>(data))
            {
                // Process color
                var color = ProcessColor(entry.Color);

                switch (entry.Type)
                {
                    case "point":
                        {
                            // Process Point
                            var point = ParsePoint(entry.A);

                            list.Add(new Models.Primitives.Point(point, color));
                            break;
                        }

                    case "line" or "rectangle":
                        {
                            // Process A
                            var a = ParsePoint(entry.A);

                            // Process B
                            var b = ParsePoint(entry.B);

                            list.Add(entry.Type == "line" ? new Line(a, b, color) : new Models.Primitives.Rectangle(a, b, color, entry.Filled));
                            break;
                        }

                    case "circle":
                        {
                            // Process Center
                            var center = ParsePoint(entry.Center);

                            list.Add(new Circle(center, entry.Radius, color, entry.Filled));
                            break;
                        }

                    case "triangle":
                        {
                            // Process A
                            var a = ParsePoint(entry.A);

                            // Process B
                            var b = ParsePoint(entry.B);

                            // Process C
                            var c = ParsePoint(entry.C);

                            list.Add(new Triangle(a, b, c, color, entry.Filled));
                            break;
                        }
                }
            }

            return list;
        }
    }
}
