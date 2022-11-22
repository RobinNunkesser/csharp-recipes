using System;
using Microsoft.Msagl.Core.Geometry.Curves;
using Microsoft.Msagl.Core.Layout;
using Microsoft.Msagl;
using Microsoft.Msagl.Miscellaneous;
using Microsoft.Msagl.Prototype.Ranking;
using Microsoft.Msagl.Layout.Layered;
using Microsoft.Msagl.Core.Geometry;
using Point = Microsoft.Msagl.Core.Geometry.Point;

namespace GraphDrawing
{
    public static class DummyGraph
    {
        public static GeometryGraph Graph { get; set; } = new GeometryGraph();

        static DummyGraph()
        {
            var settings = new SugiyamaLayoutSettings();

            var nodeA = new Node(CurveFactory.CreateRectangle(10.0, 10.0, new Point()), "A");
            var nodeB = new Node(CurveFactory.CreateRectangle(10.0, 10.0, new Point()), "B");
            var nodeC = new Node(CurveFactory.CreateRectangle(10.0, 10.0, new Point()), "C");
            var nodeD = new Node(CurveFactory.CreateRectangle(10.0, 10.0, new Point()), "D");
            var nodeE = new Node(CurveFactory.CreateRectangle(10.0, 10.0, new Point()), "E");
            var nodeF = new Node(CurveFactory.CreateRectangle(10.0, 10.0, new Point()), "F");

            Graph.Nodes.Add(nodeA);
            Graph.Nodes.Add(nodeB);
            Graph.Nodes.Add(nodeC);
            Graph.Nodes.Add(nodeD);
            Graph.Nodes.Add(nodeE);
            Graph.Nodes.Add(nodeF);

            Graph.Edges.Add(new Edge(nodeA, nodeB)
            {
                Weight = 1
            });

            Graph.Edges.Add(new Edge(nodeA, nodeC)
            {
                Weight = 1
            });

            Graph.Edges.Add(new Edge(nodeA, nodeD)
            {
                Weight = 1
            });

            Graph.Edges.Add(new Edge(nodeA, nodeE)
            {
                Weight = 1
            });

            Graph.Edges.Add(new Edge(nodeA, nodeF)
            {
                Weight = 1
            });

            Graph.Edges.Add(new Edge(nodeB, nodeC)
            {
                Weight = 1
            });

            Graph.Edges.Add(new Edge(nodeB, nodeD)
            {
                Weight = 1
            });

            Graph.Edges.Add(new Edge(nodeC, nodeE)
            {
                Weight = 1
            });

            Graph.Edges.Add(new Edge(nodeE, nodeF)
            {
                Weight = 1
            });


            LayoutHelpers.CalculateLayout(Graph, settings, null);

        }
    }
}

