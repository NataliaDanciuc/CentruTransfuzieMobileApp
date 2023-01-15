using CentruTransfuzieMobileApp.Models;

namespace CentruTransfuzieMobileApp;

public partial class CenterEntryPage : ContentPage
{
	public CenterEntryPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetCentersAsync();
    }
    async void OnCenterAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CenterPage
        {
            BindingContext = new Center()
        });
    }
    async void OnListViewItemSelected(object sender,
   SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new CenterPage
            {
                BindingContext = e.SelectedItem as Center
            });
        }
    }

}