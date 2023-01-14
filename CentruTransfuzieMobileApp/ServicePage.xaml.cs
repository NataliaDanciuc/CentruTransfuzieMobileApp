using CentruTransfuzieMobileApp.Models;

namespace CentruTransfuzieMobileApp;

public partial class ServicePage : ContentPage
{
    MedicalTest ml;
    public ServicePage(MedicalTest mlist)
    {
        InitializeComponent();
        ml = mlist;
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var service = (Service)BindingContext;
        await App.Database.SaveServiceAsync(service);
        listView.ItemsSource = await App.Database.GetServicesAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var service = (Service)BindingContext;
        await App.Database.DeleteServiceAsync(service);
        listView.ItemsSource = await App.Database.GetServicesAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetServicesAsync();
    }

    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Service s;
        if (listView.SelectedItem != null)
        {
            s = listView.SelectedItem as Service;
            var ls = new ListService()
            {
                MedicalTestID = ml.ID,
                ServiceID = s.ID
            };
            await App.Database.SaveListServiceAsync(ls);
        }

    }
}