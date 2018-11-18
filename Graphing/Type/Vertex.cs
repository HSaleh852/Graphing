using Graphing.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphing.Type
{
    public class Vertex : IVertex
    {
        List<IVertex> adjacentVertices;
        public IEnumerable<IVertex> AdjacentVertices => adjacentVertices;

        public Vertex()
        {
            adjacentVertices = new List<IVertex>();
        }

        public bool IsAdjacentTo(IVertex v)
        {
            return adjacentVertices.Contains(v);
        }

        public IVertex LinkTo(IVertex v)
        {
            //test is it's there?
            adjacentVertices.Add(v);

            if (v is Vertex x)
                x.adjacentVertices.Add(this);
            else v.LinkTo(this);

            return this;
        }

        public IVertex RemoveLink(IVertex v)
        {
            //test is it's there?
            adjacentVertices.Remove(v);

            if (v is Vertex x)
                x.adjacentVertices.Remove(this);
            else v.RemoveLink(this);

            return this;
        }
    }
}
