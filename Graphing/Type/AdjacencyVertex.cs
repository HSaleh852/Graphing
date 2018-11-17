using System.Collections.Generic;
using Graphing.Interface;

namespace Graphing.Type
{
    public class AdjacencyVertex : IVertex
    {
        public List<AdjacencyVertex> AdjacentVertices { private set; get; }

        public AdjacencyVertex()
        {
            AdjacentVertices = new List<AdjacencyVertex>();
        }

        public static void Connect(AdjacencyVertex v1, AdjacencyVertex v2)
        {
            v1.AdjacentVertices.Add(v2);
            v2.AdjacentVertices.Add(v1);
        }

        public static void Disconnect(AdjacencyVertex v1, AdjacencyVertex v2)
        {
            v1.AdjacentVertices.Remove(v2);
            v2.AdjacentVertices.Remove(v1);
        }
    }
}
