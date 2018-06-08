using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using ElementsLaboratory.Controls;
using PersonalizingViews.Droid.CustomRenderers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(XTableView), typeof(XTableViewRenderer))]
namespace PersonalizingViews.Droid.CustomRenderers
{
    public class XTableViewRenderer : TableViewRenderer
    {
        private bool FirstElementAdded = false;

        public XTableViewRenderer(Context context) : base(context)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<TableView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                return;

            var xTableView = (XTableView)e.NewElement;
            var listView = Control as global::Android.Widget.ListView;

            listView.Divider.SetColorFilter(Android.Graphics.Color.White, PorterDuff.Mode.Screen);
            listView.DividerHeight = 0;
        }

        protected override TableViewModelRenderer GetModelRenderer(Android.Widget.ListView listView, TableView view)
        {
            return new CustomHeaderTableViewModelRenderer(Context, listView, view);
        }

        #region CustomHeaderTableViewModelRenderer Class
        private class CustomHeaderTableViewModelRenderer : TableViewModelRenderer
        {
            private readonly XTableView _xtableView;

            public CustomHeaderTableViewModelRenderer(Context context, Android.Widget.ListView listView, TableView view) : base(context, listView, view)
            {
                _xtableView = view as XTableView;
            }

            public override Android.Views.View GetView(int position, Android.Views.View convertView, ViewGroup parent)
            {
                var view = base.GetView(position, convertView, parent);

                var element = GetCellForPosition(position);

                // section header will be a TextCell
                if (element.GetType() == typeof(TextCell))
                {
                    try
                    {
                        /* -- Header -- */

                        // Get the textView of the actual layout.
                        var textView = ((((view as LinearLayout).GetChildAt(0) as LinearLayout).GetChildAt(1) as LinearLayout).GetChildAt(0) as TextView);

                        // Get the divider below the header
                        var divider = (view as LinearLayout).GetChildAt(1);

                        // Set the color
                        textView.SetTextColor(_xtableView.GroupHeaderColor.ToAndroid());
                        divider.SetBackgroundColor(_xtableView.GroupHeaderColor.ToAndroid());

                        textView.TextAlignment = Android.Views.TextAlignment.Center;

                        /* -- Rows -- */

                        // Get the textView of the actual layout.
                        var textView2 = ((((view as LinearLayout).GetChildAt(0) as LinearLayout).GetChildAt(2) as LinearLayout).GetChildAt(0) as TextView);

                        // Get the divider below the header
                        var divider2 = (view as LinearLayout).GetChildAt(2);

                        textView2.SetTextColor(Xamarin.Forms.Color.Red.ToAndroid());
                        divider2.SetBackgroundColor(Xamarin.Forms.Color.Red.ToAndroid());

                    }
                    catch (Exception) { }
                }

                return view;
            }
        }
        #endregion
    }
}