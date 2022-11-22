using System;
using Microsoft.Msagl.Drawing;

namespace GraphDrawing
{
    public class GraphicsDrawable : IDrawable
    {
        public GraphicsDrawable()
        {
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            foreach (var node in DummyGraph.Graph.Nodes)
            {
                System.Console.WriteLine($"{node.Center.X} {node.Center.Y} {node.BoundingBox.Left} {node.BoundingBox.Top}");


            }

            canvas.StrokeColor = Colors.Red;
            canvas.StrokeSize = 6;
            canvas.DrawLine(10, 10, 90, 100);

        }
    }
}

