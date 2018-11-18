using System.Collections.Generic;

namespace Graphing.Interface
{
    public interface IVertex
    {
        IEnumerable<IVertex> AdjacentVertices { get; }
        bool IsAdjacentTo(IVertex v);
        IVertex LinkTo(IVertex v);
        IVertex RemoveLink(IVertex v);
    }
}
