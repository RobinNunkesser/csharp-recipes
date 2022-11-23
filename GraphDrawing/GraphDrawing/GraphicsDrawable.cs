﻿using System;
using Microsoft.Msagl.Core.Geometry.Curves;
using Microsoft.Msagl.Core.Layout;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.Layout.Layered;
using Microsoft.Msagl.Miscellaneous;
using Font = Microsoft.Maui.Graphics.Font;
using Label = Microsoft.Msagl.Core.Layout.Label;
using Node = Microsoft.Msagl.Core.Layout.Node;
using Edge = Microsoft.Msagl.Core.Layout.Edge;

namespace GraphDrawing
{
    public class GraphicsDrawable : IDrawable
    {
        public static double Scale { get; set; } = 1.0;

        public GraphicsDrawable()
        {
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            var graph = DummyGraph.Graph;
            LayoutGraph(graph, dirtyRect);
            DrawGraph(canvas, graph, (edge) => 3.0, (edge) => false);
        }

        private static void LayoutGraph(GeometryGraph graph, RectF dirtyRect)
        {
            var aspectRatio = dirtyRect.Width / dirtyRect.Height;
            var minimalHeight = 0.0;
            var minimalWidth = 0.0;

            var settings = new SugiyamaLayoutSettings()
            {
                AspectRatio = aspectRatio,
                MinimalHeight = minimalHeight,
                MinimalWidth = minimalWidth
            };

            LayoutHelpers.CalculateLayout(graph, settings, null);
            graph.UpdateBoundingBox();
            var scale = Math.Min(dirtyRect.Height / graph.BoundingBox.Height, dirtyRect.Width / graph.BoundingBox.Width);
            if (scale < 1.0)
            {
                Scale = scale;
                graph.Transform(PlaneTransformation.ScaleAroundCenterTransformation(scale, new Microsoft.Msagl.Core.Geometry.Point(graph.BoundingBox.Center.X, graph.BoundingBox.Center.Y)));
                graph.UpdateBoundingBox();
            }

        }

        private static void DrawGraph(ICanvas canvas, GeometryGraph graph, Func<Edge, double> weights, Func<Edge, bool> mark)
        {
            canvas.FontColor = Colors.Gray;
            canvas.FontSize = (float)(16 * Scale);
            canvas.Font = Font.Default;
            // Move model to positive axis.

            graph.Translate(new Microsoft.Msagl.Core.Geometry.Point(-graph.Left, -graph.Bottom));

            foreach (var node in graph.Nodes)
            {
                DrawNode(canvas, node);
            }

            foreach (var edge in DummyGraph.Graph.Edges)
            {
                DrawEdge(canvas, edge, weights(edge), mark(edge));
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

        private static void DrawLabel(ICanvas canvas, Label label, String text)
        {
            canvas.DrawString(text, (float)(label.BoundingBox.LeftBottom.X + 10.0), (float)label.BoundingBox.LeftBottom.Y, (float)label.BoundingBox.Width, (float)label.BoundingBox.Height, HorizontalAlignment.Left, VerticalAlignment.Center);
        }

        private static void DrawEdge(ICanvas canvas, Edge edge, double weight, bool mark)
        {
            canvas.StrokeColor = mark ? Colors.Blue : Colors.Grey;
            canvas.StrokeSize = 2;

            // When curve is a line segment.
            if (edge.Curve is LineSegment)
            {
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
            DrawLabel(canvas, edge.Label, weight.ToString());
        }
    }
}

