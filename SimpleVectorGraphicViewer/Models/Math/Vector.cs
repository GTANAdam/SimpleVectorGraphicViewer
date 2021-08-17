using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVectorGraphicViewer.Models.Math
{
    public struct Vector
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static Vector New(PointF p1, PointF p2)
        {
            return new Vector(p2.X - p1.X, p2.Y - p1.Y);
        }

        public static double Dot(Vector u, Vector v)
        {
            return u.X * v.X + u.Y * v.Y;
        }
    }
}
