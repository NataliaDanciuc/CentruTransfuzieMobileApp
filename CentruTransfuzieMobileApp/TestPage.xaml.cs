using CentruTransfuzieMobileApp.Models;

namespace CentruTransfuzieMobileApp;

public partial class TestPage : ContentPage
{
	public TestPage()
	{
		InitializeComponent();
	}
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ServicePage((MedicalTest)
       this.BindingContext)
        {
            BindingContext = new Service()
        });

    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var medl = (MedicalTest)BindingContext;

        listView.ItemsSource = await App.Database.GetListServicesAsync(medl.ID);
    }

    

}