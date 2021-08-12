using System;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;
using SimpleVectorGraphicViewer.Utils.Wrappers;
using SimpleVectorGraphicViewer.Utils.Extensions;
using SimpleVectorGraphicViewer.Models;
using SimpleVectorGraphicViewer.Models.Primitives;
using Rectangle = SimpleVectorGraphicViewer.Models.Primitives.Rectangle;

namespace SimpleVectorGraphicViewer
{
    public class Plan : Control
    {
        internal List<Primitive> Primitives = new();

        internal static float UNIT_BLOCK_SIZE = 25;
        private static readonly System.Drawing.Rectangle PointRect = new(-3, -3, 6, 6);

        private static Pen AxisXPen;
        private static Pen AxisYPen;
        private static Pen MinorPen;

        internal static Font MinorFont;
        private static AdjustableArrowCap BigArrow;

        private Models.Primitives.Point HoveredOn;
        private Cursor CurrentCursor = Cursors.Default;

        private float ViewHeight;

        public Plan()
        {
            ResetView();

            Paint += Plan_Paint;
            MouseDown += Plan_MouseDown;
            MouseMove += Plan_MouseMove;
            MouseWheel += Plan_MouseWheel;
            ResizeRedraw = true;

            // Reduce flickering
            DoubleBuffered = true;

            ShowPresetShapes();
        }

        /// <summary>
        /// Resets zoom level
        /// </summary>
        internal void ResetView()
        {
            ViewHeight = 3.261147f;
        }

        /// <summary>
        /// Shows already defined shapes on graph
        /// </summary>
        internal void ShowPresetShapes()
        {
            var line = new Line(a: new PointF(-3, -3), b: new PointF(-9, -9), color: Color.Blue);
            var line2 = new Line(a: new PointF(-9, -3), b: new PointF(-3, -9), color: Color.Blue);

            var circle = new Circle(center: new PointF(6, -6), radius: 3f, filled: false, color: Color.Chocolate);
            var tria = new Triangle(a: new PointF(6, 8), b: new PointF(3, 3), c: new PointF(9, 3), filled: false, color: Color.Green);
            var rect = new Rectangle(a: new PointF(-9, 8), b: new PointF(-3, 3), filled: false, color: Color.Red);

            Primitives.Clear();

            Primitives.Add(line);
            Primitives.Add(line2);
            Primitives.Add(rect);
            Primitives.Add(circle);
            Primitives.Add(tria);

            Primitives.Add(2, 3, Color.Green);
            Primitives.Add(-3, 1, Color.Red);
            Primitives.Add(-1.5f, -2.5f, Color.Blue);

            Invalidate();
        }

        /// <summary>
        /// Method is invoked whenever control is re/drawn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Plan_Paint(object sender, PaintEventArgs e)
        {
            float res = 3;
            if (Form1.Instance != null && Form1.Instance.scaleWindowToolStripMenuItem.Checked)
            {
                res = (float)Screen.FromControl(this).Bounds.Size.Width / ClientSize.Width;
            }

            UNIT_BLOCK_SIZE = 20 * ViewHeight / res;

            MinorFont = new(FontFamily.GenericSansSerif, UNIT_BLOCK_SIZE / 3);
            BigArrow = new(UNIT_BLOCK_SIZE / 5, UNIT_BLOCK_SIZE / 8);
            AxisXPen = new(Color.Black, 1.5f) { CustomEndCap = BigArrow };
            AxisYPen = new(Color.Black, 1.5f) { CustomStartCap = BigArrow };
            MinorPen = new(Color.Gray, 0.25f) { DashStyle = DashStyle.Dot };

            // Calculate width/height
            var width = ClientSize.Width / 2;
            var height = ClientSize.Height / 2;

            // Smoothen round dot rendering
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Translate 0 to center
            e.Graphics.TranslateTransform(width, height);

            // Render only hovered-on point
            if (HoveredOn != null) 
            {
                e.Graphics.FillEllipse(Brushes.Black, HoveredOn.Coord.Scale().ToPlan());
                return;
            }

            // Render grid
            for (float x = 0, y = 0; x > -width || y > -height; x -= UNIT_BLOCK_SIZE, y -= UNIT_BLOCK_SIZE)
            {
                if (x == 0 || y == 0) continue;

                // Vertical grid loop
                // Draw left vertical lines
                e.Graphics.DrawLine(MinorPen, x, -height, x, height);

                // Graduation
                e.Graphics.DrawLine(Pens.Black, x, 4, x, -4);
                {
                    var str = Math.Round(x / UNIT_BLOCK_SIZE).ToString();
                    var resMes = e.Graphics.MeasureString(str, MinorFont);

                    e.Graphics.DrawString(str, MinorFont, Brushes.Black, new PointF(x - (resMes.Width / 2), 9));
                }

                // Draw right vertical lines
                e.Graphics.DrawLine(MinorPen, -x, -height, -x, height);

                // Graduation
                e.Graphics.DrawLine(Pens.Black, -x, 4, -x, -4);
                {
                    var str = Math.Round(-x / UNIT_BLOCK_SIZE).ToString();
                    var resMes = e.Graphics.MeasureString(str, MinorFont);

                    e.Graphics.DrawString(str, MinorFont, Brushes.Black, new PointF(-x - (resMes.Width / 2), 9));
                }

                // Horizontal grid loop
                // Draw top horizontal lines
                e.Graphics.DrawLine(MinorPen, -width, y, width, y);

                // Graduation
                e.Graphics.DrawLine(Pens.Black, 4, y, -4, y);
                {
                    var str = Math.Round(-y / UNIT_BLOCK_SIZE).ToString();
                    var resMes = e.Graphics.MeasureString(str, MinorFont);

                    e.Graphics.DrawString(str, MinorFont, Brushes.Black, new PointF(9, y - (resMes.Height / 2)));
                }

                // Draw bottom horizontal lines
                e.Graphics.DrawLine(MinorPen, -width, -y, width, -y);

                // Graduation
                e.Graphics.DrawLine(Pens.Black, 4, -y, -4, -y);
                {
                    var str = Math.Round(y / UNIT_BLOCK_SIZE).ToString();
                    var resMes = e.Graphics.MeasureString(str, MinorFont);

                    e.Graphics.DrawString(str, MinorFont, Brushes.Black, new PointF(9, -y - (resMes.Height / 2)));
                }
            }

            // Draw X-Axis
            e.Graphics.DrawLine(AxisXPen, -width, 0, width, 0); 
            e.Graphics.DrawString("x", MinorFont, Brushes.Black, new PointF(width - UNIT_BLOCK_SIZE/3, UNIT_BLOCK_SIZE/6));

            // Draw Y-Axis
            e.Graphics.DrawLine(AxisYPen, 0, -height, 0, height); 
            e.Graphics.DrawString("y", MinorFont, Brushes.Black, new PointF(-UNIT_BLOCK_SIZE/2,  -height));

            // Draw coordinate-0
            e.Graphics.FillEllipse(Brushes.Magenta, PointRect);
            e.Graphics.DrawString("(0,0)", MinorFont, Brushes.Magenta, new PointF(UNIT_BLOCK_SIZE/17, UNIT_BLOCK_SIZE/-1.4f));

            // Draw points
            foreach (var basePrimitive in Primitives)
            {
                using var brush = new SolidBrush(basePrimitive.Color);
                using var pen = new Pen(brush, 1.5f);

                basePrimitive.Render(e.Graphics, pen, brush);
            }

            BigArrow?.Dispose();
            AxisXPen?.Dispose();
            AxisYPen?.Dispose();
            MinorPen?.Dispose();
            MinorFont?.Dispose();
        }

