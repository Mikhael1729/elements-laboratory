using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElementsLaboratory.Views;

using Xamarin.Forms;

namespace ElementsLaboratory
{
    /// <summary>
    /// I use it to get resources from the android application
    /// </summary>
    public class AppResources
    {
        private static readonly Lazy<AppResources> instance = new Lazy<AppResources>(() => new AppResources());
        public double ActionBarHeight { get; set; } 

        private AppResources()
        { }

        public static AppResources Instance
        {
            get => instance.Value;
        }

    }

	public partial class App : Application
	{
        /// <summary>
        /// It's the MainPage.
        /// </summary>
        public static MainBottomBarPage MainBottomBarPage { get; set; }

        /// <summary>
        /// Serves to access MainPage from anywhere.
        /// </summary>
        public static NavigationPage NavigationPage { get; set; }

        public App ()
		{
			InitializeComponent();

            MainBottomBarPage = new MainBottomBarPage();
            NavigationPage = new NavigationPage(MainBottomBarPage);

            MainPage = NavigationPage;
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
