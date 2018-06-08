using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ElementsLaboratory.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExperimentsPage
	{
        // Scroll View
        double scrollHeight;

        // Positions
        double newPosition;
        double lastPosition;
        private double impresition;

        public ExperimentsPage ()
		{
			InitializeComponent ();

            newPosition = 0;
            lastPosition = 0;
            impresition = 0;
            scrollHeight = 0;

            ElementsScrollView.Scrolled += ScrollViewScrolled;
        }

        private void ScrollViewScrolled(object sender, ScrolledEventArgs e)
        {
            // Initializing scroll height.
            if (scrollHeight == 0)
                scrollHeight = ElementsScrollView.ContentSize.Height - ElementsScrollView.Height;

            // Initializing impresition bar.
            if (impresition == 0)
                impresition = AppResources.Instance.ActionBarHeight/2;

            // Getting space available.
            newPosition = e.ScrollY;
            
            // Getting the absolute value of difference between new position and las position.
            double difference = newPosition - lastPosition;
            if (difference < 0)
                difference = difference * -1;

            // Action to execute at the start.
            if (newPosition ==  0 && !ControlsAreVisible())
                ShowElements();

            // Actions to execute at the middle.
            if (difference > impresition && lastPosition != 0)
            {
                // If I up, hide the navigation bar, else, show it.
                if ((newPosition > (lastPosition + impresition)) && ControlsAreVisible())
                    HideElements();
                else if ((newPosition < (lastPosition - impresition)) && !ControlsAreVisible())
                    ShowElements();
            }

            //// Actions to execute at the end.
            //if (spaceAvailableForScrolling > e.ScrollY + impresition)
            //    HideElements();

            lastPosition = newPosition;
        }

        private void HideElements()
        {
            NavigationPage.SetHasNavigationBar(App.MainBottomBarPage, false);
            Fab.TranslateTo(0, 40);
        }

        private void ShowElements()
        {
            NavigationPage.SetHasNavigationBar(App.MainBottomBarPage, true);
            Fab.TranslateTo(0, -40);
        }

        private bool ControlsAreVisible()
        {
            if (NavigationPage.GetHasNavigationBar(App.MainBottomBarPage))
                return true;
            else
                return false;
        }
    }
}