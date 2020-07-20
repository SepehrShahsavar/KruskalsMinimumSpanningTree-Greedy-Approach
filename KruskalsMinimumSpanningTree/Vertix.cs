using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruskalsMinimumSpanningTree
{
    public class Vertix
    {
        public Point Point { get; set; }
        public int Name { get; set; }

        public Vertix(Point p, int v)
        {
            Point = p;
            Name = v;
        }

        public static bool isDuplicated(List<Vertix> vertices , Point p)
        {
            foreach (var item in vertices)
            {
                if (item.Point.Equals(p))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
