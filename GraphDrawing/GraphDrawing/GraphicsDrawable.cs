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

            // When curve is a line segment.
            if (edge.Curve is LineSegment)
            {
                var line = edge.Curve as LineSegment;
                canvas.DrawLine((float)line.Start.X, (float)line.Start.Y, (float)line.End.X, (float)line.End.Y);
            }
            // When curve is a complex segment.
            // TODO: solve with canvas.DrawPath
            else if (edge.Curve is Curve)
            {
                Point? pt = null;
                foreach (var segment in (edge.Curve as Curve).Segments)
                {
                    if (edge.Curve is LineSegment)
                    {
                        var line = edge.Curve as LineSegment;
                        canvas.DrawLine((float)line.Start.X, (float)line.Start.Y, (float)line.End.X, (float)line.End.Y);
                        pt = new Point((float)line.End.X, (float)line.End.Y);
                    }
                    else if (segment is CubicBezierSegment)
                    {
                        var bezier = segment as CubicBezierSegment;
                        var p0 = bezier.B(0);
                        var p1 = bezier.B(1);
                        var p2 = bezier.B(2);
                        var p3 = bezier.B(3);
                        canvas.DrawLine((float)p0.X, (float)p0.Y, (float)p1.X, (float)p1.Y);
                        canvas.DrawLine((float)p1.X, (float)p1.Y, (float)p2.X, (float)p2.Y);
                        canvas.DrawLine((float)p2.X, (float)p2.Y, (float)p3.X, (float)p3.Y);
                    }
                    else if (segment is Ellipse)
                    {

                        var ellipse = segment as Ellipse;
                        for (var i = ellipse.ParStart;
                                    i < ellipse.ParEnd;
                                    i += (ellipse.ParEnd - ellipse.ParStart) / 5.0)
                        {
                            var p = ellipse.Center
                                + (Math.Cos(i) * ellipse.AxisA)
                                + (Math.Sin(i) * ellipse.AxisB);
                            if (pt != null)
                            {
                                canvas.DrawLine((float)pt.Value.X, (float)pt.Value.Y, (float)p.X, (float)p.Y);
                            }
                            pt = new Point(p.X, p.Y);
                        }
                    }
                }
            }
        }
    }
}

