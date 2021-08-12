using System.Drawing;

namespace SimpleVectorGraphicViewer.Models
{
    public abstract class Primitive
    {
        public Color Color { get; set; } = Color.Black;
        public bool Filled { get; set; }

        internal virtual bool IsPointWithin(PointF point) => false;
        internal virtual void Render(Graphics graphics, Pen pen, Brush brush = null) { }
    }
}
