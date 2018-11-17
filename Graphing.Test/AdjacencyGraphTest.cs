using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graphing.Type;
using Graphing.Interface;
using System.Linq;

namespace Graphing.Test
{
    [TestClass]
    public class AdjacencyGraphTest
    {
        [TestMethod]
        public void TestCreation()
        {
            AdjacencyGraph x = new AdjacencyGraph();
        }

        [TestMethod]
        public void AddVertexTest()
        {
            AdjacencyGraph g = new AdjacencyGraph();

            g.AddVertex(new AdjacencyVertex());

            Assert.AreEqual(1, g.Vertices.Count);
        }

        [TestMethod]
        public void RemoveVertexTest()
        {
            AdjacencyGraph g = new AdjacencyGraph();
            AdjacencyVertex v = new AdjacencyVertex();

            g.AddVertex(v);

            g.RemoveVertex(v);

            Assert.AreEqual(0, g.Vertices.Count);
        }

        [TestMethod]
        public void AddEdgeTest()
        {
            AdjacencyGraph g = new AdjacencyGraph();
            AdjacencyVertex v1 = new AdjacencyVertex(), v2 = new AdjacencyVertex();

            g.AddVertex(v1);
            g.AddVertex(v2);
            g.AddEdge(v1, v2);

            Assert.AreEqual(1, v1.AdjacentVertices.Count);
            Assert.AreEqual(1, v2.AdjacentVertices.Count);
        }

        [TestMethod]
        public void RemoveEdgeTest()
        {
            AdjacencyGraph g = new AdjacencyGraph();
            AdjacencyVertex v1 = new AdjacencyVertex(), v2 = new AdjacencyVertex();

            g.AddVertex(v1);
            g.AddVertex(v2);
            g.AddEdge(v1, v2);
            g.RemoveEdge(v1, v2);

            Assert.AreEqual(0, v1.AdjacentVertices.Count);
            Assert.AreEqual(0, v2.AdjacentVertices.Count);
        }

        [TestMethod]
        public void AddTest()
        {
            AdjacencyGraph g = new AdjacencyGraph();
            AdjacencyVertex
                v1 = new AdjacencyVertex(),
                v2 = new AdjacencyVertex(),
                v3 = new AdjacencyVertex(),
                v4 = new AdjacencyVertex(),
                v5 = new AdjacencyVertex();

            g.AddVertex(v1);
            g.AddVertex(v2);
            g.AddVertex(v3);
            g.AddVertex(v4);
            g.AddVertex(v5);
            g.AddEdge(v1, v2);
            g.AddEdge(v2, v3);
            g.AddEdge(v3, v1);
            g.AddEdge(v1, v4);

            Assert.AreEqual(5, g.Vertices.Count);
            Assert.AreEqual(3, v1.AdjacentVertices.Count);
            Assert.AreEqual(2, v2.AdjacentVertices.Count);
            Assert.AreEqual(2, v3.AdjacentVertices.Count);
            Assert.AreEqual(1, v4.AdjacentVertices.Count);
            Assert.AreEqual(0, v5.AdjacentVertices.Count);
        }

        [TestMethod]
        public void AdjacentTest()
        {
            AdjacencyGraph g = new AdjacencyGraph();
            AdjacencyVertex
                v1 = new AdjacencyVertex(),
                v2 = new AdjacencyVertex(),
                v3 = new AdjacencyVertex();

            g.AddVertex(v1);
            g.AddVertex(v2);
            g.AddVertex(v3);
            g.AddEdge(v1, v2);

            Assert.AreEqual(true, g.Adjacent(v1, v2));
            Assert.AreEqual(false, g.Adjacent(v2, v3));
            Assert.AreEqual(false, g.Adjacent(v3, v1));
        }

        [TestMethod]
        public void NeighborsTest()
        {
            AdjacencyGraph g = new AdjacencyGraph();
            AdjacencyVertex
                v1 = new AdjacencyVertex(),
                v2 = new AdjacencyVertex(),
                v3 = new AdjacencyVertex(),
                v4 = new AdjacencyVertex();

            g.AddVertex(v1);
            g.AddVertex(v2);
            g.AddVertex(v3);
            g.AddVertex(v4);
            g.AddEdge(v1, v2);
            g.AddEdge(v2, v3);

            Assert.AreEqual(2, g.Neighbors(v2).Count());
            Assert.AreEqual(v1, g.Neighbors(v2).First());
            Assert.AreEqual(v3, g.Neighbors(v2).Last());
            Assert.AreEqual(1, g.Neighbors(v1).Count());
            Assert.AreEqual(v2, g.Neighbors(v1).First());
            Assert.AreEqual(1, g.Neighbors(v3).Count());
            Assert.AreEqual(v2, g.Neighbors(v3).First());
            Assert.AreEqual(0, g.Neighbors(v4).Count());
        }
    }
}
