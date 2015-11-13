using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Cession.Geometries;
using G = Cession.Geometries;
using System.Windows.Forms;

namespace GeometryDemo
{
    public class PolyTool:Tool
    {
        protected List<G.Point> points = new List<G.Point>();
        protected G.Point? current;

        public override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if(e.Button == MouseButtons.Left && points.Count == 0)
                points.Add(e.Location.ToGp());
        }

        public override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if(e.Button == MouseButtons.Left)
            {
                current = e.Location.ToGp();
                Refresh();
            }
        }

        public override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if(e.Button == MouseButtons.Left)
            {
                points.Add(e.Location.ToGp());
                current = null;
                Refresh();
            }
        }

        public override void Draw(Graphics g)
        {
            if(points.Count > 1)
            {
                for (int i = 0; i < points.Count-1; i++)
                {
                    g.DrawLine(Pens.Black,points[i].ToPointF(), points[i + 1].ToPointF());
                }
            }
            if (null != current && points.Count > 0)
                g.DrawLine(Pens.Black,points.Last().ToPointF(), current.Value.ToPointF());
        }
    }
}
