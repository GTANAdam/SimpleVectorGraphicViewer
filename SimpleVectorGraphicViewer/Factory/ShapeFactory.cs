using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleVectorGraphicViewer.Factories.Interfaces;
using SimpleVectorGraphicViewer.Factory.Utils;
using SimpleVectorGraphicViewer.Models;
using SimpleVectorGraphicViewer.Models.Primitives;
using SimpleVectorGraphicViewer.Utils.Wrappers;

namespace SimpleVectorGraphicViewer.Factories
{
    internal class ShapeFactory : IShapeFactory
    {
        Primitive IShapeFactory.Create(PrimitiveRaw entry)
        {
            var color = DataExtractors.GetColor(entry.Color);

            switch (entry.Type)
            {
                case "point":
                    {
                        // Process Point
                        var point = DataExtractors.GetPoint(entry.A);
                        return new Point(point, color);
                    }

                case "line":
                    {
                        var a = DataExtractors.GetPoint(entry.A);
                        var b = DataExtractors.GetPoint(entry.B);

                        return new Line(a, b, color);
                    }

                case "rectangle":
                    {
                        var a = DataExtractors.GetPoint(entry.A);
                        var b = DataExtractors.GetPoint(entry.B);

                        // if 4 points were provided
                        if (!string.IsNullOrWhiteSpace(entry.C) && !string.IsNullOrWhiteSpace(entry.D))
                        {
                            var c = DataExtractors.GetPoint(entry.C);
                            var d = DataExtractors.GetPoint(entry.D);

                            if (ShapeValidator.IsRectangleAnyOrder(a, b, c, d))
                            {
                                return new Rectangle(a, b, c, d, color, entry.Filled);
                            }
                            else // Not a rectangle
                            {
                                MessageBoxEx.Show(Form1.Instance, "Incorrect rectangle coordinates!", "Incorrect Shape Error");
                                return null; 
                            }
                        }

                        return new Rectangle(a, b, color, entry.Filled);
                    }

                case "circle":
                    {
                        // Process Center
                        var center = DataExtractors.GetPoint(entry.Center);
                        return new Circle(center, entry.Radius, color, entry.Filled);
                    }

                case "triangle":
                    {
                        // Process A
                        var a = DataExtractors.GetPoint(entry.A);
                        var b = DataExtractors.GetPoint(entry.B);
                        var c = DataExtractors.GetPoint(entry.C);

                        return new Triangle(a, b, c, color, entry.Filled);
                    }

                default: return null;
            }
        }
    }
}
