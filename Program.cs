using NetTopologySuite.Geometries;

namespace MistyMarkVisualize;

internal static class Program
{
    public static List<Coordinate> MistyCoordinates { get; private set; } = [];
    public static List<Coordinate> AllCoordinates { get; private set; } = [];

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        string exeDir = AppDomain.CurrentDomain.BaseDirectory;
        string mistyPath = Path.Combine(exeDir, "misty.txt");
        if (!File.Exists(mistyPath))
        {
            MessageBox.Show($"Could not find file: {mistyPath}", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        var lines = File.ReadLines(mistyPath);
        MistyCoordinates = CoordinateLoader.Load(lines);

        string allPath = Path.Combine(exeDir, "all.txt");
        if (File.Exists(allPath))
        {
            lines = File.ReadLines(allPath);
            AllCoordinates = CoordinateLoader.Load(lines);
        }

        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }
}