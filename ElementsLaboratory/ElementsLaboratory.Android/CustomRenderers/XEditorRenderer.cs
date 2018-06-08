using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Util;
using ElementsLaboratory.Controls;
using ElementsLaboratory.Droid.CustomRenderers;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ElementsLaboratory.Controls.XEditor), typeof(XEditorRenderer))]
namespace ElementsLaboratory.Droid.CustomRenderers
{
    public class XEditorRenderer : EditorRenderer
    {
        public XEditorRenderer(Context context) : base(context)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (Control == null || e.NewElement == null)
                return;

            XEditor element = (XEditor)e.NewElement;

            // Placeholder.
            this.Control.Hint = element.Placeholder;
            this.Control.SetHintTextColor(ColorStateList.ValueOf(element.PlaceholderColor.ToAndroid()));

            // Internal Padding.
            if (element.InternalPadding != default(int))
            {
                var internalPaddingInPx = ConvertToPx(element.InternalPadding);
                Control.SetPadding(internalPaddingInPx, internalPaddingInPx, internalPaddingInPx, internalPaddingInPx);
            }

            // Border color.
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop && element.BorderColor != default(Xamarin.Forms.Color))
                Control.BackgroundTintList = ColorStateList.ValueOf(element.BorderColor.ToAndroid());
            else if (Build.VERSION.SdkInt < BuildVersionCodes.Lollipop && element.BorderColor != Xamarin.Forms.Color.Black)
                Control.Background.SetColorFilter(element.BorderColor.ToAndroid(), PorterDuff.Mode.SrcAtop);

            element.Unfocused += (sender, evt) => { ChangeColor(element.BorderColor.ToAndroid()); };
            element.Focused += (sender, evt) => { ChangeColor(element.BorderColorFocused.ToAndroid()); };

            // Text alignment.
            if (element.HorizontalTextAlignment == Xamarin.Forms.TextAlignment.Center)
                Control.Gravity = Android.Views.GravityFlags.CenterHorizontal;
            else if (element.HorizontalTextAlignment == Xamarin.Forms.TextAlignment.Start)
                Control.Gravity = Android.Views.GravityFlags.Start;
            else if (element.HorizontalTextAlignment == Xamarin.Forms.TextAlignment.End)
                Control.Gravity = Android.Views.GravityFlags.End;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            // MaxLines (Should be called once)
            if (e.PropertyName.ToLower() == "renderer")
                Control.SetMaxLines((Element as XEditor).MaxLines);
        }

        private void ChangeColor(Android.Graphics.Color color)
        {
            if (Control != null)
            {
                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop && color != (default(Xamarin.Forms.Color)).ToAndroid())
                    Control.BackgroundTintList = ColorStateList.ValueOf(color);
                if (Build.VERSION.SdkInt < BuildVersionCodes.Lollipop && color != (default(Xamarin.Forms.Color)).ToAndroid())
                    Control.Background.SetColorFilter(color, PorterDuff.Mode.SrcAtop);
            }
        }

        private int ConvertToPx(int dp)
        {
            var px = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, dp, Context.Resources.DisplayMetrics);
            return px;
        }
    }
}