        /// <summary>
        /// Converts a point from one coordinate space to another
        /// </summary>
        /// <param name="location"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        private PointF ConvertPoint(PointF location, CoordinateSpace from, CoordinateSpace to)
        {
            using var g = CreateGraphics();

            // Translate 0-coordinate to middle
            g.TranslateTransform(ClientSize.Width / 2, ClientSize.Height / 2);

            var points = new PointF[] { location };

            // Transform points relative to translated coordinates
            g.TransformPoints(from, to, points);

            return points[0];
        }

        /// <summary>
        /// Method invoked whenever mouse is clicked on control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Plan_MouseDown(object sender, MouseEventArgs e)
        {
            var point = ConvertPoint(e.Location, CoordinateSpace.World, CoordinateSpace.Device);

            var exitLoop = false;
            Parallel.ForEach(Primitives, (prim, state) => // safe
            {
                if (!prim.IsPointWithin(point)) return;

                exitLoop = true;
                state.Stop();
                Form1.Instance.UIThread(() => MessageBoxEx.Show(Form1.Instance, prim.ToString(), "Primitive Properties"));
            });
            if (exitLoop) return;

            var ptr = Primitives.GetClosestTo(point);
            if (ptr == null) return;

            MessageBoxEx.Show(Form1.Instance, $"Type: {ptr.GetType().Name}\nCoordinates: {ptr}\nColor: {ptr.Color.A}; {ptr.Color.R}; {ptr.Color.G}; {ptr.Color.B}", "Properties");
        }

        /// <summary>
        /// Method invoked whenever mouse is moved across the control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Plan_MouseMove(object sender, MouseEventArgs e)
        {
            //if (Environment.TickCount - LastCheck < 1) return;
            //LastCheck = Environment.TickCount;

            CurrentCursor = Cursors.Default;
            var point = ConvertPoint(e.Location, CoordinateSpace.World, CoordinateSpace.Device);

            foreach (var prim in Primitives)
            {
                if (!prim.IsPointWithin(point)) continue;
                CurrentCursor = Cursors.Hand;
                goto End;
            }

            void InvalidatePoint(Models.Primitives.Point ptr)
            {
                var absolutePoint = ConvertPoint(ptr.Coord.Scale(), CoordinateSpace.Device, CoordinateSpace.World);
                var roundedRect = System.Drawing.Rectangle.Round(absolutePoint.ToRect(6));
                Invalidate(roundedRect);
            }

            var ptr = Primitives.GetClosestTo(point);
            if (ptr == null) 
            {
                if (HoveredOn != null && HoveredOn.Enabled)
                {
                    HoveredOn.Enabled = false;
                    InvalidatePoint(HoveredOn);
                    HoveredOn = null;
                }
            }
            else if (!ptr.Enabled)
            {
                ptr.Enabled = true;
                HoveredOn = ptr;
                InvalidatePoint(HoveredOn);
            } else
            {
                CurrentCursor = Cursors.Hand;
            }

            End:
            Cursor.Current = CurrentCursor;
            Form1.Instance.toolStripStatusLabel1.Text = $"Pointer: {point.Relative().String()}";
        }

        /// <summary>
        /// Method invoked whenever mouse wheel is scrolled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Plan_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0 && ViewHeight <= 0.9811481) return;
            ViewHeight += e.Delta/300f;
            Invalidate();
        }
    }
}