using System;
using Microsoft.Maui.Graphics;
using Microsoft.Msagl.Core.Geometry.Curves;
using Microsoft.Msagl.Core.Layout;
using Font = Microsoft.Maui.Graphics.Font;
using Label = Microsoft.Msagl.Core.Layout.Label;

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
            canvas.FontColor = Colors.Gray;
            canvas.FontSize = 18;
            canvas.Font = Font.Default;
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
            canvas.StrokeColor = Colors.Gray;
            canvas.StrokeSize = 1;
            canvas.DrawEllipse((float)node.BoundingBox.LeftBottom.X, (float)node.BoundingBox.LeftBottom.Y, (float)node.Width, (float)node.Height);
            if (node.UserData is String)
            {
                canvas.DrawString((string)node.UserData, (float)node.BoundingBox.LeftBottom.X, (float)node.BoundingBox.LeftBottom.Y, (float)node.BoundingBox.Width, (float)node.BoundingBox.Height, HorizontalAlignment.Center, VerticalAlignment.Center);
            }
        }

        private static void DrawLabel(ICanvas canvas, Label label)
        {
            canvas.DrawString("X", (float)label.BoundingBox.LeftBottom.X, (float)label.BoundingBox.LeftBottom.Y, (float)label.BoundingBox.Width, (float)label.BoundingBox.Height, HorizontalAlignment.Center, VerticalAlignment.Center);
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
                path.MoveTo((float)edge.Curve.Start.X, (float)edge.Curve.Start.Y);
                foreach (var segment in (edge.Curve as Curve).Segments)
                {
                    if (edge.Curve is LineSegment)
                    {
                        var line = edge.Curve as LineSegment;
                        path.LineTo((float)line.End.X, (float)line.End.Y);
                    }
                    else if (segment is CubicBezierSegment)
                    {
                        var bezier = segment as CubicBezierSegment;
                        path.CurveTo((float)bezier.B(1).X, (float)bezier.B(1).Y, (float)bezier.B(2).X, (float)bezier.B(2).Y, (float)bezier.B(3).X, (float)bezier.B(3).Y);
                    }
                    else if (segment is Ellipse)
                    {
                        var ellipse = segment as Ellipse;
                        // TODO: Use path.AddArc instead?

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
            DrawLabel(canvas, edge.Label);
        }
    }
}

