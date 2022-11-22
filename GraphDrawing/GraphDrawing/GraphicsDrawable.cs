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
            DrawGraph(canvas, dirtyRect, graph);
        }

        private static void DrawGraph(ICanvas canvas, RectF dirtyRect, GeometryGraph graph)
        {
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
                canvas.StrokeColor = Colors.Blue;
                var line = edge.Curve as LineSegment;
                canvas.DrawLine((float)line.Start.X, (float)line.Start.Y, (float)line.End.X, (float)line.End.Y);
            }
            // When curve is a complex segment.            
            else if (edge.Curve is Curve)
            {
                PathF path = new PathF();
                System.Console.WriteLine($"Starting Path from ({edge.Curve.Start.X},{edge.Curve.Start.Y}) to ({edge.Curve.End.X},{edge.Curve.End.Y})");
                path.MoveTo((float)edge.Curve.Start.X, (float)edge.Curve.Start.Y);
                foreach (var segment in (edge.Curve as Curve).Segments)
                {
                    if (edge.Curve is LineSegment)
                    {
                        var line = edge.Curve as LineSegment;
                        System.Console.WriteLine($"Adding line from ({line.Start.X},{line.Start.Y}) to ({line.End.X},{line.End.Y})");
                        path.LineTo((float)line.End.X, (float)line.End.Y);
                    }
                    else if (segment is CubicBezierSegment)
                    {
                        var bezier = segment as CubicBezierSegment;
                        System.Console.WriteLine($"Adding curve from ({bezier.B(0).X},{bezier.B(0).Y}) to ({bezier.B(3).X},{bezier.B(3).Y})");
                        path.CurveTo((float)bezier.B(1).X, (float)bezier.B(1).Y, (float)bezier.B(2).X, (float)bezier.B(2).Y, (float)bezier.B(3).X, (float)bezier.B(3).Y);
                    }
                    else if (segment is Ellipse)
                    {
                        var ellipse = segment as Ellipse;
                        // TODO: Use path.AddArc instead?
                        System.Console.WriteLine($"Adding ellipse from ({ellipse.Start.X},{ellipse.Start.Y}) to ({ellipse.End.X},{ellipse.End.Y})");

                        for (var i = ellipse.ParStart;
                                    i < ellipse.ParEnd;
                                    i += (ellipse.ParEnd - ellipse.ParStart) / 5.0)
                        {
                            var p = ellipse.Center
                                + (Math.Cos(i) * ellipse.AxisA)
                                + (Math.Sin(i) * ellipse.AxisB);
                            path.LineTo((float)p.X, (float)p.Y);
                        }
                    }
                }
                path.LineTo((float)edge.Curve.End.X, (float)edge.Curve.End.Y);
                canvas.DrawPath(path);
            }
        }
    }
}

