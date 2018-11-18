using Graphing.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphing.Type
{
    public class AdjacencyGraph : GraphObject, IGraph
    {
        protected List<IVertex> vertices;
        public IEnumerable<IVertex> Vertices => vertices;

        public AdjacencyGraph(GraphPermissions permissions, GraphBehaviour behaviour) : base(permissions, behaviour)
        {
            vertices = new List<IVertex>();
        }
        public AdjacencyGraph() : this(defaultPermissions, defaultBehaviour) { }

        public IGraph AddEdge(IVertex v1, IVertex v2)
        {
            //AssertIsInGraph(t1, "Vertex v1 must be in the graph.");
            //AssertIsInGraph(t2, "Vertex v2 must be in the graph.");
            //AssertIsNotInGraph(t1, t2, "Vertices already connected.");
            if (!vertices.Contains(v1) || !vertices.Contains(v2))
                throw new ArgumentException();
            if (!permissions.HasFlag(GraphPermissions.AllowMultipleEdges) && v1.IsAdjacentTo(v2))
                if (behaviour == GraphBehaviour.ThrowUnpermittedBehaviour)
                    throw new ArgumentException();

            v1.LinkTo(v2);

            return this;
        }

        public IGraph AddVertex(IVertex v)
        {
            //AssertIsNotInGraph(t, "Vertex already in graph.");
            if (!vertices.Contains(v))
                vertices.Add(v);

            return this;
        }

        public bool Adjacent(IVertex v1, IVertex v2)
        {
            //AssertIsInGraph(t1, "Vertex v1 must be in the graph.");
            //AssertIsInGraph(t2, "Vertex v2 must be in the graph.");
            
            return v1.IsAdjacentTo(v2);
        }

        public IEnumerable<IVertex> Neighbors(IVertex v)
        {
            //AssertIsInGraph(t, "Vertex not in graph.");
            if (!vertices.Contains(v))
                throw new ArgumentException();

            return v.AdjacentVertices;
        }

        public IGraph RemoveEdge(IVertex v1, IVertex v2)
        {
            //AssertIsInGraph(t1, "Vertex v1 must be in the graph.");
            //AssertIsInGraph(t2, "Vertex v2 must be in the graph.");
            //AssertIsInGraph(t1, t2, "Vertices not connected.");
            if (!vertices.Contains(v1) || !vertices.Contains(v2) || !v1.IsAdjacentTo(v2))
                throw new ArgumentException();

            v1.RemoveLink(v2);

            return this;
        }

        public IGraph RemoveVertex(IVertex v)
        {
            //AssertIsInGraph(t, "Vertex not in graph.");
            if (!vertices.Contains(v))
                throw new ArgumentException();

            vertices.Remove(v);

            foreach (var t in v.AdjacentVertices)
                t.RemoveLink(v);

            return this;
        }

        //void AssertIsInGraph(AdjacencyVertex v, string message)
        //{
        //    if (!Vertices.Contains(v))
        //        throw new ArgumentException(message);
        //}

        //void AssertIsInGraph(AdjacencyVertex v1, AdjacencyVertex v2, string message)
        //{
        //    if (!v1.AdjacentVertices.Contains(v2))
        //        throw new ArgumentException(message);
        //}

        //void AssertIsNotInGraph(AdjacencyVertex v, string message)
        //{
        //    if (Vertices.Contains(v))
        //        throw new ArgumentException(message);
        //}

        //void AssertIsNotInGraph(AdjacencyVertex v1, AdjacencyVertex v2, string message)
        //{
        //    if (v1.AdjacentVertices.Contains(v2))
        //        throw new ArgumentException(message);
        //}

        //AdjacencyVertex AssertIsAdjacencyVertex(IVertex v, string message)
        //{
        //    if (v is AdjacencyVertex t)
        //        return t;

        //    throw new ArgumentException(message);
        //}
    }
}
