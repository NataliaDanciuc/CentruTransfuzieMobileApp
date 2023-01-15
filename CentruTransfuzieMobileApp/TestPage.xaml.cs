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
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var mlist = (MedicalTest)BindingContext;
        mlist.Date = DateTime.UtcNow;
       Center selectedCenter = (CenterPicker.SelectedItem as Center);
        mlist.CenterID = selectedCenter.ID;

        await App.Database.SaveMedicalTestAsync(mlist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var mlist = (MedicalTest)BindingContext;
        await App.Database.DeleteMedicalTestAsync(mlist);
        await Navigation.PopAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var items = await App.Database.GetCentersAsync();
        CenterPicker.ItemsSource = (System.Collections.IList)items;
        CenterPicker.ItemDisplayBinding = new Binding("CenterDetails");
        var medl = (MedicalTest)BindingContext;

        listView.ItemsSource = await App.Database.GetListServicesAsync(medl.ID);
    }

    

}