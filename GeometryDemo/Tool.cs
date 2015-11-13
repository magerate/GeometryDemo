using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GeometryDemo
{
    public abstract class Tool
    {
        public static GeometryPanel Panel { get; set; }

        public virtual void OnMouseDown(MouseEventArgs e)
        {
        }

        public virtual void OnMouseUp(MouseEventArgs e)
        {
        }

        public virtual void OnMouseMove(MouseEventArgs e)
        {
        }

        public virtual void OnDoubleClick(EventArgs e)
        {

        }

        public virtual void OnKeyDown(KeyEventArgs e)
        {

        }

        public virtual void Draw(Graphics g)
        {

        }

        public void Refresh()
        {
            Panel.Invalidate();
        }
    }
}
