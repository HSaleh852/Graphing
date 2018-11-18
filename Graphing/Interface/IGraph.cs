using System.Collections.Generic;

namespace Graphing.Interface
{
    public interface IGraph
    {
        IEnumerable<IVertex> Vertices { get; }
        bool Adjacent(IVertex v1, IVertex v2);
        IEnumerable<IVertex> Neighbors(IVertex v);
        IGraph AddVertex(IVertex v);
        IGraph RemoveVertex(IVertex v);
        IGraph AddEdge(IVertex v1, IVertex v2);
        IGraph RemoveEdge(IVertex v1, IVertex v2);
    }
}
