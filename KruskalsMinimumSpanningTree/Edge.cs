using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruskalsMinimumSpanningTree
{
    public class Edge : IComparable<Edge>
    {
        public int src , dest , weight;

        public Edge(int s , int d , int w)
        {
            src = s;
            dest = d;
            weight = w;
        }

        public Edge()
        {

        }
        public int CompareTo(Edge other)
        {
            return this.weight - other.weight;
        }
    }
}
