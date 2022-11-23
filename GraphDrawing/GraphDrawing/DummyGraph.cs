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
            var nodeSize = 30.0;
            var labelWidth = 60.0;
            var labelHeight = 30.0;

            var nodeA = new Node(CurveFactory.CreateRectangle(nodeSize, nodeSize, new Point()), "A");
            var nodeB = new Node(CurveFactory.CreateRectangle(nodeSize, nodeSize, new Point()), "B");
            var nodeC = new Node(CurveFactory.CreateRectangle(nodeSize, nodeSize, new Point()), "C");
            var nodeD = new Node(CurveFactory.CreateRectangle(nodeSize, nodeSize, new Point()), "D");
            var nodeE = new Node(CurveFactory.CreateRectangle(nodeSize, nodeSize, new Point()), "E");
            var nodeF = new Node(CurveFactory.CreateRectangle(nodeSize, nodeSize, new Point()), "F");

            Graph.Nodes.Add(nodeA);
            Graph.Nodes.Add(nodeB);
            Graph.Nodes.Add(nodeC);
            Graph.Nodes.Add(nodeD);
            Graph.Nodes.Add(nodeE);
            Graph.Nodes.Add(nodeF);

            Graph.Edges.Add(new Edge(nodeA, nodeB)
            {
                Label = new Microsoft.Msagl.Core.Layout.Label()
                {
                    Width = labelWidth,
                    Height = labelHeight
                }
            });

            Graph.Edges.Add(new Edge(nodeA, nodeC)
            {
                Label = new Microsoft.Msagl.Core.Layout.Label()
                {
                    Width = labelWidth,
                    Height = labelHeight
                }
            });

            Graph.Edges.Add(new Edge(nodeA, nodeD)
            {
                Label = new Microsoft.Msagl.Core.Layout.Label()
                {
                    Width = labelWidth,
                    Height = labelHeight
                }
            });

            Graph.Edges.Add(new Edge(nodeA, nodeE)
            {
                Label = new Microsoft.Msagl.Core.Layout.Label()
                {
                    Width = labelWidth,
                    Height = labelHeight
                }
            });

            Graph.Edges.Add(new Edge(nodeA, nodeF)
            {
                Label = new Microsoft.Msagl.Core.Layout.Label()
                {
                    Width = labelWidth,
                    Height = labelHeight
                }
            });

            Graph.Edges.Add(new Edge(nodeB, nodeC)
            {
                Label = new Microsoft.Msagl.Core.Layout.Label()
                {
                    Width = labelWidth,
                    Height = labelHeight
                }
            });

            Graph.Edges.Add(new Edge(nodeB, nodeD)
            {
                Label = new Microsoft.Msagl.Core.Layout.Label()
                {
                    Width = labelWidth,
                    Height = labelHeight
                }
            });

            Graph.Edges.Add(new Edge(nodeC, nodeE)
            {
                Label = new Microsoft.Msagl.Core.Layout.Label()
                {
                    Width = labelWidth,
                    Height = labelHeight
                }
            });

            Graph.Edges.Add(new Edge(nodeE, nodeF)
            {
                Label = new Microsoft.Msagl.Core.Layout.Label()
                {
                    Width = labelWidth,
                    Height = labelHeight
                }
            });

        }
    }
}

