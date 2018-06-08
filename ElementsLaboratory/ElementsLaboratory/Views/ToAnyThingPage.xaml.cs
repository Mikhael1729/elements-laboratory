using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ElementsLaboratory.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ToAnyThingPage : ContentPage
	{
		public ToAnyThingPage ()
		{
			InitializeComponent ();
		}

        private void OnSearchElementsPageClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SearchElementsPage());
        }

    }
}