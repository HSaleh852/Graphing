using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphing.Interface
{
    public interface IRandomGraph : IGraph
    {
        IRandomGraph NextEdge();
    }
}
