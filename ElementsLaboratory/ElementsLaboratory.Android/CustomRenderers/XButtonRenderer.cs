using Android.Content;
using Android.Graphics.Drawables;
using Android.Util;
using ElementsLaboratory.Controls;
using ElementsLaboratory.Droid.CustomRenderers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(XButton), typeof(XButtonRenderer))]
namespace ElementsLaboratory.Droid.CustomRenderers
{
    public class XButtonRenderer : ButtonRenderer
    {
        public XButtonRenderer(Context context) : base(context)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                return;

            XButton element = (XButton)e.NewElement;

            // Converting values to PX.
            int borderRadiusInDp = ConvertToPx(element.BorderRadius);
            int borderWidthInDp = ConvertToPx(Convert.ToInt32(element.BorderWidth));

            // Appliying styles.
            var gradientDrawable = new GradientDrawable();
            gradientDrawable.SetCornerRadius(borderRadiusInDp);
            gradientDrawable.SetColor(element.BackgroundColor.ToAndroid());
            gradientDrawable.SetStroke(borderWidthInDp, element.BorderColor.ToAndroid());

            Control.SetBackground(gradientDrawable);
        }

        private int ConvertToPx(int dp)
        {
            //Resources resources = Context.Resources;
            //DisplayMetrics metrics = resources.DisplayMetrics;
            //float dp = px / (metrics.Xdpi / (float)Android.Util.DisplayMetricsDensity.Default);
            var px = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, dp, Context.Resources.DisplayMetrics);

            return px;
        }
    }
}