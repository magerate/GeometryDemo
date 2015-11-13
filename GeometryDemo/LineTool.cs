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
    public class LineTool:Tool
    {
        private G.Point? p1;
        private G.Point? p2;

        public override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                p1 = e.Location.ToGp();
        }

        public override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                p2 = e.Location.ToGp();
            Refresh();
        }

        public override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                p2 = e.Location.ToGp();
            Refresh();
        }

        public override void Draw(Graphics g)
        {
            if(p1 != null && p2 != null)
            {
                g.DrawLine(Pens.Black, p1.Value.ToPointF(), p2.Value.ToPointF());
            }
        }
    }
}
