namespace MistyMarkVisualize;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        NUD_Tolerance.ValueChanged += ChangeTolerance;
        UpdateImage();
        if (Program.AllCoordinates.Count > 0)
            CheckAllCoordinates();
    }

    private void ChangeTolerance(object? sender, EventArgs e) => UpdateImage();

    private void UpdateImage()
    {
        var tolerance = (double)NUD_Tolerance.Value;
        var bmp = MistyMarkVisualizer.GetImage(Program.MistyCoordinates, tolerance);
        PB_Image.Image = bmp;
    }

    // Checks if all the coordinates are within the fog zone, and if so, exports them to a new text file.
    private void CheckAllCoordinates()
    {
        var tolerance = (double)NUD_Tolerance.Value;
        var list = MistyMarkVisualizer.GetFilteredMistyList(Program.MistyCoordinates, Program.AllCoordinates, tolerance);

        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "all_fog.txt");
        File.WriteAllText(filePath, list.ToString());
    }
}
