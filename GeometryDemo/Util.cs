using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GeometryDemo
{
    public static class Util
    {
        public static Cession.Geometries.Point ToGp(this Point p)
        {
            return new Cession.Geometries.Point(p.X, p.Y);
        }

        public static PointF ToPointF(this Cession.Geometries.Point p)
        {
            return new PointF((float)p.X, (float)p.Y);
        }
    }
}
