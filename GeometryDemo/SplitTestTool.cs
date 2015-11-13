using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Cession.Geometries;
using G = Cession.Geometries;

namespace GeometryDemo
{
    public class SplitTestTool:PolyTool
    {
        private G.Point[] polygon;
        private G.Point? p1;
        private G.Point? p2;
        private G.Point[][] result;
        private Random rnd = new Random();

        private Color GetRandomColor()
        {
            return Color.FromArgb(255,
                rnd.Next(255),
                rnd.Next(255),
                rnd.Next(255)
                );
        }

        public override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if(e.Button == MouseButtons.Right)
            {
                if (polygon == null)
                {
                    polygon = points.ToArray();
                    points.Clear();
                }
                else if (p1 == null || p2 == null)
                {
                    p1 = points[0];
                    p2 = points[1];
                }

                if(polygon != null && p1 != null && p2 != null)
                {
                    result = Polygon.Split(polygon, p1.Value, p2.Value);
                }
                Refresh();
            }
        }

        public override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if(e.KeyCode == Keys.Space)
            {
                points.Clear();
                current = null;
                polygon = null;
                result = null;
                p1 = null;
                p2 = null;
                Refresh();
            }
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);
            if(polygon != null && result == null)
            {
                g.FillPolygon(Brushes.Blue, polygon.Select(p => p.ToPointF()).ToArray());
            }

            if(result != null)
            {
                foreach (var item in result)
                {
                    var brush = new SolidBrush(GetRandomColor());
                    var rp = item.Select(p => p.ToPointF()).ToArray();
                    g.FillPolygon(brush, rp);
                    g.DrawPolygon(Pens.Black, rp);
                    brush.Dispose();
                }
            }
        }
    }
}
