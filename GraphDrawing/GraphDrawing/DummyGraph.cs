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

            var nodeA = new Node(CurveFactory.CreateRectangle(1.0, 1.0, new Point()));
            var nodeB = new Node(CurveFactory.CreateRectangle(1.0, 1.0, new Point()));

            Graph.Nodes.Add(nodeA);
            Graph.Nodes.Add(nodeB);

            Graph.Edges.Add(new Edge(nodeA, nodeB)
            {
                Weight = 1
            });

            LayoutHelpers.CalculateLayout(Graph, settings, null);

        }
    }
}

