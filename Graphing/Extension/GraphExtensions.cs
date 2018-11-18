using Graphing.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphing.Extension
{
    public static class GraphExtensions
    {
        public static bool IsConnected(this IGraph graph)
        {
            if (graph.Vertices.Count() < 2)
                return true;

            var covered = new List<IVertex>();
            Queue<IVertex> q = new Queue<IVertex>();
            q.Enqueue(graph.Vertices.First());
            while (q.Count > 0)
            {
                var current = q.Peek();
                covered.Add(current);
                foreach (var v in current.AdjacentVertices)
                    if (!covered.Contains(v))
                        q.Enqueue(v);

                q.Dequeue();
            }

            return covered.Count == graph.Vertices.Count();
        }
    }
}
