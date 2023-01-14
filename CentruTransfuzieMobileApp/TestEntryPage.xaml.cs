using CentruTransfuzieMobileApp.Models;

namespace CentruTransfuzieMobileApp;

public partial class TestEntryPage : ContentPage
{
	public TestEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetMedicalTestsAsync();
    }
    async void OnMedicalTestAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TestPage
        {
            BindingContext = new MedicalTest()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new TestPage
            {
                BindingContext = e.SelectedItem as MedicalTest
            });
        }
    }

}