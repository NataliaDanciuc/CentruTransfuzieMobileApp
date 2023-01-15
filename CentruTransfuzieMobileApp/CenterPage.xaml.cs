
using CentruTransfuzieMobileApp.Models;
namespace CentruTransfuzieMobileApp;

public partial class CenterPage : ContentPage
{
	public CenterPage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var center = (Center)BindingContext;
        await App.Database.SaveCenterAsync(center);
        await Navigation.PopAsync();
    }
    async void OnShowMapButtonClicked(object sender, EventArgs e)
    {
        var center = (Center)BindingContext;
        var address = center.Adress;
        var locations = await Geocoding.GetLocationsAsync(address);

        var options = new MapLaunchOptions
        {
            Name = "Centrul meu preferat" };
       var location = locations?.FirstOrDefault();
        // var myLocation = await Geolocation.GetLocationAsync();
        var myLocation = new Location(46.7731796289, 23.6213886738);
        await Map.OpenAsync(location, options);
    }

}