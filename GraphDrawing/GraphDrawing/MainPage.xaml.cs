using System.Drawing;
using Microsoft.Msagl.Core.Geometry.Curves;
using Microsoft.Msagl.Core.Layout;
using Microsoft.Msagl;
using Image = Microsoft.Maui.Controls.Image;
using Microsoft.Msagl.Miscellaneous;
using Microsoft.Msagl.Prototype.Ranking;

namespace GraphDrawing;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        /*count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);*/

        /*
        double w = 10;
        double h = 10;
        
        MsaglGraph graph = new MsaglGraph();
        Node a = new Node("a", new Ellipse(w, h, new Point()));
        Node b = new Node("b", CurveFactory.CreateBox(w, h, new Point()));
        graph.AddNode(a); graph.AddNode(b);
        Edge e = new Edge(a, b);
        graph.AddEdge(e);
        graph.CalculateLayout();
        */


        Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("");
        graph.AddEdge("A", "B");
        graph.AddEdge("A", "B");
        graph.FindNode("A").Attr.FillColor =
        Microsoft.Msagl.Drawing.Color.Red;
        graph.FindNode("B").Attr.FillColor =
        Microsoft.Msagl.Drawing.Color.Blue;

        var settings = graph.CreateLayoutSettings();

        graph.CreateGeometryGraph();


        foreach (var node in graph.GeometryGraph.Nodes)
        {
            System.Console.WriteLine($"{node.Center.X} {node.Center.X} {node.BoundingBox.Left} {node.BoundingBox.Top}");


        }



        LayoutHelpers.CalculateLayout(graph.GeometryGraph, settings, null);

        foreach (var node in graph.GeometryGraph.Nodes)
        {
            System.Console.WriteLine($"{node.Center.X} {node.Center.X} {node.BoundingBox.Left} {node.BoundingBox.Top}");


        }

        /*Microsoft.Msagl.GraphViewerGdi.GraphRenderer renderer
        = new Microsoft.Msagl.GraphViewerGdi.GraphRenderer
        (graph);
        renderer.CalculateLayout();
        int width = 50;
        Bitmap bitmap = new Bitmap(width, (int)(graph.Height *
(width / graph.Width)), System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
        renderer.Render(bitmap);
        image = Convert(bitmap);*/

    }

    private Image Convert(System.Drawing.Image img)
    {
        MemoryStream stream = new MemoryStream();
        img.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);

        Image output = new Image()
        {
            Source = ImageSource.FromStream(() => stream)
        };

        return output;
    }
}


internal class FakeLocalFile : IDisposable
{
    public string FilePath { get; }

    /// <summary>
    /// Currently ImageSource.FromStream is not working on windows devices.
    /// This class saves the passed stream in a cache directory, returns the local path and deletes it on dispose.
    /// </summary>
    public FakeLocalFile(Stream source)
    {
        FilePath = Path.Combine(FileSystem.Current.CacheDirectory, $"{Guid.NewGuid()}.tmp");
        using var fs = new FileStream(FilePath, FileMode.Create);
        source.CopyTo(fs);
    }

    public void Dispose()
    {
        if (File.Exists(FilePath))
            File.Delete(FilePath);
    }
}