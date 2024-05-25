namespace Lab5.Pages;

public partial class AccelerometerPage : ContentPage
{
    public AccelerometerPage()
    {
        InitializeComponent();
        Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;

    }

    private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
    {
        var data = e.Reading;
        AccelerometerLabel.Text = $"X: {data.Acceleration.X}, Y: {data.Acceleration.Y}, Z: {data.Acceleration.Z}";
    }

    private void OnToggleAccelerometerButtonClicked(object sender, EventArgs e)
    {
        if (Accelerometer.IsMonitoring)
        {
            Accelerometer.Stop();
            ToggleButton.Text = "Start Accelerometer";
        }
        else
        {
            Accelerometer.Start(SensorSpeed.UI);
            ToggleButton.Text = "Stop Accelerometer";
        }
    }
}
