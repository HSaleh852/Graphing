namespace Graphing.Interface
{
    public interface IWeightedGraph<T> : IGraph
    {
        T GetEdgeValue(IVertex v1, IVertex v2);
        IWeightedGraph<T> SetEdgeValue(IVertex v1, IVertex v2, T val);
    }
}
