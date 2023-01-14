using CentruTransfuzieMobileApp.Models;

namespace CentruTransfuzieMobileApp;

public partial class TestPage : ContentPage
{
	public TestPage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var mlist = (MedicalTest)BindingContext;
        mlist.Date = DateTime.UtcNow;
        await App.Database.SaveMedicalTestAsync(mlist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var mlist = (MedicalTest)BindingContext;
        await App.Database.DeleteMedicalTestAsync(mlist);
        await Navigation.PopAsync();
    }

}