using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ElementsLaboratory.Behaviors
{
    public abstract class UpAndDownBehavior : Behavior<ScrollView>
    {
        double scrollHeight;

        // Positions
        double newPosition;
        double lastPosition;
        private double impresition;

        public UpAndDownBehavior()
        {
            newPosition = 0;
            lastPosition = 0;
            impresition = 0;
            scrollHeight = 0;
        }

        protected override void OnAttachedTo(ScrollView scrollView)
        {
            scrollView.Scrolled += ScrollViewScrolled;
            base.OnAttachedTo(scrollView);
        }

        protected override void OnDetachingFrom(ScrollView entry)
        {
            entry.Scrolled -= ScrollViewScrolled;
            base.OnDetachingFrom(entry);
        }

        private void ScrollViewScrolled(object sender, ScrolledEventArgs e)
        {
            //var ElementsScrollView = e.
            //// Initializing scroll height.
            //if (scrollHeight == 0)
            //    scrollHeight = ElementsScrollView.ContentSize.Height - ElementsScrollView.Height;

            //// Initializing impresition bar.
            //if (impresition == 0)
            //    impresition = AppResources.Instance.ActionBarHeight / 2;

            //// Getting space available.
            //newPosition = e.ScrollY;

            //// Getting the absolute value of difference between new position and las position.
            //double difference = newPosition - lastPosition;
            //if (difference < 0)
            //    difference = difference * -1;

            //// Action to execute at the start.
            //if (newPosition == 0 && !ControlsAreVisible())
            //    ShowElements();

            //// Actions to execute at the middle.
            //if (difference > impresition && lastPosition != 0)
            //{
            //    // If I up, hide the navigation bar, else, show it.
            //    if ((newPosition > (lastPosition + impresition)) && ControlsAreVisible())
            //        HideElements();
            //    else if ((newPosition < (lastPosition - impresition)) && !ControlsAreVisible())
            //        ShowElements();
            //}

            ////// Actions to execute at the end.
            ////if (spaceAvailableForScrolling > e.ScrollY + impresition)
            ////    HideElements();

            //lastPosition = newPosition;
        }

        public abstract bool ControlsAreVisible();

        public abstract void ShowElements();

        public abstract void HideElements();
    }
}
