namespace Lab5.Pages;

public partial class CameraPage : ContentPage
{
    public CameraPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private async void OnTakePhotoButtonClicked(object sender, EventArgs e)
    {
        if (MediaPicker.IsCaptureSupported)
        {
            FileResult photo = await MediaPicker.CapturePhotoAsync();
            if (photo != null)
            {
                string filePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                using (Stream sourceStream = await photo.OpenReadAsync())
                using (FileStream localFileStream = File.OpenWrite(filePath))
                {
                    await sourceStream.CopyToAsync(localFileStream);
                }
                photoImage.Source = ImageSource.FromFile(filePath);
            }
        }
    }
}