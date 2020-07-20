using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KruskalsMinimumSpanningTree
{
    public partial class Form2 : Form
    {
        private readonly int _radius = 20;
        private int vertix;
        List<Vertix> points;
        List<Edge> edges;

        public Form2(int height, int width, List<Vertix> points , List<Edge> e , int v)
        {
            InitializeComponent();
            this.Height = height;
            this.Width = width;
            this.points = points;
            vertix = v;
            edges = e;
        }

        private void Draw(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Pen black = new Pen(Color.Black);
            Pen yellow = new Pen(Color.FromArgb(0, 8, 57));
            SolidBrush yellowBrush = new SolidBrush(Color.FromArgb(255, 164, 27));

            Graph graph = new Graph(vertix , edges);
            graph.kruskalMST();

            for (int i = 0; i < graph.result.Count; i++)
            {
                Edge edge = graph.result[i];
                Point src = points.Where(x => x.Name == edge.src).FirstOrDefault().Point;
                Point dest = points.Where(x => x.Name == edge.dest).FirstOrDefault().Point;
                g.DrawLine(yellow, src.X, src.Y, dest.X, dest.Y);
            }


            for (int i = 0; i < points.Count; i++)
            {
                Point point = points[i].Point;
                g.DrawEllipse(black , point.X - _radius , point.Y - _radius , 2 * _radius, 2 * _radius);
                g.FillEllipse(yellowBrush, point.X - _radius, point.Y - _radius, 2 * _radius, 2 * _radius);
            }

      
            e.Dispose();
        }

    }
}
