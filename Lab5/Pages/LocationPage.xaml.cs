using static Plugin.LocalNotification.NotificationRequestGeofence;

namespace Lab5.Pages;

public partial class LocationPage : ContentPage
{
    public LocationPage()
    {
        InitializeComponent();
    }

    private async void OnGetLocationButtonClicked(object sender, EventArgs e)
    {
        try
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            if (location != null)
            {
                LocationLabel.Text = $"Latitude: {location.Latitude}, Longitude: {location.Longitude}";

                try
                {
                    await Map.Default.OpenAsync(location);
                }
                catch (Exception ex)
                {
                    LocationLabel.Text = $"Error: {ex.Message}";
                }
            }
            else
            {
                LocationLabel.Text = "No location available.";
            }
        }
        catch (Exception ex)
        {
            LocationLabel.Text = $"Error: {ex.Message}";
        }
    }

}