using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphing.Interface
{
    public interface IValueVertex<T> : IVertex
    {
        T GetValue();
        IValueVertex<T> SetValue(T t);
    }
}
