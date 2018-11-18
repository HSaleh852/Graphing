using Graphing.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphing.Type
{
    public class RandomGraph : AdjacencyGraph, IRandomGraph
    {
        Random r;

        public RandomGraph(int n, GraphPermissions permissions, GraphBehaviour behaviour) : base(permissions, behaviour)
        {
            while (n-- > 0)
                AddVertex(new Vertex());//maybe abstract this away with a generic parameter

            r = new Random(DateTime.Now.Millisecond);
        }
        public RandomGraph(int n) : this(n, defaultPermissions, defaultBehaviour) { }

        public IRandomGraph NextEdge()
        {
            IVertex v;
            switch (permissions)
            {
                case GraphPermissions.AllowMultipleEdges | GraphPermissions.AllowLoops:
                    RandomVertex(vertices).LinkTo(RandomVertex(vertices));
                    break;
                case GraphPermissions.AllowMultipleEdges:
                    v = RandomVertex(vertices);
                    v.LinkTo(RandomVertex(vertices.Where(x => x != v).ToList()));
                    break;
                case GraphPermissions.AllowLoops:
                    v = RandomVertex(vertices.Where(x => x.AdjacentVertices.Count() < vertices.Count - 1).ToList());
                    v.LinkTo(RandomVertex(vertices.Except(v.AdjacentVertices).ToList()));
                    break;
                default:
                    if (vertices.All(x => x.AdjacentVertices.Count() == vertices.Count - 1))
                        return this;

                    v = RandomVertex(vertices.Where(x => x.AdjacentVertices.Count() < vertices.Count - 1).ToList());
                    v.LinkTo(RandomVertex(vertices.Except(v.AdjacentVertices.Concat(new List<IVertex>() { v })).ToList()));
                    break;
            }

            return this;
        }

        IVertex RandomVertex(List<IVertex> vert)
        {
            return vert[r.Next(vert.Count)];
        }
    }
}
