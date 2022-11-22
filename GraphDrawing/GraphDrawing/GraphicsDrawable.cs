using System;
using Microsoft.Msagl.Core.Geometry.Curves;
using Microsoft.Msagl.Core.Layout;

namespace GraphDrawing
{
    public class GraphicsDrawable : IDrawable
    {
        public GraphicsDrawable()
        {
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            var graph = DummyGraph.Graph;
            // Move model to positive axis.
            graph.UpdateBoundingBox();
            graph.Translate(new Microsoft.Msagl.Core.Geometry.Point(-graph.Left, -graph.Bottom));

            foreach (var node in graph.Nodes)
            {
                DrawNode(canvas, node);
            }

            foreach (var edge in DummyGraph.Graph.Edges)
            {
                DrawEdge(canvas, edge);
            }


        }

        private static void DrawNode(ICanvas canvas, Node node)
        {
            canvas.StrokeColor = Colors.Red;
            canvas.StrokeSize = 6;
            canvas.DrawEllipse((float)node.Center.X, (float)node.Center.Y, 5, 5);
        }

        private static void DrawEdge(ICanvas canvas, Edge edge)
        {
            canvas.StrokeColor = Colors.Red;
            canvas.StrokeSize = 4;
            //canvas.DrawArc();

            // When curve is a line segment.
            if (edge.Curve is LineSegment)
            {
                var line = edge.Curve as LineSegment;
                canvas.DrawLine((float)line.Start.X, (float)line.Start.Y, (float)line.End.X, (float)line.End.Y);
            }
        }
    }
}

