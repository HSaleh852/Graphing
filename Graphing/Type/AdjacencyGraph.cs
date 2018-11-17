using Graphing.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphing.Type
{
    public class AdjacencyGraph : IGraph
    {
        public List<AdjacencyVertex> Vertices { private set; get; }

        public AdjacencyGraph()
        {
            Vertices = new List<AdjacencyVertex>();
        }

        public IGraph AddEdge(IVertex v1, IVertex v2)
        {
            var t1 = AssertIsAdjacencyVertex(v1, "Vertex v1 must be of type AdjacencyVertex.");
            var t2 = AssertIsAdjacencyVertex(v2, "Vertex v2 must be of type AdjacencyVertex.");
            AssertIsInGraph(t1, "Vertex v1 must be in the graph.");
            AssertIsInGraph(t2, "Vertex v2 must be in the graph.");
            AssertIsNotInGraph(t1, t2, "Vertices already connected.");

            AdjacencyVertex.Connect(t1, t2);
            return this;
        }

        public IGraph AddVertex(IVertex v)
        {
            var t = AssertIsAdjacencyVertex(v, "Vertex must be of type AdjacencyVertex.");
            AssertIsNotInGraph(t, "Vertex already in graph.");

            Vertices.Add(t);

            return this;
        }

        public bool Adjacent(IVertex v1, IVertex v2)
        {
            var t1 = AssertIsAdjacencyVertex(v1, "Vertex v1 must be of type AdjacencyVertex.");
            var t2 = AssertIsAdjacencyVertex(v2, "Vertex v2 must be of type AdjacencyVertex.");
            AssertIsInGraph(t1, "Vertex v1 must be in the graph.");
            AssertIsInGraph(t2, "Vertex v2 must be in the graph.");

            return t1.AdjacentVertices.Contains(t2);
        }

        public IEnumerable<IVertex> Neighbors(IVertex v)
        {
            var t = AssertIsAdjacencyVertex(v, "Vertex must be of type AdjacencyVertex.");
            AssertIsInGraph(t, "Vertex not in graph.");

            return t.AdjacentVertices.Cast<IVertex>();
        }

        public IGraph RemoveEdge(IVertex v1, IVertex v2)
        {
            var t1 = AssertIsAdjacencyVertex(v1, "Vertex v1 must be of type AdjacencyVertex.");
            var t2 = AssertIsAdjacencyVertex(v2, "Vertex v2 must be of type AdjacencyVertex.");
            AssertIsInGraph(t1, "Vertex v1 must be in the graph.");
            AssertIsInGraph(t2, "Vertex v2 must be in the graph.");
            AssertIsInGraph(t1, t2, "Vertices not connected.");

            AdjacencyVertex.Disconnect(t1, t2);

            return this;
        }

        public IGraph RemoveVertex(IVertex v)
        {
            var t = AssertIsAdjacencyVertex(v, "Vertex must be of type AdjacencyVertex.");
            AssertIsInGraph(t, "Vertex not in graph.");

            Vertices.Remove(t);

            foreach (var tt in t.AdjacentVertices)
                AdjacencyVertex.Disconnect(t, tt);

            return this;
        }

        void AssertIsInGraph(AdjacencyVertex v, string message)
        {
            if (!Vertices.Contains(v))
                throw new ArgumentException(message);
        }

        void AssertIsInGraph(AdjacencyVertex v1, AdjacencyVertex v2, string message)
        {
            if (!v1.AdjacentVertices.Contains(v2))
                throw new ArgumentException(message);
        }

        void AssertIsNotInGraph(AdjacencyVertex v, string message)
        {
            if (Vertices.Contains(v))
                throw new ArgumentException(message);
        }

        void AssertIsNotInGraph(AdjacencyVertex v1, AdjacencyVertex v2, string message)
        {
            if (v1.AdjacentVertices.Contains(v2))
                throw new ArgumentException(message);
        }

        AdjacencyVertex AssertIsAdjacencyVertex(IVertex v, string message)
        {
            if (v is AdjacencyVertex t)
                return t;

            throw new ArgumentException(message);
        }
    }
}
