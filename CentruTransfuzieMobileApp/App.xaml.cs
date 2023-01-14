
using CentruTransfuzieMobileApp.Data;
using System;


namespace CentruTransfuzieMobileApp;

public partial class App : Application
{
    static MedicalTestDatabase database;
    public static MedicalTestDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
                MedicalTestDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), " MedicalTest.db3"));
            }
            return database;
        }
    }


    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
