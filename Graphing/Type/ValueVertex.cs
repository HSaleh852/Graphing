using Graphing.Interface;

namespace Graphing.Type
{
    public class ValueVertex<T> : Vertex, IValueVertex<T>
    {
        T t;

        public ValueVertex(T t)
        {
            this.t = t;
        }

        public T GetValue()
        {
            return t;
        }

        public IValueVertex<T> SetValue(T t)
        {
            this.t = t;
            return this;
        }

        public override string ToString()
        {
            return t.ToString();
        }
    }
}