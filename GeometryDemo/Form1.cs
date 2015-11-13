using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeometryDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitTools();
        }

        private void InitTools()
        {
            var tools = new Tool[]
            {
                new LineTool(),
                new PolyTool(),
                new SplitTestTool(),
            };

            foreach (var t in tools)
            {
                var menuItem = new ToolStripMenuItem();
                menuItem.Text = t.GetType().Name;
                menuItem.Tag = t;
                menuItem.Click += MenuItem_Click;
                toolsToolStripMenuItem.DropDownItems.Add(menuItem);
            }
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;
            var tool = menuItem.Tag as Tool;
            geometryPanel1.Tool = tool;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Tool.Panel = geometryPanel1;
        }
    }
}
