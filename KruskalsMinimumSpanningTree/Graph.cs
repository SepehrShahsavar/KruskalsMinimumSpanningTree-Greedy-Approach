using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruskalsMinimumSpanningTree
{
    public class Graph
    {
        private int vertice;
        private List<Edge> edges;
        public List<Edge> result = new List<Edge>();
        public Graph(int v , List<Edge> edges)
        {
            vertice = v;
            this.edges = edges;

        }

        private int find(Subset[] subsets , int i)
        {
            if(subsets[i].parent != i)
            {
                subsets[i].parent = find(subsets, subsets[i].parent);
            }

            return subsets[i].parent;
        }

        private void merge(Subset[] subsets , int x , int y)
        {
            int xroot = find(subsets, x);
            int yroot = find(subsets, y);
 
            if (subsets[xroot].rank < subsets[yroot].rank)
                subsets[xroot].parent = yroot;
            else if (subsets[xroot].rank > subsets[yroot].rank)
                subsets[yroot].parent = xroot;
            else
            {
                subsets[yroot].parent = xroot;
                subsets[xroot].rank++;
            }
        }

        public void kruskalMST()
        {
            int e = 0;   
            int i = 0; 

            // step 1 : sorting edges by their weight 
            edges.Sort();

            Subset[] subsets = new Subset[vertice];
            for (i = 0; i < vertice; ++i)
                subsets[i] = new Subset();

            // Create V subsets with single elements  
            for (int v = 0; v < vertice; ++v)
            {
                subsets[v].parent = v;
                subsets[v].rank = 0;
            }

            i = 0; 
 
            while (e < vertice - 1)
            {
                // step 2: Pick the smallest edge
                var next_edge = edges[i++];

                int x = find(subsets, next_edge.src);
                int y = find(subsets, next_edge.dest);

                // If including this edge does't cause cycle,  
                // include it in result and increment the index  
                // of result for next edge
                // and merge the subsets 
                if (x != y)
                {
                    result.Add(next_edge);
                    e++;
                    merge(subsets, x, y);
                }
            }
        }
    }
}
