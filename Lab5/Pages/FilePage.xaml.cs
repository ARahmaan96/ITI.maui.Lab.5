namespace Lab5.Pages;

public partial class FilePage : ContentPage
{
    public FilePage()
    {
        InitializeComponent();
    }

    private async void OnSaveFileButtonClicked(object sender, EventArgs e)
    {
        string text = textInput.Text;
        string filename = Path.Combine(FileSystem.AppDataDirectory, "testfile.txt");

        await File.WriteAllTextAsync(filename, text);
        SaveFileLabel.Text = $"File saved: {filename}";
    }

    private async void OnReadFileButtonClicked(object sender, EventArgs e)
    {
        string filename = Path.Combine(FileSystem.AppDataDirectory, "testfile.txt");

        if (File.Exists(filename))
        {
            string text = await File.ReadAllTextAsync(filename);
            SaveFileLabel.Text = $"File content: {text}";
        }
        else
        {
            SaveFileLabel.Text = "File not found.";
        }
    }
}